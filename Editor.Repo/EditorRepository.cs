using Dapper;
using Editor.Entity.Data;
using Editor.Entity.Static_Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Editor.Repo
{
    public class EditorRepository
    {
        public void Add(DataTable dataTable, int count = 0, int? editorId = null, int? length = null, int? retain = null)
        {
            try
            {
                string sql;
                bool _success = false;
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@valuesDataTable", dataTable.AsTableValuedParameter("[ReaderDataTableType]"));

                    sql = @" exec [UpdateEditorData]  @valuesDataTable = @valuesDataTable";

                    if (retain != null)
                    {
                        param.Add("@count", count);
                        param.Add("@dataLength", length);
                        param.Add("@editorId", editorId);
                        param.Add("@retain", retain);
                        sql += " exec [UpdateDataOrdinal] @count=@count, @dataLength=@dataLength, @editorId=@editorId, @retain=@retain";
                    }

                    using (var multi = con.QueryMultiple(sql, param))
                    {
                        _success = multi.Read<bool>().FirstOrDefault();
                    }

                    //con.Execute("[UpdateEditorData]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        public ReaderData GetReaderData(int editorId, int retain)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@retain", retain);
                    param.Add("@editorId", editorId);
                    return con.Query<ReaderData>("[GetReaderDataByRetainValue]", param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }

        public void Update(int id, int ordinal, int dataLength, string values)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@id", id);
                    param.Add("@ordinal", ordinal);
                    param.Add("@characters", values);
                    param.Add("@dataLength", dataLength);
                    con.Execute("[UpdateDataById]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }


        public void DeleteByIndex(int index, int editorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@index", index);
                    param.Add("@editorId", editorId);
                    con.Execute("[DeleteDataByIndex]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }
        





    }
}
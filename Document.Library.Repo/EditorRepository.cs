using Dapper;
using Document.Library.Entity;
using Document.Library.Globals.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Repo
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


        public void DeleteByIndex(int editorId, int index, int length)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@index", index);
                    param.Add("@editorId", editorId);
                    param.Add("@length", editorId);
                    con.Execute("[DeleteDataByIndex]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }


        public void DeleteFromFirst(int editorId, int length)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@length", length);
                    param.Add("@editorId", editorId);
                    con.Execute("[DeleteDataFromFirst]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }




        public IEnumerable<FileEditor> GetAll(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@userId", userId);
                    return con.Query<FileEditor>("[GetFileByUserId]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        public List<ReaderData> GetData(Guid userId, int editorId)
        {
            try
            {
                List<ReaderData> dataList = null;
                List<Attributor> attributors = null;
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@userId", userId);
                    param.Add("@editorId", editorId);

                    string sql = @"exec [GetDataByEditorId] @userId=@userId, @editorId=@editorId";

                    using (var multi = con.QueryMultiple(sql, param))
                    {
                        dataList = multi.Read<ReaderData>().ToList();                            
                    }

                }

                /*
                 * Check if attributor length is 0 dont iterate over loop
                 * assign null value if no attributor is found at line number 194.
                 */
                //int i = 0;
                //if(attributors.Count() > 0)
                //{
                //    foreach (ReaderData data in dataList)
                //    {
                //        List<Attributor> atr = new List<Attributor>();

                //        while (i < attributors.Count())
                //        {
                //            if (attributors[i].ReaderDataId == data.Id)
                //            {
                //                atr.Add(attributors[i]);
                //            }
                //            else
                //            {
                //                break;
                //            }
                //            i++;
                //        }
                //        data.Attributes = (atr.Count() > 0) ? atr  : null ;
                //    }
                //}


                return dataList;
            }
            catch
            {
                throw;
            }
        }


        public FileEditor Create(string name, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@name", name);
                    param.Add("@userId", userId);
                    return con.Query<FileEditor>("[CreateNewEditor]", param: param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
        }





    }

}

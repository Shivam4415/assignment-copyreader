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
        public void Add(DataTable dataTable)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@valuesDataTable", dataTable.AsTableValuedParameter("[ReaderDataTableType]"));
                    con.Execute("[UpdateEditorData]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ReaderData> GetReaderData(int editorId, int retain)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@retain", retain);
                    param.Add("@editorId", editorId);
                    return con.Query<ReaderData>("[GetReaderDataByRetainValue]", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        


    }
}
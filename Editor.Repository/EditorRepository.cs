using Dapper;
using Editor.Entity.Static_Class;
using Editor.Entity.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Editor.Repository
{
    public class EditorRepository
    {
        public IEnumerable<FileEditor> GetAll(string userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@userId", userId);

                    return con.Query<FileEditor>("[GetEditorByUserId]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }


        public void Update()
        {
            try
            {

            }
            catch
            {
                throw;
            }
        }

    }
}
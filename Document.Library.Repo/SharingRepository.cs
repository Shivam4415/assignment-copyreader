using Dapper;
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
    public class SharingRepository
    {
        public void UpdateSharedObjectForNewUser(int userId, string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GlobalConnection.Editor))
                {
                    var param = new DynamicParameters();
                    param.Add("@email", email);
                    param.Add("@userId", userId);
                    con.Execute("[UpdateSharedObjectForNewUser]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

    }
}

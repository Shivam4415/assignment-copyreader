using Document.Library.Globals.Enum;
using Document.Library.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.ServiceLayer
{
    public static class SharingServices
    {
        public static void UpdateSharedObjectForNewUser(int userId, string email)
        {
            try
            {
                new SharingRepository().UpdateSharedObjectForNewUser(userId, email);
            }
            catch
            {
                throw;
            }

        }

        //public static Dictionary<string, Permission> Share(List<string> email, )


    }
}

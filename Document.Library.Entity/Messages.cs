using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Entity
{
    public static class Messages
    {
        public static string NotFound { get { return "Not Found"; } }
        public static string InternalServerError { get { return "Internal Server Error"; } }

        public static string RequestForbidden { get { return "Fobidden"; } }

        public static string InvalidCredentials { get { return "Invalid Credentials"; } }


    }
}

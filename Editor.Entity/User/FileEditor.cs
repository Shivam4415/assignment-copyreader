using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Editor.Entity.User
{
    public class FileEditor
    {
        public int Id { get; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Guid ModifiedBy { get; set; }

    }
}
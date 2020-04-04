﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Editor.Entity.User
{
    public class UserSession
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsPersistent { get; set; }

        public DateTime LastAccess { get; set; }
    }
}
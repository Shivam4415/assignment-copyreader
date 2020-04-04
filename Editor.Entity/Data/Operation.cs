﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Editor.Entity.Data
{
    public class Operation
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool HasVerified { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsOnline { get; set; }

        public DateTime? LastActive { get; set; }
    }
}
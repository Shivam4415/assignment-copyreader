using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Editor.Global
{
    public static class Constants
    {
        public static TimeSpan CacheSlidingExpirationTimeSpan { get; set; } = new TimeSpan(0, 60, 0); //60 Minutes

    }
}
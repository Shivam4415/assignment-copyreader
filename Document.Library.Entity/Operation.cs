using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Entity
{
    public class Operation
    {
        //[JsonProperty("insert", NullValueHandling = NullValueHandling.Ignore)]
        public string Insert { get; set; }

        //[JsonProperty("retain", NullValueHandling = NullValueHandling.Ignore)]
        public int? Retain { get; set; }

        //[JsonProperty("delete", NullValueHandling = NullValueHandling.Ignore)]
        public int? Delete { get; set; }

        //"attributes", 
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Attributor Attributes { get; set; }


    }
}

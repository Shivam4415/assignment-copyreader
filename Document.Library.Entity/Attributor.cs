using Document.Library.Globals.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Entity
{
    public class Attributor
    {
        ////[JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        //public Header? Header { get; set; }

        ////[JsonIgnore]
        ////public int Start { get; set; }

        ////[JsonIgnore]
        ////public int Length { get; set; }

        ////[JsonProperty("link",NullValueHandling = NullValueHandling.Ignore)]
        //public string Link { get; set; }

        ////[JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Italic { get; set; }

        ////[JsonProperty("underline",NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Underline { get; set; }

        ////[JsonProperty("strike",NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Strike { get; set; }

        ////[JsonProperty("bold",NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Bold { get; set; }

        ////[JsonProperty("image",NullValueHandling = NullValueHandling.Ignore)]
        //public string Image { get; set; }




        public Header Header { get; set; }

        public int? ReaderDataId { get; set; }

        public string Link { get; set; }

        public bool? Italic { get; set; }

        public bool? Underline { get; set; }

        public bool? Strike { get; set; }

        public bool? Bold { get; set; }

        public string Image { get; set; }

    }
}

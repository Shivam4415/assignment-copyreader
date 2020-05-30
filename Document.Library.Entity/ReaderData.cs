using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Entity
{
    public class ReaderData
    {
        //private string _header = "";
        //private string _link = "";
        //private string _italic = "";
        //private string _underline = "";
        //private string _strike = "";
        //private string _bold = "";
        //private string _image = "";

        [JsonIgnore]
        public int Id { get; set; }

        public int Ordinal { get; set; }

        public int EditorId { get; set; }

        public int Length { get; set; }

        public string Value { get; set; }

        public List<Attributor> Attributes { get; set; }

        public string AttributorSettings {
            get { return Attributes != null ? JsonConvert.SerializeObject(Attributes) : null;    }
            set { Attributes = JsonConvert.DeserializeObject<List<Attributor>>(AttributorSettings); }
        }

        //[JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
        //public string Header { 
        //    get 
        //    { 
        //        return _header; 
        //    } 
        //    set 
        //    { 
        //        _header = value; 
        //    } 
        //}
        //public List<AttributorSettings> Headers {
        //    get
        //    {
        //        return (_header != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_header) : null;
        //    }
        //}

        //[JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        //public string Link {
        //    get { return _link;  }
        //    set { _link = value; }
        //}
        //public List<AttributorSettings> Links
        //{
        //    get
        //    {
        //        return (_link != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_link) : null;
        //    }
        //}

        //[JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
        //public string Italic {
        //    get { return _italic; }
        //    set { _italic = value; }
        //}
        //public List<AttributorSettings> ItalicSetting
        //{
        //    get
        //    {
        //        return (_italic != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_italic) : null;
        //    }
        //}

        //[JsonProperty("underline", NullValueHandling = NullValueHandling.Ignore)]
        //public string Underline {
        //    get { return _underline; }
        //    set { _underline = value; }
        //}
        //public List<AttributorSettings> UnderlineSetting
        //{
        //    get
        //    {
        //        return (_underline != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_underline) : null;
        //    }
        //}

        //[JsonProperty("strike", NullValueHandling = NullValueHandling.Ignore)]
        //public string Strike {
        //    get { return _strike; }
        //    set { _strike = value; }
        //}
        //public List<AttributorSettings> StrikeSetting
        //{
        //    get
        //    {
        //        return (_strike != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_strike) : null;
        //    }
        //}

        //[JsonProperty("bold", NullValueHandling = NullValueHandling.Ignore)]
        //public string Bold {
        //    get { return _bold; }
        //    set { _bold = value; }
        //}
        //public List<AttributorSettings> BoldSetting
        //{
        //    get
        //    {
        //        return (_bold != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_bold) : null;
        //    }
        //}

        //[JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        //public string Image {
        //    get { return _image; }
        //    set { _image = value; }
        //}
        //public List<AttributorSettings> Images
        //{
        //    get
        //    {
        //        return (_image != null) ? JsonConvert.DeserializeObject<List<AttributorSettings>>(_image) : null;
        //    }
        //}
    }
}

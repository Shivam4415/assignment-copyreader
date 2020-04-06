using Editor.Entity.Enum;

namespace Editor.Entity.Data
{
    public class Attributor
    {
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
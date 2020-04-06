using Newtonsoft.Json;

namespace Editor.Entity.Data
{
    public class ReaderData
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int Ordinal { get; set; }

        public int EditorId { get; set; }

        public int Length { get; set; }

        public string Value { get; set; }

        public Attributor Attributes { get; set; }

    }
}
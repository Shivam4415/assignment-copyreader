namespace Editor.Entity.Data
{
    public class Operation
    {
        public string Insert { get; set; }

        public int? Retain { get; set; }

        public int? Delete { get; set; }

        public Attributor Attributes { get; set; }


    }
}
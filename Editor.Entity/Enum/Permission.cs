namespace Editor.Entity.Enum
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum Permission
    {
        None = 0,
        Read = 1,
        Write = 2,
        Full = 3,
    }
}
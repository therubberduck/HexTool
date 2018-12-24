namespace SqliteDatabaseLibrary
{
    public class DbColumn
    {
        public const string Integer = "INTEGER";
        public const string Real = "REAL";
        public const string Text = "TEXT";

        public string Name { get; }
        public string Type { get; }
        public bool IsPrimaryKey { get; }
        public bool NotNull { get; }
        public object DefaultValue { get; }

        public DbColumn(string name, string type, bool notNull = false, object defaultValue = null, bool isPrimaryKey = false)
        {
            Name = name;
            Type = type;
            NotNull = notNull;
            DefaultValue = defaultValue;
            IsPrimaryKey = isPrimaryKey;
        }
    }
}

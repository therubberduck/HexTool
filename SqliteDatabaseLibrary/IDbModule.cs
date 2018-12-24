

namespace SqliteDatabaseLibrary
{
    public interface IDbModule
    {
        string TableName { get; }
        DbColumn[] AllColumns { get; }
    }
}

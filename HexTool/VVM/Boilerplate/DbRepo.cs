using HexTool.Database;

// ReSharper disable once CheckNamespace
namespace HexTool.VVM
{
    public abstract class DbRepo : Repo
    {
        protected DbInterface _db;

        public DbRepo(DbInterface db)
        {
            _db = db;
        }
    }
}

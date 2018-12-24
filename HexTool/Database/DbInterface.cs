using HexTool.Database.Schema;
using SqliteDatabaseLibrary;

namespace HexTool.Database
{
    public class DbInterface : SqliteDbInterface
    {
        public DbHexContent HexContent;

        public DbInterface(string dbPath) : base(dbPath, typeof(DbUpdater))
        {

        }

        protected override void InitModules(SqLiteDb db)
        {
            HexContent = new DbHexContent(this, db);
        }

        public override IDbModule[] GetAllModules()
        {
            return new IDbModule[] { HexContent };
        }
    }
}

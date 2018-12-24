using SqliteDatabaseLibrary;

namespace HexTool.Database
{
    public class DbUpdater : DbUpdateSchema
    {
        private const long CurrentVersion = 2;

        public override long DatabaseVersion()
        {
            return CurrentVersion;
        }

        protected override void RunDbSchemaUpdates(SqLiteDb db, SqliteDbInterface moduleInterface)
        {
            DbInterface localInterface = (DbInterface)moduleInterface;

            long version = db.GetVersion();

            if (version < CurrentVersion)
            {
                db.DropTables(localInterface.GetAllModules());
                db.CreateTables(localInterface.GetAllModules());
            }        
        }
    }
}

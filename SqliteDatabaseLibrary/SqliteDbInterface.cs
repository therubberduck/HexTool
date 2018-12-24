using System;

namespace SqliteDatabaseLibrary
{
    public abstract class SqliteDbInterface
    {
        private readonly SqLiteDb _db;

        protected SqliteDbInterface(string dbPath, Type updateSchemaClass)
        {
            _db = new SqLiteDb(dbPath);

            InitModules(_db);

            DbUpdateSchema updateSchema = (DbUpdateSchema)Activator.CreateInstance(updateSchemaClass);
            updateSchema.Init(_db, this);
            updateSchema.CheckForDbSchemaUpdates();
        }

        protected abstract void InitModules(SqLiteDb db);

        public abstract IDbModule[] GetAllModules();
    }
}

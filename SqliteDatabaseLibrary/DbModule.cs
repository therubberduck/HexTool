﻿using System.Collections.Generic;

namespace SqliteDatabaseLibrary
{
    public abstract class DbModule : IDbModule
    {
        protected SqliteDbInterface DbInterface;
        protected SqLiteDb Db;

        public abstract string TableName { get; }
        public abstract DbColumn[] AllColumns { get; }
        public string[] AllColumnNames { get; }
        public const string Id = "Id";

        protected DbModule(SqliteDbInterface dbInterface, SqLiteDb db)
        {
            DbInterface = dbInterface;
            Db = db;
            AllColumnNames = new string[AllColumns.Length];
            for (int i = 0; i < AllColumns.Length; i++)
            {
                AllColumnNames[i] = AllColumns[i].Name;
            }
        }

        public List<long> GetAllIds()
        {
            var ids = new List<long>();

            var result = Db.Select(TableName, new[] { Id });
            foreach (object[] o in result)
            {
                var dbId = (long)o[0];
                ids.Add(dbId);
            }
            return ids;
        }

        public void Remove(long id)
        {
            Db.Delete(TableName, Id, id);
        }

        public void ClearTable()
        {
            Db.ClearTable(TableName);
        }

        protected int GetInt(object dbObject)
        {
            return (int)(long)dbObject;
        }
    }
}

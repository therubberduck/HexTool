using System;
using System.Collections.Generic;
using System.Linq;

namespace SqliteDatabaseLibrary
{
    public abstract class DbObjectModule<T> : DbModule
    {
        public DbObjectModule(SqliteDbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }

        public List<T> GetAll()
        {
            return GetAll(null);
        }

        public List<T> GetAll(string orderBy)
        {
            var otherClauses = "";
            if (orderBy != null)
            {
                otherClauses += "ORDER BY " + orderBy;
            }

            var result = Db.Select(TableName, AllColumnNames, otherClauses);

            var returnList = new List<T>();
            foreach (object[] o in result)
            {
                var resultObject = MakeObject(o);
                returnList.Add(resultObject);
            }
            return returnList;
        }

        public T Get(long id)
        {
            object[] result = Db.Select(TableName, AllColumnNames, Id, id);
            if (!result.Any())
            {
                return default(T);
            }

            var o = (object[])result[0];
            var returnObject = MakeObject(o);
            return returnObject;
        }

        protected abstract T MakeObject(object[] dbObject);
    }
}

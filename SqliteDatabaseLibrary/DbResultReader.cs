using System;

namespace SqliteDatabaseLibrary
{
    public class DbResultReader
    {
        private readonly object[] _columnsResult;
        private int _i;

        public DbResultReader(object[] columnsResult)
        {
            _columnsResult = columnsResult;
            _i = 0;
        }

        public double ReadFloat()
        {
            double result = _columnsResult[_i] is DBNull ? -1 : Convert.ToDouble(_columnsResult[_i]);
            _i++;
            return result;
        }

        public int ReadInt()
        {
            int result = _columnsResult[_i] is DBNull ? -1 : Convert.ToInt32(_columnsResult[_i]);
            _i++;
            return result;
        }

        public long ReadLong()
        {
            long result = _columnsResult[_i] is DBNull ? -1 : (long)_columnsResult[_i];
            _i++;
            return result;
        }

        public string ReadString()
        {
            string result = _columnsResult[_i] is DBNull ? null : (string)_columnsResult[_i];
            _i++;
            return result;
        }

        public bool ResultHasEntry()
        {
            return _columnsResult.Length > _i + 1;
        }

        public void SkipColumn()
        {
            _i++;
        }

        public string ReadString(DbModule module, string columnName)
        {
            for (int i = 0; i < module.AllColumnNames.Length; i++)
            {
                if (module.AllColumnNames[i].Equals(columnName))
                {
                    return _columnsResult[i] is DBNull ? null : (string)_columnsResult[i];
                }
            }
            return null;
        }
    }
}

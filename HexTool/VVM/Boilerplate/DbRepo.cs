using HexTool.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

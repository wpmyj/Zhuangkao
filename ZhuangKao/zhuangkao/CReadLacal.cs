using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace zhuangkao
{
    public class CReadLacal : CLink
    {
        //private COracleDatabase _db;
        //public override CDatabase Db
        //{
        //    get { return _db; }
        //}

        //public CReadLacal(string connstr)
        //{
        //    _db = new COracleDatabase(connstr);
        //}


        //private CAccessDatabase _db;
        //public override CDatabase Db
        //{
        //    get { return _db; }
        //}

        //public CReadLacal(string connstr)
        //{
        //    _db = new CAccessDatabase(connstr);
        //}

        private CMsSqlDatabase _db;
        public override CDatabase Db
        {
            get { return _db; }
        }

        public CReadLacal(string connstr)
        {
            _db = new CMsSqlDatabase(connstr);
        }

    }
}

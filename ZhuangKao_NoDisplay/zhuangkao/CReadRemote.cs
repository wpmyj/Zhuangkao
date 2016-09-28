using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CReadRemote:CLink
    {
        //private CMsSqlDatabase _db;
        //public override CDatabase Db
        //{
        //    get { return _db; }
        //}

        //public CReadRemote(string connstr)
        //{
        //    _db = new CMsSqlDatabase(connstr);
        //}


        //private COracleDatabase _db;
        private CMsSqlDatabase _db;
        public override CDatabase Db
        {
            get { return _db; }
        }

        public CReadRemote(string connstr)
        {
            //_db = new COracleDatabase(connstr);
            _db = new CMsSqlDatabase(connstr);
        }
    }
}

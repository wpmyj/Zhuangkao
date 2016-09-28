using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;

namespace zhuangkao
{
    public abstract class CLink
    {

        private bool _linkstate;
        public bool LinkState
        {
            get { return _linkstate; }
        }
        public abstract CDatabase Db { get;}
        //private string _errorinfo;
        //public string Errorinfo
        //{
        //    get { return _errorinfo; }
        //}

        private  bool _useable;
        public bool Useable
        {
            get { return _useable; }
            set 
            {
                _linkstate = value;
                _useable = value; 
            }
        }

        public CLink()
        {
            _linkstate = false;
        }

        private Thread _linkthread;

        public void OpenConnect()
        {
            _linkthread = new Thread(linkthreadfun);
            _linkthread.Start();
        }
        public void CloseConnect()
        {
            Db.CloseConnect();
            _useable = false;
            _linkstate = false;
        }

        private void linkthreadfun()
        {
            if (Db.OpenConnect())
            {
                _linkstate = true;
                _useable = true;
            }
            else
            {
                _useable = false;
                _linkstate = false;
            }
          
        }

    }
}

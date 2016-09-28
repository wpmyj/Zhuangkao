using System;
using System.Collections.Generic;
using System.Text;

namespace Signal
{
    public interface IMonitor : IDisposable
    {
        //For loop thread
        void Monitor();

        void UpdateMonData();

        void RegMonitor(IMonObserver obj);

        void UnRegMonitor(IMonObserver obj);

        void Start();

        void Close();

        IntPtr HotKeyHandle
        {
            get;
            set;
        }

        SignLength SignalLength
        {
            get;
        }

        bool Ready
        {
            get;
            set;
        }

        CMonData CurrData
        {
            get;
        }
    }
}

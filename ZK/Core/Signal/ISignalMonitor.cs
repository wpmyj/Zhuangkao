using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Signal
{
    public interface ISignalMonitor : IDisposable
    {
        //For loop thread
        void Monitor();

        void UpdateMonData();

        void RegMonitor(IMonObserver obj);

        void UnRegMonitor(IMonObserver obj);

        void Start();

        void Close();

        IMonData CreateMonDate(SignLength length);

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

        IMonData CurrData
        {
            get;
        }
    }
}

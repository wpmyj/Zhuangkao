using System;
using System.Collections.Generic;
using System.Text;
using Shared;
using Signal;

namespace Exam
{
    public class SignalEventArgs : EventArgs
    {
        private SignalType _type;
        public SignalType Type
        {
            get { return _type; }
        }
        private int _number = 0;
        public int Number
        {
            get { return _number; }
        }

        public SignalEventArgs(SignalType type, int i)
        {
            _type = type;
            _number = i;
        }
    }

    public class TimeOutEventArgs : EventArgs
    {
        private int _timeOutTime = 0;
        public int TimeOut
        {
            get { return _timeOutTime; }
            set { _timeOutTime = value; }
        }

        public TimeOutEventArgs(int i)
        {
            _timeOutTime = i;
        }
    }

    public delegate void SignalEvent(object sender, SignalEventArgs args);
    public delegate void TimeOutEvent(object sender, TimeOutEventArgs args);
    public interface ITranslater : IMonObserver
    {
        IMonitor Monitor
        {
            get;
        }
    }
}

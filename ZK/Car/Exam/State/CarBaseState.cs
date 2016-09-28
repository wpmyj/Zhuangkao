using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Share.Util;

namespace Cn.Youdundianzi.Exam.State
{
    public abstract class CarBaseState : CState
    {
        protected CSettings csettings;

        public CarBaseState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            stateManager = sm;
            csettings = (CSettings)stateManager.Settings;
        }

        public ICarStateManager CarStateManager
        {
            get { return stateManager as ICarStateManager; }
        }

        public override void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            base.OnHitGanEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.Gan, e.Number));
        }

        public override void OnExamTimeOutEvent(object seder, TimeOutEventArgs e)
        {
            base.OnExamTimeOutEvent(seder, e);
            OnFailure(new ExamResultMsg(ResultType.TimeOut, e.TimeOut));
        }

        protected TimeSpan _minBlockDelay = new TimeSpan();
        public TimeSpan MinBlockDelay
        {
            get { return _minBlockDelay; }
        }

        protected TimeSpan _minLeaveDelay = new TimeSpan();
        public TimeSpan MinLeaveDelay
        {
            get { return _minLeaveDelay; }
        }

        protected bool MinDelayReached(int millisecond)
        {
            return MinDelayReached(new TimeSpan(0, 0, 0, 0, millisecond));
        }
        protected bool MinDelayReached(TimeSpan minDelay)
        {
            return MinDelayReached(this.EntryTime, minDelay);
        }
        protected bool MinDelayReached(DateTime starttime, int millisecond)
        {
            return MinDelayReached(starttime, new TimeSpan(0, 0, 0, 0, millisecond));
        }
        protected bool MinDelayReached(DateTime startTime, TimeSpan minDelay)
        {
            TimeSpan duration = DateTime.Now.Subtract(startTime);
            if (duration.CompareTo(minDelay) < 0)
                return false;
            else
                return true;
        }
    }
}

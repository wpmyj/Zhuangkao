using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Share.Util.Motor;

namespace Cn.Youdundianzi.Exam.State
{
    public abstract class MotorBaseState : CState
    {
        protected MotorSignalSettings settings;

        //private StateManager stateManager;
        public MotorBaseState(MotorSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            stateManager = sm;
            settings = (MotorSignalSettings)stateManager.Settings;
            _minBlockDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinBlockDelay);
            _minLeaveDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinLeaveDelay);
        }

        abstract protected void BlockXian5();

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    base.OnBlockXianEvent(sender, e);
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
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

        private TimeSpan _minBlockDelay;
        public TimeSpan MinBlockDelay
        {
            get { return _minBlockDelay; }
        }

        private TimeSpan _minLeaveDelay;
        public TimeSpan MinLeaveDelay
        {
            get { return _minLeaveDelay; }
        }


        protected bool MinDelayReached(TimeSpan minDelay)
        {
            TimeSpan duration = DateTime.Now.Subtract(this.EntryTime);
            if (duration.CompareTo(minDelay) < 0)
                return false;
            else
                return true;
        }
    }
}

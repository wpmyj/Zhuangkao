using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;
using Signal.MotorSignal;

namespace Exam.State.XA3WMotorState
{
    public class MotorBaseState : CState
    {
        protected MotorSignalSettings settings;

        protected MotorStateManager motorStateManager;
        public MotorBaseState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            motorStateManager = sm;
            settings = (MotorSignalSettings)motorStateManager.Settings;
            _minBlockDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinBlockDelay);
            _minLeaveDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinLeaveDelay);
        }

        protected void BlockXian5()
        {
            motorStateManager.Pass5();
            ChangeState(motorStateManager.C5);
            translator.StartStateTimeOut(settings.StateDelayConfig.Delay2);
        }

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

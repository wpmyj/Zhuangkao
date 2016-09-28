using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class DK4SState : BaseState
    {
        public DK4SState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK4S";
        }

        public override string DisplayName
        {
            get
            {
                return "倒库。离开4线至停车。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 7:
                    if (!carStateMgr.CKNotified)
                        ChangeState(carStateMgr.DKTO, settings.StateDelayConfig.Delay9);
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 7:
                    if (carStateMgr.CKNotified)
                        ChangeState(carStateMgr.CKF4);
                    break;
            }
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.CKNotified)
            {
                ChangeState(carStateMgr.CKF4);
            }
            else
            {
                OnFailure(new ExamResultMsg(ResultType.LXC));
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            ChangeState(carStateMgr.DKTO, settings.StateDelayConfig.Delay9);
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            ChangeState(carStateMgr.DKTO, settings.StateDelayConfig.Delay9);
        }

        public override void OnStateChange(Cn.Youdundianzi.Core.Signal.IMonData mondata)
        {
            base.OnStateChange(mondata);
            CSignals sig = mondata.GetSignals(SignalType.XIAN);
            if (sig[4] == 0)
                OnFailure(new ExamResultMsg(ResultType.Xian, 4));
        }
    }
}


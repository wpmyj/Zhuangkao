using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class JK4SState : BaseState
    {
        public JK4SState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK4S";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。过了4线到停车。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                case 0:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 7:
                    if (!carStateMgr.YKNotified)
                    {
                        ChangeState(carStateMgr.JKTO, settings.StateDelayConfig.Delay9);
                    }
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 7:
                    if (carStateMgr.YKNotified)
                    {
                        ChangeState(carStateMgr.YK1F);
                    }
                    break;
            }
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.YKNotified)
            {
                ChangeState(carStateMgr.YK1F);
            }
            else
            {
                OnFailure(new ExamResultMsg(ResultType.LXC));
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            ChangeState(carStateMgr.JKTO, settings.StateDelayConfig.Delay9);
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            ChangeState(carStateMgr.JKTO, settings.StateDelayConfig.Delay9);
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


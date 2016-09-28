using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class XCK4SState : BaseState
    {
        public XCK4SState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCK4S";
        }

        public override string DisplayName
        {
            get
            {
                return "斜出库。离开4线倒停车。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    if (MinDelayReached(settings.StateDelayConfig.Delay6))
                    {
                        if (carStateMgr.DKNotified)
                        {
                            ChangeState(carStateMgr.DK24);
                        }
                        else
                            OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    }
                    break;
                case 3:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            ChangeState(carStateMgr.XCKE, settings.StateDelayConfig.Delay11);
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            if (carStateMgr.DKNotified)
                ChangeState(carStateMgr.DK12);
            else
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(carStateMgr.XCKE, settings.StateDelayConfig.Delay11);
        }

        public override void OnStateChange(Cn.Youdundianzi.Core.Signal.IMonData mondata)
        {
            base.OnStateChange(mondata);
            CSignals sig = mondata.GetSignals(SignalType.XIAN);
            if (sig[3] == 0)
                OnFailure(new ExamResultMsg(ResultType.Xian, 3));
            if (sig[1] == 0)
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }
    }
}


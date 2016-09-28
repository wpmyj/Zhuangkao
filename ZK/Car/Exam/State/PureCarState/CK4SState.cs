using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class CK4SState : BaseState
    {
        public CK4SState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "CK4S";
        }

        public override string DisplayName
        {
            get
            {
                return "出库。离4线后至停车。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 2:
                    OnSuccess(new ExamResultMsg(ResultType.PASS));
                    break;
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            OnSuccess(new ExamResultMsg(ResultType.PASS));
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            OnSuccess(new ExamResultMsg(ResultType.PASS));
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnStateChange(Cn.Youdundianzi.Core.Signal.IMonData mondata)
        {
            base.OnStateChange(mondata);
            CSignals sig = mondata.GetSignals(SignalType.XIAN);
            if (sig[3] == 0)
                OnFailure(new ExamResultMsg(ResultType.Xian, 3));
        }
    }
}


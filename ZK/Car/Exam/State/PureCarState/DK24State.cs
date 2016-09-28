using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class DK24State : BaseState
    {
        public DK24State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK24";
        }

        public override string DisplayName
        {
            get
            {
                return "倒库。压二线至压四线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 2:
                    carStateMgr.DKLineNum = 3;
                    break;
                case 3:
                    ChangeState(carStateMgr.DK4);
                    break;
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 2:
                    carStateMgr.DKL3Time = DateTime.Now;
                    break;
                case 1:
                    carStateMgr.DKL2Time = DateTime.Now;
                    break;
            }
            base.OnLeaveXianEvent(sender, e);
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.LXC));
        }
        public override void OnStateChange(Cn.Youdundianzi.Core.Signal.IMonData mondata)
        {
            base.OnStateChange(mondata);
            CSignals sig = mondata.GetSignals(SignalType.XIAN);
            if (sig[2] == 0)
                OnFailure(new ExamResultMsg(ResultType.Xian, 2));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class XCK4State : BaseState
    {
        public XCK4State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCK4";
        }

        public override string DisplayName
        {
            get
            {
                return "Ð±³ö¿â¡£Ñ¹4Ïß¡£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    ChangeState(carStateMgr.XCK14);
                    break;
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
                case 3:
                    ChangeState(carStateMgr.XCKL4, settings.StateDelayConfig.Delay3);
                    break;
            }
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
            if (sig[5] == 0)
                OnFailure(new ExamResultMsg(ResultType.Xian, 5));
        }
    }
}


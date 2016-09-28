using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class YK2FState : BaseState
    {
        public YK2FState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK2F";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二进到停车。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    YKHideLine2();
                    break;
                case 0:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 6:
                    ChangeState(carStateMgr.YK3S);
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    YKLeaveLine2();
                    break;
                case 6:
                    ChangeState(carStateMgr.YK2B, settings.StateDelayConfig.Delay4);
                    break;
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            ChangeState(carStateMgr.YK3S);
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            ChangeState(carStateMgr.YK2B, settings.StateDelayConfig.Delay4);
        }
    }
}


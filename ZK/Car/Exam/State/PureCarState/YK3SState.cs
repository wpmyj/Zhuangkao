using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class YK3SState : BaseState
    {
        public YK3SState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK3S";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二进时停车。";
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
                    ChangeState(carStateMgr.YK2F);
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

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            ChangeState(carStateMgr.YK2B, settings.StateDelayConfig.Delay4);
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            ChangeState(carStateMgr.YK2F);
        }
    }
}


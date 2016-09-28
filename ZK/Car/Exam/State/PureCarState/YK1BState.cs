using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class YK1BState : BaseState
    {
        public YK1BState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK1B";
        }

        public override string DisplayName
        {
            get
            {
                return "ÒÆ¿â¡£Ò»ÍËµ½Í£³µ¡£";
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
                case 7:
                    ChangeState(carStateMgr.YK2S);
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
                case 7:
                    ChangeState(carStateMgr.YK2F);
                    break;
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            ChangeState(carStateMgr.YK2S);
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            ChangeState(carStateMgr.YK2F);
        }
    }
}


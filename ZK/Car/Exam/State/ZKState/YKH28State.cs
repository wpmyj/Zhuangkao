using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YKH28State : BaseState
    {
        public YKH28State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YKH28";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二退离开7线后，压着2线压8线。";
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    carStateMgr.HasLeaveLine2 = true;
                    ChangeState(carStateMgr.YKL28, settings.StateDelayConfig.Delay4);
                    break;
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                case 6:
                    OnFailure(new ExamResultMsg(ResultType.YKBR));
                    break;
                case 0:
                case 2:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.YKBR));
        }
    }
}

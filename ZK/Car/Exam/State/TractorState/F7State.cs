using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F7State : BaseState
    {
        public F7State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F7";
        }

        public override string DisplayName
        {
            get
            {
                return "F7：前进，离开2线且压了5线（可压2线）";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 6:
                    ChangeState(carStateMgr.F8, 500);
                    break;
                case 0:
                //case 1:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                //case 3:
                //    OnFailure(new ExamResultMsg(ResultType.LXC));
                //    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(carStateMgr.F7_2, settings.StateDelayConfig.Delay1);
        }
    }
}


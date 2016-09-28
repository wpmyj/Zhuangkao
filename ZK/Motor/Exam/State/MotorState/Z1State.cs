using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.MotorState
{
    public class Z1State : BaseState
    {
        public Z1State(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Z1";
        }

        public override string DisplayName
        {
            get
            {
                return " ªœÚ÷’µ„";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    //if (!MinDelayReached(this.MinLeaveDelay))
                    //    return;

                    OnSuccess(new ExamResultMsg(ResultType.PASS));
                    break;
                case 4:
                    //OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                default:
                    base.OnBlockXianEvent(sender, e);
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.ZT));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.MotorState
{
    public class Y1State : BaseState
    {
        public Y1State(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Y1";
        }

        public override string DisplayName
        {
            get
            {
                return "Æð²½";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 4:
                    if (!MinDelayReached(this.MinLeaveDelay))
                        return;

                    BlockXian5();
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

using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.MotorState
{
    public class YState : MotorBaseState
    {
        public YState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Y";
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 4:
                    if (!MinDelayReached(this.MinLeaveDelay))
                        return;

                    base.OnBlockXianEvent(sender, e);
                    BlockXian5();
                    break;
                case 1:
                case 2:
                    switch (motorStateManager.C5Time)
                    {
                        case 4:
                        case 5:
                            return;
                        default:
                            base.OnBlockXianEvent(sender, e);
                            break;
                    }
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

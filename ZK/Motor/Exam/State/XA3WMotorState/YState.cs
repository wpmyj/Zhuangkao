using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA3WMotorState
{
    public class YState : BaseState
    {
        public YState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Y";
        }

        public override string DisplayName
        {
            get
            {
                return "ср╡Ю";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    switch (motorStateManager.C5Time)
                    {
                        case 4:
                        case 5:
                            OnFailure(new ExamResultMsg(ResultType.LXC));
                            break;
                        default:
                            return;
                    }
                    break;
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
                        case 2:
                        case 7:
                            OnFailure(new ExamResultMsg(ResultType.LXC));
                            break;
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

using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA2WMotorState
{
    public class ZState : BaseState
    {
        public ZState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Z";
        }

        public override string DisplayName
        {
            get
            {
                return "���";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    switch (motorStateManager.C5Time)
                    {
                        case 3:
                        case 6:
                            OnFailure(new ExamResultMsg(ResultType.LXC));
                            break;
                    }
                    break;
                case 2:
                    switch (motorStateManager.C5Time)
                    {
                        case 1:
                        case 8:
                        case 3:
                        case 6:
                            OnFailure(new ExamResultMsg(ResultType.LXC));
                            break;
                    }
                    break;
                case 4:
                    if (!MinDelayReached(this.MinLeaveDelay))
                        return;

                    base.OnBlockXianEvent(sender, e);
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

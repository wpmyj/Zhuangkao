using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.XA3WMotorState
{
    public class Z2State : MotorBaseState
    {
        public Z2State(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "Z2";
        }

        public override string DisplayName
        {
            get
            {
                return "转弯结束，准备过5线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 2:
                case 3:
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.XA3WMotorState
{
    public class JSState : MotorBaseState
    {
        public JSState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "JS";
        }

        public override string DisplayName
        {
            get
            {
                return "½áÊø";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            //base.OnBlockXianEvent(sender, e);
        }

        public override void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            //base.OnHitGanEvent(sender, e);
        }
    }
}

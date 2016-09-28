using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.MotorState
{
    public class JSState : MotorBaseState
    {
        public JSState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "JS";
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

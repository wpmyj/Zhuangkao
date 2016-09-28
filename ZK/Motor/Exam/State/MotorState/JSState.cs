using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam.State.MotorState
{
    public class JSState : BaseState
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
                return "����";
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

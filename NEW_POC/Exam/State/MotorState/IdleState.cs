using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.MotorState
{
    public class IdleState : MotorBaseState
    {
        public IdleState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "IDLE";
        }
        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            
        }
        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            
        }
        public override void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            
        }
        public override void OnResetGanEvent(object sender, SignalEventArgs e)
        {
            
        }
        public override void OnFailure(IResultMessage msg)
        {
            
        }
        public override void OnSuccess(IResultMessage msg)
        {
            
        }
        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA2WMotorState
{
    public class IdleState : BaseState
    {
        public IdleState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "IDLE";
        }

        public override string DisplayName
        {
            get
            {
                return "ø’œ–";
            }
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
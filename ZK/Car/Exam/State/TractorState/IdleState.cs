using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class IdleState : BaseState 
    {
        public IdleState(CarSignalTranslator st, StateManager sm)
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

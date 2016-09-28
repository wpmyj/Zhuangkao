using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
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
                return "����";
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

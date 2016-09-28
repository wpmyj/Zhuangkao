using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class SampleState : ZKBaseCState
    {
        public SampleState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "SAMPLE";
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            Console.WriteLine("SAMPLE: OnBlockXianEvent {0}",e.Number);
            if (e.Number == 0)
            {
                ChangeState(zkStateManager.IDLE);
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            Console.WriteLine("SAMPLE: OnLeaveXianEvent {0}", e.Number);
        }

        public override void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            Console.WriteLine("SAMPLE: OnHitGanEvent {0}", e.Number);
        }

        public override void OnResetGanEvent(object sender, SignalEventArgs e)
        {
            Console.WriteLine("SAMPLE: OnResetGanEvent {0}", e.Number);
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            Console.WriteLine("SAMPLE: OnCarMoveForwardEvent");
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            Console.WriteLine("SAMPLE: OnCarMoveBackEvent");
            ChangeState(zkStateManager.IDLE);
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            Console.WriteLine("SAMPLE: OnCarStopEvent");
        }

        public override void OnCarFlameoutEvent(object sender, EventArgs e)
        {
            Console.WriteLine("SAMPLE: OnCarFlameoutEvent");
            ChangeState(zkStateManager.SAMPLE);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class SampleState : BaseState
    {
        public SampleState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "SAMPLE";
        }

        public override string DisplayName
        {
            get
            {
                return "ÊÂÀý×´Ì¬";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            Console.WriteLine("SAMPLE: OnBlockXianEvent {0}",e.Number);
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
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            Console.WriteLine("SAMPLE: OnCarStopEvent");
        }

        public override void OnCarFlameoutEvent(object sender, EventArgs e)
        {
            Console.WriteLine("SAMPLE: OnCarFlameoutEvent");
        }
    }
}

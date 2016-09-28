using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA2WMotorState
{
    public class KSState : BaseState
    {
        public KSState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            this._name = "KS";
        }

        public override string DisplayName
        {
            get
            {
                return "¿ªÊ¼";
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    if (!MinDelayReached(this.MinBlockDelay))
                        return;

                    base.OnLeaveXianEvent(sender, e);
                    ChangeState(motorStateManager.Y1);
                    translator.StartStateTimeOut(settings.StateDelayConfig.Delay1);
                    translator.StartExamTimeOut(settings.ExamTimeOutDelay);
                    break;
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

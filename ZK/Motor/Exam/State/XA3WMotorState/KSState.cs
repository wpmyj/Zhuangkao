using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.XA3WMotorState
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

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    ChangeState(motorStateManager.Y1);
                    translator.StartStateTimeOut(settings.StateDelayConfig.Delay1);
                    translator.StartExamTimeOut(settings.ExamTimeOutDelay);
                    break;
                default:
                    break;
            }
        }

        public override void OnHitGanEvent(object sender, SignalEventArgs e)
        {
            //base.OnHitGanEvent(sender, e);
        }
    }
}

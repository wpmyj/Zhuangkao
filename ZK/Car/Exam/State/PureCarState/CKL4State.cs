using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class CKL4State : BaseState
    {
        public CKL4State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "CKL4";
        }

        public override string DisplayName
        {
            get
            {
                return "³ö¿â¡£Àë4Ïß£¨ÉÁ¶¯£©¡£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.CK4);
                    break;
                case 1:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(carStateMgr.CK4S, settings.StateDelayConfig.Delay6);
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.LXC));
        }
    }
}


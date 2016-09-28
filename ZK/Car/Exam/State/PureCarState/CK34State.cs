using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class CK34State : BaseState
    {
        public CK34State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "CK34";
        }

        public override string DisplayName
        {
            get
            {
                return "³ö¿â¡£Ñ¹3Ïß";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.CKL4, settings.StateDelayConfig.Delay3);
                    break;
            }
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.LXC));
        }
    }
}


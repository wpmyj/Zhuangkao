using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B1State : BaseState
    {
        public B1State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B1";
        }

        public override string DisplayName
        {
            get
            {
                return "B1£ººóÍË¡£Ñ¹5Ïß";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.B3, settings.StateDelayConfig.Delay1);
                    break;
                case 0:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 4:
                    ChangeState(carStateMgr.B2, settings.StateDelayConfig.Delay1);
                    break;
            }
        }
    }
}


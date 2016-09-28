using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F1State : BaseState
    {
        public F1State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F1";
        }

        public override string DisplayName
        {
            get
            {
                return "F1£ºÇ°½ø£¬Ñ¹4Ïß";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.F3, settings.StateDelayConfig.Delay1);
                    break;
                case 2:
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
                    ChangeState(carStateMgr.F2, settings.StateDelayConfig.Delay1);
                    break;
            }
        }
    }
}


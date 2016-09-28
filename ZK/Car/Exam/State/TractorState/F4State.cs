using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F4State : BaseState
    {
        public F4State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F4";
        }

        public override string DisplayName
        {
            get
            {
                return "F4：前进，离开4线且压了2线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 4:
                    ChangeState(carStateMgr.F5, settings.StateDelayConfig.Delay1);
                    break;
                //case 3:
                //case 5:
                //case 6:
                    //OnFailure(new ExamResultMsg(ResultType.LXC));
                    //break;
                //case 0:
                //case 2:
                //    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                //    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.F6, settings.StateDelayConfig.Delay1);
                    break;
            }
        }
    }
}


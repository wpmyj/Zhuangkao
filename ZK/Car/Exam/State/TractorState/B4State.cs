using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B4State : BaseState
    {
        public B4State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B4";
        }

        public override string DisplayName
        {
            get
            {
                return "B4：后退。压了2线离开了5线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    ChangeState(carStateMgr.B5, settings.StateDelayConfig.Delay1);
                    break;
                //case 4:
                //暂时取消路线错判断
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
                    ChangeState(carStateMgr.B6, settings.StateDelayConfig.Delay1);
                    break;
            }
        }
    }
}


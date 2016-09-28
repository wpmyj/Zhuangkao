using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B7State : BaseState
    {
        public B7State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B7";
        }

        public override string DisplayName
        {
            get
            {
                return "B7：后退。压4线（可压2线）";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                //case 1:
                case 2:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                //case 4:
                    //OnFailure(new ExamResultMsg(ResultType.LXC));
                    //break;
            }
        }

        //public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        //{
        //    base.OnLeaveXianEvent(sender, e);
        //    switch (e.Number)
        //    {
        //        case 3:
        //            ChangeState(carStateMgr.B8, settings.StateDelayConfig.Delay2);
        //            break;
        //    }
        //}

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(carStateMgr.B7_2, settings.StateDelayConfig.Delay1);
        }
    }
}


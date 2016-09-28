using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YKH2State : BaseState
    {
        public YKH2State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YKH2";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二退离开7线后，压2线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 7:
                    carStateMgr.HasLeaveLine2 = false;
                    ChangeState(carStateMgr.YKH28, settings.StateDelayConfig.Delay4);
                    break;
                case 3:
                    if (carStateMgr.HasLeaveLine2)
                        ChangeState(carStateMgr.XCK41);
                    else
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 6:
                    if (carStateMgr.HasLeaveLine2)
                        ChangeState(carStateMgr.XCK74);
                    else
                        OnFailure(new ExamResultMsg(ResultType.YKBR));
                        //OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 0:
                case 2:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    carStateMgr.HasLeaveLine2 = true;
                    ChangeState(carStateMgr.YKL2);
                    break;
            }
        }
    }
}

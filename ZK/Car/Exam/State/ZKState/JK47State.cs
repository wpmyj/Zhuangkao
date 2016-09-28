using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JK47State : BaseState
    {
        public JK47State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK47";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。四线至七线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 6:
                    ChangeState(carStateMgr.JK74);
                    break;
                case 0:
                    if (carStateMgr.JKLineNum == 1)
                    {
                        if (MinDelayReached(carStateMgr.JKL1Time, settings.StateDelayConfig.Delay8))
                        {
                            OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                        }
                    }
                    else
                        OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 1:
                    if (carStateMgr.JKLineNum == 2)
                    {
                        if (MinDelayReached(carStateMgr.JKL2Time, settings.StateDelayConfig.Delay7))
                        {
                            OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                        }
                    }
                    else
                        OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            switch (e.Number)
            {
                case 0:
                    carStateMgr.JKL1Time = DateTime.Now;
                    break;
                case 1:
                    carStateMgr.JKL2Time = DateTime.Now;
                    break;
            }
            base.OnLeaveXianEvent(sender, e);
        }

    }
}

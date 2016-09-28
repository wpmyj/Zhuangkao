using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JK77State : BaseState
    {
        public JK77State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK77";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。压四线，离七线（闪烁）。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 6:
                    if (MinDelayReached(settings.StateDelayConfig.Delay1))
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    else
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
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    carStateMgr.JKL1Time = DateTime.Now;
                    break;
                case 1:
                    carStateMgr.JKL2Time = DateTime.Now;
                    break;
                case 3:
                    if (MinDelayReached(settings.StateDelayConfig.Delay1))
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    else
                        ChangeState(carStateMgr.JKL4, settings.StateDelayConfig.Delay3);
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class DK77State : BaseState
    {
        public DK77State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "DK77";
        }

        public override string DisplayName
        {
            get
            {
                return "µπø‚°£¿Î7œﬂ£®…¡À∏£©°£";
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
                        ChangeState(carStateMgr.DK74);
                    break;
                case 2:
                    if (carStateMgr.DKLineNum == 3)
                    {
                        if (MinDelayReached(carStateMgr.DKL3Time, settings.StateDelayConfig.Delay8))
                        {
                            OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                        }
                    }
                    else
                        OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 1:
                    if (carStateMgr.DKLineNum == 2)
                    {
                        if (MinDelayReached(carStateMgr.DKL2Time, settings.StateDelayConfig.Delay7))
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
                case 2:
                    carStateMgr.DKL3Time = DateTime.Now;
                    break;
                case 1:
                    carStateMgr.DKL2Time = DateTime.Now;
                    break;
                case 3:
                    if (MinDelayReached(settings.StateDelayConfig.Delay1))
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    else
                        ChangeState(carStateMgr.DKL4, settings.StateDelayConfig.Delay3);
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JKL4State : BaseState
    {
        public JKL4State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JKL4";
        }

        public override string DisplayName
        {
            get
            {
                return "进库。离开4线。等待超时。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    if (CurrentMonData.GetSignal(SignalType.XIAN, 6) == 1)
                        ChangeState(carStateMgr.JK74);
                    else
                        ChangeState(carStateMgr.JK77);
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

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (CurrentMonData.GetSignal(SignalType.XIAN, 1) == 0)
                OnFailure(new ExamResultMsg(ResultType.Xian, 1));
            else
                ChangeState(carStateMgr.JK48, settings.StateDelayConfig.Delay2);
        }

    }
}

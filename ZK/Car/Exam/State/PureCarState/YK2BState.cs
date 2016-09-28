using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class YK2BState : BaseState
    {
        public YK2BState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK2B";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二退到停车。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    YKHideLine2();
                    break;
                case 0:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 7:
                    if (this.CurrentMonData.GetSignal(SignalType.XIAN, 1) == 1) //如果压8线时未压2线
                    {
                        ChangeState(carStateMgr.YK4S, 500);
                    }
                    else//如果压8线时压2线
                    {
                        ChangeState(carStateMgr.YK4S, settings.StateDelayConfig.Delay10);
                    }
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
                    YKLeaveLine2();
                    break;
                case 7:
                    if (carStateMgr.XCKNotified)
                        ChangeState(carStateMgr.XCK24);
                    else
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
            }
        }

        public override void OnCarStopEvent(object sender, EventArgs e)
        {
            base.OnCarStopEvent(sender, e);
            if (this.CurrentMonData.GetSignal(SignalType.XIAN, 1) == 1) //如果停车时未压2线
            {
                ChangeState(carStateMgr.YK4S, 500);
            }
            else//如果停车时压2线
            {
                ChangeState(carStateMgr.YK4S, settings.StateDelayConfig.Delay10);
            }
        }

        public override void OnCarMoveForwardEvent(object sender, EventArgs e)
        {
            base.OnCarMoveForwardEvent(sender, e);
            if (carStateMgr.XCKNotified)
                ChangeState(carStateMgr.XCK24);
            else
                OnFailure(new ExamResultMsg(ResultType.LXC));
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (this.CurrentMonData.GetSignal(SignalType.XIAN, 1) == 1) //如果超时时未压2线
            {
                ChangeState(carStateMgr.YK4S, 500);
            }
            else//如果超时时压2线
            {
                ChangeState(carStateMgr.YK4S, settings.StateDelayConfig.Delay10);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YK782State : BaseState
    {
        public YK782State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK782";
            _lastLeave7 = this.EntryTime;
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二退离开7线后。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.YKH2);
                    break;
                case 7:
                    if (carStateMgr.HasLeaveLine2)
                        ChangeState(carStateMgr.YKL28, settings.StateDelayConfig.Delay4);
                    else
                        ChangeState(carStateMgr.YKH28, settings.StateDelayConfig.Delay4);
                    break;
                case 6:
                    if (MinDelayReached(_lastLeave7, settings.StateDelayConfig.Delay3))
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 0:
                case 2:
                case 3:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        private DateTime _lastLeave7;

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    carStateMgr.HasLeaveLine2 = true;
                    ChangeState(carStateMgr.YKL2);
                    break;
                case 6:
                    _lastLeave7 = DateTime.Now;
                    break;
            }
        }
    }
}

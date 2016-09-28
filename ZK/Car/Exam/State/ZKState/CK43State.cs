using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class CK43State : BaseState
    {
        public CK43State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "CK43";
        }

        public override string DisplayName
        {
            get
            {
                return "出库。离开4线，等待离开3线，等待超时。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                case 3:
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
                case 2:
                    ChangeState(carStateMgr.CKE, settings.StateDelayConfig.Delay6);
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            ChangeState(carStateMgr.CKE, settings.StateDelayConfig.Delay6);
        }
    }
}

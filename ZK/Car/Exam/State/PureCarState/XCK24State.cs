using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class XCK24State : BaseState
    {
        public XCK24State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "XCK24";
        }

        public override string DisplayName
        {
            get
            {
                return "斜出库。压2线至压4线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 3:
                    if (this.CurrentMonData.GetSignal(SignalType.XIAN, 1) == 0)
                        ChangeState(carStateMgr.XCK4);
                    else
                        OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
                case 0:
                case 2:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnCarMoveBackEvent(object sender, EventArgs e)
        {
            base.OnCarMoveBackEvent(sender, e);
            OnFailure(new ExamResultMsg(ResultType.LXC));
        }
    }
}


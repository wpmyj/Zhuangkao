using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class YK772State : BaseState
    {
        public YK772State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "YK772";
        }

        public override string DisplayName
        {
            get
            {
                return "移库。二进压7线至二退离开7线。";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                case 2:
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
                case 6:
                    carStateMgr.HasLeaveLine2 = (CurrentMonData.GetSignal(SignalType.XIAN, 1) != 0);
                    ChangeState(carStateMgr.YK782);
                    break;
            }
        }
    }
}

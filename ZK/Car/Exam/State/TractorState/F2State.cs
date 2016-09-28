using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F2State : BaseState
    {
        public F2State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F2";
        }

        public override string DisplayName
        {
            get
            {
                return "F2：前进，压4线，离4线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.F4);
                    break;
                case 2:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 1) == 0)  //如果压2线
            {
                ChangeState(carStateMgr.F4);
            }
        }
    }
}


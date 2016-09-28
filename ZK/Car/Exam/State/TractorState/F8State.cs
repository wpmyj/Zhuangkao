using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F8State : BaseState
    {
        public F8State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F8";
        }

        public override string DisplayName
        {
            get
            {
                return "F8：前进，压7线后检查1、2、5、6线";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                case 1:
                case 5:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            //如果压了1、2、5、6线
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 0)==0)
            {
                OnFailure(new ExamResultMsg (ResultType.Xian,0));
                return;
            }
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 1)==0)
            {
                OnFailure(new ExamResultMsg (ResultType.Xian,1));
                return;
            }
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 4)==0)
            {
                OnFailure(new ExamResultMsg (ResultType.Xian,4));
                return;
            }
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 5)==0)
            {
                OnFailure(new ExamResultMsg (ResultType.Xian,5));
                return;
            }
            ChangeState(carStateMgr.FB);
        }
    }
}


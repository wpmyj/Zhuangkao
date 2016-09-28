using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B8State : BaseState
    {
        public B8State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B8";
        }

        public override string DisplayName
        {
            get
            {
                return "B8�����ˡ��뿪4�ߣ��ص��׿�";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                case 2:
                //case 3:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            //���ѹ��2��3��4��
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 1) == 0)
            {
                OnFailure(new ExamResultMsg(ResultType.Xian, 1));
                return;
            }
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 2) == 0)
            {
                OnFailure(new ExamResultMsg(ResultType.Xian, 2));
                return;
            }
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 3) == 0)
            {
                OnFailure(new ExamResultMsg(ResultType.Xian, 3));
                return;
            }
            OnSuccess(new ExamResultMsg(ResultType.PASS));
        }
    }
}


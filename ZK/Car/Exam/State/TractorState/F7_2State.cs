using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Share.Module.Sound;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F7_2State : BaseState
    {
        public F7_2State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F7_2";
        }

        public override string DisplayName
        {
            get
            {
                return "F7_2��ǰ�����뿪2����ѹ��5�ߣ�����ѹ2�ߣ�";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 6:
                    CVoice.Play("����ɹ�����ʼ������");
                    ChangeState(carStateMgr.F8, 500);
                    break;
                case 0:
                case 1:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                //case 3:
                //    OnFailure(new ExamResultMsg(ResultType.LXC));
                //    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 6) == 0)  //���ѹ��7��
            {
                CVoice.Play("����ɹ�����ʼ������");
                ChangeState(carStateMgr.F8, 500);
            }
        }
    }
}


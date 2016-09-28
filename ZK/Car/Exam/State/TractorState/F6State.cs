using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class F6State : BaseState
    {
        public F6State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "F6";
        }

        public override string DisplayName
        {
            get
            {
                return "F6��ǰ�����뿪2��";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 4:
                    ChangeState(carStateMgr.F7, settings.StateDelayConfig.Delay3);
                    break;
                case 0:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
                case 2:
                //��ʱȡ��·�ߴ��ж�
                //case 3:
                case 5:
                case 6:
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 4) == 0)  //���ѹ��5��
            {
                ChangeState(carStateMgr.F7, settings.StateDelayConfig.Delay3);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B5State : BaseState
    {
        public B5State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B5";
        }

        public override string DisplayName
        {
            get
            {
                return "B5�����ˡ�ѹ��4��δ�뿪2��";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                //case 2:
                //    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                //    break;
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.LXC));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.B7, settings.StateDelayConfig.Delay3);
                    break;
                //��ʱȡ��·�ߴ��ж�
                //case 3:
                //    OnFailure(new ExamResultMsg(ResultType.LXC));
                //    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 1) == 1)  //����뿪2��
            {
                ChangeState(carStateMgr.B7, settings.StateDelayConfig.Delay3);
            }
        }
    }
}


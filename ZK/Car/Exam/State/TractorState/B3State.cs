using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class B3State : BaseState
    {
        public B3State(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "B3";
        }

        public override string DisplayName
        {
            get
            {
                return "B3�����ˡ�ѹ2�ߣ��ȴ��뿪5��";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 0:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }

        public override void OnLeaveXianEvent(object sender, SignalEventArgs e)
        {
            base.OnLeaveXianEvent(sender, e);
            switch (e.Number)
            {
                case 4:
                    ChangeState(carStateMgr.B4);
                    break;
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            if (translator.CurrentData.GetSignal(SignalType.XIAN, 4) == 1)  //����뿪5��
            {
                ChangeState(carStateMgr.B4);
            }
        }
    }
}


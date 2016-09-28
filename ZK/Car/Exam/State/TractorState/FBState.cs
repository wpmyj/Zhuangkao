using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class FBState : BaseState
    {
        public FBState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "FB";
        }

        public override string DisplayName
        {
            get
            {
                return "FB：移库成功，等待后退";
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
                case 4:
                    ChangeState(carStateMgr.B1);
                    break;
            }
        }
    }
}


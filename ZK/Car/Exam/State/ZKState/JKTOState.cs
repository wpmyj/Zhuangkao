using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JKTOState : BaseState
    {
        public JKTOState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JKTO";
        }

        public override string DisplayName
        {
            get
            {
                return "½ø¿â¡£³¬Ê±ºó¡£";
            }
        }

        public override void OnBlockXianEvent(object sender, SignalEventArgs e)
        {
            base.OnBlockXianEvent(sender, e);
            switch (e.Number)
            {
                case 1:
                    ChangeState(carStateMgr.YK27);
                    break;
                case 0:
                case 4:
                    OnFailure(new ExamResultMsg(ResultType.Xian, e.Number));
                    break;
            }
        }
    }
}

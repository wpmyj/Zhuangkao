using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class JK8TOState : BaseState
    {
        public JK8TOState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JK8TO";
        }

        public override string DisplayName
        {
            get
            {
                return "½ø¿â¡£Ñ¹8Ïß¡£";
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

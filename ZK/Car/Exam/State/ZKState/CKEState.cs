using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Exam.State.PureLineCarState;
using Cn.Youdundianzi.Share.Exam;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
{
    public class CKEState : BaseState
    {
        public CKEState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "CKE";
        }

        public override string DisplayName
        {
            get
            {
                return "½áÊø¡£";
            }
        }

        public override void OnStateTimeOutEvent(object sender, TimeOutEventArgs e)
        {
            base.OnStateTimeOutEvent(sender, e);
            OnSuccess(new ExamResultMsg(ResultType.PASS));
        }
    }
}

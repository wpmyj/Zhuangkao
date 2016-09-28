using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Exam;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class JSState : BaseState
    {
        public JSState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            this._name = "JS";
        }

        public override string DisplayName
        {
            get
            {
                return "øº ‘Ω· ¯°£";
            }
        }
    }
}


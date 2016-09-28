using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class JSState : CState
    {
        public JSState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "JS";
        }
    }
}

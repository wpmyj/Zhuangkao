using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class XCKTO2State : CState
    {
        public XCKTO2State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "XCKTO2";
        }
    }
}

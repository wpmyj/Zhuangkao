using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class YKTO2State : CState
    {
        public YKTO2State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "YKTO2";
        }
    }
}

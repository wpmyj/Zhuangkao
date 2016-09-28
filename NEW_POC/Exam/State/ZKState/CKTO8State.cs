using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class CKTO8State : CState
    {
        public CKTO8State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "CKTO8";
        }
    }
}

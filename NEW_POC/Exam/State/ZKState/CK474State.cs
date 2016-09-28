using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class CK474State : CState
    {
        public CK474State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "CK474";
        }
    }
}

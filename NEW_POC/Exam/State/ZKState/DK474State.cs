using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class DK474State : CState
    {
        public DK474State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "DK474";
        }
    }
}

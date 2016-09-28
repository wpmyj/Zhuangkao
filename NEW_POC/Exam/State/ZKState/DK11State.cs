using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class DK11State : CState
    {
        public DK11State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "DK11";
        }
    }
}

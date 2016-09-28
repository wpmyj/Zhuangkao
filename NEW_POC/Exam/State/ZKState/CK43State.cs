using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class CK43State : CState
    {
        public CK43State(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "CK43";
        }
    }
}

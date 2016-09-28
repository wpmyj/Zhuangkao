using System;
using System.Collections.Generic;
using System.Text;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class DK8TOState : CState
    {
        public DK8TOState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            this._name = "DK8TO";
        }
    }
}

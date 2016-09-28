using System;
using System.Collections.Generic;
using System.Text;
using Exam;
using Exam.SignalTranslator;

namespace Exam.State.ZKState
{
    public class ZKBaseCState : CState
    {
        protected ZKStateManager zkStateManager;
        public ZKBaseCState(ZKSignalTranslator st, ZKStateManager sm)
            : base(st, sm)
        {
            zkStateManager = sm;
        }
    }
}

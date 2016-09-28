using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Exam.State.XA3WMotorState
{
    public class BaseState : MotorBaseState
    {
        protected MotorStateManager motorStateManager;
        public BaseState(MotorSignalTranslator st, MotorStateManager sm)
            : base(st, sm)
        {
            motorStateManager = sm;
        }

        protected override void  BlockXian5()
 	    {
            motorStateManager.Pass5();
            ChangeState(motorStateManager.C5);
            translator.StartStateTimeOut(settings.StateDelayConfig.Delay2);
        }
    }
}

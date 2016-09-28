using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Exam.State;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Util.Car;

namespace Cn.Youdundianzi.Exam.State.PureRadioCarState
{
    public class BaseState: CarBaseState
    {
        protected CarStateManager carStateMgr;
        protected CarSignalSettings settings;

        public BaseState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            carStateMgr = stateManager as CarStateManager;
            settings = (CarSignalSettings)csettings;
            _minBlockDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinBlockDelay);
            _minLeaveDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinLeaveDelay);
        }

        protected void YKHideLine2()
        {
            carStateMgr.YKH2StartTime = DateTime.Now;
        }

        protected void YKLeaveLine2()
        {
            if (!carStateMgr.YKH2StartTime.Equals(DateTime.MinValue))
                carStateMgr.YKHideLine2Duration += DateTime.Now.Subtract(carStateMgr.YKH2StartTime);
        }
    }
}

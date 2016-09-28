using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Exam.State;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Util.Car;

namespace Cn.Youdundianzi.Exam.State.PureLineCarState
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
    }
}

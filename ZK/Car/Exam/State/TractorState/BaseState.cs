using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Exam.State;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Util.Tractor;

namespace Cn.Youdundianzi.Exam.State.Tractor
{
    public class BaseState: CarBaseState
    {
        protected TractorStateManager carStateMgr;
        protected TractorSignalSettings settings;

        public BaseState(CarSignalTranslator st, StateManager sm)
            : base(st, sm)
        {
            carStateMgr = stateManager as TractorStateManager;
            settings = (TractorSignalSettings)csettings;
            _minBlockDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinBlockDelay);
            _minLeaveDelay = TimeSpan.FromMilliseconds(settings.StateDelayConfig.MinLeaveDelay);
        }
    }
}

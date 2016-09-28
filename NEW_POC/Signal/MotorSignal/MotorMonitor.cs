using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Signal.MotorSignal;
using System.Threading;
using Shared;
using Signal;
using Util;

namespace Signal.MotorSignal
{
    public class MotorMonitor : CMonitor
    {
        private MotorSignalSettings settings;

        public MotorMonitor(CSettings setting)
            : base(setting)
        {
            this.settings = (MotorSignalSettings)setting;
        }

        protected override IIO CreateSimIO()
        {
            return new CSimIO(HotKeyHandle,settings);
        }
    }
}

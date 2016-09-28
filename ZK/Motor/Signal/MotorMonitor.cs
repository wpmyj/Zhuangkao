using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Threading;
using Cn.Youdundianzi.Share.Signal.JKY;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Motor;
using Cn.Youdundianzi.Share.Util.Sim6G6X4C;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Share.Signal.Motor
{
    public class MotorMonitor : CJKYBaseMonitor
    {
        public MotorMonitor(CSettings setting)
            : base(setting)
        {
        }

        protected override IIO CreateSimIO()
        {
            return new CSimIO(HotKeyHandle, this.commonSettings.SignConfig);
        }
    }
}

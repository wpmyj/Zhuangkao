using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Sim6G6X4C;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Share.Signal.JKY
{
    public class CTestMonitor : CJKYBaseMonitor
    {
        public CTestMonitor(CSettings setting)
            : base(setting)
        {
        }

        protected override IIO CreateSimIO()
        {
            return new CSimIO(HotKeyHandle,this.commonSettings.SignConfig);
        }
    }
}

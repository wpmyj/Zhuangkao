using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using Cn.Youdundianzi.Share.Signal.JKY;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Sim6G8X4C;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Share.Util.Car;

namespace Cn.Youdundianzi.Share.Signal.Car
{
    public class OldCarMonitor : CJKYBaseMonitor
    {
        private CSettings settings;

        public OldCarMonitor(CSettings setting)
            : base(setting)
        {
            this.settings = setting;
        }

        protected override IIO CreateSimIO()
        {
            return new CSimIO(HotKeyHandle, settings.SignConfig);
        }

        protected override void ReadIO()
        {
            IMonData mod = mondata;
            sbyte tmpreturn = 0;
            CSignals gs = mod.GetSignals(SignalType.GAN);
            CSignals xs = mod.GetSignals(SignalType.XIAN);
            CSignals cs = mod.GetSignals(SignalType.CHE);
            for (int i = 0; i < readIOLoopTime; i++)
            {
                iorw.write(iowport, (byte)i);
                Thread.Sleep(lvbodelaytime);
                tmpreturn = (sbyte)iorw.read(iorport);
                if (i < ganlen)
                    gs[i] = readbit(tmpreturn, (sbyte)ganpos);
                if (i < xianlen)
                    xs[i] = readbit(tmpreturn, (sbyte)xianpos);
                if (i < chelen)
                    cs[i] = readbit(tmpreturn, (sbyte)chepos);
            }
            //信号处理
            sbyte[] garr = mod.GetSignals(SignalType.GAN).SignalArray;
            sbyte[] xarr = mod.GetSignals(SignalType.XIAN).SignalArray;
            sbyte[] carr = mod.GetSignals(SignalType.CHE).SignalArray;
            xarr[6] = garr[3];
            xarr[7] = garr[5];
            //取反
            mondata_qf(ref garr, adminQFGan);
            mondata_qf(ref xarr, adminQFXian);
            //管理员屏蔽
            mondata_adminpb(ref garr, adminPBGan);
            mondata_adminpb(ref xarr, adminPBXian);
            //屏蔽
            mondata_pb(ref carr, SignalType.CHE, PBChe);
            mondata_pb(ref garr, SignalType.GAN, PBGan);
            mondata_pb(ref xarr, SignalType.XIAN, PBXian);
        }
    }
}

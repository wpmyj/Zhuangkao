using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using Util;
using Shared;

namespace Signal
{
    public abstract class CMonitor : IMonitor
    {
        protected CSettings commonSettings;
        protected Thread mythread;
        protected int delaytime;
        protected int lvbodelaytime;
        protected bool issimulate;
        protected IIO iorw;
        protected bool exit = true;
        protected byte old37a;
        protected ArrayList regobj;

        protected SignLength signLen;

        protected int g_jifennum;
        protected int x_jifennum;

        protected CMonData mondata;
        protected CMonData mondata_cur;
        protected CMonData mondata_old;
        
        protected int adminPBGan;
        protected int adminPBXian;
        protected int adminQFGan;
        protected int adminQFXian;
        protected int PBChe;
        protected int PBGan;
        protected int PBXian;

        protected List<CSignals> g_jifenQueue;
        protected List<CSignals> x_jifenQueue;

        protected int ganpos;
        protected int xianpos;
        protected int chepos;

        protected uint ganlen, xianlen, chelen;

        private IntPtr _hkHandle = IntPtr.Zero;
        public IntPtr HotKeyHandle
        {
            get { return _hkHandle; }
            set { _hkHandle = value; }
        }

        public CMonitor(CSettings settings)
        {
            commonSettings = settings.GetCommonSettings();
            g_jifennum = commonSettings.SignConfig.GanJiFen;
            x_jifennum = commonSettings.SignConfig.XianJiFen;
            if (g_jifennum < 2 || g_jifennum > 100)
            {
                g_jifennum = 2;
            }
            if (x_jifennum < 2 || x_jifennum > 100)
            {
                x_jifennum = 2;
            }
            
            signLen = new SignLength();

            signLen.GAN_LENGTH = ganlen = commonSettings.SignConfig.GanLength;
            signLen.XIAN_LENGTH = xianlen = commonSettings.SignConfig.XianLength;
            signLen.CHE_LENGTH = chelen = commonSettings.SignConfig.CheLength;

            mondata = new CMonData(signLen);
            mondata_cur = new CMonData(signLen);
            mondata_old = new CMonData(signLen);
            g_jifenQueue = new List<CSignals>(g_jifennum);
            x_jifenQueue = new List<CSignals>(x_jifennum);

            adminPBGan = settings.SignConfig.AdminPBGan;
            adminPBXian = settings.SignConfig.AdminPBXian;
            adminQFGan = settings.SignConfig.AdminQFGan;
            adminQFXian = settings.SignConfig.AdminQFXian;
            PBChe = settings.SignConfig.PBChe;
            PBGan = settings.SignConfig.PBGan;
            PBXian = settings.SignConfig.PBXian;

            ganpos = commonSettings.SignConfig.GanPosition;
            xianpos = commonSettings.SignConfig.XianPosition;
            chepos = commonSettings.SignConfig.ChePosition;

            ApplyCommonSettings();

            mythread = new Thread(Monitor);
            regobj = new ArrayList();
        }

        protected void ApplyCommonSettings()
        {
            delaytime = commonSettings.Delaytime;
            lvbodelaytime = commonSettings.Lvbodelaytime;
            issimulate = commonSettings.IsSimulate;
        }
        #region IMonitor Members

        virtual public void Monitor()
        {
            while (exit == false)
            {
                UpdateMonData();
                for (int j = 0; j < regobj.Count; j++)
                {
                    IMonObserver tmpmonobs;
                    tmpmonobs = (IMonObserver)regobj[j];
                    tmpmonobs.Notify(CurrData);
                }
                Thread.Sleep(delaytime);
            }
            iorw.write(0x37a, old37a);//恢复打印机原先状态
            iorw.close();//2008年7月13日修改，重复打开考试窗体提示IO初始化错误
            //Thread.Sleep(5000);
        }

        virtual public CMonData CurrData
        {
            get { return mondata_cur; }
        }

        public void RegMonitor(IMonObserver obj)
        {
            regobj.Add(obj);
        }

        public void UnRegMonitor(IMonObserver obj)
        {
            regobj.Remove(obj);
        }

        abstract protected IIO CreateSimIO();

        virtual public void Start()
        {
            if (commonSettings.IsSimulate && _hkHandle != IntPtr.Zero)
                iorw = CreateSimIO();
            else
                iorw = new CIO();
            if (iorw == null)
                throw new Exception("Invalid IO.");
            old37a = iorw.read(0x37a);
            iorw.write(0x37a, 7);
            exit = false;
            if (mythread.ThreadState == ThreadState.Unstarted)
            {
                mythread.Start();
            }
        }

        virtual public void Close()
        {
            exit = true;
            mythread.Join();
        }

        ~CMonitor()
        {
            Close();
        }

        #endregion

        virtual protected void ReadIO()
        {
            CMonData mod = mondata;
            sbyte tmpreturn = 0;
            for (int i = 0; i < 6; i++)
            {
                iorw.write(0x378, (byte)i);
                Thread.Sleep(lvbodelaytime);
                tmpreturn = (sbyte)iorw.read(0x379);
                mod.GetSignals(SignalType.GAN)[i] = readbit(tmpreturn, (sbyte)ganpos);
                mod.GetSignals(SignalType.XIAN)[i] = readbit(tmpreturn, (sbyte)xianpos);
                mod.GetSignals(SignalType.CHE)[i] = readbit(tmpreturn, (sbyte)chepos);
            }
            //信号处理
            sbyte[] garr = mod.GetSignals(SignalType.GAN).SignalArray;
            sbyte[] xarr = mod.GetSignals(SignalType.XIAN).SignalArray;
            sbyte[] carr = mod.GetSignals(SignalType.CHE).SignalArray;
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

        protected sbyte readbit(sbyte data, sbyte movecount)
        {
            return (sbyte)((data >> movecount) & 1);
        }

        #region IMonitor Members

        virtual public void UpdateMonData()
        {
            mondata_old.Copy(mondata);
            mondata = new CMonData(signLen);

            ReadIO();

            if (g_jifenQueue.Count >= g_jifennum)
                g_jifenQueue.RemoveAt(0);
            g_jifenQueue.Add(mondata.GetSignals(Shared.SignalType.GAN));

            if (x_jifenQueue.Count >= x_jifennum)
                x_jifenQueue.RemoveAt(0);
            x_jifenQueue.Add(mondata.GetSignals(Shared.SignalType.XIAN));
            CSignals gsign = JiFen(g_jifenQueue.ToArray(), g_jifennum, Shared.SignalType.GAN, ganlen);
            CSignals xsign = JiFen(x_jifenQueue.ToArray(), x_jifennum, Shared.SignalType.XIAN, xianlen);

            mondata.SetSignals(Shared.SignalType.GAN, gsign);
            mondata.SetSignals(Shared.SignalType.XIAN, xsign);

            mondata_cur.Copy(mondata);
        }

        public SignLength SignalLength
        {
            get { return signLen; }
        }

        protected bool _ready = false;
        public bool Ready
        {
            get { return _ready; }
            set { _ready = value; }
        }

        #endregion
        protected CSignals JiFen(CSignals[] datas, int jfNum, Shared.SignalType type, uint signLen)
        {
            CSignals data = new CSignals(type, CMonData.RAW_LENGTH);
            for (int i = 0; i < Math.Min(jfNum, datas.Length); i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    data[j] = (sbyte)(data[j] | datas[i][j]);
                }
            }
            return data;
        }

        protected void mondata_qf(ref sbyte[] data,int qfcode)//信号取反
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (sbyte)(data[i] ^ ((qfcode >> i) & 1));//与取反位异或可以直接取反
            }
        }

        protected void mondata_adminpb(ref sbyte[] data,int pbcode) //管理员信号屏蔽
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (sbyte)(data[i] | ((pbcode >> i) & 1));//与取反位或可以直接赋值1
            }
        }

        protected void mondata_pb(ref sbyte[] data, Shared.SignalType type, int pbcode) //信号屏蔽
        {
            if (type == Shared.SignalType.CHE)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (((pbcode >> i) & 1) == 1)
                    {
                        data[i] = 0;
                    }
                }
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (((pbcode >> i) & 1) == 1)
                    {
                        data[i] = -1;
                    }
                }
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}

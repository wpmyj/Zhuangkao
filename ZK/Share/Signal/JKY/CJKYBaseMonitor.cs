using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using System.Reflection;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Share.Util;

namespace Cn.Youdundianzi.Share.Signal.JKY
{
    public abstract class CJKYBaseMonitor : ISignalMonitor
    {
        protected CSettings commonSettings;
        protected Thread mythread;
        protected int delaytime;
        protected int lvbodelaytime;
        protected bool issimulate;
        protected IIO iorw;
        protected int iorport, iowport, printerport;
        protected bool exit = true;
        protected byte old37a;
        protected ArrayList regobj;

        protected int readIOLoopTime;
        protected SignLength signLen;

        protected int g_jifennum;
        protected int x_jifennum;
        protected int lx_jifennum;
        protected int max_x_jifennum;

        enum JFType
        {
            BLOCK,
            LEAVE
        }

        protected IMonData mondata;
        protected IMonData mondata_cur;
        protected IMonData mondata_old;
        
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

        public CJKYBaseMonitor(CSettings settings)
        {
            commonSettings = settings;
            SignalConfigures sigConf = settings.SignConfig;
            iorport = sigConf.IOReaderPort;
            iowport = sigConf.IOWritterPort;
            printerport = sigConf.PrinterPort;
            g_jifennum = sigConf.GanJiFen;
            x_jifennum = sigConf.XianJiFen;
            lx_jifennum = sigConf.LXianJiFen;
            if (g_jifennum < 2 || g_jifennum > 100)
            {
                g_jifennum = 2;
            }
            if (x_jifennum < 2 || x_jifennum > 100)
            {
                x_jifennum = 2;
            }
            if (lx_jifennum < 2 || lx_jifennum > 100)
            {
                lx_jifennum = 2;
            }

            max_x_jifennum = Math.Max(x_jifennum, lx_jifennum);
            
            signLen = new SignLength();

            signLen.GAN_LENGTH = ganlen = sigConf.GanLength;
            signLen.XIAN_LENGTH = xianlen = sigConf.XianLength;
            signLen.CHE_LENGTH = chelen = sigConf.CheLength;

            readIOLoopTime = sigConf.ReadIOLoopTime;

            mondata = CreateMonDate(signLen);
            mondata_cur = CreateMonDate(signLen);
            mondata_old = CreateMonDate(signLen);
            g_jifenQueue = new List<CSignals>(g_jifennum);
            x_jifenQueue = new List<CSignals>(max_x_jifennum);

            adminPBGan = sigConf.AdminPBGan;
            adminPBXian = sigConf.AdminPBXian;
            adminQFGan = sigConf.AdminQFGan;
            adminQFXian = sigConf.AdminQFXian;
            PBChe = sigConf.PBChe;
            PBGan = sigConf.PBGan;
            PBXian = sigConf.PBXian;

            ganpos = sigConf.GanPosition;
            xianpos = sigConf.XianPosition;
            chepos = sigConf.ChePosition;

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
            //iorw.write(printerport, old37a);//恢复打印机原先状态
            iorw.close();//2008年7月13日修改，重复打开考试窗体提示IO初始化错误
            //Thread.Sleep(5000);
        }

        virtual public IMonData CurrData
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
            old37a = iorw.read(printerport);
            iorw.write(printerport, 7);
            exit = false;
            if (mythread.ThreadState == ThreadState.Unstarted)
            {
                mythread.Start();
            }
        }

        virtual public void Close()
        {
            exit = true;
            regobj.Clear();
            if (iorw != null)
                iorw.close();
            try
            {
                mythread.Join();
            }
            catch (ThreadStateException tse)
            {
            }
        }

        ~CJKYBaseMonitor()
        {
            Close();
        }

        #endregion

        virtual protected void ReadIO()
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
            mondata = CreateMonDate(signLen);

            ReadIO();

            if (g_jifenQueue.Count >= g_jifennum)
                g_jifenQueue.RemoveAt(0);
            g_jifenQueue.Add(mondata.GetSignals(SignalType.GAN));

            if (x_jifenQueue.Count >= max_x_jifennum)
                x_jifenQueue.RemoveAt(0);
            x_jifenQueue.Add(mondata.GetSignals(SignalType.XIAN));
            CSignals gsign = JiFen(g_jifenQueue.ToArray(), g_jifennum, SignalType.GAN, ganlen);
            CSignals xsign = XJiFen(x_jifenQueue.ToArray(), SignalType.XIAN, xianlen);

            mondata.SetSignals(SignalType.GAN, gsign);
            mondata.SetSignals(SignalType.XIAN, xsign);

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
        protected CSignals JiFen(CSignals[] datas, int jfNum, SignalType type, uint signLen)
        {
            CSignals data = new CSignals(type, signLen);
            for (int i = 0; i < Math.Min(jfNum, datas.Length); i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    data[j] = (sbyte)(data[j] | datas[i][j]);
                }
            }
            return data;
        }

        protected CSignals XJiFen(CSignals[] datas, SignalType type, uint signLen)
        {
            CSignals data = new CSignals(type, signLen);

            for (int i = 0; i < signLen; i++)
                data[i] = datas[datas.Length - 1][i];

            for (int j = 0; j < signLen; j++)
            {
                if (data[j] == 0)
                {
                    int sindex = datas.Length - x_jifennum;
                    if (sindex < 0) sindex = 0;
                    for (int i = sindex; i < datas.Length; i++)
                    {
                        data[j] = (sbyte)(data[j] | datas[i][j]);
                    }
                }
                else if (data[j] == 1)
                {
                    int sindex = datas.Length - lx_jifennum;
                    if (sindex < 0) sindex = 0;
                    for (int i = sindex; i < datas.Length; i++)
                    {
                        data[j] = (sbyte)(data[j] & datas[i][j]);
                    }
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

        protected void mondata_pb(ref sbyte[] data, SignalType type, int pbcode) //信号屏蔽
        {
            if (type == SignalType.CHE)
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

        #region ISignalMonitor Members


        public IMonData CreateMonDate(SignLength length)
        {
            return new CJKYMonData(length);
        }
        #endregion
    }
}

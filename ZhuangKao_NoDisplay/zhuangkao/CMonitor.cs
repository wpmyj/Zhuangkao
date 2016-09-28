using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;

namespace zhuangkao
{
    public class CMonitor
    {
        private ModuleSettings settings;
        private CMonData adminpb; //管理员屏蔽信号
        private CMonData adminqf; //信号取反
        private ulong[] lbgan;
        private ManualResetEvent mrevent;
        private CIO iorw;
        private CMonData mondata_s;
        private CMonData mondata_s_cur;
        private CMonData mondata_l;
        private CMonData mondata_l_cur;
        private CMonData mondata_s_old;
        private CMonData mondata_l_old;
        private CMonData currmondata;
        private byte old37a;
        private int exit;
        private  int gan_s;
        private  int gan_l;
        private  int che;
        private  int xian_l;
        private  int xian_s;
        private Thread mythread;
        private ArrayList regobj;
        private CMonData[] modarray_s;
        private CMonData[] modarray_l;
        private int jifennum=1;
        private List<CMonData> jifenQueue_s;
        private List<CMonData> jifenQueue_l;

        public CMonData CurrData
        {
            get 
            {
                if (che_type == 0)
                {
                    return mondata_s_cur; 
                }
                else
                {
                    return mondata_l_cur;
                }
            }
        }

        public CMonData LastData
        {
            get
            {
                if (che_type == 0)
                {
                    return mondata_s_old;
                }
                else
                {
                    return mondata_l_old;
                }
            }
        }
    
private int delaytime;
        public int DelayTime
        {
            get
            {
                return delaytime;
            }
            set
            {
                if (value > 0)
                {
                    delaytime = value;
                }

            }
        }
        private int lvbodelaytime;//濾波延時
        public int LvboDelayTime
        {
            get 
            {
                return lvbodelaytime;
            }
            set
            {
                if (value > 0)
                {
                    lvbodelaytime = value;
                }
            }
        }

        private int che_type;//0是小车，非0是大车
        public int Che_Type
        {
            get
            {
                return che_type;
            }
            set
            {
                che_type = value;
                if (che_type == 0)
                {
                    currmondata = mondata_s;
                }
                else
                {
                    currmondata = mondata_l;
                }
            }
        }

        public bool  IsShield(int shieldtype, int sindex)
        {
            switch (shieldtype)
            {
                case 0:
                    return currmondata.gan[sindex-1] == -1;
            
                case 1:
                    return currmondata.xian[sindex-1] == -1;
              
                case 2:
                    return currmondata.che[sindex-1] == -1;
              
                default:
                    return false;
                  
            }
        }
        
        public void UnShield(int shieldtype, int sindex)
        {
            if ((sindex > 9) || (sindex < 1))
            {
                return;
            }
            if (shieldtype == 0)
            {
                if (sindex < 7)
                {
                    currmondata.gan[sindex - 1] = 1;
                }
            }
            if (shieldtype == 1)
            {
                currmondata.xian[sindex - 1] = 1;
            }
            if (shieldtype == 2)
            {
                if (sindex < 5)
                {
                    currmondata.che[sindex - 1] = 1;
                }
            }
        }

        public void Shield(int shieldtype,int sindex) //shieldtype為屏蔽的類型，0為杆，1為綫，2為車
        {
            if ((sindex > 9)||(sindex<1))
            {
                return;
            }
            if (shieldtype == 0)
            {
                if (sindex < 7)
                {
                    currmondata.gan[sindex - 1] = -1;
                }
            }
            if (shieldtype == 1)
            {
                currmondata.xian[sindex-1] = -1;
            }
            if (shieldtype == 2)
            {
                if (sindex < 5)
                {
                    currmondata.che[sindex-1] = -1;
                }
            }
        }

     
        public void RegMonitor(IMonObserve obj)
        {
            regobj.Add(obj);
        }

        public void UnRegMonitor(IMonObserve obj)
        {
            regobj.Remove(obj);
        }

      


        private bool isequal(CMonData a, CMonData b) //判斷是否相等
        {
            if (a == null && b == null)
            {
                return true;
            }
            if (a == null || b == null)
            {
                return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (i < 6)
                {
                    if ((a.gan[i] != b.gan[i]) || (a.xian[i] != b.xian[i]))
                    {
                        return false;
                    }
                    else
                    {
                        if (i < 4)
                        {
                            if (a.che[i] != b.che[i])
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    if (a.xian[i] != b.xian[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public CMonitor()
        {
            settings = ModuleConfig.GetSettings();
            jifennum = settings.Jifennum;
            if (jifennum < 3 || jifennum > 100)
            {
                jifennum = 3;
            }
            iorw = new CIO();
            mondata_s = new CMonData();
            mondata_l = new CMonData();
            mondata_s_cur = new CMonData();
            mondata_l_cur = new CMonData();
            mondata_s_old = new CMonData();
            mondata_l_old = new CMonData();
            jifenQueue_s = new List<CMonData>(jifennum);
            jifenQueue_l = new List<CMonData>(jifennum);
            old37a = iorw.read(0x37a);
            iorw.write(0x37a, 7);
            exit = 0;
            mrevent = new ManualResetEvent(false);
            mythread = new Thread(Monitor);
            delaytime = settings.Delaytime;
            lvbodelaytime = settings.Lvbodelaytime;
            regobj = new ArrayList();
            lbgan = new ulong [9];
            adminpb = new CMonData();
            adminqf = new CMonData();
            for (int i = 0; i < 9; i++)
            {
               lbgan[i] = 0;
            }
            Che_Type = 0;//注意此处为public变量，赋值时会做一系列同步操作
            gan_l = settings.Gan_l;
            gan_s = settings.Gan_s;
            xian_l = settings.Xian_l;
            xian_s = settings.Xian_s;
            che = settings.Che;
            modarray_s = new CMonData[jifennum];
            modarray_l = new CMonData[jifennum];
            for (int i = 0; i < jifennum ; i++)
            {
                modarray_s[i] = new CMonData();
                modarray_l[i] = new CMonData();
            }
        }

        private sbyte readbit(sbyte data, sbyte movecount)
        {
            return (sbyte)((data >> movecount) & 1);
        }

        public void Start()
        {
            if (mythread.ThreadState == ThreadState.Unstarted)
            {
                mythread.Start();
            } 
        }

        public void Close()
        {
            exit = 1;
            mythread.Join();
            
            //if (mythread.ThreadState == ThreadState.WaitSleepJoin)
            //{
            //    mrevent.Set();
            //}
            //if (mythread.ThreadState == ThreadState.StopRequested)
            //{
                //mythread.Join();
                //iorw.close();
            //}
          
        }

        public void Suspend()
        {
            if (mythread.ThreadState == ThreadState.Running)
            {
                mrevent.Reset();
            }
        }

        public void Resume()
        {
            if (mythread.ThreadState == ThreadState.WaitSleepJoin)
            {
                mrevent.Set();
            }
        }

        private  void Monitor()
        {
            while (exit == 0)
            {
                UpdateMonData();
                //if (!LastData.Equals(CurrData))
                //{
                    for (int j = 0; j < regobj.Count; j++)
                    {
                        IMonObserve tmpmonobs;
                        tmpmonobs = (IMonObserve)regobj[j];
                        tmpmonobs.Notify(CurrData);
                    }
                //}
                Thread.Sleep(delaytime);
            }
            iorw.write(0x37a, old37a);//恢复打印机原先状态
            iorw.close();//2008年7月13日修改，重复打开考试窗体提示IO初始化错误
            Thread.Sleep(5000);
        }


        private void mondata_qf_s(ref CMonData mondata) //小车信号取反
        {
            for (int i=0; i < mondata.xinhaocount; i++)
            {
                mondata.gan[i] =(sbyte)(mondata.gan[i] ^ ((settings.AdminQFGan_s >> i) & 1));//与取反位异或可以直接取反
                mondata.xian[i] = (sbyte)(mondata.xian[i] ^ ((settings.AdminQFXian_s >> i) & 1));//与取反位异或可以直接取反
            }
        }

        private void mondata_qf_l(ref CMonData mondata)//大车信号取反
        {
            for (int i = 0; i < mondata.xinhaocount; i++)
            {
                mondata.gan[i] = (sbyte)(mondata.gan[i] ^ ((settings.AdminQFGan_l >> i) & 1));//与取反位异或可以直接取反
                mondata.xian[i] = (sbyte)(mondata.xian[i] ^ ((settings.AdminQFXian_l >> i) & 1));//与取反位异或可以直接取反
            }
        }



        private void mondata_adminpb_s(ref CMonData mondata) //小车管理员信号屏蔽
        {
            for (int i = 0; i < mondata.xinhaocount; i++)
            {
                mondata.gan[i] = (sbyte)(mondata.gan[i]|((settings.AdminPbGan_s >> i) & 1));//与取反位或可以直接赋值1
                mondata.xian[i] = (sbyte)(mondata.xian[i]|((settings.AdminPbXian_s >> i) & 1));
            }
        }


        private void mondata_adminpb_l(ref CMonData mondata) //大车管理员信号屏蔽
        {
            for (int i = 0; i < mondata.xinhaocount; i++)
            {
                mondata.gan[i] = (sbyte)(mondata.gan[i] | ((settings.AdminPbGan_l >> i) & 1));//与取反位或可以直接赋值1
                mondata.xian[i] = (sbyte)(mondata.xian[i]|((settings.AdminPbXian_l >> i) & 1));
            }
        }

        private void mondata_pb_s(ref CMonData mondata) //小车信号屏蔽
        {
            for (int i = 0; i < mondata.xinhaocount; i++)
            {
                if (((settings.PbGan_s >> i) & 1) == 1)
                {
                    mondata.gan[i] = -1;
                }
                if (((settings.PbXian_s >> i) & 1) == 1)
                {
                    mondata.xian[i] = -1;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (((settings.PbChe_s >> i) & 1) == 1)
                {
                    mondata.che[i] = 0;
                }
            }
        }


        private void mondata_pb_l(ref CMonData mondata) //大车信号屏蔽
        {
            for (int i = 0; i < mondata.xinhaocount; i++)
            {
                if (((settings.PbGan_l >> i) & 1) == 1)
                {
                    mondata.gan[i] = -1;
                }
                if (((settings.PbXian_l >> i) & 1) == 1)
                {
                    mondata.xian[i] = -1;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (((settings.PbChe_l >> i) & 1) == 1)
                {
                    mondata.che[i] = 0;
                }
            }

        }



        //单库：小车4杆作为7线，小车6杆作为8线，大车4杆作为9线。
        // 套库：小车4杆作为小车7线，小车6杆作为小车8线，大车4杆作为9线。大车7线与小车公用，大车6杆作为大车8线。
       
        private void readio(ref CMonData mod_s,ref CMonData mod_l)
        {
            sbyte tmpreturn = 0;
            for (int i = 0; i < 6; i++)
            {
                iorw.write(0x378, (byte)i);
                Thread.Sleep(lvbodelaytime);
                tmpreturn = (sbyte)iorw.read(0x379);
                mod_s.gan[i] = readbit(tmpreturn, (sbyte)gan_s);
                mod_s.xian[i] = readbit(tmpreturn, (sbyte)xian_s);
                mod_l.gan[i] = readbit(tmpreturn, (sbyte)gan_l);
                mod_l.xian[i] = readbit(tmpreturn, (sbyte)xian_l);
                if (i < 4)
                {
                    mod_s.che[i] = readbit(tmpreturn, (sbyte)che);
                    mod_l.che[i] = readbit(tmpreturn, (sbyte)che);
                }
            }

            if (che_type == 0)
            {
                //小车信号处理
                mod_s.xian[6] = mod_s.gan[3];//小车4杆作为7线
                mod_s.gan[3] = 1;
                mod_s.xian[7] = mod_s.gan[5];//小车6杆作为8线
                mod_s.gan[5] = 1;
                mod_s.xian[8] = mod_l.gan[3];//大车4杆作为9线
                mod_l.gan[3] = 1;
                mondata_qf_s(ref mod_s);//取反
                mondata_adminpb_s(ref mod_s);//管理员信号屏蔽
                mondata_pb_s(ref mod_s);//信号屏蔽
            }
            else
            {
                //大车信号处理
                mod_l.xian[6] = mod_s.gan[3];//小车4杆作为7线
                mod_s.gan[3] = 1;
                mod_l.xian[7] = mod_l.gan[5];//大车6杆作为8线
                mod_l.gan[5] = 1;
                mod_l.xian[8] = mod_l.gan[3];//大车4杆作为9线
                mod_l.gan[3] = 1;
                mondata_qf_l(ref mod_l);//取反
                mondata_adminpb_l(ref mod_s);//管理员信号屏蔽
                mondata_pb_l(ref mod_s);//信号屏蔽
            }
        }

        public void UpdateMonData()
        {
            mondata_s_old.Copy(mondata_s);
            mondata_l_old.Copy(mondata_l);
            for (int j = 0; j < mondata_s.xinhaocount; j++)
            {
                mondata_s.xian[j] = 0;
                mondata_l.xian[j] = 0;
                if (j < 6)
                {
                    mondata_s.gan[j] = 0;
                    mondata_l.gan[j] = 0;
                }
            }

            readio(ref mondata_s, ref mondata_l);

            if (jifenQueue_s.Count >= jifennum)
                jifenQueue_s.RemoveAt(0);
            jifenQueue_s.Add(mondata_s);

            if (jifenQueue_l.Count >= jifennum)
                jifenQueue_l.RemoveAt(0);
            jifenQueue_l.Add(mondata_l);

            mondata_s = JiFen(jifenQueue_s.ToArray(), jifennum);
            mondata_l = JiFen(jifenQueue_l.ToArray(), jifennum);


            //for (int i = 0; i < jifennum; i++)
            //{
            //    readio(ref modarray_s[i], ref modarray_l[i]);
            //    for (int j = 0; j < mondata_s.xinhaocount; j++)
            //    {
            //        mondata_s.xian[j] = (sbyte)(mondata_s.xian[j] | modarray_s[i].xian[j]);
            //        mondata_l.xian[j] = (sbyte)(mondata_l.xian[j] | modarray_l[i].xian[j]);
            //        //if (j < 6)
            //        //{
            //        //    mondata_s.gan[j] = (sbyte)(mondata_s.gan[j] | modarray_s[i].gan[j]);
            //        //    mondata_l.gan[j] = (sbyte)(mondata_l.gan[j] | modarray_l[i].gan[j]);
            //        //}
            //    }
            //}

            //for (int i = 0; i < 6; i++)
            //{
            //    mondata_s.gan[i] = (sbyte)(modarray_s[jifennum - 1].gan[i] | modarray_s[jifennum - 2].gan[i] | modarray_s[jifennum - 3].gan[i]);
            //    mondata_l.gan[i] = (sbyte)(modarray_l[jifennum - 1].gan[i] | modarray_l[jifennum - 2].gan[i] | modarray_l[jifennum - 3].gan[i]);
            //}

            //for (int i = 0; i < 4; i++)
            //{
            //    mondata_s.che[i] = (sbyte)(modarray_s[jifennum - 1].che[i] & modarray_s[jifennum - 2].che[i] & modarray_s[jifennum - 3].che[i]);
            //}

            mondata_s_cur.Copy(mondata_s);
            mondata_l_cur.Copy(mondata_l);
        }

        private CMonData JiFen(CMonData[] datas, int jfNum)
        {
            CMonData data = new CMonData();
            for (int i = 0; i < Math.Min(jfNum, datas.Length); i++)
            {
                for (int j = 0; j < data.xinhaocount; j++)
                {
                    data.xian[j] = (sbyte)(data.xian[j] | datas[i].xian[j]);
                }
            }
            int GstartIndex = datas.Length - Math.Min(jfNum / 2, datas.Length);
            for (int i = datas.Length - 1; i >= GstartIndex; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    data.gan[j] = (sbyte)(data.gan[j] | datas[i].gan[j]);
                }
            }
            int CstartIndex = datas.Length - Math.Min(1, datas.Length);
            for (int i = datas.Length - 1; i >= CstartIndex; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    data.che[j] = (sbyte)(data.che[j] | datas[i].che[j]);
                }
            }
            return data;
        }

        //~CMonitor()
        //{
        //    iorw.write(0x37a, old37a);//恢复打印机原先状态
        //    iorw.close();
        //}
    }
}

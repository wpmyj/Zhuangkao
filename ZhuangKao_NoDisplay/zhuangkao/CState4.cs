using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
//-----CState4逻辑描述---------------------------------------------------------------
//进入状态4则启动定时器，每隔1秒检测2线，如果连续2（可以设置）秒检测信号为1则表示离开2线，则开始同样方式检测4线，(在压4线时中停计数)如果离开4线后
//中停设置标志，在前进或后退时对中停标志做出处理。
//-----------------------------------------------------------------------------------


namespace zhuangkao
{
    public class CState4:CState
    {
        private Timer tm;
        private int fz;
        private bool xian1or2ok;
        private bool stopmark;


        public CState4(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec, ExamForm efrom)
            : base(ganc, xianc, chec,efrom)
        {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
            //stopmark = false;
        }

        public override void StateSwitchMesg()
        {
            
            fz = 0;
            xian1or2ok = false;
            stopmark = false;
            tm.Interval = 1000;
            tm.Start();
            eform.toolStripStatusLabel2.Text = "开始检测离线信号";
            base.StateSwitchMesg();
        }

      

      

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            if (xian1or2ok)
            {
                checkxian4();
            }
            else
            {
                checkxian1or2();
            }
        }

        private void checkxian4()
        {
            if (eform.cm.CurrData.xian[3] == 1)
            {
                fz++;
                if (fz >= 2)//大于2秒
                {
                    tm.Stop();
                    eform.toolStripStatusLabel2.Text = "离开4线";
                    StateManager.SwitchState("State4i");
                    eform.toolStripStatusLabel1.Text = "状态：4i";
                    che.JempStop();
                    che.Moveto(220, 305, che.back);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[17] * 1000 / che.StepCount;//根据配置计算状态4在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 30;
                    }
                }
            }
            else
            {
                fz = 0;
            }
        }

        private void checkxian1or2()
        {
            if (eform.cm.CurrData.xian[jinku_line - 1] == 1)
            {
                fz++;
                if (fz >= 2)
                {
                    xian1or2ok = true;
                    eform.toolStripStatusLabel2.Text = "离开2线";
                    fz = 0;
                }
            }
            else
            {
                fz = 0;
            }
        }


        public override void Che_tc()
        {
            
              stopmark = true;
              che.Pause();
                     
            base.Che_tc();
        }

        public override void Che_ht()
        {
            if (stopmark)
            {
                stopcount++;
 //               if (stopcount >= eform.settings.MaxStopCount)
 //               {
 //                   tm.Stop();
 ////                   tm.Tick -= new EventHandler(Timerfun);
 //                   StateManager.SwitchState("StateEnd");
 //                   che.SetWeizhi(che.X, che.Y);
 //                   che.SetRangle(che.Rangle);
 //                   eform.KaoShiEndFun(0, "中停");
 //                   return;
 //               }
                Zhongting_fun(eform.settings.MaxStopCount, tm);
            }
            stopmark = false;
            base.Che_ht();
        }


        public override void Xian1_Bump()
        {
            if (jinku_line == 2)
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(200, che.Y + 10);
                che.SetRangle(300);
                eform.KaoShiEndFun(0, "压线1");
            }
            else
            {
                if (xian1or2ok)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(200, che.Y + 10);
                    che.SetRangle(300);
                    eform.KaoShiEndFun(0, "压线1");
                }
            }

            base.Xian1_Bump();
        }


        public override void Xian2_Bump()
        {
            if (jinku_line == 1)
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(235, che.Y + 10);
                che.SetRangle(300);
                eform.KaoShiEndFun(0, "压线2");

            }
            else
            {
                if (xian1or2ok)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(235, che.Y + 10);
                    che.SetRangle(250);
                    eform.KaoShiEndFun(0, "压线2");

                }
            }
           
            base.Xian2_Bump();
        }

       

        public override void Gan1_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(205, 150);
            che.SetRangle(250);
            eform.KaoShiEndFun(0, "碰杆1");
            base.Gan1_Bump();
        }

        public override void Gan2_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(230, 150);
            che.SetRangle(290);
            eform.KaoShiEndFun(0, "碰杆2");
            base.Gan2_Bump();
        }

       
        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Close()
        {
            tm.Stop();
        }

    }
}

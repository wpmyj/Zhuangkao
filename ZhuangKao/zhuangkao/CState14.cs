using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState14:CState
    {
        private Timer tm;
        private Timer checkQJtm4;
        private Timer checkQJtm7;
        private int tmpcount, qjmark4, qjmark7;
        private bool xian2or3ok;
        private bool stopmark;

        public CState14(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            tm = new Timer();
            tm.Tick+=new EventHandler(Timerfun);
            checkQJtm4 = new Timer();
            checkQJtm4.Tick += new EventHandler(checkQianJinByXian4);
            checkQJtm7 = new Timer();
            checkQJtm7.Tick += new EventHandler(checkQianJinByXian7);
        }

        public override void StateSwitchMesg()
        {
            tm.Interval = 1000;
            tm.Start();
            tmpcount = 0;
            stopmark = false;
            xian2or3ok = false;
            base.StateSwitchMesg();
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
                if (stopcount >= eform.settings.MaxStopCount)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(che.X, che.Y);
                    che.SetRangle(che.Rangle);
                    eform.KaoShiEndFun(0, "中停");
                    return;
                }
                stopmark = false;
            }
            base.Che_ht();
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
           
            if (xian2or3ok)
            {
                check_xian4();
            }
            else
            {
                check_xian2or3();
            }
        }

        private void check_xian4()
        {
            if (eform.cm.CurrData.xian[3] == 1)
            {
                tmpcount++;
                if (tmpcount >= 2)
                {
                    tmpcount = 0;
                    this.Close();
                    eform.toolStripStatusLabel2.Text = "离开4线";
                    eform.toolStripStatusLabel1.Text = "状态：14i";
                    StateManager.SwitchState("State14i");
                    che.JempStop();
                    che.Moveto(305, 305, che.back);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[18] * 1000 / che.StepCount;//根据配置计算状态4在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 30;
                    }
                }
            }
            else
            {
                tmpcount = 0;
            }
       
        }

        private void checkQianJinByXian4(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[3] == 1 && eform.cm.CurrData.xian[6] == 1)
            {
                qjmark4++;
                if (qjmark4 >= 2)   //调整此处即可调整可容许前进时间
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(che.X, che.Y);
                    eform.KaoShiEndFun(0, "路线错");
                }
            }
            else
            {
                qjmark4 = 0;
            }
        }

        private void checkQianJinByXian7(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[6] == 1 && eform.cm.CurrData.xian[3] == 0)
            {
                qjmark7++;
                if (qjmark7 >= 2)   //调整此处即可调整可容许前进时间
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(che.X, che.Y);
                    eform.KaoShiEndFun(0, "路线错");
                }
            }
            else
            {
                qjmark7 = 0;
            }
        }

        private void check_xian2or3()
        {
          
            if (eform.cm.CurrData.xian[jinku_line - 1] == 1)
            {
                tmpcount++;
                if (tmpcount >= 2)
                {
                    tmpcount = 0;
                    xian2or3ok = true;
                    eform.toolStripStatusLabel2.Text = "离开2线";
                }
            }
            else
            {
                tmpcount = 0;
            }
        }

        public override void Xian4_Bump()
        {
            checkQJtm4.Interval = 1000;
            checkQJtm4.Start();
            base.Xian4_Bump();
        }

        public override void Xian3_Bump()
        {
            if (jinku_line == 2)
            {
                if (eform.cm.CurrData.xian[6] == 0)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(329, 154);
                    che.SetRangle(-125);
                    eform.KaoShiEndFun(0, "压线3");
                }
            }
            else
            {
                if (xian2or3ok && eform.cm.CurrData.xian[6] == 0)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(329, 154);
                    che.SetRangle(-125);
                    eform.KaoShiEndFun(0, "压线3");
                }
            }
            base.Xian3_Bump();
        }

        public override void Xian2_Bump()
        {
            if (jinku_line == 1)
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(283, che.Y + 10);
                che.SetRangle(-75);
                eform.KaoShiEndFun(0, "压线2");
            }
            else
            {
                if (xian2or3ok)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(283, che.Y + 10);
                    che.SetRangle(-75);
                    eform.KaoShiEndFun(0, "压线2");
                }
            }
            base.Xian2_Bump();
        }

        private void bump_gan(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "碰杆" + gannum.ToString());
        }

        private void bump_xian(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "压线" + gannum.ToString());
        }

        public override void Gan1_Bump() //2008年6月30日增加
        {
            bump_gan(194,132,245, 1);
            base.Gan1_Bump();
        }

        public override void Gan2_Bump()
        {
            bump_gan(290, 155, 250, 2);
            base.Gan2_Bump();
        }

        public override void Gan3_Bump()
        {
            bump_gan(320, 153, 290, 3);
            base.Gan3_Bump();
        }
 
        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Close()
        {
            tm.Stop();
            checkQJtm4.Stop();
            checkQJtm7.Stop();
        }


        public override void Xian7_Bump()
        {
            checkQJtm4.Stop();
            checkQJtm7.Interval = 1000;
            checkQJtm7.Start();
            base.Xian7_Bump();
        }

    }
}

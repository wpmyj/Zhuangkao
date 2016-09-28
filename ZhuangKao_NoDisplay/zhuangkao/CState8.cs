using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState8:CState
    {
        private bool stopmark;
        private Timer tm;
        private bool stopok;//车已停好准备斜出库
        private Timer tm3; //T3延时

        public CState8(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
            tm3 = new Timer();
            tm3.Tick += new EventHandler(Timerfun);
 
        }

        public override void StateSwitchMesg()
        {
            stopmark = false;
            stopok = false;
            tm.Interval = 5000;
            tm.Start();
            base.StateSwitchMesg();
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            tm.Stop();
            tm3.Stop();
            stopok_fun();
        }

        private void stopok_fun()
        {
            if (stopok)
            {
                return;
            }
            tm.Stop();
            tm3.Stop();
            stopok = true ;
            if (che.State == che.run)
            {
                che.JempStop();
            }
            xian[1].Visable = true;
            if (eform.cm.CurrData.xian[1] == 0)
            {
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(278, 299);
                che.SetRangle(-120);
                eform.KaoShiEndFun(0, "移库不入");
                return;
            }
            eform.toolStripStatusLabel2.Text = "开始斜出库";
            //System.Console.Beep();
            // 播放语音
            if (eform.IsExam)
            {
                CVoice.Play(eform.student.Xm + "?开始斜出库");
            }
            else
            {
                CVoice.Play("开始斜出库");
            }
        }

        public override void Xian8_Bump()
        {
            if ((eform.cm.CurrData.xian[1] == 1) && stopok == false)
            {
                stopok_fun();
            }
            else
            {
                tm.Interval = eform.settings.T3 * 1000; //3000;
                tm3.Start();
            }
            base.Xian8_Bump();
        }

        public override void Che_tc()
        {
            stopmark = true;
            stopok_fun();
            base.Che_tc();
        }

        public override void Che_ht()
        {
            if (stopmark)
            {
                stopcount++;
                //if (stopcount >= eform.settings.MaxStopCount)
                //{
                //    StateManager.SwitchState("StateEnd");
                //    che.SetWeizhi(che.X, che.Y);
                //    che.SetRangle(che.Rangle);
                //    eform.KaoShiEndFun(0, "中停");
                //    return;
                //}
                Zhongting_fun(eform.settings.MaxStopCount);
               
            }
            stopmark = false;
            base.Che_ht();
        }


        public override void Che_qj()
        {
            if (stopok)
            {
                this.Close();
                StateManager.SwitchState("State9");
                eform.toolStripStatusLabel1.Text = "状态：9";
                xian[1].Visable = false;
                xian[6].Visable = false;
                che.Moveto(280, 240, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[9] * 1000 / che.StepCount;//根据配置计算状态9在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
            }
            else
            {
                if (stopmark)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(che.X, che.Y);
                    che.SetRangle(che.Rangle);
                    eform.KaoShiEndFun(0, "路线错");
                }
            }
            base.Che_qj();
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

        public override void Gan1_Bump()
        {
            bump_gan(197, 161, 255, 1);
            base.Gan1_Bump();
        }

        public override void Gan2_Bump()
        {
            bump_gan(262, 163, 270, 2);
            base.Gan2_Bump();
        }

        public override void Gan3_Bump()
        {
            bump_gan(331, 164, 290, 3);
            base.Gan3_Bump();
        }

        public override void Gan4_Bump()
        {
            bump_gan(190, 328, 290, 4);
            base.Gan4_Bump();
        }

        public override void Gan5_Bump()
        {
            bump_gan(262, 326, 270, 5);
            base.Gan5_Bump();
        }

        public override void Gan6_Bump()
        {
            bump_gan(328, 331, 240, 6);
            base.Gan6_Bump();
        }

        public override void Xian1_Bump()
        {
            bump_xian(192, 254, 295, 1);
            base.Xian1_Bump();
        }

        public override void Xian3_Bump()
        {
            bump_xian(333, 242, 240, 3);
            base.Xian3_Bump();
        }

        public override void Xian4_Bump()
        {
            bump_xian(285, 158, 295, 4);
            base.Xian4_Bump();
        }

        public override void Xian5_Bump()
        {
            bump_xian(304, 338, 270, 5);
            base.Xian5_Bump();
        }

        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Xian2_Bump()
        {
            if (stopok)
            {
                xian[1].Visable = false;
                xian[6].Visable = false;
                eform.toolStripStatusLabel1.Text = "状态：10";
                che.Moveto(280, 240, che.forward);
                che.JempStop();
                che.Moveto(255, 190, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[10] * 1000 / che.StepCount;//根据配置计算状态10在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                StateManager.SwitchState("State10");
                eform.toolStripStatusLabel1.Text = "状态：10";
            }

            base.Xian2_Bump();
        }

        public override void Close()
        {
            tm.Stop();
            tm3.Stop();
        }

    }
}

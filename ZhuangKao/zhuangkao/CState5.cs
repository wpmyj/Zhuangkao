//2008年5月15日，修改挡7线延时t1= 秒或延时t2= 秒时，视为收到停车信号（模型车位置调整）。
//模拟车开始向前移动，离开7线延时t1= 秒时，视为收到后退信号进入状态6。


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState5:CState
    {

        private bool stopmark;
        private Timer tm;//时间T1
        private bool lkxian8;//代表离开了线8

        public CState5(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            //stopmark = false;
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            tm.Stop();
            if (eform.cm.CurrData.xian[6] == 1)//判断离开7线
            {
                StateManager.SwitchState("State6");
                eform.toolStripStatusLabel1.Text = "状态：6";
                che.Moveto(280, 305, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[5] * 1000 / che.StepCount;//根据配置计算状态5在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
            }
            else
            {
                tm.Start();
            }
            return;
        }

        public override void StateSwitchMesg()
        {
            stopmark = false;
            lkxian8 = false;
            eform.toolStripStatusLabel2.Text = "移库中";

            base.StateSwitchMesg();
        }

        public override void Xian7_Bump()
        {
            tm.Interval = eform.settings.T1 * 1000; //2000;
            tm.Start();
            if (che.State == che.run)
            {
                che.JempStop();
            }
            lkxian8 = true;//代表离开了线8，如果再次压线8则代表进入下一个状态
            base.Xian7_Bump();
        }


        public override void Xian8_Bump()
        {
            if (lkxian8)
            {
                tm.Stop();
                StateManager.SwitchState("State6");
                eform.toolStripStatusLabel1.Text = "状态：6";
                che.Moveto(280, 305, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[5] * 1000 / che.StepCount;//根据配置计算状态5在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
            }
            base.Xian8_Bump();
        }

        public override void Che_tc()
        {
            stopmark = true;
            base.Che_tc();
        }

        public override void Che_qj()
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
            base.Che_qj();
        }

        public override void Che_ht()
        {
            StateManager.SwitchState("State6");
            eform.toolStripStatusLabel1.Text = "状态：6";
            if (che.State == che.run)
            {
                che.JempStop();
            }
            che.Moveto(280, 305, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[5] * 1000 / che.StepCount;//根据配置计算状态5在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 10;
            }
            base.Che_ht();
        }

        private void bump_gan(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "碰杆"+gannum.ToString());
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
            bump_xian(192,254,295,1);
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

        public override void Close()
        {
            tm.Stop();
            base.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState11i:CState
    {
        private Timer tm;
        private bool xiechuku_stopok;
        private bool stopmark;

        public CState11i(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
        }

        public override void StateSwitchMesg()
        {
            tm.Interval = 6000;
            tm.Start();
            stopmark = true;
            base.StateSwitchMesg();
        }

        private void xiechuku_stopok_fun()
        {
            tm.Stop();
            xian[1].Visable = true;
            xian[6].Visable = true;
            if (che.State == che.run)
            {
                che.JempStop();
            }
            eform.toolStripStatusLabel2.Text = "开始倒库";
            //System.Console.Beep();
            CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
            xiechuku_stopok = true;
            // 播放语音

            if (eform.IsExam)
            {
                CVoice.Play(eform.student.Xm + "?开始倒库");
            }
            else
            {
                CVoice.Play("开始倒库");
            }
        }

        public override void Che_qj()
        {
            if (stopmark)
            {
                stopcount++;
                Zhongting_fun(2, tm);
            }
            stopmark = false;
            base.Che_qj();
        }


        public override void Che_ht()
        {
            if (xiechuku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State12");
                eform.toolStripStatusLabel1.Text = "状态：12";

                che.Moveto(225, 75, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[12] * 1000 / che.StepCount;//根据配置计算状态12在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                xian[7].Visable = false;
            }
            base.Che_ht();
        }

        public override void Xian1_Bump()
        {
            if (xiechuku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State12");
                eform.toolStripStatusLabel1.Text = "状态：12";

                che.Moveto(215, 75, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[12] * 1000 / che.StepCount;//根据配置计算状态12在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                xian[7].Visable = false;
            }
            base.Xian1_Bump();
        }

        public override void Xian2_Bump()
        {
            //进入CState13;
            if (xiechuku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State13");
                eform.toolStripStatusLabel1.Text = "状态：13";
                che.Moveto(215, 75, che.back);
                che.JempStop();
                che.Moveto(305, 85, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[13] * 1000 / che.StepCount;//根据配置计算状态13在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                xian[7].Visable = false;
            }
            base.Xian2_Bump();
        }


        public override void Che_tc()
        {
            stopmark = true;
            xiechuku_stopok_fun();
            base.Che_tc();
        }


        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            xiechuku_stopok_fun();
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

        public override void Xian6_Bump()
        {
            bump_xian(182, 62, -115, 6);
            base.Xian6_Bump();
        }

        public override void Xian3_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(329, 76);
            che.SetRangle(180);
            eform.KaoShiEndFun(0, "行进方向错");
            base.Xian3_Bump();
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

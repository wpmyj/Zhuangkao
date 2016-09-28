using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState14i:CState
    {
        private bool laststate;
        private bool jinku_stopok;
        private Timer tm;
        private Timer tm1;

        public CState14i(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
            tm1 = new Timer();
            tm1.Tick += new EventHandler(Timerfun1);
        }

        public override void StateSwitchMesg()
        {
            jinku_stopok = false;
            tm.Interval = 9000;
            tm.Start();
            laststate = false;
            tm1.Interval = 1000;
            base.StateSwitchMesg();
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            jinku_stop_fun();
            return;

        }

        private void Timerfun1(Object myObject, EventArgs myEventArgs)
        {
            if (jinku_stopok)
            {
                if (eform.cm.CurrData.xian[7] == 1)
                {
                    tm.Stop();
                    tm1.Stop();
                    StateManager.SwitchState("State15");
                    eform.toolStripStatusLabel1.Text = "状态：15";
                    if (che.State == che.run)
                    {
                        che.JempStop();
                    }
                    che.Moveto(305, 177, che.forward);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[15] * 1000 / che.StepCount;//根据配置计算状态14在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 10;
                    }
                }
            }
            return;

        }


        private void jinku_stop_fun()
        {
            tm.Stop();
            che.JempStop();
            if (laststate)
            {
                eform.toolStripStatusLabel2.Text = "考试完成";
                //System.Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
                // 播放语音
                if (eform.IsExam)
                {
                    CVoice.Play(eform.student.Xm + "?考试完成");
                }
                else
                {
                    CVoice.Play("考试完成");
                }
            }
            else
            {
                jinku_stopok = true;
                eform.toolStripStatusLabel2.Text = "开始出库";
                //System.Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
                // 播放语音
                if (eform.IsExam)
                {
                    CVoice.Play(eform.student.Xm + "?开始出库");
                }
                else
                {
                    CVoice.Play("开始出库");
                }
                tm1.Start();//开始计时进入状态15
            }
        }

        public override void Che_tc()
        {
            jinku_stop_fun();
            base.Che_tc();
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

        public override void Gan5_Bump()
        {
            bump_gan(280, 333, 280, 5);
            base.Gan5_Bump();
        }

        public override void Gan6_Bump()
        {
            bump_gan(328, 330, 260, 6);
            base.Gan6_Bump();
        }

        public override void Xian2_Bump()
        {
            if (jinku_stopok)
            {
                bump_xian(280, 252, -75, 2);
            }
            base.Xian2_Bump();
        }

        public override void Xian5_Bump()
        {
            bump_xian(308, 338, 270, 5);
            base.Xian5_Bump();
        }

        public override void Che_qj()
        {
            if (jinku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State15");
                eform.toolStripStatusLabel1.Text = "状态：15";
                if (che.State == che.run)
                {
                    che.JempStop();
                }
                che.Moveto(305, 177, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[15] * 1000 / che.StepCount;//根据配置计算状态14在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
            }
            else
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.KaoShiEndFun(0, "路线错");
                return;
            }
           
            base.Che_qj();
        }

        public override void Xian7_Bump()
        {
            if (jinku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State15");
                eform.toolStripStatusLabel1.Text = "状态：15";
                if (che.State == che.run)
                {
                    che.JempStop();
                }
                che.Moveto(305, 177, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[15] * 1000 / che.StepCount;//根据配置计算状态14在设定时间内的速度（屏幕刷新速度）
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
            }
            base.Xian7_Bump();
        }

        public override void Xian4_Bump()
        {
            this.Close();
            StateManager.SwitchState("State16");
            eform.toolStripStatusLabel1.Text = "状态：16";
            if (che.State == che.run)
            {
                che.JempStop();
            }
            che.Moveto(325, 75, che.forward);
            try
            {
                eform.timer1.Interval = eform.StateTime[16] * 1000 / che.StepCount;//根据配置计算状态14在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 10;
            }
            base.Xian4_Bump();
        }

        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Close()
        {
            tm.Stop();
            tm1.Stop();
        }

    }
}

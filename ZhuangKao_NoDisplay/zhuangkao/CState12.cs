using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState12:CState
    {
        private bool stopmark;

        public CState12(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            stopmark = false;
        }

        public override void StateSwitchMesg()
        {
            stopmark = false;
            base.StateSwitchMesg();
        }


        public override void Che_tc()
        {
            stopmark = true;
            che.Pause();
            base.Che_tc();
        }

        public override void Che_qj()
        {
            if (stopmark)
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.KaoShiEndFun(0, "行进方向错");
                return;
            }
            base.Che_qj();
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
                Zhongting_fun(2);
            }
            stopmark = false;
            base.Che_ht();
        }

        public override void Xian2_Bump()
        {
            StateManager.SwitchState("State13");
            eform.toolStripStatusLabel1.Text = "状态：13";
            if (che.State == che.run)
            {
                che.JempStop();
            }
           // che.Moveto(305, 85, che.back);
            che.Moveto(285, 100, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[13] * 1000 / che.StepCount;//根据配置计算状态13在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 10;
            }
            base.Xian2_Bump();
        }


        private void bump_gan(int x, int y, int range, int gannum)
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "碰杆" + gannum.ToString());
        }

        private void bump_xian(int x, int y, int range, int gannum)
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "压线" + gannum.ToString());
        }

        public override void Xian6_Bump()
        {
            bump_xian(che.X, 52, 200, 6);
            base.Xian6_Bump();
        }


        public override void Xian4_Bump()
        {
            bump_xian(189, 97, 220, 4);
            base.Xian4_Bump();
        }

        public override void Gan1_Bump()
        {
            bump_gan(134, 95, 195, 1);
            base.Gan1_Bump();
        }

        public override void Gan2_Bump()
        {
            bump_gan(225,95,195, 2);
            base.Gan2_Bump();
        }

        public override void Close()
        {
            base.Close();
        }


    }
}

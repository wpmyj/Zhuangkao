using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState13:CState
    {
        private bool stopmark;

        public CState13(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
  
        }

        public override void StateSwitchMesg()
        {
            stopmark = false;
            jinku_line = 2;
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
                Zhongting_fun(2);
            }
            stopmark = false;
            base.Che_ht();
        }

        public override void Che_qj()
        {
            if (stopmark)
            {
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.KaoShiEndFun(0, "路线错");
            }
            base.Che_qj();
        }

        public override void Xian4_Bump()
        {
            StateManager.SwitchState("State14");
            eform.toolStripStatusLabel1.Text = "状态：14";
            if (che.State == che.run)
            {
                che.JempStop();
            }
            //che.Moveto(305, 305, che.back);
            che.Moveto(305, 140, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[14] * 1000 / che.StepCount;//根据配置计算状态14在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 10;
            }

            base.Xian4_Bump();
        }

        public override void Xian3_Bump()
        {
            jinku_line = 3;
            base.Xian3_Bump();
        }


        public override void Xian6_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(266, 60);
            che.SetRangle(220);
            eform.KaoShiEndFun(0, "压线6");
            base.Xian6_Bump();
        }

        public override void Gan2_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(239, 84);
            che.SetRangle(215);
            eform.KaoShiEndFun(0, "碰杆2");
            base.Gan2_Bump();
        }

        public override void Gan3_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(329, 89);
            che.SetRangle(215);
            eform.KaoShiEndFun(0, "碰杆3");
            base.Gan3_Bump();
        }

    }
}

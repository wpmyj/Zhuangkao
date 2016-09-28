using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState9:CState
    {
        private bool stopmark;

        public CState9(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            
        }

        public override void StateSwitchMesg()
        {
            stopmark = false;
            base.StateSwitchMesg();
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
                Zhongting_fun(eform.settings.MaxStopCount);
            }
            stopmark = false;
            base.Che_qj();
        }

        public override void Che_ht()
        {
            if (stopmark)
            {
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.KaoShiEndFun(0, "路线错");
            }
            base.Che_ht();
        }

        public override void Xian2_Bump()
        {
          
            eform.toolStripStatusLabel1.Text = "状态：10";
            if (che.State == che.run)
            {
                che.JempStop();
            }
            che.Moveto(255, 190,che.forward);
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

  
        public override void Gan2_Bump()
        {
            bump_gan(280, 165, -110, 2);
            base.Gan2_Bump();
        }

        public override void Gan3_Bump()
        {
            bump_gan(331, 164, 290, 3);
            base.Gan3_Bump();
        }

 
        public override void Gan5_Bump()
        {
            bump_gan(280, 332, -70, 5);
            base.Gan5_Bump();
        }

        public override void Gan6_Bump()
        {
            bump_gan(328, 331, 240, 6);
            base.Gan6_Bump();
        }

   
        public override void Xian3_Bump()
        {
            bump_xian(333, 242, 240, 3);
            base.Xian3_Bump();
        }

        public override void Xian4_Bump()
        {
            bump_xian(285, 158, 270, 4);
            base.Xian4_Bump();
        }

        public override void Xian5_Bump()
        {
            bump_xian(304, 338, 270, 5);
            base.Xian5_Bump();
        }

    }
}

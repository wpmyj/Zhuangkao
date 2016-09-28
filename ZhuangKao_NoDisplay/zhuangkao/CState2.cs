using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState2:CState
    {
        private bool stopmark;//防止错误的前进信号，只有收到停车信号后再收到前进才判路线错误

        public CState2(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec, ExamForm efrom)
            : base(ganc, xianc, chec,efrom)
        {
        }

        public override void StateSwitchMesg()
        {
            stopmark = false;
            base.StateSwitchMesg();
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

       
        public override void  Che_tc()
        {
            stopmark = true;
            che.Pause();
 	        base.Che_tc();
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
            stopmark = false;
            base.Che_qj();
        }

        public override void Xian2_Bump()
        {
            if (che.State == che.run)
            {
                che.JempStop();
            }
            StateManager.SwitchState("State3");
            che.Moveto(220, 85, che.back);
            //che.Moveto(240,100, che.back);
            
            try
            {
                eform.timer1.Interval = eform.StateTime[3] * 1000 / che.StepCount;//根据配置计算状态3在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "状态：3";
            base.Xian2_Bump();
        }

        public override void Xian4_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(315, 90);
            che.SetRangle(310);
            eform.KaoShiEndFun(0, "路线错");
            base.Xian4_Bump();
        }

        public override void Gan2_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(285, 90);
            che.SetRangle(330);
            eform.KaoShiEndFun(0,"碰杆2");
           // gan[1].Stat = 0;
            base.Gan2_Bump();
        }

        public override void Gan3_Bump()
        {
            StateManager.SwitchState("StateEnd");
            if (che.X >= gan[2].X)
            {
                che.SetWeizhi(385, 90);
                che.SetRangle(330);
            }
            else
            {
                che.SetWeizhi(317, 90);
                che.SetRangle(210);
            }
            eform.KaoShiEndFun(0, "碰杆3");
            // gan[1].Stat = 0;
            base.Gan3_Bump();
        }

        public override void Xian6_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(che.X - 50, 50);
            che.SetRangle(340);
            eform.KaoShiEndFun(0,"压线6");
            base.Xian6_Bump();
        }
    }
}

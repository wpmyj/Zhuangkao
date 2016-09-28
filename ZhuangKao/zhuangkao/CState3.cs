using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState3:CState
    {
        private bool stopmark;

        public CState3(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
        }

        public override void StateSwitchMesg()
        {
            jinku_line = 2;
            stopmark = false;
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

        public override void Gan1_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(195, 90);
            che.SetRangle(330);
            eform.KaoShiEndFun(0, "碰杆1");
            base.Gan1_Bump();
        }

        public override void Xian1_Bump()
        {
            jinku_line = 1; //默认认为车进库为压2线进库，如果有压1线信号则认为是压1线进库
            base.Xian1_Bump();
        }

        public override void Xian4_Bump()
        {
            //if (eform.cm.CurrData.xian[0] == 0)
            //{
            //    jinku_line = 1;
            //}
            //else
            //{
            //    jinku_line = 2;
            //}
            if (che.State == che.run)
            {
                che.JempStop();
            }
            StateManager.SwitchState("State4");
            eform.toolStripStatusLabel1.Text = "状态：4";
            che.Moveto(220, 140, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[17] * 1000 / che.StepCount;//根据配置计算状态4在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
           // che.SetRangle(270);
            base.Xian4_Bump();
        }

        public override void Xian6_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(che.X - 50, 50);
            che.SetRangle(340);
            eform.KaoShiEndFun(0, "压线6");
            base.Xian6_Bump();
        }

        public override void Gan2_Bump() //2008年6月30日增加
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(255,113);
            che.SetRangle(320);
            eform.KaoShiEndFun(0, "碰杆2");
            base.Gan2_Bump();
        }
    }
}

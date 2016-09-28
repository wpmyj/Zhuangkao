using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState1:CState
    {
        
        public CState1(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform):base(ganc,xianc,chec,eform)
        {
        }

        public override void Che_xh()
        {
            //熄火不做处理
        }

        public override void Che_ht()
        {
            StateManager.SwitchState("State2");
            che.Moveto(290, 75, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[2] * 1000 / che.StepCount;//根据配置计算状态1在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text="状态：2";
            xian[6].Visable = false;

            base.Che_ht();
        }

        public override void Xian3_Bump()
        {
            StateManager.SwitchState("State2");
            che.Moveto(290, 75, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[2] * 1000 / che.StepCount;//根据配置计算状态2在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "状态：2";
            xian[6].Visable = false;
            base.Che_ht();
            base.Xian3_Bump();
        }

        public override void Xian2_Bump()
        {
            xian[6].Visable = false;
            che.Moveto(290, 75, che.back);
            che.JempStop();
            StateManager.SwitchState("State3");
            che.Moveto(220, 85, che.back);
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


        public override void Xian9_Bump()
        {
            StateManager.SwitchState("State2");
            che.Moveto(290, 75, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[2] * 1000 / che.StepCount;//根据配置计算状态1在设定时间内的速度（屏幕刷新速度）
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "状态：2";
            xian[6].Visable = false;
            base.Xian9_Bump();
        }

        public override void Xian6_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(che.X - 50, 50);
            che.SetRangle(340);
            eform.KaoShiEndFun(0, "压线6");
            base.Xian6_Bump();
        }
    }
}

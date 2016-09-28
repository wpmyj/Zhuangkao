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
            //Ϩ��������
        }

        public override void Che_ht()
        {
            StateManager.SwitchState("State2");
            che.Moveto(290, 75, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[2] * 1000 / che.StepCount;//�������ü���״̬1���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text="״̬��2";
            xian[6].Visable = false;

            base.Che_ht();
        }

        public override void Xian3_Bump()
        {
            StateManager.SwitchState("State2");
            che.Moveto(290, 75, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[2] * 1000 / che.StepCount;//�������ü���״̬2���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "״̬��2";
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
                eform.timer1.Interval = eform.StateTime[3] * 1000 / che.StepCount;//�������ü���״̬3���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "״̬��3";
            base.Xian2_Bump();
        }


        public override void Xian9_Bump()
        {
            StateManager.SwitchState("State2");
            che.Moveto(290, 75, che.back);
            try
            {
                eform.timer1.Interval = eform.StateTime[2] * 1000 / che.StepCount;//�������ü���״̬1���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "״̬��2";
            xian[6].Visable = false;
            base.Xian9_Bump();
        }

        public override void Xian6_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(che.X - 50, 50);
            che.SetRangle(340);
            eform.KaoShiEndFun(0, "ѹ��6");
            base.Xian6_Bump();
        }
    }
}

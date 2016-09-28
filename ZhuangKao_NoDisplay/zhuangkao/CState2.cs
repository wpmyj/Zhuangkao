using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState2:CState
    {
        private bool stopmark;//��ֹ�����ǰ���źţ�ֻ���յ�ͣ���źź����յ�ǰ������·�ߴ���

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
                eform.KaoShiEndFun(0, "·�ߴ�");
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
                eform.timer1.Interval = eform.StateTime[3] * 1000 / che.StepCount;//�������ü���״̬3���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
            }
            catch
            {
                eform.timer1.Interval = 30;
            }
            eform.toolStripStatusLabel1.Text = "״̬��3";
            base.Xian2_Bump();
        }

        public override void Xian4_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(315, 90);
            che.SetRangle(310);
            eform.KaoShiEndFun(0, "·�ߴ�");
            base.Xian4_Bump();
        }

        public override void Gan2_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(285, 90);
            che.SetRangle(330);
            eform.KaoShiEndFun(0,"����2");
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
            eform.KaoShiEndFun(0, "����3");
            // gan[1].Stat = 0;
            base.Gan3_Bump();
        }

        public override void Xian6_Bump()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(che.X - 50, 50);
            che.SetRangle(340);
            eform.KaoShiEndFun(0,"ѹ��6");
            base.Xian6_Bump();
        }
    }
}

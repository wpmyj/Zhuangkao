using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState0 : CState
    {
        private Timer tm;
        private int counter = 0;
        public CState0(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec, ExamForm eform)
            : base(ganc, xianc, chec, eform)
        {
            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new EventHandler(tm_Tick);
        }

        public override void StateSwitchMesg()
        {
            base.StateSwitchMesg();
        }

        void tm_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == eform.settings.PrepareDuration)
            {
                CVoice.Play("��ʼ����");
                this.Close();
                StateManager.SwitchState("State1");
                eform.toolStripStatusLabel1.Text = "״̬��1";
                xian[6].Visable = false;
                base.Che_ht();
            }
        }

        public override void Che_xh()
        {
            //Ϩ��������
        }

        public override void Che_ht()
        {
            this.Close();
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

            base.Che_ht();
        }

        public override void Xian3_Bump()
        {
            this.Close();
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
            this.Close();
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
            this.Close();
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

        public override void Close()
        {
            tm.Stop();
            base.Close();
        }

        public override void Start()
        {
            tm.Start();
            eform.toolStripStatusLabel1.Text = "״̬��0";
            base.Start();
        }
    }
}

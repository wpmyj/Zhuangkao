using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState14i_Che:CState
    {
        private bool jinku_stopok;
        private Timer tm;
        private Timer tm1;

        public CState14i_Che(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {

        }

        public override void StateSwitchMesg()
        {
            jinku_stopok = false;
            base.StateSwitchMesg();
        }

        private void jinku_stop_fun()
        {
            che.JempStop();
            jinku_stopok = true;
            eform.toolStripStatusLabel2.Text = "��ʼ����";
            if (eform.settings.HasVoice)
            {
                //System.Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
                // ��������
                if (eform.IsExam)
                {
                    CVoice.Play(eform.student.Xm + "?��ʼ����");
                }
                else
                {
                    CVoice.Play("��ʼ����");
                }
            }
        }

        public override void Che_tc()
        {
            if (!jinku_stopok)
                jinku_stop_fun();
            base.Che_tc();
        }

        private void bump_gan(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "����" + gannum.ToString());
        }

        private void bump_xian(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "ѹ��" + gannum.ToString());
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
                eform.toolStripStatusLabel1.Text = "״̬��15";
                if (che.State == che.run)
                {
                    che.JempStop();
                }
                che.Moveto(305, 177, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[15] * 1000 / che.StepCount;//�������ü���״̬14���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
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
                eform.KaoShiEndFun(0, "·�ߴ�");
                return;
            }
           
            base.Che_qj();
        }

        public override void Xian4_Bump()
        {
            this.Close();
            StateManager.SwitchState("State16");
            eform.toolStripStatusLabel1.Text = "״̬��16";
            if (che.State == che.run)
            {
                che.JempStop();
            }
            che.Moveto(325, 75, che.forward);
            try
            {
                eform.timer1.Interval = eform.StateTime[16] * 1000 / che.StepCount;//�������ü���״̬14���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
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
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState11i:CState
    {
        private bool xiechuku_stopok;
        private bool stopmark;
        private Timer tm;
        private bool leaveXian1;
        private int tempi = 0;

        public CState11i(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {

        }

        public override void StateSwitchMesg()
        {
            stopmark = true;
            leaveXian1 = false;
            tm = new Timer();
            tm.Interval = 500;
            tm.Tick += Timerfun;
            base.StateSwitchMesg();
            tm.Start();
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[0] == 1 && leaveXian1 == false)
            {
                leaveXian1 = true;
                xian[1].Visable = true;
                xian[6].Visable = true;
            }
            else if (leaveXian1 && !xiechuku_stopok)
            {
                if (tempi < eform.StateTime[19])
                { 
                    tempi++;
                }
                else
                {
                    xiechuku_stopok_fun();
                }
            }
        }

        private void xiechuku_stopok_fun()
        {
            if (xiechuku_stopok)
            {
                return;
            }
            else
            {
                xian[1].Visable = true;
                xian[6].Visable = true;
                if (che.State == che.run)
                {
                    che.JempStop();
                }
                eform.toolStripStatusLabel2.Text = "��ʼ����";
                xiechuku_stopok = true;
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
        }

        public override void Che_ht()
        {
            if (xiechuku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State12");
                eform.toolStripStatusLabel1.Text = "״̬��12";

                che.Moveto(225, 75, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[12] * 1000 / che.StepCount;//�������ü���״̬12���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                xian[7].Visable = false;
            }
            base.Che_ht();
        }

        public override void Xian1_Bump()
        {
            if (xiechuku_stopok || leaveXian1)
            {
                this.Close();
                StateManager.SwitchState("State12");
                eform.toolStripStatusLabel1.Text = "״̬��12";

                che.Moveto(215, 75, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[12] * 1000 / che.StepCount;//�������ü���״̬12���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                xian[7].Visable = false;
            }
            base.Xian1_Bump();
        }

        public override void Xian2_Bump()
        {
            //����CState13;
            if (xiechuku_stopok || leaveXian1)
            {
                this.Close();
                StateManager.SwitchState("State13");
                eform.toolStripStatusLabel1.Text = "״̬��13";
                che.Moveto(215, 75, che.back);
                che.JempStop();
                che.Moveto(305, 85, che.back);
                try
                {
                    eform.timer1.Interval = eform.StateTime[13] * 1000 / che.StepCount;//�������ü���״̬13���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
                }
                catch
                {
                    eform.timer1.Interval = 10;
                }
                xian[7].Visable = false;
            }
            base.Xian2_Bump();
        }


        public override void Che_tc()
        {
            stopmark = true;
            xiechuku_stopok_fun();
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


        public override void Gan1_Bump()
        {
            bump_gan(197, 161, 255, 1);
            base.Gan1_Bump();
        }

        public override void Gan2_Bump()
        {
            bump_gan(262, 163, 270, 2);
            base.Gan2_Bump();
        }

        public override void Xian6_Bump()
        {
            bump_xian(182, 62, -115, 6);
            base.Xian6_Bump();
        }

        public override void Xian3_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(329, 76);
            che.SetRangle(180);
            eform.KaoShiEndFun(0, "�н������");
            base.Xian3_Bump();
        }


        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Close()
        {
            tm.Stop();
            base.Close();
        }

    }
}

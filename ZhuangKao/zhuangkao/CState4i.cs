using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState4i:CState
    {
        private bool jinku_stopok;
        private Timer tm;//ʱ��T2
        private Timer tm1;//ʱ��T1


         public CState4i(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec, ExamForm efrom)
            : base(ganc, xianc, chec,efrom)
        {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);

            tm1 = new Timer();
            tm1.Tick += new EventHandler(Timerfun);
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            jinku_stop_fun();
            return;
        }

        public override void StateSwitchMesg()
        {
            jinku_stopok = false;
            tm.Interval = eform.settings.T2 * 1000; //9000;
            tm.Start();
            eform.toolStripStatusLabel2.Text = "�뿪4��";
            base.StateSwitchMesg();
        }

        private void jinku_stop_fun() //����ͣ������
        {

            tm.Stop();
            tm1.Stop();
            if (jinku_stopok == false)
            {
                if (che.State == che.run)
                {
                    che.JempStop();
                }
                if (eform.cm.CurrData.xian[1] == 1)
                {
                    xian[6].Visable = true;
                    xian[1].Visable = false;
                    jinku_stopok = true;
                    eform.toolStripStatusLabel2.Text = "׼���ƿ�";
                    //System.Console.Beep();
                    if (eform.settings.HasVoice)
                    {
                        CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
                        // ��������
                        if (eform.IsExam)
                        {
                            CVoice.Play(eform.student.Xm + "?׼���ƿ�");
                        }
                        else
                        {
                            CVoice.Play("׼���ƿ�");
                        }
                    }
                }
                else
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(239, 294);
                    che.SetRangle(300);
                    eform.KaoShiEndFun(0, "ѹ��2");
                }
            }

        }

        public override void Xian2_Bump()
        {
            if (jinku_stopok)
            {
                StateManager.SwitchState("State5");
                eform.toolStripStatusLabel1.Text = "״̬��5";
                che.Moveto(260, 190, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[5] * 1000 / che.StepCount;//�������ü���״̬5���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
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
                che.SetWeizhi(239, 294);
                che.SetRangle(300);
                eform.KaoShiEndFun(0, "ѹ��2");
            }
            base.Xian2_Bump();
        }

        public override void Xian8_Bump()
        {
            tm1.Interval = eform.settings.T1 * 1000; //2000;
            tm1.Start();
            if (che.State == che.run)
            {
                che.JempStop();
            }
            base.Xian8_Bump();
        }

        public override void Xian5_Bump()
        {

                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(220, 330);
                che.SetRangle(270);
                eform.KaoShiEndFun(0, "ѹ��5");
            base.Xian5_Bump();
        }


        public override void Gan4_Bump()
        {

                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(195, 329);
                che.SetRangle(-80);
                eform.KaoShiEndFun(0, "����4");
           
            base.Gan4_Bump();
        }


        public override void Gan5_Bump()
        {

                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(235, 335);
                che.SetRangle(-100);
                eform.KaoShiEndFun(0, "����5");
           
            base.Gan5_Bump();
        }

        public override void Che_tc()
        {
            jinku_stop_fun();
            base.Che_tc();
        }

        public override void Che_qj()
        {
            if (jinku_stopok)
            {
                this.Close();
                StateManager.SwitchState("State5");
                eform.toolStripStatusLabel1.Text = "״̬��5";
                che.Moveto(260, 190, che.forward);
                try
                {
                    eform.timer1.Interval = eform.StateTime[5] * 1000 / che.StepCount;//�������ü���״̬5���趨ʱ���ڵ��ٶȣ���Ļˢ���ٶȣ�
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
            }
            base.Che_qj();
        }


        public override void Xian1_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(197,304);
            che.SetRangle(240);
            eform.KaoShiEndFun(0, "ѹ��1");
            base.Xian1_Bump();
        }

        public override void Xian4_Bump()
        {
            if (jinku_stopok)
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(214, 135);
                che.SetRangle(270);
                eform.KaoShiEndFun(0, "ѹ��4");
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
            tm.Stop();
            tm1.Stop();
        }

    }
}

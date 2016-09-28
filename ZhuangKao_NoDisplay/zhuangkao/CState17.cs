using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState17:CState
    {
        private bool passxian3;
        private bool stopmark;
        private Timer tm;

        public CState17(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
        }



        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
                this.Close();
                che.JempStop();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.toolStripStatusLabel2.Text = "¿¼ÊÔºÏ¸ñ";
                xian[7].Visable = true;
                //²¥·ÅÓïÒô
                if (eform.IsExam)
                {
                    CVoice.Play(eform.student.Xm + "£¬¿¼ÊÔºÏ¸ñ");
                }
                else
                {
                    CVoice.Play("¿¼ÊÔºÏ¸ñ");
                }
                eform.KaoShiEndFun(1, "¿¼ÊÔºÏ¸ñ");
                return;
               
               

        }

        public override void StateSwitchMesg()
        {
            if (eform.cm.IsShield(1, 3))
            {
                passxian3 = true;
            }
            else
            {
                passxian3 = false;
            }
            stopmark = false;
            tm.Interval = 5000;
            tm.Start();
            base.StateSwitchMesg();
        }

        public override void Xian3_Bump()
        {
            passxian3 = true;
            base.Xian3_Bump();
        }


        public override void Che_tc()
        {
            if (passxian3)
            {
                this.Close();
                che.JempStop();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.toolStripStatusLabel2.Text = "¿¼ÊÔºÏ¸ñ";
                xian[7].Visable = true;
                //²¥·ÅÓïÒô
                if (eform.IsExam)
                {
                    CVoice.Play(eform.student.Xm + "?¿¼ÊÔºÏ¸ñ");
                }
                else
                {
                    CVoice.Play("¿¼ÊÔºÏ¸ñ");
                }
                eform.KaoShiEndFun(1, "¿¼ÊÔºÏ¸ñ");

               
            }
            else
            {
                stopmark = true;
            }
            base.Che_tc();
        }


        public override void Xian9_Bump()
        {
            if (passxian3)
            {
                this.Close();
                che.JempStop();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.toolStripStatusLabel2.Text = "¿¼ÊÔºÏ¸ñ";
                xian[7].Visable = true;
                //²¥·ÅÓïÒô
                if (eform.IsExam)
                {
                    CVoice.Play(eform.student.Xm + "?¿¼ÊÔºÏ¸ñ");
                }
                else
                {
                    CVoice.Play("¿¼ÊÔºÏ¸ñ");
                }
                eform.KaoShiEndFun(1, "¿¼ÊÔºÏ¸ñ");

                
            }
            base.Xian9_Bump();
        }

        public override void Che_ht()
        {
            if (stopmark)
            {
                this.Close();
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(che.X, che.Y);
                che.SetRangle(che.Rangle);
                eform.KaoShiEndFun(0, "Â· Ïß ´í");
            }
            base.Che_ht();
        }

        public override void Che_qj()
        {
            if (stopmark)
            {
                Zhongting_fun(eform.settings.MaxStopCount);
            }
            base.Che_qj();
        }


        public override void Close()
        {
            tm.Stop();
            base.Close();
        }

    }
}

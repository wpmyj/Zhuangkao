using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CState
    {

        protected CGanFairy[] gan;
        protected CLineFairy[] xian;
        protected CBmpFairy che;
        protected ExamForm eform;
        public  static int stopcount;
        protected static int jinku_line;//�жϽ���ķ���ѹ2�߽��⻹��ѹ1�߽��⣩,2Ϊѹ2�ߣ�1Ϊѹ1��


        public CState(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm examform)
        {
            gan = ganc;
            xian = xianc;
            che = chec;
            eform = examform;
            stopcount = 0;
            jinku_line = 2;

        }

        //------------------��ͣ����(��ʱͣ��)-------------------------------------------
        protected void Zhongting_fun(int maxcount)
        {
            //if (stopcount == 1)
            //{
            //    eform.toolStripStatusLabel3.Text = "��ͣ 1 ��";
            //}
            //if (stopcount >= maxcount)
            //{
            //    StateManager.SwitchState("StateEnd");
            //    che.SetWeizhi(che.X, che.Y);
            //    che.SetRangle(che.Rangle);
            //    eform.toolStripStatusLabel3.Text = "��ͣ 2 ��";
            //    eform.KaoShiEndFun(0, "��ͣ");
                
            //}
        }

        protected void Zhongting_fun(int maxcount,System.Windows.Forms.Timer tm)
        {
            //if (stopcount == 1)
            //{
            //    eform.toolStripStatusLabel3.Text = "��ͣ 1 ��";
            //}
            //if (stopcount >= maxcount)
            //{
            //    tm.Stop();
            //    StateManager.SwitchState("StateEnd");
            //    che.SetWeizhi(che.X, che.Y);
            //    che.SetRangle(che.Rangle);
            //    eform.toolStripStatusLabel3.Text = "��ͣ 2 ��";
            //    eform.KaoShiEndFun(0, "��ͣ");

            //}
        }
        //----------------------------------------------------------------------------

        public virtual void Gan1_Bump()
        {
        }
        public virtual void Gan2_Bump()
        {
        }
        public virtual void Gan3_Bump()
        {
        }
        public virtual void Gan4_Bump()
        {
        }
        public virtual void Gan5_Bump()
        {
        }
        public virtual void Gan6_Bump()
        {
        }

        public virtual void Xian1_Bump()
        {
        }
        public virtual void Xian2_Bump()
        {
        }
        public virtual void Xian3_Bump()
        {
        }
        public virtual void Xian4_Bump()
        {
        }
        public virtual void Xian4_Leave()
        {
        }
        public virtual void Xian5_Bump()
        {
        }
        public virtual void Xian6_Bump()
        {
        }
        public virtual void Xian7_Bump()
        {
        }
        public virtual void Xian7_Leave()
        {
        }
        public virtual void Xian8_Bump()
        {
        }
        public virtual void Xian9_Bump()
        {
        }

        public virtual void Che_qj()
        {
            che.UnPause();
        }
        public virtual void Che_ht()
        {
            che.UnPause();
        }
        public virtual void Che_tc()
        {
           // che.Pause();
        }
        public virtual void Che_xh()
        {
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(che.X, che.Y);
            eform.KaoShiEndFun(0,"Ϩ��");
        }
        public virtual void StateSwitchMesg()
        {
        }

        public virtual void Close()
        {
        }

        public virtual void Start()
        {
        }
    }
}

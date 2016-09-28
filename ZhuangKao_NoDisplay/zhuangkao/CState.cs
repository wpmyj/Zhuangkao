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
        protected static int jinku_line;//判断进库的方向（压2线进库还是压1线进库）,2为压2线，1为压1线


        public CState(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm examform)
        {
            gan = ganc;
            xian = xianc;
            che = chec;
            eform = examform;
            stopcount = 0;
            jinku_line = 2;

        }

        //------------------中停处理(暂时停用)-------------------------------------------
        protected void Zhongting_fun(int maxcount)
        {
            //if (stopcount == 1)
            //{
            //    eform.toolStripStatusLabel3.Text = "中停 1 次";
            //}
            //if (stopcount >= maxcount)
            //{
            //    StateManager.SwitchState("StateEnd");
            //    che.SetWeizhi(che.X, che.Y);
            //    che.SetRangle(che.Rangle);
            //    eform.toolStripStatusLabel3.Text = "中停 2 次";
            //    eform.KaoShiEndFun(0, "中停");
                
            //}
        }

        protected void Zhongting_fun(int maxcount,System.Windows.Forms.Timer tm)
        {
            //if (stopcount == 1)
            //{
            //    eform.toolStripStatusLabel3.Text = "中停 1 次";
            //}
            //if (stopcount >= maxcount)
            //{
            //    tm.Stop();
            //    StateManager.SwitchState("StateEnd");
            //    che.SetWeizhi(che.X, che.Y);
            //    che.SetRangle(che.Rangle);
            //    eform.toolStripStatusLabel3.Text = "中停 2 次";
            //    eform.KaoShiEndFun(0, "中停");

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
            eform.KaoShiEndFun(0,"熄火");
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

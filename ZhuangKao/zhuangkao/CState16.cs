using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState16:CState
    {
        private Timer tm;
        private int tmpcount;

        public CState16(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec, ExamForm eform)
            : base(ganc, xianc, chec, eform)
        {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
        }

        public override void StateSwitchMesg()
        {
            tmpcount=0;
            tm.Interval = 1000;
            tm.Start();
            base.StateSwitchMesg();
        }


        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[3] == 1)
            {
                tmpcount++;
                if (tmpcount >= 2)
                {
                    tmpcount = 0;
                    tm.Stop();
                    eform.toolStripStatusLabel2.Text = "离开4线";
                    eform.toolStripStatusLabel1.Text = "状态：17";
                    StateManager.SwitchState("State17");
                    che.JempStop();
                    che.Moveto(445, 75, che.forward);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[16] * 1000 / che.StepCount;//根据配置计算状态4在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 30;
                    }
                }
            }
            else
            {
                tmpcount = 0;
            }

        }

        private void bump_gan(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "碰杆" + gannum.ToString());
        }


        public override void Gan2_Bump()
        {
            bump_gan(290, 155, 250, 2);
            base.Gan2_Bump();
        }

        public override void Gan3_Bump()
        {
            bump_gan(320, 153, 290, 3);
            base.Gan3_Bump();
        }


        public override void Xian2_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(284,102);
            che.SetRangle(230);
            eform.KaoShiEndFun(0, "路线错");
            base.Xian2_Bump();
        }



        public override void Close()
        {
            tm.Stop();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState11:CState
    {
        private Timer tm;
        private int tmpcount; //临时记时
        public CState11(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec, ExamForm eform)
            : base(ganc, xianc, chec, eform)
       {
            tm = new Timer();
            tm.Tick += new EventHandler(Timerfun);
          
        }

        public override void StateSwitchMesg()
        {
            tm.Interval = 1000;
            tm.Start();
            tmpcount = 0;
            base.StateSwitchMesg();
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[3] == 1)
            {
                tmpcount++;
                if (tmpcount >= 2)
                {
                    tm.Stop();
                    if (che.State == che.run)
                    {
                        che.JempStop();
                    }
                    StateManager.SwitchState("State11i");
                    eform.toolStripStatusLabel1.Text = "状态：11i";
                    che.Moveto(50, 75, che.forward);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[11] * 1000 / che.StepCount;//根据配置计算状态11在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 10;
                    }
                }
            }
            else
            {
                tmpcount = 0;
            }
        }


        public override void Gan1_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(186,123);
            che.SetRangle(230);
            eform.KaoShiEndFun(0, "碰杆1");
            base.Gan1_Bump();
        }

        public override void Gan2_Bump()
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(231,116);
            che.SetRangle(230);
            eform.KaoShiEndFun(0, "碰杆2");
            base.Gan2_Bump();
        }

        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Close()
        {
            tm.Stop();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public class CState8:CState
    {
        //private Timer tm72;
        //private Timer tm22;
        //private Timer tm28;
        //private Timer tm27;
        //private Timer tm74;
        //private bool leave2for8 = false;
        //private int leave2for8conter = 0;
        private int leave2after7, leave2after8, bump8counter;
        private bool pass7 = false;
        private bool pass8 = false;
        private Timer tm7, tm8, tm2;    //, tm4;

        public CState8(CGanFairy[] ganc, CLineFairy[] xianc, CBmpFairy chec,ExamForm eform)
            : base(ganc, xianc, chec,eform)
        {
            tm7 = new Timer();
            tm7.Interval = 500;
            tm7.Tick += new EventHandler(onTm7);
            tm2 = new Timer();
            tm2.Interval = 500;
            tm2.Tick += new EventHandler(onTm2);
            tm8 = new Timer();
            tm8.Interval = 500;
            tm8.Tick += new EventHandler(onTm8);
            //tm4 = new Timer();
            //tm4.Interval = 500;
            //tm4.Tick += new EventHandler(onTm4);
        }

        private void onTm7(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[6] == 0)
            {
                tm2.Stop();
                if (leave2after7 + leave2after8 <= 2)
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(278, 299);
                    che.SetRangle(-120);
                    eform.KaoShiEndFun(0, "移库不入");
                    return;
                }
                else
                {
                    if (eform.cm.CurrData.xian[3] == 0)
                    {
                        //if (che.State == che.run)
                        //{
                        //    che.JempStop();
                        //}
                        che.Moveto(170, 75, che.forward);
                        try
                        {
                            eform.timer1.Interval = eform.StateTime[11] * 1000 / che.StepCount;//根据配置计算状态12在设定时间内的速度（屏幕刷新速度）
                        }
                        catch
                        {
                            eform.timer1.Interval = 10;
                        }
                        this.Close();
                        StateManager.SwitchState("State11");
                        eform.toolStripStatusLabel1.Text = "状态：11";
                        return;
                    }
                    else
                    {
                        if (!pass7)
                        {
                            if (che.State == che.run)
                            {
                                che.JempStop();
                            }
                            che.Moveto(280, 240, che.forward);
                            try
                            {
                                eform.timer1.Interval = eform.StateTime[10] * 1000 / che.StepCount;//根据配置计算状态10在设定时间内的速度（屏幕刷新速度）
                            }
                            catch
                            {
                                eform.timer1.Interval = 10;
                            }
                            pass7 = true;
                        }
                    }
                    return;
                }
            }
            else
            {
                if (eform.cm.CurrData.xian[7] == 0 && pass8 == false)
                {
                    tm7.Stop();
                    if (che.State == che.run)
                    {
                        che.JempStop();
                    }
                    che.Moveto(305, 305, che.forward);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[11] * 1000 / che.StepCount;//根据配置计算状态12在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 10;
                    }
                    pass8 = true;
                    CVoice.Play("开始斜出库");
                    tm8.Start();
                }
            }
        }
        private void onTm2(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[1] == 1)
            {
                if (eform.cm.CurrData.xian[7] == 1)
                {
                    leave2after7++;
                }
                else
                {
                    leave2after8++;
                }
            }
        }
        private void onTm8(Object myObject, EventArgs myEventArgs)
        {
            if (eform.cm.CurrData.xian[7] == 1 || bump8counter > eform.settings.State8delay)
            {
                if (leave2after8 >= 2)
                {
                    tm8.Stop();
                    che.Moveto(280, 240, che.forward);
                    //che.JempStop();
                    //che.Moveto(255, 190, che.forward);
                    try
                    {
                        eform.timer1.Interval = eform.StateTime[10] * 1000 / che.StepCount;//根据配置计算状态10在设定时间内的速度（屏幕刷新速度）
                    }
                    catch
                    {
                        eform.timer1.Interval = 10;
                    }
                    tm7.Start();
                    return;
                }
                else
                {
                    this.Close();
                    StateManager.SwitchState("StateEnd");
                    che.SetWeizhi(278, 299);
                    che.SetRangle(-120);
                    eform.KaoShiEndFun(0, "移库不入");
                    return;
                }
            }
            else
            {
                bump8counter++;
            }
        }
        //private void onTm4(Object myObject, EventArgs myEventArgs)
        //{
        //}
        //private void leave7leave2(Object myObject, EventArgs myEventArgs)
        //{
        //    if (eform.cm.CurrData.xian[1] == 1)
        //    {
        //        tm72.Stop();
        //        tm22.Start();
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[6] == 0)
        //    {
        //        this.Close();
        //        StateManager.SwitchState("StateEnd");
        //        che.SetWeizhi(278, 299);
        //        che.SetRangle(-120);
        //        eform.KaoShiEndFun(0, "移库不入");
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[7] == 0)
        //    {
        //        tm72.Stop();
        //        tm28.Start();
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[4] == 0)
        //    {
        //        bump_xian(285, 158, 295, 4);
        //        return;
        //    }
        //}
        //private void leave2bamp2(Object myObject, EventArgs myEventArgs)
        //{
        //    if (eform.cm.CurrData.xian[1] == 0)
        //    {
        //        tm22.Stop();
        //        if (che.State == che.run)
        //        {
        //            che.JempStop();
        //        }
        //        che.Moveto(255, 190, che.forward);
        //        try
        //        {
        //            eform.timer1.Interval = eform.StateTime[10] * 1000 / che.StepCount;//根据配置计算状态10在设定时间内的速度（屏幕刷新速度）
        //        }
        //        catch
        //        {
        //            eform.timer1.Interval = 10;
        //        }
        //        tm27.Start();
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[6] == 0)
        //    {
        //        this.Close();
        //        StateManager.SwitchState("StateEnd");
        //        che.SetWeizhi(che.X, che.Y);
        //        che.SetRangle(che.Rangle);
        //        eform.KaoShiEndFun(0, "路线错");
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[7] == 0)
        //    {
        //        tm22.Stop();
        //        tm28.Start();
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[4] == 0)
        //    {
        //        bump_xian(285, 158, 295, 4);
        //    }
        //}

        //private void bamp2bamp8(Object myObject, EventArgs myEventArgs)
        //{
        //    if (eform.cm.CurrData.xian[1] == 1)
        //        leave2for8 = true;
        //    leave2for8conter++;
        //    if (eform.cm.CurrData.xian[7] == 1 || leave2for8conter >= eform.settings.State8delay)
        //    {
        //        if (leave2for8)
        //        {
        //            tm28.Stop();
        //            if (che.State == che.run)
        //            {
        //                che.JempStop();
        //            }
        //            che.Moveto(255, 190, che.forward);
        //            try
        //            {
        //                eform.timer1.Interval = eform.StateTime[10] * 1000 / che.StepCount;//根据配置计算状态10在设定时间内的速度（屏幕刷新速度）
        //            }
        //            catch
        //            {
        //                eform.timer1.Interval = 10;
        //            }
        //            tm27.Start();
        //            return;
        //        }
        //        else
        //        {
        //            this.Close();
        //            StateManager.SwitchState("StateEnd");
        //            che.SetWeizhi(278, 299);
        //            che.SetRangle(-120);
        //            eform.KaoShiEndFun(0, "移库不入");
        //            return;
        //        }
        //    }
        //}
        //private void bamp2bamp7(Object myObject, EventArgs myEventArgs)
        //{
        //    if (eform.cm.CurrData.xian[6] == 0)
        //    {
        //        tm27.Stop();
        //        tm74.Start();
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[7] == 0)
        //    {
        //        this.Close();
        //        StateManager.SwitchState("StateEnd");
        //        che.SetWeizhi(che.X, che.Y);
        //        che.SetRangle(che.Rangle);
        //        eform.KaoShiEndFun(0, "路线错");
        //        return;
        //    }
        //}
        //private void bamp7bamp4(Object myObject, EventArgs myEventArgs)
        //{
        //    if (eform.cm.CurrData.xian[3] == 0)
        //    {
        //        if (che.State == che.run)
        //        {
        //            che.JempStop();
        //        }
        //        che.Moveto(170, 75, che.forward);
        //        try
        //        {
        //            eform.timer1.Interval = eform.StateTime[11] * 1000 / che.StepCount;//根据配置计算状态12在设定时间内的速度（屏幕刷新速度）
        //        }
        //        catch
        //        {
        //            eform.timer1.Interval = 10;
        //        }
        //        StateManager.SwitchState("State11");
        //        eform.toolStripStatusLabel1.Text = "状态：11";
        //        return;
        //    }
        //    if (eform.cm.CurrData.xian[6] == 1)
        //    {
        //        this.Close();
        //        StateManager.SwitchState("StateEnd");
        //        che.SetWeizhi(che.X, che.Y);
        //        che.SetRangle(che.Rangle);
        //        eform.KaoShiEndFun(0, "路线错");
        //        return;
        //    }
        //}
        public override void StateSwitchMesg()
        {
            tm7.Start();
            tm2.Start();
            base.StateSwitchMesg();
        }

/**===============================================================================
        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            tm.Stop();
            tm3.Stop();
            stopok_fun();
        }

        private void stopok_fun()
        {
            if (stopok)
            {
                return;
            }
            tm.Stop();
            tm3.Stop();
            stopok = true;
            if (che.State == che.run)
            {
                che.JempStop();
            }
            xian[1].Visable = true;
            if (eform.cm.CurrData.xian[1] == 0)
            {
                StateManager.SwitchState("StateEnd");
                che.SetWeizhi(278, 299);
                che.SetRangle(-120);
                eform.KaoShiEndFun(0, "移库不入");
                return;
            }
            eform.toolStripStatusLabel2.Text = "开始斜出库";
            //System.Console.Beep();
            // 播放语音
            if (eform.IsExam)
            {
                CVoice.Play(eform.student.Xm + "?开始斜出库");
            }
            else
            {
                CVoice.Play("开始斜出库");
            }
        }
 * */

        public override void Che_tc()
        {
            base.Che_tc();
        }

        public override void Che_ht()
        {
            base.Che_ht();
        }


        public override void Che_qj()
        {
            base.Che_qj();
        }


        private void bump_gan(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "碰杆" + gannum.ToString());
        }

        private void bump_xian(int x, int y, int range, int gannum)
        {
            this.Close();
            StateManager.SwitchState("StateEnd");
            che.SetWeizhi(x, y);
            che.SetRangle(range);
            eform.KaoShiEndFun(0, "压线" + gannum.ToString());
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

        public override void Gan3_Bump()
        {
            bump_gan(331, 164, 290, 3);
            base.Gan3_Bump();
        }

        public override void Gan4_Bump()
        {
            bump_gan(190, 328, 290, 4);
            base.Gan4_Bump();
        }

        public override void Gan5_Bump()
        {
            bump_gan(262, 326, 270, 5);
            base.Gan5_Bump();
        }

        public override void Gan6_Bump()
        {
            bump_gan(328, 331, 240, 6);
            base.Gan6_Bump();
        }

        public override void Xian1_Bump()
        {
            bump_xian(192, 254, 295, 1);
            base.Xian1_Bump(); 
        }

        public override void Xian3_Bump()
        {
            bump_xian(333, 242, 240, 3);
            base.Xian3_Bump();
        }

        public override void Xian4_Bump()
        {
            //bump_xian(285, 158, 295, 4);
            base.Xian4_Bump();
        }

        public override void Xian5_Bump()
        {
            bump_xian(304, 338, 270, 5);
            base.Xian5_Bump();
        }

        public override void Che_xh()
        {
            this.Close();
            base.Che_xh();
        }

        public override void Xian2_Bump()
        {
            //if (stopok)
            //{
            //    xian[1].Visable = false;
            //    xian[6].Visable = false;
            //    eform.toolStripStatusLabel1.Text = "状态：10";
            //    che.Moveto(280, 240, che.forward);
            //    che.JempStop();
            //    che.Moveto(255, 190, che.forward);
            //    try
            //    {
            //        eform.timer1.Interval = eform.StateTime[10] * 1000 / che.StepCount;//根据配置计算状态10在设定时间内的速度（屏幕刷新速度）
            //    }
            //    catch
            //    {
            //        eform.timer1.Interval = 10;
            //    }
            //    StateManager.SwitchState("State10");
            //    eform.toolStripStatusLabel1.Text = "状态：10";
            //}

            base.Xian2_Bump();
        }

        public override void Close()
        {
            tm7.Stop();
            tm2.Stop();
            tm8.Stop();
            //tm4.Stop();
            base.Close();
        }
    }
}

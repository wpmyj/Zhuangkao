using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Exam;
using Cn.Youdundianzi.Share.Exam;
using Cn.Youdundianzi.Exam;
using Cn.Youdundianzi.Exam.State;
using Cn.Youdundianzi.Share.Signal.Car;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Util.Car;
using Cn.Youdundianzi.Share.Module.ModelDisplay;

namespace Cn.Youdundianzi.Share.Module.ModelDisplay.Car
{
    public class CarSignalModelDisplayPanel : CarModelDisplayPanel
    {
        public CarSignalModelDisplayPanel()
            : base()
        {
        }

        #region IExamObserver Members

        public override void Notify(IState state)
        {
            CarBaseState mstate = (CarBaseState)state;

            switch (mstate.Name)
            {
                case "SAMPLE":

                case "IDLE":
                    che.SetWeizhi(che.X, che.Y);
                    break;

                //开始
                case "KS":
                    ResetElements();
                    break;

                //进库
                case "JK32":
                    che.Speed = stateDuration[0];
                    che.Moveto(290, 75, che.back);
                    break;
                case "JK24":
                    xian[6].Visable = false;
                    che.JempStop();
                    che.Speed = stateDuration[0];
                    che.Moveto(220, 85, che.back);
                    break;
                case "JK4":
                    if (che.Destx == 220 && che.Desty == 85)
                    {
                        che.JempStop();
                        che.Moveto(220, 170, che.back);
                    }
                    break;
                case "JKL4":
                    break;
                case "JK4S":
                    xian[6].Visable = true;
                    if (che.Destx == 220 && che.Desty == 170)
                    {
                        che.JempStop();
                        che.Moveto(220, 305, che.back);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "JKTO":
                    che.Pause();
                    break;

                //移库
                case "YK1F":
                    xian[1].Visable = false;
                    if (che.Destx == 220 && che.Desty == 305)
                    {
                        che.JempStop();
                        che.Moveto(260, 190, che.forward);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "YK1S":
                    che.Pause();
                    break;
                case "YK1B":
                    if (che.Destx == 260 && che.Desty == 190)
                    {
                        che.JempStop();
                        che.Moveto(280, 305, che.back);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "YK2S":
                    che.Pause();
                    break;
                case "YK2F":
                    if (che.Destx == 280 && che.Desty == 305)
                    {
                        che.JempStop();
                        che.Moveto(305, 190, che.forward);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "YK3S":
                    che.Pause();
                    break;
                case "YK2B":
                    if (che.Destx == 305 && che.Desty == 190)
                    {
                        che.JempStop();
                        che.Moveto(305, 305, che.back);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "YK4S":
                    xian[1].Visable = true;
                    che.Pause();
                    break;
                
                //斜出库
                case "XCK24":
                    xian[1].Visable = false;
                    xian[6].Visable = false;
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(255, 190, che.forward);
                    break;
                case "XCK4":
                    if (che.Destx == 255 && che.Desty == 190)
                    {
                        che.JempStop();
                        che.Speed = stateDuration[1];
                        che.Moveto(170, 75, che.forward);
                    }
                    break;
                case "XCK14":
                    break;
                case "XCKL4":
                    break;
                case "XCK4S":
                    if (che.Destx == 170 && che.Desty == 75)
                    {
                        che.JempStop();
                        che.Speed = stateDuration[0];
                        che.Moveto(50, 75, che.forward);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "XCKE":
                    che.Pause();
                    xian[1].Visable = true;
                    xian[6].Visable = true;
                    break;

                //倒库
                case "DK12":
                    che.JempStop();
                    che.Moveto(215, 75, che.back);
                    break;                    
                case "DK24":
                    xian[7].Visable = false;
                    che.JempStop();
                    che.Moveto(305, 85, che.back);
                    break;
                case "DK4":
                    if (che.Destx == 305 && che.Desty == 85)
                    {
                        che.JempStop();
                        che.Moveto(305, 140, che.back);
                    }
                    break;
                case "DKL4":
                    break;
                case "DK4S":
                    if (che.Destx == 305 && che.Desty == 140)
                    {
                        che.JempStop();
                        che.Moveto(305, 280, che.back);
                    }
                    else
                    {
                        che.UnPause();
                    }
                    break;
                case "DKTO":
                    che.Pause();
                    break;
                
                //出库
                case "CKF4":
                    che.JempStop();
                    che.Moveto(305, 177, che.forward);
                    break;
                case "CK4":
                    if (che.Destx == 305 && che.Desty == 177)
                    {
                        che.JempStop();
                        che.Moveto(325, 75, che.forward);
                    }
                    break;
                case "CKL4":
                    break;
                case "CK4S":
                    che.JempStop();
                    che.Moveto(445, 75, che.forward);
                    break;

                //结束
                case "JS":
                    che.SetWeizhi(che.X, che.Y);
                    break;
            }
        }

        #endregion
    }
}

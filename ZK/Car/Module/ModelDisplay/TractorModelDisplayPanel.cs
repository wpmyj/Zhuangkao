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
using Cn.Youdundianzi.Share.Util.Tractor;
using Cn.Youdundianzi.Share.Module.ModelDisplay;

namespace Cn.Youdundianzi.Share.Module.ModelDisplay.Car
{
    public class TractorModelDisplayPanel : BaseModelDisplayPanel
    {
        private ITractorStateManager _sm;
        public TractorModelDisplayPanel()
            : base()
        {
        }

        public override void InitializeExamComponent(CSettings set, ISignalMonitor mon, IStateManager sm)
        {
            base.InitializeExamComponent(set, mon, sm);
            _sm = sm as ITractorStateManager;
            this.Size = new Size(520, 428);
        }

        #region IExamObserver Members

        public override void Notify(CExam exam)
        {
            if (!exam.Passed)
            {
                //若要改变出错时模型车位置，请调整此处代码。
                //可再为每种ResultType添加switch(exam.Message.Index)，
                //以细化针对不同杆线错误时，模型车的位置
                switch (exam.Message.TypeOfResult)
                {
                    case ResultType.Gan:
                        che.SetWeizhi(gan[exam.Message.Index].X, gan[exam.Message.Index].Y);
                        break;
                    case ResultType.Xian:
                        switch (exam.Message.Index)
                        {
                            case 0:
                            case 1:
                            case 2:
                                che.SetWeizhi(che.X, xian[exam.Message.Index].Y1);
                                break;
                            case 3:
                            case 4:
                            case 5:
                                che.SetWeizhi(xian[exam.Message.Index].X1, che.Y);
                                break;
                        }
                        break;
                    case ResultType.ZT:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.XH:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.LXC:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.YKBR:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    case ResultType.TimeOut:
                        che.SetWeizhi(che.X, che.Y);
                        break;
                    default:
                        break;
                }
            }
        }

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
                    //车初始位置(80, 215)
                    break;

                //前进
                case "F1":
                    che.Speed = stateDuration[0];
                    che.Moveto(140, 215, che.forward);
                    break;
                case "F2":
                    che.JempStop();
                    che.Moveto(185, 215, che.forward);
                    break;
                case "F3":
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(185, 195, che.forward);
                    break;
                case "F4":
                    che.JempStop();
                    che.Speed = stateDuration[2];
                    che.Moveto(260, 180, che.forward);
                    break;
                case "F5":
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(380, 145, che.forward);
                    break;
                case "F6":
                    che.JempStop();
                    che.Moveto(335, 145, che.forward);
                    break;
                case "F7":
                    che.JempStop();
                    che.Speed = stateDuration[0];
                    che.Moveto(425, 145, che.forward);
                    break;
                case "F8":
                    che.JempStop();
                    che.Moveto(440, 145, che.forward);
                    break;
                case "FB":
                    che.JempStop();
                    break;
                
                //后退
                case "B1":
                    che.JempStop();
                    che.Speed = stateDuration[0];
                    che.Moveto(380, 145, che.back);
                    break;
                case "B2":
                    che.JempStop();
                    che.Moveto(335, 145, che.back);
                    break;
                case "B3":
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(335, 160, che.back);
                    break;
                case "B4":
                    che.JempStop();
                    che.Speed = stateDuration[2];
                    che.Moveto(260, 180, che.back);
                    break;
                case "B5":
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(175, 205, che.back);
                    break;
                case "B6":
                    che.JempStop();
                    che.Moveto(185, 215, che.back);
                    break;
                case "B7":
                    che.Speed = stateDuration[0];
                    che.Moveto(140, 215, che.back);
                    break;
                case "B8":
                    che.Moveto(80, 215, che.back);
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

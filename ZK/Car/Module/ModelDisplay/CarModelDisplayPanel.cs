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
    public class CarModelDisplayPanel : BaseModelDisplayPanel
    {
        private ICarStateManager _sm;
        public CarModelDisplayPanel()
            : base()
        {
        }

        public override void InitializeExamComponent(CSettings set, ISignalMonitor mon, IStateManager sm)
        {
            base.InitializeExamComponent(set, mon, sm);
            _sm = sm as ICarStateManager;
            this.Size = new Size(520, 428);

            //1����
            xian[0].Linex = set.InitPosition.Xian[0].X1;
            xian[0].Liney = 10;

            //2����
            xian[1].Linex = set.InitPosition.Xian[1].X1;
            xian[1].Liney = 10;

            //3����
            xian[2].Linex = set.InitPosition.Xian[2].X1;
            xian[2].Liney = 10;

            //4����
            xian[3].Linex = 10;
            xian[3].Liney = set.InitPosition.Xian[3].Y1;

            //5����
            xian[4].Linex = set.InitPosition.Xian[0].X1;
            xian[4].Liney = set.InitPosition.Xian[4].Y1;

            //6����
            xian[5].Linex = 10;
            xian[5].Liney = set.InitPosition.Xian[5].Y1;

            //7����
            xian[6].LineName = string.Empty;

            //8����
            xian[7].LineName = string.Empty;

            //9����
            xian[8].LineName = string.Empty;
        }

        #region IExamObserver Members

        public override void Notify(IMonData data)
        {
            base.Notify(data);
            xian[6].Stat = xian[7].Stat = xian[8].Stat = xian[3].Stat;
        }

        public override void Notify(CExam exam)
        {
            if (!exam.Passed)
            {
                //��Ҫ�ı����ʱģ�ͳ�λ�ã�������˴����롣
                //����Ϊÿ��ResultType���switch(exam.Message.Index)��
                //��ϸ����Բ�ͬ���ߴ���ʱ��ģ�ͳ���λ��
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
                                che.SetWeizhi(xian[exam.Message.Index].X1, che.Y);
                                break;
                            case 4:
                            case 5:
                                che.SetWeizhi(che.X, xian[exam.Message.Index].Y1);
                                break;
                            case 3:
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
                        che.SetWeizhi(xian[1].X1 - 10, che.Y);
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

                //��ʼ
                case "KS":
                    ResetElements();
                    break;

                //����
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
                case "JK47":
                    che.JempStop();
                    che.Moveto(220, 140, che.back);
                    break;
                case "JK74":
                    che.Moveto(220, 170, che.back);
                    break;
                case "JK77":
                    break;
                case "JKL4":
                    break;
                case "JK48":
                    xian[6].Visable = true;
                    che.JempStop();
                    che.Moveto(220, 305, che.back);
                    break;
                case "JK8TO":
                    break;
                case "JKTO":
                    break;

                //�ƿ�
                case "YK27":
                    xian[1].Visable = false;
                    che.JempStop();
                    che.Moveto(260, 190, che.forward);
                    break;
                case "YK771":
                    che.JempStop();
                    break;
                case "YK781":
                    che.JempStop();
                    che.Moveto(280, 305, che.back);
                    break;
                case "YK88":
                    che.JempStop();
                    break;
                case "YK87":
                    che.JempStop();
                    che.Moveto(305, 190, che.forward);
                    break;
                case "YK772":
                    che.JempStop();
                    break;
                case "YK782":
                    che.JempStop();
                    che.Moveto(305, 250, che.back);
                    break;
                case "YKL2":
                    break;
                case "YKH2":
                    break;
                case "YKL28":
                    xian[1].Visable = true;
                    che.Moveto(305, 305, che.back);
                    break;
                case "YKH28":
                    che.Moveto(305, 305, che.back);
                    break;
                
                //б����
                case "XCKH2":
                    xian[1].Visable = false;
                    xian[6].Visable = false;
                    break;
                case "XCKL2":
                    break;
                case "XCK74":
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(255, 190, che.forward);
                    break;
                case "XCK41":
                    che.JempStop();
                    che.Speed = stateDuration[1];
                    che.Moveto(170, 75, che.forward);
                    break;
                case "XCK14":
                    break;
                case "XCK4E":
                    che.JempStop();
                    che.Speed = stateDuration[0];
                    che.Moveto(50, 75, che.forward);
                    break;
                case "XCKE":
                    xian[1].Visable = true;
                    xian[6].Visable = true;
                    break;

                //����
                case "DK11":
                    break;
                case "DK12":
                    che.JempStop();
                    che.Moveto(215, 75, che.back);
                    break;                    
                case "DK24":
                    xian[7].Visable = false;
                    che.JempStop();
                    che.Moveto(305, 85, che.back);
                    break;
                case "DK47":
                    che.JempStop();
                    che.Moveto(305, 140, che.back);
                    break;
                case "DK74":
                    break;
                case "DK77":
                    break;
                case "DKL4":
                    break;
                case "DK48":
                    che.JempStop();
                    che.Moveto(305, 280, che.back);
                    break;
                
                //����
                case "CK84":
                    che.JempStop();
                    che.Moveto(305, 177, che.forward);
                    break;
                case "CK44":
                    che.JempStop();
                    che.Moveto(325, 75, che.forward);
                    break;
                case "CK34":
                    break;
                case "CK43":
                    che.JempStop();
                    che.Moveto(445, 75, che.forward);
                    break;
                case "CKE":
                    xian[7].Visable = true;
                    break;

                //����
                case "JS":
                    che.SetWeizhi(che.X, che.Y);
                    break;
            }
        }

        #endregion

        protected override void ResetElements()
        {
            base.ResetElements();
            xian[1].Visable = true;
            xian[6].Visable = true;
            xian[7].Visable = true;
        }
    }
}

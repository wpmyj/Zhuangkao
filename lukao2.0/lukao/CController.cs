using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace lukao
{
    public class CController
    {
        main_view mainview;
        CModel model;
        private System.Timers.Timer t1;
        private byte[] senddata;
        private CMyMessageFuns sendmessagefuns;//发送信息处理
        private CMyMessageFuns recvmessagefuns;//接收信息处理
        private CSeriesMsg msg;
        public delegate void ButtonEnable(int myindex);
        public event ButtonEnable OnButtonEnable;


        public CController(CModel model,main_view mainview)
        {
            this.mainview = mainview;
            this.model = model;
            senddata = new byte[30];
            sendmessagefuns = new CMyMessageFuns();
            sendmessagefuns.InputData(senddata);
            recvmessagefuns = new CMyMessageFuns();
            t1 = new System.Timers.Timer();
            t1.Elapsed += new ElapsedEventHandler(Timerfun);
            if (this.model.settings.Fspltimer == 0)
            {
                t1.Interval = 2000;
            }
            else
            {
                t1.Interval =this.model.settings.Fspltimer;
            }
            t1.AutoReset = true;
            //model.OnUserDataReceived += new CModel.UserDataReceived(model_OnUserDataReceived);
            msg = new CSeriesMsg(model);
            msg.OnUserDataReceived += new CSeriesMsg.UserDataReceived(msg_OnUserDataReceived);
            t1.Start();
         
        }

        public void ShowMain_view()
        {
            //mainview.ShowDialog();
            mainview.Show();
        }


        //---------串口数据接收处理------------------------------
        public void msg_OnUserDataReceived(object sender, byte[] e)
        {
            t1.Stop();
            System.Threading.Thread.Sleep(100);
            recvmessagefuns.InputData(e);
            string tmps = recvmessagefuns.GetDevnum();
            try
            {
                if (recvmessagefuns.GetVerifyCode() != recvmessagefuns.CountVerifyCode())
                {
                    work();
                    t1.Start();
                    return;
                }
                if (recvmessagefuns.GetDevnum() == model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder)
                {
                    switch (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status)
                    {
                        case "未知":
                            if (recvmessagefuns.GetCmdWord() == 0x33)
                            {
                                if (recvmessagefuns.GetStatus() == 0x30)
                                {
                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "空闲";
                                    mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                }
                                if (recvmessagefuns.GetStatus() == 0x31)
                                {
                                    //需要复位考试设备，同步考试设备状态
                                }
                                model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount = 0;
                            }
                            break;
                        case "空闲":
                            if (recvmessagefuns.GetCmdWord() == 0x36)
                            {
                                model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "正在考试";
                                mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount = 0;
                            }
                            break;
                        case "正在考试":
                            if (recvmessagefuns.GetCmdWord() == 0x38)
                            {
                                if (recvmessagefuns.GetKscj() < 101)
                                {
                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.fxcj[model.ksdevmanager.QqIndex] = recvmessagefuns.GetKscj();
                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.kscj =
                                        model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.kscj - recvmessagefuns.GetKscj();

                                    if (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.kscj > model.settings.Jgfs)
                                    {
                                        //考试及格处理
                                        int i = 0;
                                        while ((i < model.ksdevmanager.KsDevCount) && (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.fxcj[i] != -1))
                                        {
                                            i++;
                                        }
                                        if (i >= model.ksdevmanager.KsDevCount)
                                        {
                                            //整体考试完成了
                                            if (model.SaveStudentInfo(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent))
                                            {
                                                //model.UpdateDataSet();
                                                System.Threading.Thread.Sleep(200);
                                                mainview.UpdateDataGrid();
                                                model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].RemoveStudent(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent);
                                                mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                            }
                                            else
                                            {
                                                System.Windows.Forms.MessageBox.Show("考生信息存储失败！");
                                            }
                                        }
                                        else
                                        {
                                            //继续未考试项目
                                            model.ksdevmanager.ksdevmodels[i].AddStudent(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent);
                                            model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].RemoveStudent(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent);
                                            mainview.KsdevRefresh(i);
                                            mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                        }
                                    }
                                    else
                                    {
                                        //考试不及格处理
                                        if (model.SaveStudentInfo(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent))
                                        {
                                            //model.UpdateDataSet();
                                            System.Threading.Thread.Sleep(200);
                                            mainview.UpdateDataGrid();
                                            model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].RemoveStudent(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent);
                                            mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                        }
                                        else
                                        {
                                            System.Windows.Forms.MessageBox.Show("考生信息存储失败！");
                                        }

                                    }

                                    for (int i = 0; i < 10; i++)
                                    {
                                        System.Threading.Thread.Sleep(200);
                                        sendmessagefuns.ClearData();
                                        sendmessagefuns.SetCmdHead();
                                        sendmessagefuns.SetCmdWord(0x39);
                                        sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                                        sendmessagefuns.SetVerifyCode();
                                        sendmessagefuns.SetEndCode();
                                        msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                                    }

                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "未知";
                                    mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                    System.Threading.Thread.Sleep(2000);
                                }
                            }
                            break;
                        case "复位":
                            switch (recvmessagefuns.GetCmdWord())
                            {
                                case 0x33:
                                    if (recvmessagefuns.GetStatus() == 0x30)
                                    {
                                        model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "空闲";
                                        mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                        OnButtonEnable(model.ksdevmanager.QqIndex);
                                    }
                                    if (recvmessagefuns.GetStatus() == 0x31)
                                    {
                                        //需要复位考试设备，同步考试设备状态
                                    }
                                    
                                    break;
                                case 0x36:
                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "正在考试";
                                    mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount = 0;
                                    OnButtonEnable(model.ksdevmanager.QqIndex);
                                    break;
                                case 0x39:
                                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "未知";
                                    mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                                    OnButtonEnable(model.ksdevmanager.QqIndex);
                                    break;
                            }
                            break;

                    }
                }
                else
                {
                    // work();
                }
            }
            catch
            {
               // work();
                t1.Start();
                return;
            }
           // work();
            t1.Start();
            
        }

        private void Timerfun(Object myObject, ElapsedEventArgs myEventArgs)
        {
            t1.Stop();
            try
            {
                work();
            }
            catch
            {
                t1.Start();
                return;
            }
            t1.Start();
        }

        private void work()
        {
            model.ksdevmanager.MoveNext();
            switch (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status)
            {
                case "未知":
                    if (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount > 3)
                    {
                        model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "空闲";
                        mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                        model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount = 0;
                        break;
                    }
                    sendmessagefuns.ClearData();
                    sendmessagefuns.SetCmdHead();
                    sendmessagefuns.SetCmdWord(0x31);
                    sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                    sendmessagefuns.SetVerifyCode();
                    sendmessagefuns.SetEndCode();
                    msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount++;
                    break;
                case "空闲":
                    if (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].StudentList.Count > 0)
                    {
                        if (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount > 3)
                        {
                            model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Status = "未知";
                            mainview.KsdevRefresh(model.ksdevmanager.QqIndex);
                            model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount = 0;
                            break;
                        }
                        sendmessagefuns.ClearData();
                        sendmessagefuns.SetCmdHead();
                        sendmessagefuns.SetCmdWord(0x35);
                        sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                        sendmessagefuns.SetZkzhm(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.zkzmbh);
                        sendmessagefuns.SetXm(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.xm);
                        sendmessagefuns.SetVerifyCode();
                        sendmessagefuns.SetEndCode();
                        msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                        model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount++;
                        
                    }
                    break;
                case "正在考试":
                    sendmessagefuns.ClearData();
                    sendmessagefuns.SetCmdHead();
                    sendmessagefuns.SetCmdWord(0x37);
                    sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                    sendmessagefuns.SetVerifyCode();
                    sendmessagefuns.SetEndCode();
                    msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                    break;
                case "复位":
                    switch (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].resetcount)
                    {
                        case 0://查询
                            sendmessagefuns.ClearData();
                            sendmessagefuns.SetCmdHead();
                            sendmessagefuns.SetCmdWord(0x31);
                            sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                            sendmessagefuns.SetVerifyCode();
                            sendmessagefuns.SetEndCode();
                            msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                            break;
                        case 1://考生登记
                            if (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].StudentList.Count > 0)
                            {
                                sendmessagefuns.ClearData();
                                sendmessagefuns.SetCmdHead();
                                sendmessagefuns.SetCmdWord(0x35);
                                sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                                sendmessagefuns.SetZkzhm(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.zkzmbh);
                                sendmessagefuns.SetXm(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].DqStudent.xm);
                                sendmessagefuns.SetVerifyCode();
                                sendmessagefuns.SetEndCode();
                                msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                            }
                            model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].commcount++;
                            break;
                        case 2://成绩回传
                            sendmessagefuns.ClearData();
                            sendmessagefuns.SetCmdHead();
                            sendmessagefuns.SetCmdWord(0x37);
                            sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                            sendmessagefuns.SetVerifyCode();
                            sendmessagefuns.SetEndCode();
                            msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                            break;
                        case 3://回传确认
                            sendmessagefuns.ClearData();
                            sendmessagefuns.SetCmdHead();
                            sendmessagefuns.SetCmdWord(0x39);
                            sendmessagefuns.SetDevnum(model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].Ksdevorder);
                            sendmessagefuns.SetVerifyCode();
                            sendmessagefuns.SetEndCode();
                            msg.SendData(senddata, sendmessagefuns.GetCmdLength());
                            break;
                    }

                    model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].resetcount++;
                    if (model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].resetcount > 3)
                    {
                        model.ksdevmanager.ksdevmodels[model.ksdevmanager.QqIndex].resetcount = 0;
                    }
                    break;
                case "故障":
                    break;
              }
             
        }
    }
}

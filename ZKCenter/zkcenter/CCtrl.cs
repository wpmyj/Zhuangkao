//******************************************
//      Main_Form窗体的控制类
//******************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zkcenter
{
    public class CCtrl
    {

        public  CNetServer Server;
        private  Main_Form mainform;
        private CModel model;
        //private CDisplaycomm displaycomm;
        private ModuleSettings settings;

        public CCtrl(CModel model)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            this.model = model;
            model.Event_RemoteSQLLink += new CModel.D_RemoteSQLLink(model_Event_ORACLELink);
          
            Server = new CNetServer();
            Server.Event_Devlogin += new CNetServer.D_DEVLOGIN(Server_Event_Devlogin);
            Server.Event_Devlogout+=new CNetServer.D_DEVLOGOUT(Server_Event_Devlogout);
            Server.Event_Devnetdata+=new CNetServer.D_DEVNETDATA(Server_Event_Devnetdata);
            settings = ModuleConfig.GetSettings();
            //displaycomm = new CDisplaycomm(settings);
            //displaycomm.ShowText("欢迎来到大成驾校考试!");
            mainform = new Main_Form(this,this.model);
            Application.Run(mainform);
           // model.RemoteDBlink();
        }

     #region 网络事件处理
        private void Server_Event_Devlogin(int devnum)
        {
            mainform.ChangeDevStatus(devnum, DevStatus.设备就绪);
        }

        private void Server_Event_Devlogout(int devnum)
        {
            CStuDevlist tmpDevList = (CStuDevlist)(model.devmanager.DevList[devnum]);
            if (tmpDevList == null)
                return;
            for (int i = 0; i < ((CStuDevlist)(model.devmanager.DevList[devnum])).Stumum; i++)
            {
                CStudent stu = model.devmanager.GetStudent(devnum, i);
                if (stu != null)
                {
                    DisplayStrings.DeleteString(stu.DisplayString(devnum));
                }
            }
            //displaycomm.ShowText(DisplayStrings.GetAllStrings());
            mainform.ReUpdateStuColor(devnum);
            mainform.ChangeDevStatus(devnum, DevStatus.未连接);
        }

        private void Server_Event_Devnetdata(CNetData data)
        {
            CNetData tmpdata = new CNetData();
            switch (data.cmdCommand)
            {
                case Command.GetStudent:
                    
                    CStudent stu = model.devmanager.GetStudent(data.intDevnum);
                    if (stu != null)
                    {
                        tmpdata.Clear();
                        tmpdata.cmdCommand = Command.Zkzhm;
                        tmpdata.strZjbh = stu.zkzmbh;
                        Server.SendData(data.intDevnum, tmpdata);
                        mainform.ChangeDevStatus(data.intDevnum, DevStatus.身份验证);
                        mainform.UpdateStuColor(data.intDevnum);
                        if (DisplayStrings.GetValue(stu.DisplayString(data.intDevnum)) == null)
                            DisplayStrings.AddString(stu.DisplayString(data.intDevnum), "考试");
                        else
                            DisplayStrings.UpdateString(stu.DisplayString(data.intDevnum), "考试");
                        CVoice.Play(stu.DisplayString(data.intDevnum) + "考试。");
                        CStudent stu2 = model.devmanager.GetStudent(data.intDevnum, 1);
                        if (stu2 != null)
                        {
                            DisplayStrings.AddString(stu2.DisplayString(data.intDevnum), "排队");
                            //CVoice.Play(stu2.DisplayString(data.intDevnum) + "排队。");
                        }
                        //displaycomm.ShowText(DisplayStrings.GetAllStrings());
                    }
                    break;
                case Command.Ksks:
                    if (mainform.GetDeviceStatus(data.intDevnum) != DevStatus.正在考试)
                    {
                        mainform.ChangeDevStatus(data.intDevnum, DevStatus.正在考试);
                        //把设备列表中第一个考生显示颜色改为红色，表示正在考试
                        mainform.UpdateStuColor(data.intDevnum);
                        CStudent stu1 = model.devmanager.GetStudent(data.intDevnum, 0);
                        if (stu1 != null)
                            DisplayStrings.DeleteString(stu1.DisplayString(data.intDevnum));
                        CStudent stu2and3;
                        for (int i = 1; i < 3; i++)
                        {
                            stu2and3 = model.devmanager.GetStudent(data.intDevnum, i);
                            if (stu2and3 != null)
                                DisplayStrings.AddString(stu2and3.DisplayString(data.intDevnum), "排队");
                            else
                                break;
                        }
                        //displaycomm.ShowText(DisplayStrings.GetAllStrings());
                    }
                    break;
                case Command.Kswc:
                    mainform.ChangeDevStatus(data.intDevnum, DevStatus.设备就绪);
                    mainform.ReUpdateStuColor(data.intDevnum);
                    //把设备列表中第一个考生删除掉
                    mainform.DeleteFirstStudent(data.intDevnum);
                    tmpdata.Clear();
                    tmpdata.cmdCommand = Command.DeleteStudent;
                    tmpdata.intDevnum = data.intDevnum;
                    tmpdata.strZjbh = data.strZjbh;
                    Server.SendData(data.intDevnum, tmpdata);
                    break;
                case Command.Jjks:
                    System.Windows.Forms.MessageBox.Show("考生" + ((CStudent)(model.devmanager.GetStudent(data.intDevnum))).zkzmbh + "被" + data.intDevnum.ToString() + "号考库拒绝！");
                    mainform.ReUpdateStuColor(data.intDevnum);
                    CStudent stu3 = model.devmanager.GetStudent(data.intDevnum, 0);
                    if (stu3 != null)
                        DisplayStrings.UpdateString(stu3.DisplayString(data.intDevnum), "排队");
                    //displaycomm.ShowText(DisplayStrings.GetAllStrings());
                    mainform.ChangeDevStatus(data.intDevnum, DevStatus.设备就绪);
                    ////把设备列表中第一个考生删除掉
                    //mainform.DeleteFirstStudent(data.intDevnum);
                    ////删除对应的远端设备列表中的排队考生
                    //tmpdata.Clear();
                    //tmpdata.cmdCommand = Command.DeleteStudent;
                    //tmpdata.intDevnum = data.intDevnum;
                    //tmpdata.strZjbh = data.strZjbh;
                    //Server.SendData(data.intDevnum, tmpdata);
                    break;
                case Command.Updatelist:
                    //同步更新远程设备排队考生列表
                    UpdateRemoteListview(data.intDevnum);
                    break;
            }
        }
     #endregion 网络事件处理结束

        private void UpdateRemoteListview(int devnum)
        {
            CNetData tmpdata = new CNetData();
            //发送清除列表命令
            tmpdata.cmdCommand = Command.ClearStudent;
            tmpdata.intDevnum = devnum;
            Server.SendData(devnum, tmpdata);
            tmpdata.Clear();
            System.Threading.Thread.Sleep(5);

            for (int i = 0; i < ((CStuDevlist)model.devmanager.DevList[devnum]).StudentList.Count; i++)
            {
                tmpdata.cmdCommand = Command.AddStudent;
                tmpdata.strZjbh = ((CStudent)((CStuDevlist)model.devmanager.DevList[devnum]).StudentList[i]).zkzmbh;
                tmpdata.Xm = ((CStudent)((CStuDevlist)model.devmanager.DevList[devnum]).StudentList[i]).xm;
                tmpdata.intDevnum = devnum;
                Server.SendData(devnum, tmpdata);
                tmpdata.Clear();
                System.Threading.Thread.Sleep(20);
            }
        }


        public void model_Event_ORACLELink(bool islink)
        {
            mainform.OracleStatusChange(islink);
        }

        //对应菜单项清除所有考生事件处理
        public void Menu_clear(int devnum)
        {
            for (int i = 0; i < ((CStuDevlist)(model.devmanager.DevList[devnum])).Stumum; i++)
            {
                CStudent stu = model.devmanager.GetStudent(devnum, i);
                if (stu != null)
                {
                    DisplayStrings.DeleteString(stu.DisplayString(devnum));
                }
            }
            //displaycomm.ShowText(DisplayStrings.GetAllStrings());
            model.devmanager.ClearStudent(devnum);
            mainform.UpdateStudentlist(devnum, (CStuDevlist)model.devmanager.DevList[devnum]);
            //清除对应的远端设备列表中的排队考生
            CNetData tmpdata = new CNetData();
            tmpdata.cmdCommand = Command.ClearStudent;
            tmpdata.intDevnum = devnum;
            Server.SendData(devnum, tmpdata);
        }

        //对应菜单项删除考生事件处理
        public void Menu_del(int devnum, string zkzhm)
        {
            CStudent stu = model.devmanager.GetStudent(devnum, zkzhm);
            if (stu != null)
                DisplayStrings.DeleteString(stu.DisplayString(devnum));
            model.devmanager.DeleteStudent(devnum, zkzhm);
            mainform.UpdateStudentlist(devnum, (CStuDevlist)model.devmanager.DevList[devnum]);
            CStudent stu2and3;
            for (int i = 1; i < 3; i++)
            {
                stu2and3 = model.devmanager.GetStudent(devnum, i);
                if (stu2and3 != null)
                    DisplayStrings.AddString(stu2and3.DisplayString(devnum), "排队");
                else
                    break;
            }
            //displaycomm.ShowText(DisplayStrings.GetAllStrings());
           
            //删除对应的远端设备列表中的排队考生
            CNetData tmpdata = new CNetData();
            tmpdata.cmdCommand = Command.DeleteStudent;
            tmpdata.intDevnum = devnum;
            tmpdata.strZjbh = zkzhm;
            Server.SendData(devnum, tmpdata);
        }
    }
}

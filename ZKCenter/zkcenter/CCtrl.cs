//******************************************
//      Main_Form����Ŀ�����
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
            //displaycomm.ShowText("��ӭ������ɼ�У����!");
            mainform = new Main_Form(this,this.model);
            Application.Run(mainform);
           // model.RemoteDBlink();
        }

     #region �����¼�����
        private void Server_Event_Devlogin(int devnum)
        {
            mainform.ChangeDevStatus(devnum, DevStatus.�豸����);
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
            mainform.ChangeDevStatus(devnum, DevStatus.δ����);
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
                        mainform.ChangeDevStatus(data.intDevnum, DevStatus.�����֤);
                        mainform.UpdateStuColor(data.intDevnum);
                        if (DisplayStrings.GetValue(stu.DisplayString(data.intDevnum)) == null)
                            DisplayStrings.AddString(stu.DisplayString(data.intDevnum), "����");
                        else
                            DisplayStrings.UpdateString(stu.DisplayString(data.intDevnum), "����");
                        CVoice.Play(stu.DisplayString(data.intDevnum) + "���ԡ�");
                        CStudent stu2 = model.devmanager.GetStudent(data.intDevnum, 1);
                        if (stu2 != null)
                        {
                            DisplayStrings.AddString(stu2.DisplayString(data.intDevnum), "�Ŷ�");
                            //CVoice.Play(stu2.DisplayString(data.intDevnum) + "�Ŷӡ�");
                        }
                        //displaycomm.ShowText(DisplayStrings.GetAllStrings());
                    }
                    break;
                case Command.Ksks:
                    if (mainform.GetDeviceStatus(data.intDevnum) != DevStatus.���ڿ���)
                    {
                        mainform.ChangeDevStatus(data.intDevnum, DevStatus.���ڿ���);
                        //���豸�б��е�һ��������ʾ��ɫ��Ϊ��ɫ����ʾ���ڿ���
                        mainform.UpdateStuColor(data.intDevnum);
                        CStudent stu1 = model.devmanager.GetStudent(data.intDevnum, 0);
                        if (stu1 != null)
                            DisplayStrings.DeleteString(stu1.DisplayString(data.intDevnum));
                        CStudent stu2and3;
                        for (int i = 1; i < 3; i++)
                        {
                            stu2and3 = model.devmanager.GetStudent(data.intDevnum, i);
                            if (stu2and3 != null)
                                DisplayStrings.AddString(stu2and3.DisplayString(data.intDevnum), "�Ŷ�");
                            else
                                break;
                        }
                        //displaycomm.ShowText(DisplayStrings.GetAllStrings());
                    }
                    break;
                case Command.Kswc:
                    mainform.ChangeDevStatus(data.intDevnum, DevStatus.�豸����);
                    mainform.ReUpdateStuColor(data.intDevnum);
                    //���豸�б��е�һ������ɾ����
                    mainform.DeleteFirstStudent(data.intDevnum);
                    tmpdata.Clear();
                    tmpdata.cmdCommand = Command.DeleteStudent;
                    tmpdata.intDevnum = data.intDevnum;
                    tmpdata.strZjbh = data.strZjbh;
                    Server.SendData(data.intDevnum, tmpdata);
                    break;
                case Command.Jjks:
                    System.Windows.Forms.MessageBox.Show("����" + ((CStudent)(model.devmanager.GetStudent(data.intDevnum))).zkzmbh + "��" + data.intDevnum.ToString() + "�ſ���ܾ���");
                    mainform.ReUpdateStuColor(data.intDevnum);
                    CStudent stu3 = model.devmanager.GetStudent(data.intDevnum, 0);
                    if (stu3 != null)
                        DisplayStrings.UpdateString(stu3.DisplayString(data.intDevnum), "�Ŷ�");
                    //displaycomm.ShowText(DisplayStrings.GetAllStrings());
                    mainform.ChangeDevStatus(data.intDevnum, DevStatus.�豸����);
                    ////���豸�б��е�һ������ɾ����
                    //mainform.DeleteFirstStudent(data.intDevnum);
                    ////ɾ����Ӧ��Զ���豸�б��е��Ŷӿ���
                    //tmpdata.Clear();
                    //tmpdata.cmdCommand = Command.DeleteStudent;
                    //tmpdata.intDevnum = data.intDevnum;
                    //tmpdata.strZjbh = data.strZjbh;
                    //Server.SendData(data.intDevnum, tmpdata);
                    break;
                case Command.Updatelist:
                    //ͬ������Զ���豸�Ŷӿ����б�
                    UpdateRemoteListview(data.intDevnum);
                    break;
            }
        }
     #endregion �����¼��������

        private void UpdateRemoteListview(int devnum)
        {
            CNetData tmpdata = new CNetData();
            //��������б�����
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

        //��Ӧ�˵���������п����¼�����
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
            //�����Ӧ��Զ���豸�б��е��Ŷӿ���
            CNetData tmpdata = new CNetData();
            tmpdata.cmdCommand = Command.ClearStudent;
            tmpdata.intDevnum = devnum;
            Server.SendData(devnum, tmpdata);
        }

        //��Ӧ�˵���ɾ�������¼�����
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
                    DisplayStrings.AddString(stu2and3.DisplayString(devnum), "�Ŷ�");
                else
                    break;
            }
            //displaycomm.ShowText(DisplayStrings.GetAllStrings());
           
            //ɾ����Ӧ��Զ���豸�б��е��Ŷӿ���
            CNetData tmpdata = new CNetData();
            tmpdata.cmdCommand = Command.DeleteStudent;
            tmpdata.intDevnum = devnum;
            tmpdata.strZjbh = zkzhm;
            Server.SendData(devnum, tmpdata);
        }
    }
}

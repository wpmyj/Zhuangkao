using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace zkcenter
{
    public partial class Main_Form : Form
    {
        CCtrl ctrl;
        CModel model;
        CStudent Inputstudent;

        CDevListview[] devlist;
        CViewManage ViewManage;
        public Main_Form(CCtrl ctrl,CModel model)
        {
           
            InitializeComponent();
            this.ctrl = ctrl;
            this.model = model;
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Init();
            model.RemoteDBlink();
            model.LocalDBlink();
     
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            //devlist.SetLocation(300, 300);
        }

        public bool ChangeDevStatus(int devnum,DevStatus devstatus)
        {
           return  ViewManage.ChangeDevStatus(devnum, devstatus);
        }
       

    #region ��ʼ������
        private void Init()
        {
            string[] tmpstr =  model.settings.DevOrder.ToString().Split(',');
            //model.DevNumber = tmpstr.Length;
            ViewManage = new CViewManage(panelDockContainer2);
            //bar1.Text = "��ϵ�绰��13849176996";
            pictureBox1.Top = 585;//logoͼ��λ��
            devlist = new CDevListview[model.DevNumber];
            pictureBox2.ImageLocation = ".\\img\\photonull.bmp";
            pictureBox3.ImageLocation = ".\\img\\photonull.bmp";
            for (int i = 0; i <model.DevNumber;i++ )
            {
                devlist[i] = new CDevListview(panelDockContainer2,Convert.ToInt16(tmpstr[i]));
                ViewManage.AddControl(devlist[i]);
                comboBox1.Items.Add(tmpstr[i]);
                devlist[i].Menu_clear +=new CDevListview.MenuEventHandler(Main_Form_Menu_clear);
                devlist[i].Menu_del+=new CDevListview.MenuEventHandler(Main_Form_Menu_del);
                devlist[i].Menu_showstu+=new CDevListview.MenuEventHandler(Main_Form_Menu_showstu);
            }
            ViewManage.AutoMove();//�Զ������豸LISTVIEW
            if ((devlist[model.DevNumber - 1].Left + devlist[model.DevNumber - 1].Width + groupPanel_gridview.Width) < panelDockContainer2.Width)
            {
                groupPanel_gridview.Left = devlist[model.DevNumber - 1].Left + devlist[model.DevNumber - 1].Width + 3;
                groupPanel_gridview.Top = devlist[model.DevNumber - 1].Top;
                groupPanel_gridview.Height = devlist[model.DevNumber - 1].Height;
                groupPanel_gridview.Width = devlist[model.DevNumber - 1].Width * 2;
            }
            else
            {
                groupPanel_gridview.Left = 3;
                groupPanel_gridview.Top = devlist[model.DevNumber - 1].Top + devlist[model.DevNumber - 1].Height + 5;
                groupPanel_gridview.Height = devlist[model.DevNumber - 1].Height;
                groupPanel_gridview.Width = devlist[model.DevNumber - 1].Width * 2;
            }
            OracleLinkStatus.ImageLocation = "img/red2.gif";
            comboBox1.Text = model.devmanager.GetMinnum().ToString();
            buttonX1.Enabled = false;

        }
        private void initlabel()
        {
            label_xm.Text = "������";
            label_lsh.Text = "��ˮ�ţ�" ;
            label_zkzhm.Text = "׼��֤��" ;
            label_sfzhm.Text = "���֤��" ;
            label_kscx.Text = "���Գ��ͣ�" ;
            label_kscs.Text = "���Դ�����";
            textBoxX1.Text = string.Empty;
        }
 #endregion ��ʼ���������

    #region �˵��¼�����

        private void Main_Form_Menu_clear(int devnum, string zkzhm)
        {
           //������п����¼�����
            DialogResult result = MessageBox.Show(this, "ȷ����տ����б�", "ȷ��", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                ctrl.Menu_clear(devnum);
        }

        private void Main_Form_Menu_del(int devnum, string zkzhm)
        {
            //ɾ�������¼�����
            DialogResult result = MessageBox.Show(this, "ȷ�ϴ��б���ɾ��������", "ȷ��", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                ctrl.Menu_del(devnum, zkzhm);
        }

        private void Main_Form_Menu_showstu(int devnum, string zkzhm)
        {
            //��ʾ������ϸ��Ϣ����
            ShowStudentInfo_Form showstufm = new ShowStudentInfo_Form(model.devmanager.GetStudent(devnum, zkzhm));
            showstufm.ShowDialog();
        }


    #endregion �˵��¼��������



        private void bar1_PopupOpen(object sender, DevComponents.DotNetBar.PopupOpenEventArgs e)
        {
            bar1.Text = "��ϵ�绰��13849176996";
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            int redevnum = model.devmanager.FindStudent(Inputstudent.zkzmbh);

            if (redevnum > 0)
            {
                MessageBox.Show("������" + Inputstudent.xm + "���Ѿ����豸" + redevnum.ToString() + "���Ŷ��ˣ�");
                initlabel();
                Inputstudent = null;
                buttonX1.Enabled = false;
                comboBox1.Text = model.devmanager.GetMinnum().ToString();
                return;
            }

   
            //��devmanager�豸�б����ӿ���
            ((CStuDevlist)model.devmanager.DevList[int.Parse(comboBox1.Text)]).AddStudent(Inputstudent);
            ViewManage.UpdateStudentlist(int.Parse(comboBox1.Text), ((CStuDevlist)model.devmanager.DevList[int.Parse(comboBox1.Text)]));
            model.SaveStudent(Inputstudent);

            //************************************
            CNetData tmpdata = new CNetData();
            tmpdata.cmdCommand = Command.AddStudent;
            tmpdata.intDevnum = int.Parse(comboBox1.Text);
            tmpdata.strZjbh = Inputstudent.zkzmbh;
            tmpdata.Xm = Inputstudent.xm;
            ctrl.Server.SendData(int.Parse(comboBox1.Text), tmpdata);
            //************************************

            initlabel();
            Inputstudent = null;
            buttonX1.Enabled = false;
            comboBox1.Text = model.devmanager.GetMinnum().ToString();
            textBoxX1.Focus();
                
        }

        public void UpdateStudentlist(int devnum, CStuDevlist stulist)
        {
            ViewManage.UpdateStudentlist(devnum, stulist);
        }

        public void UpdateStuColor(int devnum)
        {
            ViewManage.UpdateStuColor(devnum);
        }

        public void ReUpdateStuColor(int devnum)
        {
            ViewManage.ReUpdateStuColor(devnum);
        }

        public void DeleteFirstStudent(int devnum)
        {
            model.devmanager.DeleteFirstStudent(devnum);
            ViewManage.UpdateStudentlist(devnum,((CStuDevlist)model.devmanager.DevList[devnum]));

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            initlabel();
            Inputstudent = null;
            buttonX1.Enabled = false;
            comboBox1.Text = model.devmanager.GetMinnum().ToString();

        }

         public void OracleStatusChange(bool islink)
        {
            if (islink)
            {
                OracleLinkStatus.ImageLocation = "img/green2.gif";
            }
            else
            {
                OracleLinkStatus.ImageLocation = "img/red2.gif";
            }
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Inputstudent = null;
                if(textBoxX1.Text!=string.Empty)
                {
                   Inputstudent = model.FindStudent(textBoxX1.Text);
                   if (Inputstudent != null)
                   {
                       label_xm.Text = "������" + Inputstudent.xm;
                       label_lsh.Text = "��ˮ�ţ�" + Inputstudent.lsh;
                       label_zkzhm.Text = "׼��֤��" + Inputstudent.zkzmbh;
                       label_sfzhm.Text = "���֤��" + Inputstudent.sfzmhm;
                       label_kscx.Text = "���Գ��ͣ�" + Inputstudent.kscx;
                       label_kscs.Text = "���Դ�����" + Inputstudent.kscs.ToString();
                       buttonX1.Enabled = true;
                       buttonX1.Focus();
                   }
                }
            }
        }

        public DevStatus GetDeviceStatus(int devnum)
        {
            foreach (CDevListview devview in devlist)
            {
                if (devview.IntDevnum == devnum)
                    return devview.Status;
            }
            return DevStatus.δ����;
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (CDevListview devview in devlist)
            {
                if (devview.Status == DevStatus.�����֤ || devview.Status == DevStatus.���ڿ���)
                {
                    MessageBox.Show("���豸���ڿ��ԣ����ܹرտ������ġ�");
                    e.Cancel = true;
                    return;
                }
            }
        }
     }
}
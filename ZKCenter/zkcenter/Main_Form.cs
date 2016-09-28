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
       

    #region 初始化窗体
        private void Init()
        {
            string[] tmpstr =  model.settings.DevOrder.ToString().Split(',');
            //model.DevNumber = tmpstr.Length;
            ViewManage = new CViewManage(panelDockContainer2);
            //bar1.Text = "联系电话：13849176996";
            pictureBox1.Top = 585;//logo图标位置
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
            ViewManage.AutoMove();//自动排列设备LISTVIEW
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
            label_xm.Text = "姓名：";
            label_lsh.Text = "流水号：" ;
            label_zkzhm.Text = "准考证：" ;
            label_sfzhm.Text = "身份证：" ;
            label_kscx.Text = "考试车型：" ;
            label_kscs.Text = "考试次数：";
            textBoxX1.Text = string.Empty;
        }
 #endregion 初始化窗体结束

    #region 菜单事件处理

        private void Main_Form_Menu_clear(int devnum, string zkzhm)
        {
           //清除所有考生事件处理
            DialogResult result = MessageBox.Show(this, "确认清空考生列表？", "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                ctrl.Menu_clear(devnum);
        }

        private void Main_Form_Menu_del(int devnum, string zkzhm)
        {
            //删除考生事件处理
            DialogResult result = MessageBox.Show(this, "确认从列表中删除考生？", "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                ctrl.Menu_del(devnum, zkzhm);
        }

        private void Main_Form_Menu_showstu(int devnum, string zkzhm)
        {
            //显示考生详细信息处理
            ShowStudentInfo_Form showstufm = new ShowStudentInfo_Form(model.devmanager.GetStudent(devnum, zkzhm));
            showstufm.ShowDialog();
        }


    #endregion 菜单事件处理结束



        private void bar1_PopupOpen(object sender, DevComponents.DotNetBar.PopupOpenEventArgs e)
        {
            bar1.Text = "联系电话：13849176996";
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            int redevnum = model.devmanager.FindStudent(Inputstudent.zkzmbh);

            if (redevnum > 0)
            {
                MessageBox.Show("考生（" + Inputstudent.xm + "）已经在设备" + redevnum.ToString() + "中排队了！");
                initlabel();
                Inputstudent = null;
                buttonX1.Enabled = false;
                comboBox1.Text = model.devmanager.GetMinnum().ToString();
                return;
            }

   
            //给devmanager设备列表增加考生
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
                       label_xm.Text = "姓名：" + Inputstudent.xm;
                       label_lsh.Text = "流水号：" + Inputstudent.lsh;
                       label_zkzhm.Text = "准考证：" + Inputstudent.zkzmbh;
                       label_sfzhm.Text = "身份证：" + Inputstudent.sfzmhm;
                       label_kscx.Text = "考试车型：" + Inputstudent.kscx;
                       label_kscs.Text = "考试次数：" + Inputstudent.kscs.ToString();
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
            return DevStatus.未连接;
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (CDevListview devview in devlist)
            {
                if (devview.Status == DevStatus.身份验证 || devview.Status == DevStatus.正在考试)
                {
                    MessageBox.Show("有设备正在考试，不能关闭考试中心。");
                    e.Cancel = true;
                    return;
                }
            }
        }
     }
}
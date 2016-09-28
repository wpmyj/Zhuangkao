using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public partial class Main_Form : Form
    {
        ModuleSettings settings;
        private Displaycomm.CDisplaycomm displaycomm;

        public Main_Form()
        {
            InitializeComponent();
            settings = ModuleConfig.GetSettings();
            sideBarPanelItem2.Visible = false;
            sideBarPanelItem2.Visible = false;
            sideBarPanelItem3.Visible = false;
            sideBarPanelItem5.Visible = false;
            sideBarPanelItem6.Visible = false;
            sideBarPanelItem7.Visible = false;
            switch (CMyGlobal.G_UserClass)
            {
                case 0:
                    if (CMyGlobal.G_IsConfig)
                    {
                        sideBarPanelItem5.Visible = true;
                        sideBarPanelItem6.Visible = true;
                        sideBarPanelItem7.Visible = true;
                    }
                    else
                    {
                        sideBarPanelItem2.Visible = true;
                        sideBarPanelItem3.Visible = true;
                    }
                    break;
                case 1:
                    if (CMyGlobal.G_IsConfig)
                    {
                        sideBarPanelItem5.Visible = true;
                        sideBarPanelItem6.Visible = true;
                    }
                    else
                    {
                        sideBarPanelItem2.Visible = true;
                    }
                    break;
                case 2:
                    if (CMyGlobal.G_IsConfig)
                    {
                        sideBarPanelItem5.Visible = true;
                        sideBarPanelItem6.Visible = true;
                    }
                    else
                    {
                        sideBarPanelItem3.Visible = true;
                    }
                    break;
                case 3:
                    if (CMyGlobal.G_IsConfig)
                    {
                        sideBarPanelItem5.Visible = true;
                        sideBarPanelItem6.Visible = true;
                        buttonItem9.Visible=false;
                        buttonItem17.Visible=false;
                        buttonItem18.Visible=false;
                        buttonItem19.Visible = false;         
                    }
                    else
                    {
                        sideBarPanelItem3.Visible = true;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initDisplay();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            MonForm monf = new MonForm();
            monf.ShowDialog();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            CarSignalForm csf = new CarSignalForm();
            csf.ShowDialog();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            displaycomm.Close();
            ExamForm examform1 = new ExamForm(0, true);
            examform1.ShowDialog();
            examform1.Dispose();
            initDisplay();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            Xhpb_Form_s xhpb = new Xhpb_Form_s();
            xhpb.ShowDialog();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            AdminXhpb_s_Form adminxhpbs = new AdminXhpb_s_Form();
            adminxhpbs.ShowDialog();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            AdminXhpb_l_Form adminxhpbl = new AdminXhpb_l_Form();
            adminxhpbl.ShowDialog();
        }

              
        private void buttonItem13_Click(object sender, EventArgs e)
        {
            AdminXhqf_s_Form qfforms = new AdminXhqf_s_Form();
            qfforms.ShowDialog();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            displaycomm.Close();
            ExamForm examform1 = new ExamForm(1,true);
            examform1.ShowDialog();
            examform1.Dispose();
            initDisplay();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            Setting_Form setform = new Setting_Form();
            setform.ShowDialog();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            AdminXhqf_l_Form qfforml = new AdminXhqf_l_Form();
            qfforml.ShowDialog();
        }

       
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            displaycomm.Close();
            ExamForm examform1 = new ExamForm(0, false);
            examform1.ShowDialog();
            examform1.Dispose();
            initDisplay();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            displaycomm.Close();
            ExamForm examform1 = new ExamForm(1, false);
            examform1.ShowDialog();
            examform1.Dispose();
            initDisplay();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            //大车信号屏蔽
            Xhpb_Form_l xhpb_l = new Xhpb_Form_l();
            xhpb_l.ShowDialog();
        }


        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Gsjj_Form gsjj = new Gsjj_Form();
            gsjj.ShowDialog();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            SetPrint_Form setprint = new SetPrint_Form(settings);
            setprint.ShowDialog();
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            SetUser_Form setuser = new SetUser_Form(settings);
            setuser.ShowDialog();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            ChangePasswd_Form changepasswd = new ChangePasswd_Form();
            changepasswd.ShowDialog();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            Sound_Test_Form soundTestForm = new Sound_Test_Form();
            soundTestForm.ShowDialog();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            displaycomm.Close();
        }

        private void initDisplay()
        {
            displaycomm = new zhuangkao.Displaycomm.CDisplaycomm(settings);
            //displaycomm.Setdisplaytype = Displaycomm.DisplayType.Zhidisp;
            //displaycomm.ShowText("        ");
            displaycomm.Setdisplaytype = Displaycomm.DisplayType.Gundisp;
            //displaycomm.ShowText("欢迎成都车管所领导指导工作！");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lukao
{
    public partial class Menu_Form : Form
    {
        //public CModel model;
        //public CController ctrl;
        public ModuleSettings settings;
        string dq_sfzhm;


        public Menu_Form(int userclass,string dq_sfzhm)
        {
            InitializeComponent();
            settings = new ModuleSettings();
            settings = ModuleConfig.GetSettings();
            if (userclass > 0)
            {
                button1.Visible = false;
                button4.Visible = false; 
            }
            this.dq_sfzhm = dq_sfzhm;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetKsy_Form ksyform = new SetKsy_Form(settings);
            ksyform.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetKsxmForm ksxmform = new SetKsxmForm(settings);
            ksxmform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetPrint_Form printfm = new SetPrint_Form(settings);
            printfm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Setting_Form setform = new Setting_Form();
            setform.ShowDialog();
        }

        private void Menu_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetUserForm setuserfm = new SetUserForm();
            setuserfm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangePassword_Form cpf = new ChangePassword_Form(dq_sfzhm,settings.Ipaddress);
            cpf.ShowDialog();
        }
    }
}
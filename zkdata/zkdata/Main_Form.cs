using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zkdata
{
    public partial class Main_Form : Form
    {
        private Incept_Form inceptform;
        private Send_Form sendform;
        public Main_Form()
        {
            InitializeComponent();

            CIncept_Model inceptmodel = new CIncept_Model();
            inceptform = new Incept_Form(inceptmodel);
            inceptform.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(inceptform);
            inceptform.Dock = DockStyle.Fill;
            inceptform.Show();

            sendform = new Send_Form();
            sendform.MdiParent = this;
            splitContainer1.Panel2.Controls.Add(sendform);
            sendform.Dock = DockStyle.Fill;
            sendform.Show();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
           sendform.SendToBack();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            inceptform.SendToBack();
        }


        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Setting_Form setform = new Setting_Form();
            setform.ShowDialog();
        }
    }
}
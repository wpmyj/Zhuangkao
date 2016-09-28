using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lukao
{
    public partial class SetKsy_Form : Form
    {
        public ModuleSettings settings;

        public SetKsy_Form(ModuleSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
            string[] tmpstr = settings.Ksy.Split(',');
            for (int i = 0; i < tmpstr.Length; i++)
            {
                listBox1.Items.Add(tmpstr[i]);
            }
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tmpstr = listBox1.Items[0].ToString();
            for (int i = 1; i < listBox1.Items.Count; i++)
            {
                tmpstr = tmpstr + ","+listBox1.Items[i].ToString();
            }
            settings.Ksy = tmpstr;
            ModuleConfig.SaveSettings(settings);
        }


    }
}
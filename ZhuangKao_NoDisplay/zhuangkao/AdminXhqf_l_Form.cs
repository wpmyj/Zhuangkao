using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public partial class AdminXhqf_l_Form : Form
    {
        private ModuleSettings ms;
        private CheckBox[] gan;
        private CheckBox[] xian;

        public AdminXhqf_l_Form()
        {
            InitializeComponent();
            ms = ModuleConfig.GetSettings();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuleConfig.SaveSettings(ms);
        }

        private void Xhqf_Form_Load(object sender, EventArgs e)
        {
            gan = new CheckBox[9];
            xian = new CheckBox[9];

            for (int i = 0; i < 9; i++)
            {
                
                gan[i] = new CheckBox();
                groupBox1.Controls.Add(this.gan[i]);
                gan[i].AutoSize = true;
                gan[i].Location = new System.Drawing.Point(43+i*50, 38);
                gan[i].Text = Convert.ToString(i + 1);// "£±";
                gan[i].Size = new System.Drawing.Size(36, 16);
                gan[i].UseVisualStyleBackColor = true;
                gan[i].Click += new System.EventHandler(this.Gan_Click);
                if (((ms.AdminQFGan_l >> i) & 1) == 1)
                {
                    gan[i].Checked = true;
                }

                xian[i] = new CheckBox();
                groupBox2.Controls.Add(this.xian[i]);
                xian[i].AutoSize = true;
                xian[i].Location = new System.Drawing.Point(43 + i * 50, 38);
                xian[i].Text = Convert.ToString(i + 1);// "£±";
                xian[i].Size = new System.Drawing.Size(36, 16);
                xian[i].UseVisualStyleBackColor = true;
                xian[i].Click += new System.EventHandler(this.Xian_Click);
                if (((ms.AdminQFXian_l >> i) & 1) == 1)
                {
                    xian[i].Checked = true;
                }

            }
           // xian[1].Enabled = false;
           // xian[3].Enabled = false;
    
        }


   

        private void Gan_Click(object sender, EventArgs e)
        {
            byte tmpi;
            tmpi=Convert.ToByte(((CheckBox)sender).Text);
            if (((CheckBox)sender).Checked)
            {
                ms.AdminQFGan_l  = Set1(ms.AdminQFGan_l, tmpi);
            }
            else
            {
                ms.AdminQFGan_l = Set0(ms.AdminQFGan_l, tmpi);
            }
        }

        private void Xian_Click(object sender, EventArgs e)
        {
            byte tmpi;
            tmpi = Convert.ToByte(((CheckBox)sender).Text);
            if (((CheckBox)sender).Checked)
            {
                ms.AdminQFXian_l = Set1(ms.AdminQFXian_l, tmpi);
            }
            else
            {
                ms.AdminQFXian_l = Set0(ms.AdminQFXian_l, tmpi);
            }
        }


        private int Set1(int indata, int weizhi)
        {
            int tmp = 1;
            if ((weizhi < 0) || weizhi > 9)
            {
                return indata;
            }
            tmp = (tmp << (weizhi-1));
             return ((int)tmp | (int)indata);

        }

        private int Set0(int indata, int weizhi)
        {
            int tmp = 1;
            if ((weizhi < 0) || weizhi > 9)
            {
                return indata;
            }
            tmp = (tmp << (weizhi - 1));
            return ((int)~tmp & (int)indata);

        }
     
    }
}
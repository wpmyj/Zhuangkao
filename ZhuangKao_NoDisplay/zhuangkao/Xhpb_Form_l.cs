using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public partial class Xhpb_Form_l : Form
    {
        private ModuleSettings ms;
        private CheckBox[] gan;
        private CheckBox[] xian;
        private CheckBox[] che;
        public Xhpb_Form_l()
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

        private void Xhpb_Form_Load(object sender, EventArgs e)
        {
            gan = new CheckBox[9];
            xian = new CheckBox[9];
            che = new CheckBox[4];
            for (int i = 0; i < 9; i++)
            {

                gan[i] = new CheckBox();
                groupBox1.Controls.Add(this.gan[i]);
                gan[i].AutoSize = true;
                gan[i].Location = new System.Drawing.Point(43 + i * 50, 38);
                gan[i].Text = Convert.ToString(i + 1);// "１";
                gan[i].Size = new System.Drawing.Size(36, 16);
                gan[i].UseVisualStyleBackColor = true;
                gan[i].Click += new System.EventHandler(this.Gan_Click);
                if (((ms.PbGan_l >> i) & 1) == 1)
                {
                    gan[i].Checked = true;
                }

                xian[i] = new CheckBox();
                groupBox2.Controls.Add(this.xian[i]);
                xian[i].AutoSize = true;
                xian[i].Location = new System.Drawing.Point(43 + i * 50, 38);
                xian[i].Text = Convert.ToString(i + 1);// "１";
                xian[i].Size = new System.Drawing.Size(36, 16);
                xian[i].UseVisualStyleBackColor = true;
                xian[i].Click += new System.EventHandler(this.Xian_Click);
                if (((ms.PbXian_l >> i) & 1) == 1)
                {
                    xian[i].Checked = true;
                }

                if (i < 4)
                {
                    che[i] = new CheckBox();
                    groupBox3.Controls.Add(this.che[i]);
                    che[i].AutoSize = true;
                    che[i].Location = new System.Drawing.Point(43 + i * 80, 38);
                    che[i].Size = new System.Drawing.Size(36, 16);
                    che[i].UseVisualStyleBackColor = true;
                    che[i].Click += new System.EventHandler(this.Che_Click);
                    if (((ms.PbChe_l >> i) & 1) == 1)
                    {
                        che[i].Checked = true;
                    }
                }
            }
            xian[1].Enabled = false;
            xian[3].Enabled = false;
            che[0].Text = "前进";
            che[1].Text = "后退";
            che[2].Text = "停车";
            che[3].Text = "熄火";
        }


        private void Che_Click(object sender, EventArgs e)
        {

            string name = ((CheckBox)sender).Text;
            if (name == "前进")
            {
                if (((CheckBox)sender).Checked)
                {
                    ms.PbChe_l = Set1(ms.PbChe_l, 1);
                }
                else
                {
                    ms.PbChe_l = Set0(ms.PbChe_l, 1);
                }
            }
            if (name == "后退")
            {
                if (((CheckBox)sender).Checked)
                {
                    ms.PbChe_l = Set1(ms.PbChe_l, 2);
                }
                else
                {
                    ms.PbChe_l = Set0(ms.PbChe_l, 2);
                }
            }
            if (name == "停车")
            {
                if (((CheckBox)sender).Checked)
                {
                    ms.PbChe_l = Set1(ms.PbChe_l, 3);
                }
                else
                {
                    ms.PbChe_l = Set0(ms.PbChe_l, 3);
                }
            }
            if (name == "熄火")
            {
                if (((CheckBox)sender).Checked)
                {
                    ms.PbChe_l = Set1(ms.PbChe_l, 4);
                }
                else
                {
                    ms.PbChe_l = Set0(ms.PbChe_l, 4);
                }
            }


        }

        private void Gan_Click(object sender, EventArgs e)
        {
            byte tmpi;
            tmpi = Convert.ToByte(((CheckBox)sender).Text);
            if (((CheckBox)sender).Checked)
            {
                ms.PbGan_l = Set1(ms.PbGan_l, tmpi);
            }
            else
            {
                ms.PbGan_l = Set0(ms.PbGan_l, tmpi);
            }
        }

        private void Xian_Click(object sender, EventArgs e)
        {
            byte tmpi;
            tmpi = Convert.ToByte(((CheckBox)sender).Text);
            if (((CheckBox)sender).Checked)
            {
                ms.PbXian_l = Set1(ms.PbXian_l, tmpi);
            }
            else
            {
                ms.PbXian_l = Set0(ms.PbXian_l, tmpi);
            }
        }


        private int Set1(int indata, int weizhi)
        {
            int tmp = 1;
            if ((weizhi < 0) || weizhi > 9)
            {
                return indata;
            }
            tmp = (tmp << (weizhi - 1));
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.SetupModule
{
    public partial class GXShield : Form
    {
        string strDQFileName;//当前配置文件名
        string str2wheelconfigFilePath;
        string str3wheelconfigFilePath;
        Signal.MotorSignal.MotorSignalSettings settings2;
        Signal.MotorSignal.MotorSignalSettings settings3;
        Signal.MotorSignal.MotorSignalSettings settings;//当前settings对象


        private CheckBox[] gan;
        private CheckBox[] xian;
      

        public GXShield(Signal.MotorSignal.MotorSignalSettings set2, string str2, Signal.MotorSignal.MotorSignalSettings set3, string str3)
        {
            InitializeComponent();

            this.settings2 = set2;
            this.settings3 = set3;
            this.str2wheelconfigFilePath = str2;
            this.str3wheelconfigFilePath = str3;


            this.settings = settings2;
            this.strDQFileName = str2;
        }

        private void GXShield_Load(object sender, EventArgs e)
        {
           
                
            gan = new CheckBox[6];
            xian = new CheckBox[6];
           
            for (int i = 0; i < 6; i++)
            {

                gan[i] = new CheckBox();
                groupBox1.Controls.Add(this.gan[i]);
                gan[i].AutoSize = true;
                gan[i].Location = new System.Drawing.Point(43 + i * 50, 38);
                gan[i].Text = Convert.ToString(i + 1);
                gan[i].Size = new System.Drawing.Size(36, 16);
                gan[i].UseVisualStyleBackColor = true;
                gan[i].Click += new System.EventHandler(this.Gan_Click);
                if (((settings.SignConfig.PBGan >> i) & 1) == 1)
                {
                    gan[i].Checked = true;
                }

                xian[i] = new CheckBox();
                groupBox2.Controls.Add(this.xian[i]);
                xian[i].AutoSize = true;
                xian[i].Location = new System.Drawing.Point(43 + i * 50, 38);
                xian[i].Text = Convert.ToString(i + 1);
                xian[i].Size = new System.Drawing.Size(36, 16);
                xian[i].UseVisualStyleBackColor = true;
                xian[i].Click += new System.EventHandler(this.Xian_Click);
                if (((settings.SignConfig.PBXian>> i) & 1) == 1)
                {
                    xian[i].Checked = true;
                }

               
            }

            gan[5].Checked = true;
            xian[5].Checked = true;

            xian[0].Enabled = false;
            xian[2].Enabled = false;
            xian[4].Enabled = false;
            gan[5].Enabled = false;
            xian[5].Enabled = false;

         


            Bind(settings2, str2wheelconfigFilePath);
           
        }

       

        private void Gan_Click(object sender, EventArgs e)
        {
            byte tmpi;
            tmpi = Convert.ToByte(((CheckBox)sender).Text);
            if (((CheckBox)sender).Checked)
            {
                settings.SignConfig.PBGan = Set1(settings.SignConfig.PBGan, tmpi);
            }
            else
            {
                settings.SignConfig.PBGan = Set0(settings.SignConfig.PBGan, tmpi);
            }
        }

        private void Xian_Click(object sender, EventArgs e)
        {
            byte tmpi;
            tmpi = Convert.ToByte(((CheckBox)sender).Text);
            if (((CheckBox)sender).Checked)
            {
                settings.SignConfig.PBXian = Set1(settings.SignConfig.PBXian, tmpi);
            }
            else
            {
                settings.SignConfig.PBXian = Set0(settings.SignConfig.PBXian, tmpi);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Util.ModuleConfig.SaveSettings(settings, strDQFileName);
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            Bind(settings2, str2wheelconfigFilePath);
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            Bind(settings3, str3wheelconfigFilePath);
        }

        //绑定多选框
        private void Bind(Signal.MotorSignal.MotorSignalSettings set, string filename)
        {

            strDQFileName = filename;
            settings = set;

            for (int i = 0; i < 6; i++)
            {
                gan[i].Checked = false;
                xian[i].Checked = false;
            }


            for (int i = 0; i < 6; i++)
            {

             
                if (((settings.SignConfig.PBGan >> i) & 1) == 1)
                {
                    gan[i].Checked = true;
                }


                if (((settings.SignConfig.PBXian >> i) & 1) == 1)
                {
                    xian[i].Checked = true;
                }


            }
        }
      
 
        

    }
}
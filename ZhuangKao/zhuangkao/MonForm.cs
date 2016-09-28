using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace zhuangkao
{
    public partial class MonForm : Form,IMonObserve
    {
        private CDisplayManager CDM;
        private CGanFairy[] gan;
        private CLineFairy[] xian;
        private Bitmap[] ganbm;
        private CMonitor cm;
        private  delegate void InvokeDelegate();
        private InvokeDelegate myInvoke;
       // private int count=0;
        private Bitmap chebm1;
        private Bitmap chebm2;
        private Bitmap chebm;
        private bool alarm;//报警标志,在timer中控制报警
        private CMonData lookdata;

        public MonForm()
        {
            InitializeComponent();
        }

        private void Invokefun()
        {
            
            pictureBox1.Refresh();
          //  count++;
            //textBox1.Text = lookdata.xian[0].ToString() +
            //                lookdata.xian[1].ToString() +
            //                lookdata.xian[2].ToString() +
            //                lookdata.xian[3].ToString() +
            //                lookdata.xian[4].ToString() +
            //                lookdata.xian[5].ToString();

        }


        private void displayinit()
        {
            //-----------初始化线数据-----------------------------
            xian = new CLineFairy[9];

            xian[0] = new CLineFairy(210, 125, 210, 320);
            xian[0].LineName = "1";
            CDM.RegDisplay(xian[0]);


            xian[1] = new CLineFairy(299, 125, 299, 320);
            xian[1].LineName = "2";
            CDM.RegDisplay(xian[1]);

            xian[2] = new CLineFairy(388, 125, 388, 320);
            xian[2].LineName = "3";
            CDM.RegDisplay(xian[2]);

            xian[3] = new CLineFairy(20, 127, 558, 127);
            xian[3].LineName = "4";
            xian[3].Linex = xian[3].X1 - 20;
            xian[3].Liney = xian[3].Y1-7;
            CDM.RegDisplay(xian[3]);

            xian[4] = new CLineFairy(210, 309, 388, 309);
            xian[4].LineName = "5";
            xian[4].Linex = xian[4].X1 - 30;
            xian[4].Liney = xian[4].Y1 - 7;
            CDM.RegDisplay(xian[4]);

            xian[5] = new CLineFairy(20, 30, 558, 30);
            xian[5].LineName = "6";
            xian[5].Linex = xian[5].X1 - 20;
            xian[5].Liney = xian[5].Y1 - 7;
            CDM.RegDisplay(xian[5]);


            xian[6] = new CLineFairy(180, 157, 410, 157);
            xian[6].LineName = "7";
            xian[6].Linex = xian[6].X1 - 20;
            xian[6].Liney = xian[6].Y1 - 7;
            CDM.RegDisplay(xian[6]);

            xian[7] = new CLineFairy(180, 280, 410, 280);
            xian[7].LineName = "8";
            xian[7].Linex = xian[7].X1 - 20;
            xian[7].Liney = xian[7].Y1 - 7;
            CDM.RegDisplay(xian[7]);

            xian[8] = new CLineFairy(480, 145, 510, 10);
            xian[8].LineName = "9";
            xian[8].Linex = xian[8].X1 - 20;
            xian[8].Liney = xian[8].Y1 - 7;
            //CDM.RegDisplay(xian[8]);



            //-----------线数据初始化结束-----------------------------

            //-----------初始化杆数据-----------------------------
            ganbm = new Bitmap[3];
            ganbm[0] = new Bitmap(".\\img\\green2.gif");
            ganbm[1] = new Bitmap(".\\img\\red2.gif");
            ganbm[2] = new Bitmap(".\\img\\gray2.gif");
            for (int i = 0; i < 3; i++)
            {
                Color backcolor= ganbm[i].GetPixel(1, 1);
                ganbm[i].MakeTransparent(backcolor);
            }
            gan = new CGanFairy[6];
            for (int i = 0; i < 6; i++)
            {
                gan[i] = new CGanFairy(ganbm);
                CDM.RegDisplay(gan[i]);
                gan[i].GanName = Convert.ToString(i + 1);
            }
       
            gan[0].X = 200;
            gan[0].Y = 119;

            gan[1].X = 289;
            gan[1].Y = 119;

            gan[2].X = 378;
            gan[2].Y = 119;


            gan[3].X = 200;
            gan[3].Y = 301;

            gan[4].X = 289;
            gan[4].Y = 301;

            gan[5].X = 378;
            gan[5].Y = 301;
           
            //------杆数据初始化完成

        }

        private void DisplayRefresh()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i < 6)
                {
                    gan[i].Stat = 1;
                }
                xian[i].Stat = 1;
            }
        }

        public void Notify(CMonData mdata)
        {
            //string temstr;
            for (int i = 0; i < mdata.xinhaocount; i++)
            {
                if (i < 6)
                {
                    gan[i].Stat = mdata.gan[i];
                    lookdata.gan[i] = mdata.gan[i];
                }
                xian[i].Stat = mdata.xian[i];
                //tmp-----data
                lookdata.xian[i] = mdata.xian[i];
              }
              try
              {
                  pictureBox1.BeginInvoke(myInvoke);
              }
              catch
              {
              }
             for (int i = 0; i < mdata.xinhaocount; i++)
             {

                 if (i < 6)
                 {
                     if ((mdata.gan[i] == 0) || (mdata.xian[i] == 0))
                     {
                         alarm = true;
                         return;
                     }
                 }
                 else
                 {
                     if (mdata.xian[i] == 0)
                     {
                         alarm = true;
                         return;
                     }
                 }

             }
            alarm = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
          //  g.Clear(Color.Green);
            CDM.DisplayAll(g);
            g.DrawImage(chebm, 260, 55);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gan[1].Stat = 0;
            //pictureBox1.Refresh();
            cm.Start();
            timer1.Start();
            button1.Enabled = false;
            button1.Text= "正在检测";
            //cm.Shield(0, 3);
            //cm.Shield(1, 3);
        
        }

        private void MonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cm.Close();
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cm.Close();
            //timer1.Stop();
            this.Close();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cm.Che_Type = 0;
            chebm = chebm1;
            DisplayRefresh();
            radioButton3.Checked = true;
            alarm = false;
            pictureBox1.Refresh();
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cm.Che_Type = 1;
            chebm = chebm2;
            DisplayRefresh();
            radioButton3.Checked = true;
            alarm = false;
            pictureBox1.Refresh();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
            for (int i = 1; i <= 9; i++)
            {
               if(cm.IsShield(0,i) && (i<7))
               {
                   cm.UnShield(0, i);
               }
               if (cm.IsShield(1, i))
               {
                   cm.UnShield(1, i);
               }
            }
            pictureBox1.Refresh();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int tmptype = 0;
       

            if (radioButton5.Checked)
            {
                tmptype = 1;//线       
            }
            else
            {
                tmptype = 0;//杆
            }
            for (int i = 1; i <= 9; i++)
            {
                if (i < 7)
                {
                    cm.Shield(0, i);
                }
                cm.Shield(1, i);
            }
            cm.UnShield(tmptype, Convert.ToInt16(comboBox1.Text));
            pictureBox1.Refresh();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alarm)
            {
                //System.Console.Beep();
                CVoice.Playfile(Application.StartupPath +  "\\sound\\ding.wav");
            }
        }

        private void MonForm_Load(object sender, EventArgs e)
        {
            CDM = new CDisplayManager();
            displayinit();
            DisplayRefresh();
            cm = new CMonitor();
            cm.RegMonitor(this);
            myInvoke = new InvokeDelegate(Invokefun);
            chebm1 = new Bitmap(".\\img\\scar00.gif");
            chebm2 = new Bitmap(".\\img\\car00.gif");
            Color backcolor = chebm1.GetPixel(1, 1);
            chebm1.MakeTransparent(backcolor);
            backcolor = chebm2.GetPixel(1, 1);
            chebm2.MakeTransparent(backcolor);
            chebm = chebm2;
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            cm.Che_Type = 1;
            groupBox4.Enabled = false;
            radioButton3.Checked = true;
            radioButton4.Checked = false;
            radioButton5.Checked = true;
            radioButton6.Checked = false;
            alarm = true;
            //tmp数据
            lookdata = new CMonData();
        }

    }
}
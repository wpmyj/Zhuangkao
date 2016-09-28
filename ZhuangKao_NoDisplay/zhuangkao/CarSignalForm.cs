using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zhuangkao
{
    public partial class CarSignalForm : Form, IMonObserve
    {
        private CGanFairy qianjin;
        private CGanFairy houtui;
        private CGanFairy tingche;
        private CGanFairy xihuo;
        private Bitmap[] bm;
        private CMonitor cm;
        private delegate void InvokeDelegate();
        private InvokeDelegate myInvoke;
        private int mycount;//信号记数

        private void Invokefun()
        {
            if (qianjin.Stat == 1)
            {
                mycount++;
                listBox1.Items.Add(mycount.ToString() + ":前进");
               // Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
     
            }
            if (houtui.Stat == 1)
            {
                mycount++;
                listBox1.Items.Add(mycount.ToString() + ":后退");
                //Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");

            }
            if (tingche.Stat == 1)
            {
                mycount++;
                listBox1.Items.Add(mycount.ToString() + ":停车");
                //Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");

            }
            if (xihuo.Stat == 1)
            {
                mycount++;
                listBox1.Items.Add(mycount.ToString() + ":熄火");
                //Console.Beep();
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
  
            }
            groupBox1.Refresh();
           
        }
        public CarSignalForm()
        {
            InitializeComponent();
            myinit();
            cm = new CMonitor();
            cm.RegMonitor(this);
            cm.LvboDelayTime = 10;
            myInvoke = new InvokeDelegate(Invokefun);
            mycount = 0;
        }

        private void myinit()
        {
            listBox1.BackColor = Color.Gray;
            bm = new Bitmap[3];
            bm[0] = new Bitmap(".\\img\\green2.gif");
            Color tmpcolor = bm[0].GetPixel(1, 1);
            bm[0].MakeTransparent(tmpcolor);
            bm[1] = new Bitmap(".\\img\\red2.gif");
            tmpcolor = bm[1].GetPixel(1, 1);
            bm[1].MakeTransparent(tmpcolor);
            bm[2] = new Bitmap(".\\img\\gray2.gif");
            tmpcolor = bm[2].GetPixel(1, 1);
            bm[2].MakeTransparent(tmpcolor);

            qianjin = new CGanFairy(bm);
            qianjin.X = 35;
            qianjin.Y = 30;
            qianjin.Stat = 0;

            houtui = new CGanFairy(bm);
            houtui.X = 174;
            houtui.Y = 30;
            houtui.Stat = 0;

            tingche = new CGanFairy(bm);
            tingche.X = 305;
            tingche.Y = 30;
            tingche.Stat = 0;

            xihuo = new CGanFairy(bm);
            xihuo.X = 435;
            xihuo.Y = 30;
            xihuo.Stat = 0;


        }

        public void Notify(CMonData mdata)
        {
              qianjin.Stat = mdata.che[0];
              houtui.Stat = mdata.che[1];
              tingche.Stat = mdata.che[2];
              xihuo.Stat = mdata.che[3];
              groupBox1.BeginInvoke(myInvoke);
        }

        private void CarSignalForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            qianjin.Display(g);
            houtui.Display(g);
            tingche.Display(g);
            xihuo.Display(g);
            if (groupBox1.InvokeRequired)
            {
                groupBox1.BeginInvoke(myInvoke);
            }
        }

        

        private void CarSignalForm_Load(object sender, EventArgs e)
        {
            cm.Start();
        }

        private void CarSignalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            mycount = 0;
        }

     




    }
}
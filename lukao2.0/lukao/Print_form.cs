using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace lukao
{
    public partial class Print_form : Form
    {

        private int x;
        private int y;
        private bool IsFristShow;

        private ArrayList PrintList;
      //  private Label[] PrintLabel;

        public Print_form(int w,int h)
        {
            InitializeComponent();
            IsFristShow = true;
            this.Top = 0;
            this.Left = 0;
            this.Width = w + 75;
            this.Height = h + 80;
            pictureBox1.Width = w;
            pictureBox1.Height = h;
            pictureBox1.Left = 40;
            pictureBox1.Top = 38;
            //label1.Width = 200;
            //label1.Height = 200;
            //label1.Refresh();
            x_zz.Top = pictureBox1.Top - 10;
            y_zz.Left = pictureBox1.Left - 14;
            //x_zz.Left = pictureBox1.Left - (x_zz.Width / 2)+40;
            //y_zz.Top = pictureBox1.Top - (y_zz.Height / 2)+40;

          //  x_zz.Left = pictureBox1.Left - (x_zz.Width / 2) + label1.Left;
           // y_zz.Top = pictureBox1.Top - (y_zz.Height / 2) + label1.Top ;

            PrintList = new ArrayList();

           
        }

        public void PrintRegister(CPrintObjSet po)
        {
            PrintList.Add(po);
        }

        private void Setzz(Label la)
        {
            //int tmpx;
            //int tmpy;

            //tmpx  = pictureBox1.Left - (x_zz.Width / 2) + la.Left;
            //tmpy  = pictureBox1.Top - (y_zz.Height / 2) + la.Top;

            //if (tmpx < pictureBox1.Left)
            //{
            //    tmpx = pictureBox1.Left - (x_zz.Width / 2);
            //}
            //if (tmpy < pictureBox1.Top)
            //{
            //    tmpy = pictureBox1.Top - (y_zz.Height / 2);
            //}
            //x_zz.Left = tmpx;
            //y_zz.Top = tmpy;
            x_zz.Left = pictureBox1.Left - (x_zz.Width / 2) + la.Left;
            y_zz.Top = pictureBox1.Top - (y_zz.Height / 2) + la.Top;
          
        }

        private void RuleInit(Graphics g)
        {
            // Create a new pen
            int lm=0;
            int topbj = 13;//边距
            int leftbj = 15;
            int printbl = 4;//打印比例
            Brush bs = Brushes.BurlyWood ;
            Brush bf = Brushes.White;
            Pen skyBluePen = new Pen(bs);

            // Set the pen's width.
            skyBluePen.Width = 1.0F;

           // Set the LineJoin property.
          //  skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
              Font fn = new Font(FontFamily.GenericMonospace, 10.0F, FontStyle.Bold);


            g.DrawLine(skyBluePen, pictureBox1.Left, pictureBox1.Top - topbj, pictureBox1.Left + pictureBox1.Width, pictureBox1.Top - topbj);
            g.DrawLine(skyBluePen, pictureBox1.Left - leftbj, pictureBox1.Top, pictureBox1.Left - leftbj, pictureBox1.Top + pictureBox1.Height);
            for (int i = 0; i < (pictureBox1.Width+4); i++)
            {

                if((i % printbl)==0)
                {
                    if((lm % 10)==0)
                    {
                        g.DrawLine(skyBluePen, pictureBox1.Left + i, pictureBox1.Top - 10 - topbj, pictureBox1.Left + i, pictureBox1.Top - topbj);
                        g.DrawString((lm / 10).ToString(), fn, bf, pictureBox1.Left - 6 + i, pictureBox1.Top - 25 - topbj);
                    }
                    else
                    {
                        if ((lm % 5) == 0)
                        {
                            g.DrawLine(skyBluePen, pictureBox1.Left + i, pictureBox1.Top - 8 - topbj, pictureBox1.Left + i, pictureBox1.Top - topbj);
                        }
                        else
                        {
                            g.DrawLine(skyBluePen, pictureBox1.Left + i, pictureBox1.Top - 5 - topbj, pictureBox1.Left + i, pictureBox1.Top - topbj);
                        }
                    }
                    lm++;
                }
            }

            lm = 0;

            for (int i = 0; i < (pictureBox1.Height + 4); i++)
            {
                if ((i % printbl) == 0)
                {
                    if ((lm % 10) == 0)
                    {
                        g.DrawLine(skyBluePen, pictureBox1.Left - 10 - leftbj, pictureBox1.Top + i, pictureBox1.Left - leftbj, pictureBox1.Top + i);
                        g.DrawString((lm / 10).ToString(), fn, bf, pictureBox1.Left - 25 - leftbj, pictureBox1.Top -7 + i);
                    }
                    else
                    {
                        if ((lm % 5) == 0)
                        {
                            g.DrawLine(skyBluePen, pictureBox1.Left - 8 - leftbj, pictureBox1.Top + i, pictureBox1.Left - leftbj, pictureBox1.Top + i);
                        }
                        else
                        {
                            g.DrawLine(skyBluePen, pictureBox1.Left - 5 - leftbj, pictureBox1.Top + i, pictureBox1.Left - leftbj, pictureBox1.Top + i);
                        }
                    }
                    lm++;
                }
            }
        }

        private void Print_form_Resize(object sender, EventArgs e)
        {
  
        }

        private void Print_form_Paint(object sender, PaintEventArgs e)
        {
            RuleInit(e.Graphics);

        }

        //private void label1_Paint(object sender, PaintEventArgs e)
        //{
            
        //    Graphics g = e.Graphics;
        //    //SizeF size;
        //    //Font fn = new Font(FontFamily.GenericMonospace, 10.0F, FontStyle.Bold);
        //    //size=g.MeasureString("中华人民共和国", fn);
        //    //((Label)(sender)).Width = Convert.ToInt16(size.Width)+6;
        //    //((Label)(sender)).Height = Convert.ToInt16(size.Height)+4;
        //    //g.DrawString("中华人民共和国", fn, Brushes.Blue , 0, 2);
        //    for (int i = 0; i < PrintList.Count; i++)
        //    {
        //        ((CPrintObjSet)(PrintList[i])).PrintObj(g);
        //        PrintLabel[i].Width = ((CPrintObjSet)(PrintList[i])).Width;
        //        PrintLabel[i].Height = ((CPrintObjSet)(PrintList[i])).Height;
        //    }
        //}
       
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                ((Label)sender).Left = ((Label)sender).Left + e.X - x;
                ((Label)sender).Top = ((Label)sender).Top + e.Y - y;
                 Setzz((Label)sender);
            }
                
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            Setzz((Label)sender);
        }

       


        private void Print_form_Shown(object sender, EventArgs e)
        {
            if (IsFristShow)
            {
                if (PrintList.Count != 0)
                {
                    //  PrintLabel = new Label[PrintList.Count];
                    for (int i = 0; i < PrintList.Count; i++)
                    {
                        //PrintLabel[i] = new Label();
                        //PrintLabel[i].BackColor=System.Drawing.Color.White;
                        //PrintLabel[i].Location = new System.Drawing.Point(((CPrintObjSet)(PrintList[i])).X, ((CPrintObjSet)(PrintList[i])).Y);
                        //PrintLabel[i].Size=new System.Drawing.Size(((CPrintObjSet)(PrintList[i])).Width,((CPrintObjSet)(PrintList[i])).Height);
                        //PrintLabel[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
                        //PrintLabel[i].MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
                        //PrintLabel[i].Paint += new System.Windows.Forms.PaintEventHandler(((CPrintObjSet)(PrintList[i])).label_Paint);
                        //PrintLabel[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        //pictureBox1.Controls.Add(PrintLabel[i]); 
                        ((CPrintObjSet)(PrintList[i])).la.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
                        ((CPrintObjSet)(PrintList[i])).la.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
                        pictureBox1.Controls.Add(((CPrintObjSet)(PrintList[i])).la);

                    }
                }
                IsFristShow = false;
            }


        }
    }
}
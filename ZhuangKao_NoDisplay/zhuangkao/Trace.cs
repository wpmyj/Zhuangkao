using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace zhuangkao
{
    public class Trace
    {
        private static Random rdNum;
        private List<Point> keyPoints;  //关键点坐标序列
        private Queue<Point> bufferPoints; //轨迹点坐标序列
        private List<Point> vPoints;
        private Point[][] xian;
        private double horRate, virRate;
        private int drawSpeed = 500;

        private double speedx = 0.0;
        private double speedy = 0.0;
        private double stepcount = 0.0;

        public Trace(double horRate, double virRate, CBmpFairy che, CLineFairy[] line)
        {
            this.horRate = horRate;
            this.virRate = virRate;
            rdNum = new Random();
            xian = new Point[9][];
            for (int i = 0; i < 9; i++)
            {
                CLineFairy x = line[i];
                xian[i] = new Point[2];
                xian[i][0] = new Point((int)((double)x.X1 * horRate), (int)((double)x.Y1 * virRate));
                xian[i][1] = new Point((int)((double)x.X2 * horRate), (int)((double)x.Y2 * virRate));
                //(float)(x.X1 * horRate), (float)(x.Y1 * virRate), (float)(x.X2 * horRate), (float)(x.Y2 * virRate));
            }
            Initial(che);
        }

        public void Initial(CBmpFairy che)
        {
            keyPoints = new List<Point>();
            vPoints = new List<Point>();
            bufferPoints = new Queue<Point>();
            speedx = 0.0;
            speedy = 0.0;
            stepcount = 0.0;
            this.AddKeyPoint(new Point(che.X, che.Y));
        }

        public void AddKeyPoint(Point p)
        {
            int x = rdNum.Next(0, 20);
            int y = rdNum.Next(0, 20);
            int xn = rdNum.Next(0, 1) == 0 ? -1 : 1;
            int yn = rdNum.Next(0, 1) == 0 ? -1 : 1;
            this.keyPoints.Add(new Point(p.X + xn * x, p.Y + yn * y));
            if (keyPoints.Count >= 2)
            {
                GenerateXie(keyPoints[keyPoints.Count - 2], keyPoints[keyPoints.Count - 1]);
                GenerateVP(keyPoints[keyPoints.Count - 2]);
            }
        }

        private void GenerateXie(Point p1, Point p2)
        {
            int x = p1.X;
            int y = p1.Y;
            int dx = p2.X;
            int dy = p2.Y;
            double tmpxie = Math.Sqrt(Math.Pow(Math.Abs((double)(dx - x)), 2) + Math.Pow(Math.Abs((double)(dy - y)), 2));
            stepcount = tmpxie / 0.5;
            speedx = (dx - x) / stepcount;
            speedy = (dy - y) / stepcount;
        }

        private void GenerateVP(Point startPoint)
        {
            double tmpx = (double)startPoint.X;
            double tmpy = (double)startPoint.Y;
            for (int step = 0; step < stepcount; step++)
            {
                tmpx += speedx;
                tmpy += speedy;
                bufferPoints.Enqueue(new Point((int)(tmpx * horRate), (int)(tmpy * virRate)));
            }
        }

        public void DrawTrace(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = (int)(e.ClipRectangle.Width * 0.95);
            int height = (int)(e.ClipRectangle.Height * 0.95);
            int top = (int)(e.ClipRectangle.Height * 0.025);
            int left = (int)(e.ClipRectangle.Width * 0.025);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(left, top, width, height));
            if (xian != null)
            {
                for (int i = 0; i < xian.Length; i++)
                {
                    Point[] x = xian[i];
                    if (i != 1)
                        g.DrawLine(new Pen(Color.Red), x[0], x[1]);
                }
            }
            if (bufferPoints.Count > 0)
                vPoints.Add(bufferPoints.Dequeue());
            if (vPoints.Count > 1)
                g.DrawLines(new Pen(Color.Black), vPoints.ToArray());
        }
    }
}

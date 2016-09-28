using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace zhuangkao
{
    //struct CarMove
    //{
    //    public int X;
    //    public int Y;
    //    public bool FangXiang;
    //}

    public class CBmpFairy:IFairy
    {
        //private ArrayList _movelist;
        public  readonly int run = 1;
        public  readonly int pause = -1;
        public  readonly int stop = 0;
        private int _oldstate;//在暂停时保存原有状态
        //private int _listpointer;
        private double stepcount;//调用MOVETO函数时计算的步数

        public int StepCount
        {
            get { return (int)stepcount; }
        }


        public CBmpFairy(string filename)
        {

            bm = new Bitmap(filename);
            int xiebian = (int)Math.Sqrt(Math.Pow((double)bm.Width, 2d) + Math.Pow((double)bm.Height, 2d));
            operatebm = new Bitmap(xiebian, xiebian);
            gbm = Graphics.FromImage(operatebm);
            Color backColor = bm.GetPixel(1, 1);
            bm.MakeTransparent(backColor);
            gbm.TranslateTransform(xiebian / 2, xiebian / 2);//平移坐标系
            gbm.DrawImage(bm, -bm.Width / 2, -bm.Height / 2);//初始化图片，角度为0度
            //_movelist = new ArrayList();
            Rangle = 0;
            DestRangle = 0;
            rspeed = 6;
            _state = stop;
            //_listpointer = 0;
        }

        //private bool listnext()
        //{
        //    if((_listpointer+1)<_movelist.Count)
        //    {
        //        _listpointer++;
        //    }
        //}

        //public void MoveToList(int dx, int dy, bool direct)
        //{
        //    CarMove carmovobj;
        //    carmovobj = new CarMove();
        //    _movelist.Add();
        //}

        private int _state;
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        public readonly bool forward = true;//前进
        public readonly bool back = false;//后退
        private  int rspeed;//旋转速度控制，旋转步长
        public int RSpeed
        {
            get
            {
                return rspeed;
            }
            set
            {
                rspeed = value;
            }

        }
        private Bitmap bm;//原始位图
        private Bitmap operatebm;//实际操作的，可以旋转的位图
        private Graphics gbm;
        private int speed=2;//移动速度
      
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value < 0)
                {
                    speed = 0;
                }
                else
                {
                    speed = value;
                }
            }
        }
        private double speedx=0;
        private double speedy=0;//x,y方向的速度分量
        private int destx;
        public int Destx
        {
            get
            {
                return destx;
            }
            set
            {
                destx = value;
            }
        }

        private int desty;
        public int Desty
        {
            get
            {
                return desty;
            }
            set
            {
                desty = value;
            }
        }
        
       
        private double x=0;//当前x坐标,注意，此类型为double型是为了可以累计分量步长
        public int X
        {
            get
            {
                return (int)x;
            }
            set
            {
                x =(double)value;
                
            }
        }



        private double y=0;//当前y坐标
        public int Y
        {
            get
            {
                return (int)y;
            }
            set
            {
                y =(double)value;
           
            }
        }


        private int rangle;//当前角度
        public int Rangle
        {
            get
            {
                return rangle;
            }
            set
            {
                RotateBmp(value);
            }
        }

        private int destrangle;//目标角度
        public int DestRangle
        {
            get
            {
                return destrangle;
            }
            set
            {
                destrangle = value%360;
            }
        }

        private Trace myTrace;
        public Trace CarTrace
        {
            get
            {
                return myTrace;
            }
            set
            {
                myTrace = value;
            }
        }

        public void SetWeizhi(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Destx = _x;
            Desty = _y;
        }

        public void SetRangle(int r)
        {
            DestRangle = r;
            Rangle = DestRangle;
        }



         private int countangle(int sx,int sy,int dx,int dy)//计算任意两点连线形成的角度
        {
            int angle;
            angle = (int)(Math.Atan((double)(dy - sy) /(double)(dx - sx)) * 180 / Math.PI);
            if((dy-sy)>0 && (dx-sx)<0)
            {
                angle = 180 + angle;
            }
            if ((dy - sy) <= 0 && (dx - sx) < 0)
            {
                angle = 180 + angle;
            }

            return angle;
        }

        public void Moveto(int dx, int dy, bool direct)
        {
            Moveto(dx, dy, 0, 0, direct);
        }

        public void Moveto(int dx,int dy,int xoffside, int yoffside, bool direct)//将图像移动的某点坐标，direct为方向，true前进，false后退，函数本身只计算x和y的速度分量，由
        {                                            //Display函数内累计产生动画效果

            if ((dx == x) && (dy == y))
            {
                return;
            }
            if (speed == 0)
            {
                return;
            }
            destx = dx;
            desty = dy;
            destrangle = countangle(X, Y, destx, desty);
            if (!direct)
            {
                destrangle = (180 + destrangle)%360;
            }
            double tmpxie = Math.Sqrt(Math.Pow(Math.Abs((double)(dx - x)), 2) + Math.Pow(Math.Abs((double)(dy - y)), 2));
            stepcount = tmpxie / speed;
            speedx = (dx - x) / stepcount;
            speedy = (dy - y) / stepcount;
            _state = run;
            if (myTrace != null)
                myTrace.AddKeyPoint(new Point(dx + xoffside, dy + yoffside));
        }
 
        public void RotateBmp(int drangle) //旋转图像，参数为旋转的角度
        {
            Color backColor = operatebm.GetPixel(1, 1);
            gbm.Clear(backColor);
            gbm.RotateTransform((float)drangle);
            gbm.DrawImage(bm, -bm.Width / 2, -bm.Height / 2);
            gbm.RotateTransform(-(float)drangle);
            rangle = drangle%360;
        }

        public void Pause()
        {
            if (_state != pause)
            {
                _oldstate = _state;
                _state = pause;
            }
        }

        public void UnPause()
        {
            if (_state == pause)
            {
                _state = _oldstate;
            }
        }


        public void JempStop()
        {
            x = destx;
            y = desty;
        }

        public void Display(Graphics g)
        {
            if (_state == pause)
            {
                g.DrawImage(operatebm, X - operatebm.Width / 2, Y - operatebm.Height / 2);
                return;
            }

            if ((destx == x) && (desty == y) && (destrangle == rangle)) //如果源与目标坐标及角度都相同，则显示静态图像
            {
                g.DrawImage(operatebm, X - operatebm.Width / 2, Y - operatebm.Height / 2);
                _state = stop;
                return;
            }
            if ((destrangle % 360) != (rangle % 360))//源与目标与角度不同，则先旋转图像（旋转方向为向角度小的方向旋转）
            {
               
                if ((destrangle%360) > (rangle%360))
                {
                    if (((destrangle % 360) - (rangle % 360)) < (((rangle % 360) + 360) - destrangle % 360))
                    {
                        Rangle = Rangle + rspeed;
                        if (rangle > destrangle)
                        {
                            Rangle = destrangle;
                        }
                    }
                    else
                    {
                        Rangle = Rangle - rspeed;
                        if ((rangle + 360) < destrangle)
                        {
                            Rangle = destrangle;
                        }
                    }
                }

                if ((destrangle % 360) < (rangle % 360))
                {
                    if ((rangle - destrangle) < destrangle + 360 - rangle)
                    {
                        Rangle = Rangle - rspeed;
                        if (rangle < destrangle)
                        {
                            Rangle = destrangle;
                        }
                    }
                    else
                    {
                        Rangle = Rangle + rspeed;
                        if (rangle > (destrangle + 360))
                        {
                            Rangle = destrangle;
                        }
                    }
                }

                g.DrawImage(operatebm, X - operatebm.Width / 2, Y - operatebm.Height / 2);
                return;
            }
            //开始移动图像，根据moveto函数计算出的速度分量
             x = x + speedx;
            if ((speedx < 0) && (x <= destx))
            {
                x =(double)destx;
            }
            if((speedx>0) && (x>=destx))
            {
                x = (double)destx;
            }
            y = y + speedy;
            if((speedy<0)&& (y<desty))
            {
                y = (double)desty;
            }

            if ((speedy > 0) && (y >= desty))
            {
                y = (double)desty;
            }
            g.DrawImage(operatebm, X - operatebm.Width / 2, Y - operatebm.Height / 2);

        }
    }
}

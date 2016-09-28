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
        private int _oldstate;//����ͣʱ����ԭ��״̬
        //private int _listpointer;
        private double stepcount;//����MOVETO����ʱ����Ĳ���

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
            gbm.TranslateTransform(xiebian / 2, xiebian / 2);//ƽ������ϵ
            gbm.DrawImage(bm, -bm.Width / 2, -bm.Height / 2);//��ʼ��ͼƬ���Ƕ�Ϊ0��
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

        public readonly bool forward = true;//ǰ��
        public readonly bool back = false;//����
        private  int rspeed;//��ת�ٶȿ��ƣ���ת����
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
        private Bitmap bm;//ԭʼλͼ
        private Bitmap operatebm;//ʵ�ʲ����ģ�������ת��λͼ
        private Graphics gbm;
        private int speed=2;//�ƶ��ٶ�
      
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
        private double speedy=0;//x,y������ٶȷ���
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
        
       
        private double x=0;//��ǰx����,ע�⣬������Ϊdouble����Ϊ�˿����ۼƷ�������
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



        private double y=0;//��ǰy����
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


        private int rangle;//��ǰ�Ƕ�
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

        private int destrangle;//Ŀ��Ƕ�
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



         private int countangle(int sx,int sy,int dx,int dy)//�����������������γɵĽǶ�
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

        public void Moveto(int dx,int dy,int xoffside, int yoffside, bool direct)//��ͼ���ƶ���ĳ�����꣬directΪ����trueǰ����false���ˣ���������ֻ����x��y���ٶȷ�������
        {                                            //Display�������ۼƲ�������Ч��

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
 
        public void RotateBmp(int drangle) //��תͼ�񣬲���Ϊ��ת�ĽǶ�
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

            if ((destx == x) && (desty == y) && (destrangle == rangle)) //���Դ��Ŀ�����꼰�Ƕȶ���ͬ������ʾ��̬ͼ��
            {
                g.DrawImage(operatebm, X - operatebm.Width / 2, Y - operatebm.Height / 2);
                _state = stop;
                return;
            }
            if ((destrangle % 360) != (rangle % 360))//Դ��Ŀ����ǶȲ�ͬ��������תͼ����ת����Ϊ��Ƕ�С�ķ�����ת��
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
            //��ʼ�ƶ�ͼ�񣬸���moveto������������ٶȷ���
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

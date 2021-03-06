//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Timers;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;


namespace zhuangkao
{
    public class CIDCardInfo
    {

        public delegate void IDCardRequest(string xm,string sfzhm);
        public event IDCardRequest OnIDCardReceived;
        private CIOCard idcard;
        private bool iserr;
        private Timer t1;

        private byte[] data;
        private int len;

        public string sfzhm;
        public string xm;

        public CIDCardInfo()
        {
            idcard = new CIOCard();
            iserr = false;
            t1 = new Timer();
            t1.Tick += new EventHandler(Timerfun);
            t1.Interval = 1000;
            data = new byte[256];
        }

        public void InitIDcardDev()
        {
            int tmpnum = 1001;
            int res=0;
            while ((res != 1) && (tmpnum <= 1016))
            {
                res=idcard.Init(tmpnum);
                tmpnum++;
            }
            if (tmpnum > 1016)
            {
                iserr = true;
            }
            else
            {
                iserr = false;
            }
           // idcard.Init(1001);
        }

        public void Start()
        {
            if (!iserr)
            {
                t1.Start();
            }
        }


        public void Stop()
        {
            t1.Stop();
        }

        private void Timerfun(Object myObject, EventArgs myEventArgs)
        {
            int reval = idcard.AuthIDCard();
            if (reval > 0)
            {
                reval = idcard.ReadIDCard(data, ref len);
                if (reval > 0)
                {

                    byte[] tmpbyte = new byte[31];
                    for (int i = 0; i < 31; i++)
                    {
                        tmpbyte[i] = data[i];
                    }
                    xm = System.Text.ASCIIEncoding.Default.GetString(tmpbyte);

                    byte[] tmpbyte1 = new byte[20];
                    for (int i = 124; i < 142; i++)
                    {
                        tmpbyte1[i - 124] = data[i];
                    }
                    sfzhm = System.Text.ASCIIEncoding.Default.GetString(tmpbyte1);

                    OnIDCardReceived(xm,sfzhm);
                    //System.Console.Beep();
                    CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
                }
            }
        }

        public void CloseIDcardDev()
        {
            t1.Stop();
            idcard.Close();
        }

        ~CIDCardInfo()
        {
            CloseIDcardDev();
        }


    }
}

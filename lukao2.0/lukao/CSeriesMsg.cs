using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Timers;
using System.Collections;


namespace lukao
{
    
    public class CSeriesMsg
    {

        private SerialPort port;
        private CModel model;
        private ArrayList rlist;
        public delegate void UserDataReceived(object sender, byte[] e);
        public event UserDataReceived OnUserDataReceived;//数据到达事件


        public CSeriesMsg(CModel model)
        {
            this.model = model;
            port = new SerialPort();
            rlist = new ArrayList();
            port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = model.settings.Comport;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.ReadBufferSize = 512;
            port.WriteBufferSize = 512;//原来设置为30
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            if (port.IsOpen == false)
            {
                port.Open();
            }
            else
            {
                port.Close();
                System.Threading.Thread.Sleep(200);
                port.Open();
            }
        }

        private bool find0d(byte[] finddata) //结束符判断，现在结束符为 0xFF
        {
            for (int i = 0; i < finddata.Length; i++)
            {
                if (finddata[i] == 0xff)
                {
                    return true;
                }
            }
            return false;
        }


        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] tmpbyte = new byte[port.BytesToRead];
                port.Read(tmpbyte, 0, tmpbyte.Length);
                rlist.AddRange(tmpbyte);

                if (find0d(tmpbyte))
                {
                    byte[] tmpdata = new byte[rlist.Count];
                    rlist.CopyTo(0, tmpdata, 0, rlist.Count);
                    rlist.Clear();
                    OnUserDataReceived(this, tmpdata);
                }
            }
            catch(Exception err)
            {
                System.Windows.Forms.MessageBox.Show("收到乱码！");
                System.Windows.Forms.MessageBox.Show(err.Message.ToString() );
                port.Close();
                System.Threading.Thread.Sleep(2000);
                port.Open();
            }

        }

        public void SendData(byte[] data,int len)
        {
            port.Write(data, 0, len);
        }

        ~CSeriesMsg()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;


namespace Cn.Youdundianzi.Share.LEDDisplay
{
    public class CDisplaycommTLSC : LEDDisplay.IDisplaycomm
    {

        public delegate void UserDataReceived(byte addresscode, byte e);
        public event UserDataReceived OnUserDataReceived;//数据到达事件
        private SerialPort port;
        private DisplayConfigTLSC settings;

        public CDisplaycommTLSC(DisplayConfigTLSC settings)
        {
            this.settings = settings;
            port = new SerialPort();
            port.BaudRate = 4800;
            port.PortName = settings.Comport;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            _setdisplaytype = settings.DisplayType;
            try
            {
                port.Open();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("无法打开串口" + settings.Comport +"!");
            }
        }

       

        private DisplayType _setdisplaytype;
        public DisplayType Setdisplaytype
        {
            get { return _setdisplaytype; }
            set { _setdisplaytype = value; }
        }

        private byte _speed;
        public byte Speed
        {
            get { return _speed; }
            set 
            {
                _speed = value; 
                if (_speed < 1)
                {
                    _speed = 1;
                }
                if (_speed > 15)
                {
                    _speed = 15;
                }
            }
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] tmpbyte = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                tmpbyte[i] = 0xff;
            }
            port.Read(tmpbyte, 0, 4);
            if (OnUserDataReceived != null)
            {
                OnUserDataReceived(tmpbyte[2],tmpbyte[3]);
            }
        }

        public void ShowText(string txt)
        {
            CDisplayDataTLSC data = new CDisplayDataTLSC(settings);
            data.DispType = settings.DisplayType;
            data.Speed = settings.DisplaySpeed;
            data.AddressCode = settings.Addresscode;
            data.DisplayText = txt;
            byte[] senddata = data.ToByte();
            try
            {
                port.Write(senddata, 0, senddata.Length);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("串口通讯故障！");
            }
        }



        public void Close()
        {
            port.Close();
        }

       

    }
}

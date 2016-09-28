using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace zkcenter
{
    class CDisplaycomm
    {

        public delegate void UserDataReceived(byte addresscode, byte e);
        public event UserDataReceived OnUserDataReceived;//数据到达事件
        private SerialPort port;
        private ModuleSettings settings;

        public CDisplaycomm(ModuleSettings settings)
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
                if (settings.HasDisplay)
                    port.Open();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("无法打开串口" + settings.Comport + "!");
            }
        }

        private DisplayType _setdisplaytype;
        internal DisplayType Setdisplaytype
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
            CDisplayData data = new CDisplayData(settings);
            data.DispType = this._setdisplaytype;
            data.Speed = this._speed;
            data.AddressCode = settings.Addresscode;
            if (txt.Equals(string.Empty))
                data.DisplayText = " ";
            else
                data.DisplayText = txt;
            byte[] senddata = data.ToByte();
            try
            {
                if (settings.HasDisplay)
                    port.Write(senddata, 0, senddata.Length);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("串口通讯故障！");
            }
        }



        public void Close()
        {
            if (settings.HasDisplay)
                port.Close();
        }

    }
}

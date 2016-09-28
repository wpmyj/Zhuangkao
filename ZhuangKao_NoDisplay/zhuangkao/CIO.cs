using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace zhuangkao
{
    public class CIO
    {
        [DllImport("winio.dll", EntryPoint = "InitializeWinIo")]
        private extern static bool InitializeWinIo();

        [DllImport("winio.dll", EntryPoint = "GetPortVal")]
        private extern static bool GetPortVal(
                                     int wPortAddr,
                                     ref byte  pdwPortVal,
                                     byte bSize
                                     );

        [DllImport("winio.dll", EntryPoint = "SetPortVal")]
        private extern static bool SetPortVal(
                                int wPortAddr,
                                byte dwPortVal,
                                byte bSize
                                 );

        [DllImport("winio.dll", EntryPoint = "ShutdownWinIo")]
        private extern static void ShutdownWinIo();

        public CIO()
        {
            if (!InitializeWinIo())
            {
                System.Windows.Forms.MessageBox.Show("IO≥ı ºªØ ß∞‹£°");
            }
        }

        public byte read(int addr)
        {
            byte val=0;
            try
            {
                GetPortVal(addr, ref val, 1);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("∂¡IO¥ÌŒÛ£°");
                return 0;
            }
            return val;
        }

        public void write(int addr,byte data)
        {
            SetPortVal(addr,data,1);
        }

        public void close()
        {
            ShutdownWinIo();
        }

       
    }
}

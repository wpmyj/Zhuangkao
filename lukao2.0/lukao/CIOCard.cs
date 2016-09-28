using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace lukao
{
    public class CIOCard
    {

        [DllImport("sdtapi.dll", EntryPoint = "InitComm")]
        private  extern static int InitComm(int iPort);


        [DllImport("sdtapi.dll", EntryPoint = "CloseComm")]
        private  extern static int CloseComm();


        [DllImport("sdtapi.dll", EntryPoint = "Authenticate")]
        private extern static int Authenticate();

        [DllImport("sdtapi.dll", EntryPoint = "ReadBaseMsg")]
        
         private extern static int ReadBaseMsg(byte[] pMsg, ref int len);
        


        public int Init(int iport)
        {
            return InitComm(iport);
        }

        public int Close()
        {
            return CloseComm();
        }

        public int AuthIDCard()
        {
            return Authenticate();
        }

        public int ReadIDCard(byte[] pMsg, ref int len)
        {
            return ReadBaseMsg(pMsg, ref len); 
        }
    
        


    }
}

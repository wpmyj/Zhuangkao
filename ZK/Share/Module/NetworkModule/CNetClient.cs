using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Cn.Youdundianzi.Share.Module.Network
{
    public class CNetClient
    {
        //定义设备信息事件
        public delegate void D_DEVNETDATA(CNetData data);
        private event D_DEVNETDATA _event_devnetdata;
        public event D_DEVNETDATA Event_Devnetdata
        {
            add
            {
                _event_devnetdata += value;
            }
            remove
            {
                _event_devnetdata -= value;
            }
        }

        public Socket clientSocket;
        private byte[] byteData = new byte[1024];
        string ServerIpaddress;
        int intDevnum;

        public CNetClient(string ServerIpaddress, int intDevnum)
        {
            this.ServerIpaddress = ServerIpaddress;
            this.intDevnum = intDevnum;
            byteData = new byte[1024];

           
        }

        public void Connect()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAddress = IPAddress.Parse(ServerIpaddress);
                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 6622);

                //Connect to the server
                clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
                //Start listening to the data asynchronously
                System.Threading.Thread.Sleep(1000);
                clientSocket.BeginReceive(byteData,
                                         0,
                                         byteData.Length,
                                         SocketFlags.None,
                                         new AsyncCallback(OnReceive),
                                         null);
              
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message, "CNetClient_Connect", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.MessageBox.Show("不能与点名中心建立网络连接");
            } 
        }


        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);

                //We are connected so we login into the server
                CNetData msgToSend = new CNetData();
                msgToSend.cmdCommand = Command.Login;
                msgToSend.intDevnum  = intDevnum;
                msgToSend.strZjbh = null;

                byte[] b = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
              
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "CNetClient_OnConnect", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "CNetClient_OnSend", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);


                bool wexit = false;
                int tmpcp = 0;//数组位置指针
                int tmpsize = 0;

                while (!wexit)
                {

                    tmpsize = BitConverter.ToInt32(byteData, tmpcp);
                    if ((tmpsize == 0)||(tmpsize>100))
                    {
                        wexit = true;
                    }
                    else
                    {
                        byte[] tmpdata = new byte[tmpsize];
                        Array.Copy(byteData, tmpcp, tmpdata, 0, tmpsize);
                        tmpcp = tmpcp + tmpsize;

                        CNetData msgReceived = new CNetData(tmpdata);
                        if (_event_devnetdata != null)
                        {
                            _event_devnetdata(msgReceived);
                        }
                    }

                }



                //CNetData msgReceived = new CNetData(byteData);
                //if (_event_devnetdata != null)
                //{
                //    _event_devnetdata(msgReceived);
                //}
                
                byteData = new byte[1024];
                clientSocket.BeginReceive(byteData,
                                          0,
                                          byteData.Length,
                                          SocketFlags.None,
                                          new AsyncCallback(OnReceive),
                                          null);

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "CNetClient_OnReceive", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        public void SendData(CNetData datasend)
        {
            byte[] b = datasend.ToByte ();
            try
            {
                clientSocket.Send(b, 0, b.Length, SocketFlags.None);
            }
            catch
            {
            }
        }


        public void Close()
        {
            clientSocket.Close();
        }

    }
}

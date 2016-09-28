using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace zkcenter
{
    public class CNetServer
    {
        
        //定义设备登录事件
        public delegate void D_DEVLOGIN(int pintDevnum);
        private event D_DEVLOGIN _event_devlogin;
        public event D_DEVLOGIN Event_Devlogin
        {
            add
            {
                _event_devlogin += value;
            }
            remove
            {
                _event_devlogin -= value;
            }
        }

        //定义设备注销事件
        public delegate void D_DEVLOGOUT(int pintDevnum);
        private event D_DEVLOGOUT _event_devlogout;
        public event D_DEVLOGOUT Event_Devlogout
        {
            add
            {
                _event_devlogout += value;
            }
            remove
            {
                _event_devlogout -= value;
            }
        }

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


        struct ClientInfo
        {
            public Socket socket;   //Socket of the client
            public int intDevnum;  //设备编号（设备编号从1开始，0为非法设备）
        }

        //收到设备登录(lonin)命令后将设备信息添加到clintlist，logout后从列表中删除
        ArrayList clientList;

        //服务器socket,主侦听socket
        Socket serverSocket;

        byte[] byteData = new byte[1024];

        public CNetServer()
        {
             clientList = new ArrayList();
             try
             {
                 //We are using TCP sockets
                 serverSocket = new Socket(AddressFamily.InterNetwork,
                                           SocketType.Stream,
                                           ProtocolType.Tcp);

                 //端口设置为6622
                 IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 6622);

                 //Bind and listen on the given address
                 serverSocket.Bind(ipEndPoint);
                 serverSocket.Listen(4);

                 //Accept the incoming clients
                 serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
             }
             catch (Exception ex)
             {
                 System.Windows.Forms.MessageBox.Show(ex.Message, "CNetServer",
                     System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
             }            
        }


        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                //Start listening for more clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

                //Once the client connects then start receiving the commands from her
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                    new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "CNetServer_OnAccept",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);

                //Transform the array of bytes received from the user into an
                //intelligent form of object Data
                CNetData msgReceived = new CNetData(byteData);


                //创建接收到数据的事件处理
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.socket = clientSocket;
                        clientInfo.intDevnum = msgReceived.intDevnum;
                        clientList.Add(clientInfo);
                        if (_event_devlogin != null)
                        {
                            _event_devlogin(msgReceived.intDevnum);//发送login事件
                        }
                        break;
                    case Command.Logout:
                        int nIndex = 0;
                        int tmpdevnum=0;
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.socket == clientSocket)
                            {
                                tmpdevnum=client.intDevnum;
                                clientList.RemoveAt(nIndex);
                                break;
                            }
                            ++nIndex;
                        }
                        clientSocket.Close();
                        if (_event_devlogout != null)
                        {
                            _event_devlogout(tmpdevnum);//发送logout事件
                        }
                        break;
                    default:
                        if (_event_devnetdata != null)
                        {
                            _event_devnetdata(msgReceived);//发送其他事件
                        }
                        break;
                }

                if (msgReceived.cmdCommand != Command.Logout)
                {
                    //Start listening to the message send by the user
                    clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                }
            }
            catch
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                int nIndex = 0;
                int tmpdevnum = 0;
                foreach (ClientInfo client in clientList)
                {
                    if (client.socket == clientSocket)
                    {
                        tmpdevnum = client.intDevnum;
                        clientList.RemoveAt(nIndex);
                        break;
                    }
                    ++nIndex;
                }
                clientSocket.Close();
                if (_event_devlogout != null)
                {
                    _event_devlogout(tmpdevnum);//发送logout事件
                }
                //System.Windows.Forms.MessageBox.Show(ex.Message, "CNetServer_OnReceive",
                  //  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.MessageBox.Show("设备" + tmpdevnum.ToString() + "强行断开网络！","点名中心提示");
            }
              
        }

        //public void OnSend(IAsyncResult ar)
        //{
        //    try
        //    {
        //        Socket client = (Socket)ar.AsyncState;
        //        client.EndSend(ar);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "CNetServer_OnSend",
        //             System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        //    }
        //}


        public void SendData(int pintdevnum, CNetData datasend)
        {
            foreach (ClientInfo client in clientList)
            {
                if (client.intDevnum == pintdevnum)
                {
                    byte[] b = datasend.ToByte ();
                    client.socket.Send(b, 0, b.Length, SocketFlags.None);
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

    }
}

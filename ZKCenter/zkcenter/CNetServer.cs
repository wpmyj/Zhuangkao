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
        
        //�����豸��¼�¼�
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

        //�����豸ע���¼�
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

        //�����豸��Ϣ�¼�
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
            public int intDevnum;  //�豸��ţ��豸��Ŵ�1��ʼ��0Ϊ�Ƿ��豸��
        }

        //�յ��豸��¼(lonin)������豸��Ϣ��ӵ�clintlist��logout����б���ɾ��
        ArrayList clientList;

        //������socket,������socket
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

                 //�˿�����Ϊ6622
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


                //�������յ����ݵ��¼�����
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.socket = clientSocket;
                        clientInfo.intDevnum = msgReceived.intDevnum;
                        clientList.Add(clientInfo);
                        if (_event_devlogin != null)
                        {
                            _event_devlogin(msgReceived.intDevnum);//����login�¼�
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
                            _event_devlogout(tmpdevnum);//����logout�¼�
                        }
                        break;
                    default:
                        if (_event_devnetdata != null)
                        {
                            _event_devnetdata(msgReceived);//���������¼�
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
                    _event_devlogout(tmpdevnum);//����logout�¼�
                }
                //System.Windows.Forms.MessageBox.Show(ex.Message, "CNetServer_OnReceive",
                  //  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.MessageBox.Show("�豸" + tmpdevnum.ToString() + "ǿ�жϿ����磡","����������ʾ");
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

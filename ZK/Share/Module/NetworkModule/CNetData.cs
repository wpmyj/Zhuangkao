//*********************************************************************
//               �첽ͨѶ���������������
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.Module.Network
{
    public enum Command
    {
        Login,      //�ͻ��˵�����������¼
        Logout,     //�ͻ��˵����������ǳ�
        GetStudent,  //�ͻ��˵������������뿼�Եõ�������Ϣ
        Ksks,       //�ͻ��˵�������,���Կ�ʼ
        Kswc,       //�ͻ��˵�������,�������
        Jjks,       //�ͻ��˵�������,�ܾ�����
        Updatelist, //�ͻ��˵�������,ͬ�������Ŷӿ����б�
        Zkzhm,      //���������ͻ��ˣ�׼��֤����
        AddStudent,     //���������ͻ��ˣ����Ŷ��б������ӿ���
        DeleteStudent,     //���������ͻ��ˣ����Ŷ��б���ɾ������
        ClearStudent,   //���������ͻ��ˣ�����б��п���
        Null        //No command
    }

    public enum DevStatus
    {
        δ����,
        �豸����,
        �����֤,
        ���ڿ���
    }


    public class CNetData
    {
        public int intDevnum;      //׮���豸���
        public string strZjbh;       //֤�����,���������֤�����֤Ҳ������׼��֤
        public Command cmdCommand;    //����(login, logout, send message, etcetera)
        public string Xm;
        public int commandcount;

        private int _intZjnum;//֤����ų���
        public int intZjnum
        {
            get { return _intZjnum; }
        }

        private int _intXmnum;
        public int IntXmnum
        {
            get { return _intXmnum; }
        }

         //Default constructor
        public CNetData()
        {
            this.cmdCommand = Command.Null;
            this.intDevnum = 0;
            this.strZjbh = null;
            this._intXmnum = 0;
            this.Xm = null;
            this.commandcount = 0;
        }

        public void Clear()
        {
            this.cmdCommand = Command.Null;
            this.intDevnum = 0;
            this.strZjbh = null;
            this._intXmnum = 0;
            this.Xm = null;
            commandcount = 0;
        }

        //Converts the bytes into an object of type Data
        public CNetData(byte[] data)  //��0-3λΪ�����ţ���4-7λΪ�豸��ţ�8-11λΪ֤�����λ��,��5�Ժ��λΪ֤����ţ�
        {
            this.commandcount = (int)BitConverter.ToInt32(data, 0);

            //ȡ������λ
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 4);

            //ȡ���豸���
            this.intDevnum  = BitConverter.ToInt32(data, 8);

            //ȡ��֤�����볤��
            this._intZjnum = BitConverter.ToInt32(data, 12);

            //ȡ��֤������
            if (_intZjnum > 0)
            {
                this.strZjbh = Encoding.UTF8.GetString(data, 16, _intZjnum);
            }
            else
            {
                this.strZjbh = null;
            }
            //ȡ����������
            this._intXmnum = BitConverter.ToInt32(data, 16+_intZjnum);
            if (_intXmnum > 0)
            {
                this.Xm = System.Text.Encoding.Default.GetString(data, 20 + _intZjnum, _intXmnum);
            }else
            {
                this.Xm=null;
            }

        }

        //Converts the Data structure into an array of bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //ѹ������
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //ѹ���豸���
            result.AddRange(BitConverter.GetBytes(intDevnum));

            //ѹ��֤�����볤�Ⱥ�֤������
            if (strZjbh != null)
            {
                _intZjnum = strZjbh.Length;
            }
            else
            {
                _intZjnum = 0;
            }
            if (_intZjnum > 0)
            {
                result.AddRange(BitConverter.GetBytes(_intZjnum));
                result.AddRange(System.Text.ASCIIEncoding.Default.GetBytes(strZjbh));
            }
            else
            {
                result.AddRange(BitConverter.GetBytes(0));
            }
            if (Xm != null)
            {
                _intXmnum = (System.Text.Encoding.Default.GetBytes(Xm)).Length;
                result.AddRange(BitConverter.GetBytes(_intXmnum));
                result.AddRange(System.Text.Encoding.Default.GetBytes(Xm));
            }
            else
            {
                result.AddRange(BitConverter.GetBytes(0));
            }
            result.InsertRange(0, BitConverter.GetBytes(result.Count+4));

            return result.ToArray();
           
        }

       
    }
}

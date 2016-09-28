//*********************************************************************
//               异步通讯命令解析数据类型
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.Module.Network
{
    public enum Command
    {
        Login,      //客户端到服务器，登录
        Logout,     //客户端到服务器，登出
        GetStudent,  //客户端到服务器，申请考试得到考生信息
        Ksks,       //客户端到服务器,考试开始
        Kswc,       //客户端到服务器,考试完成
        Jjks,       //客户端到服务器,拒绝考生
        Updatelist, //客户端到服务器,同步更新排队考生列表
        Zkzhm,      //服务器到客户端，准考证号码
        AddStudent,     //服务器到客户端，在排队列表中增加考生
        DeleteStudent,     //服务器到客户端，在排队列表中删除考生
        ClearStudent,   //服务器到客户端，清除列表中考生
        Null        //No command
    }

    public enum DevStatus
    {
        未连接,
        设备就绪,
        身份验证,
        正在考试
    }


    public class CNetData
    {
        public int intDevnum;      //桩考设备编号
        public string strZjbh;       //证件编号,可以是身份证或军官证也可以是准考证
        public Command cmdCommand;    //命令(login, logout, send message, etcetera)
        public string Xm;
        public int commandcount;

        private int _intZjnum;//证件编号长度
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
        public CNetData(byte[] data)  //第0-3位为命令编号，第4-7位为设备编号，8-11位为证件编号位数,第5以后的位为证件编号，
        {
            this.commandcount = (int)BitConverter.ToInt32(data, 0);

            //取出命令位
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 4);

            //取出设备编号
            this.intDevnum  = BitConverter.ToInt32(data, 8);

            //取出证件号码长度
            this._intZjnum = BitConverter.ToInt32(data, 12);

            //取出证件号码
            if (_intZjnum > 0)
            {
                this.strZjbh = Encoding.UTF8.GetString(data, 16, _intZjnum);
            }
            else
            {
                this.strZjbh = null;
            }
            //取出姓名长度
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

            //压入命令
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //压入设备编号
            result.AddRange(BitConverter.GetBytes(intDevnum));

            //压入证件号码长度和证件号码
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

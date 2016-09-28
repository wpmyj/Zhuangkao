using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace zkdata 
{
    #region 配置对象模型类

    

    public class ModuleSettings
    {

        private string _ipaddress;
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        private string _downloaddate;
        public string Downloaddate
        {
            get { return _downloaddate; }
            set { _downloaddate = value; }
        }

        private string _SendDatetime;
        public string SendDatetime
        {
            get { return _SendDatetime; }
            set { _SendDatetime = value; }
        }

        private string _ksdd;
        public string Ksdd
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
            

        //----------打印坐标设置---------------------
    //    private int ksxm_x;
    //    public int Ksxm_x
    //    {
    //        get { return ksxm_x; }
    //        set { ksxm_x = value; }
    //    }

    //    private int ksxm_y;
    //    public int Ksxm_y
    //    {
    //        get { return ksxm_y; }
    //        set { ksxm_y = value; }
    //    }

    //    private int ksdd_x;
    //    public int Ksdd_x
    //    {
    //        get { return ksdd_x; }
    //        set { ksdd_x = value; }
    //    }

    //    private int ksdd_y;
    //    public int Ksdd_y
    //    {
    //        get { return ksdd_y; }
    //        set { ksdd_y = value; }
    //    }

    //    private int kscj_x;
    //    public int Kscj_x
    //    {
    //        get { return kscj_x; }
    //        set { kscj_x = value; }
    //    }

    //    private int kscj_y;
    //    public int Kscj_y
    //    {
    //        get { return kscj_y; }
    //        set { kscj_y = value; }
    //    }

    //    private int ksrq_x;
    //    public int Ksrq_x
    //    {
    //        get { return ksrq_x; }
    //        set { ksrq_x = value; }
    //    }

    //    private int ksrq_y;
    //    public int Ksrq_y
    //    {
    //        get { return ksrq_y; }
    //        set { ksrq_y = value; }
    //    }

    //    private int ksyxm_x;
    //    public int Ksyxm_x
    //    {
    //        get { return ksyxm_x; }
    //        set { ksyxm_x = value; }
    //    }

    //    private int ksyxm_y;
    //    public int Ksyxm_y
    //    {
    //        get { return ksyxm_y; }
    //        set { ksyxm_y = value; }
    //    }

    //    private int isprintbjg;
    //    public int Isprintbjg
    //    {
    //        get { return isprintbjg; }
    //        set { isprintbjg = value; }
    //    }

    //    private int lkrqorzkrq; //发送路考日期还是桩考日期，非0为路考日期，0为桩考日期
    //    public int lkrqORzkrq
    //    {
    //        get { return lkrqorzkrq; }
    //        set { lkrqorzkrq = value; }
    //    }

    //    private int showbutton; //显示复位和同步按钮，非0显示，0不显示
    //    public int Showbutton
    //    {
    //        get { return showbutton; }
    //        set { showbutton = value; }
    //    }
    }

    #endregion 
}

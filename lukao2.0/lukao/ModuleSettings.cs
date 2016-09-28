using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace lukao 
{
    #region ���ö���ģ����

    

    public class ModuleSettings
    {

        private string _devinfo;//01:������ 02:������
        public string DevInfo
        {
            set { _devinfo = value; }
            get { return _devinfo; }
        }

        private string _ipaddress;
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        private string _comport;
        public string Comport
        {
            get { return _comport; }
            set { _comport = value; }
        }

        private int _jgfs;//���������
        public int Jgfs
        {
            get { return _jgfs; }
            set { _jgfs = value; }
        }

        private string  _ksy;
        public string  Ksy
        {
            get { return _ksy; }
            set { _ksy = value; }
        }

        private string _ksdd;
        public string Ksdd
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }

        private int _lkcs;
        public int Lkcs
        {
            get { return _lkcs; }
            set { _lkcs = value; }
        }

        private int _useidcard;
        public int Useidcard
        {
            get { return _useidcard; }
            set { _useidcard = value; }
        }

        private int _fspltimer;//����Ƶ��
        public int Fspltimer
        {
            get { return _fspltimer; }
            set { _fspltimer = value; }
        }



        //----------��ӡ��������---------------------
        private int ksxm_x;
        public int Ksxm_x
        {
            get { return ksxm_x; }
            set { ksxm_x = value; }
        }

        private int ksxm_y;
        public int Ksxm_y
        {
            get { return ksxm_y; }
            set { ksxm_y = value; }
        }

        private int ksdd_x;
        public int Ksdd_x
        {
            get { return ksdd_x; }
            set { ksdd_x = value; }
        }

        private int ksdd_y;
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
        }

        private int kscj_x;
        public int Kscj_x
        {
            get { return kscj_x; }
            set { kscj_x = value; }
        }

        private int kscj_y;
        public int Kscj_y
        {
            get { return kscj_y; }
            set { kscj_y = value; }
        }

        private int ksrq_x;
        public int Ksrq_x
        {
            get { return ksrq_x; }
            set { ksrq_x = value; }
        }

        private int ksrq_y;
        public int Ksrq_y
        {
            get { return ksrq_y; }
            set { ksrq_y = value; }
        }

        private int ksyxm_x;
        public int Ksyxm_x
        {
            get { return ksyxm_x; }
            set { ksyxm_x = value; }
        }

        private int ksyxm_y;
        public int Ksyxm_y
        {
            get { return ksyxm_y; }
            set { ksyxm_y = value; }
        }

        private int isprintbjg;
        public int Isprintbjg
        {
            get { return isprintbjg; }
            set { isprintbjg = value; }
        }

        private int lkrqorzkrq; //����·�����ڻ���׮�����ڣ���0Ϊ·�����ڣ�0Ϊ׮������
        public int lkrqORzkrq
        {
            get { return lkrqorzkrq; }
            set { lkrqorzkrq = value; }
        }

        private int showbutton; //��ʾ��λ��ͬ����ť����0��ʾ��0����ʾ
        public int Showbutton
        {
            get { return showbutton; }
            set { showbutton = value; }
        }
    }

    #endregion 
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace zkcenter
{
    #region ���ö���ģ����

    

    public class ModuleSettings
    {

        private string _ipaddress;
        [DescriptionAttribute("Զ�����ݿ�IP��ַ��"), CategoryAttribute("���ݿ�")]
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        private string _devorder;
        [DescriptionAttribute("�����õ��豸�����С���\"1,2,5\"��ʾ1�š�2�ź�5�ſ⽫�������ԡ�"), CategoryAttribute("׮������")]
        public string DevOrder
        {
            get { return _devorder; }
            set { _devorder = value; }
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


        //==============��ʾ�����ÿ�ʼ=========================
        private bool _hasDisplay;
        [DescriptionAttribute("�Ƿ�ʹ����ʾ�ơ�"), CategoryAttribute("��ʾ��ͨѶ����")]
        public bool HasDisplay
        {
            get { return _hasDisplay; }
            set { _hasDisplay = value; }
        }

        private string _comport;
        [DescriptionAttribute("���ж˿����á�"), CategoryAttribute("��ʾ��ͨѶ����")]
        public string Comport
        {
            get { return _comport; }
            set { _comport = value; }
        }

        private DisplayBS _displaybs;
        [DescriptionAttribute("��ʾ�����ͣ�����ΪBigDisplay,С��ΪSmallDisplay��"), CategoryAttribute("��ʾ��ͨѶ����")]
        public DisplayBS Displaybs
        {
            get { return _displaybs; }
            set { _displaybs = value; }
        }


        private byte _addresscode;
        [DescriptionAttribute("��ʾ����ַ���ã�ע��Ϊʮ����ֵ��16����ǰ��0x��"), CategoryAttribute("��ʾ��ͨѶ����")]
        public byte Addresscode
        {
            get { return _addresscode; }
            set { _addresscode = value; }
        }

        private byte _displaySpeed;
        [DescriptionAttribute("��ʾ���������ƶ��ٶȡ�"), CategoryAttribute("��ʾ��ͨѶ����")]
        public byte DisplaySpeed
        {
            get { return _displaySpeed; }
            set { _displaySpeed = value; }
        }

        private DisplayType _displayType;
        [DescriptionAttribute("��ʾ�������ã�Zhidisp=0x30ֱ����ʾ,Gundisp=0x31������������ʾ��"), CategoryAttribute("��ʾ��ͨѶ����")]
        public DisplayType DisplayType
        {
            get { return _displayType; }
            set { _displayType = value; }
        }

        //==============��ʾ�����ý���=========================

        private int _voiceIndex;
        [DescriptionAttribute("���������š����ڡ�������塱->���������в쿴���������⣬�����ñ�����ֵΪ�����������ż�1��"), CategoryAttribute("����")]
        public int VoiceIndex
        {
            get { return _voiceIndex; }
            set { _voiceIndex = value; }
        }
    }

    #endregion 
}

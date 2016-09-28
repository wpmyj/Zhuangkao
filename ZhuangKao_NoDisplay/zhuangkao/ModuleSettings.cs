using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;
using zhuangkao.Displaycomm;

namespace zhuangkao 
{
    #region ���ö���ģ����

    

    public class ModuleSettings
    {
        
        private int _chetype;//�����ͣ�0��С������0�Ǵ�
        [DescriptionAttribute("���������ã�0ΪС������0Ϊ�󳵡�"), CategoryAttribute("���߸���������")]
        public int CheType
        {
            set { _chetype = value; }
            get { return _chetype; }
        }

        private int _pbgan_s;
        [DescriptionAttribute("С����ͨ���ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int PbGan_s
        {
            set { _pbgan_s = value; }
            get { return _pbgan_s; }
        }

        private int _pbxian_s;
        [DescriptionAttribute("С����ͨ���ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int PbXian_s
        {
            set { _pbxian_s = value; }
            get { return _pbxian_s; }
        }

        private int _pbche_s;
        [DescriptionAttribute("С����ͨ���ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int PbChe_s
        {
            set { _pbche_s = value; }
            get { return _pbche_s; }
        }


        private int _pbgan_l;
        [DescriptionAttribute("����ͨ���ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int PbGan_l
        {
            set { _pbgan_l = value; }
            get { return _pbgan_l; }
        }

        private int _pbxian_l;
        [DescriptionAttribute("����ͨ���ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int PbXian_l
        {
            set { _pbxian_l = value; }
            get { return _pbxian_l; }
        }

        private int _pbche_l;
        [DescriptionAttribute("����ͨ���ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int PbChe_l
        {
            set { _pbche_l = value; }
            get { return _pbche_l; }
        }

        private int _adminpbgan_s;
        [DescriptionAttribute("����ԱС�����ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int AdminPbGan_s
        {
            set { _adminpbgan_s = value; }
            get { return _adminpbgan_s; }
        }


        private int _adminpbxian_s;
        [DescriptionAttribute("����ԱС�����ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int AdminPbXian_s
        {
            set { _adminpbxian_s = value; }
            get { return _adminpbxian_s; }
        }

        private int _adminpbgan_l;
        [DescriptionAttribute("����Ա�󳵸��ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int AdminPbGan_l
        {
            set { _adminpbgan_l = value; }
            get { return _adminpbgan_l; }
        }

        private int _adminpbxian_l;
        [DescriptionAttribute("����Ա�����ź����Ρ�"), CategoryAttribute("���߸���������")]
        public int AdminPbXian_l
        {
            set { _adminpbxian_l = value; }
            get { return _adminpbxian_l; }
        }

        private int _adminqfgan_s;
        [DescriptionAttribute("����ԱС�����ź�ȡ����"), CategoryAttribute("���߸���������")]
        public int AdminQFGan_s
        {
            set { _adminqfgan_s = value; }
            get { return _adminqfgan_s; }
        }


        private int _adminqfxian_s;
        [DescriptionAttribute("����ԱС�����ź�ȡ����"), CategoryAttribute("���߸���������")]
        public int AdminQFXian_s
        {
            set { _adminqfxian_s = value; }
            get { return _adminqfxian_s; }
        }

        private int _adminqfgan_l;
        [DescriptionAttribute("����Ա�󳵸��ź�ȡ����"), CategoryAttribute("���߸���������")]
        public int AdminQFGan_l
        {
            set { _adminqfgan_l = value; }
            get { return _adminqfgan_l; }
        }

        private int _adminqfxian_l;
        [DescriptionAttribute("����Ա�����ź�ȡ����"), CategoryAttribute("���߸���������")]
        public int AdminQFXian_l
        {
            set { _adminqfxian_l = value; }
            get { return _adminqfxian_l; }
        }

        private int _prepareDuration;
        [DescriptionAttribute("�����ϳ�����ʼ����֮��ȴ�ʱ��"), CategoryAttribute("����״̬ʱ������")]
        public int PrepareDuration
        {
            set { _prepareDuration = value; }
            get { return _prepareDuration; }
        }

        private int _state2_time_s;
        [DescriptionAttribute("״̬2ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State2_Time_s
        {
            set { _state2_time_s = value; }
            get { return _state2_time_s; }
        }

        private int _state3_time_s;
        [DescriptionAttribute("״̬3ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State3_Time_s
        {
            set { _state3_time_s = value; }
            get { return _state3_time_s; }
        }

        private int _state4_time_s;
        [DescriptionAttribute("״̬4ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State4_Time_s
        {
            set { _state4_time_s = value; }
            get { return _state4_time_s; }
        }

        private int _state4i_time_s;
        [DescriptionAttribute("״̬4iʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State4i_Time_s
        {
            set { _state4i_time_s = value; }
            get { return _state4i_time_s; }
        }

        private int _state5_time_s;
        [DescriptionAttribute("״̬5ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State5_Time_s
        {
            set { _state5_time_s = value; }
            get { return _state5_time_s; }
        }

        private int _state6_time_s;
        [DescriptionAttribute("״̬6ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State6_Time_s
        {
            set { _state6_time_s = value; }
            get { return _state6_time_s; }
        }

        private int _state7_time_s;
        [DescriptionAttribute("״̬7ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State7_Time_s
        {
            set { _state7_time_s = value; }
            get { return _state7_time_s; }
        }

        private int _state8_time_s;
        [DescriptionAttribute("״̬8ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State8_Time_s
        {
            set { _state8_time_s = value; }
            get { return _state8_time_s; }
        }

        private int _state9_time_s;
        [DescriptionAttribute("״̬9ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State9_Time_s
        {
            set { _state9_time_s = value; }
            get { return _state9_time_s; }
        }

        private int _state10_time_s;
        [DescriptionAttribute("״̬10ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State10_Time_s
        {
            set { _state10_time_s = value; }
            get { return _state10_time_s; }
        }


        private int _state11_time_s;
        [DescriptionAttribute("״̬11ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State11_Time_s
        {
            set { _state11_time_s = value; }
            get { return _state11_time_s; }
        }

        private int _state12_time_s;
        [DescriptionAttribute("״̬12ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State12_Time_s
        {
            set { _state12_time_s = value; }
            get { return _state12_time_s; }
        }

        private int _state13_time_s;
        [DescriptionAttribute("״̬13ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State13_Time_s
        {
            set { _state13_time_s = value; }
            get { return _state13_time_s; }
        }

        private int _state14_time_s;
        [DescriptionAttribute("״̬14ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State14_Time_s
        {
            set { _state14_time_s = value; }
            get { return _state14_time_s; }
        }

        private int _state14i_time_s;
        [DescriptionAttribute("״̬14iʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State14i_Time_s
        {
            set { _state14i_time_s = value; }
            get { return _state14i_time_s; }
        }

        private int _state15_time_s;
        [DescriptionAttribute("״̬15ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State15_Time_s
        {
            set { _state15_time_s = value; }
            get { return _state15_time_s; }
        }

        private int _state16_time_s;
        [DescriptionAttribute("״̬16ʱ�䡣"), CategoryAttribute("С������״̬ʱ������")]
        public int State16_Time_s
        {
            set { _state16_time_s = value; }
            get { return _state16_time_s; }
        }

        private int _state2_time_l;
        [DescriptionAttribute("״̬2ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State2_Time_l
        {
            set { _state2_time_l = value; }
            get { return _state2_time_l; }
        }

        private int _state3_time_l;
        [DescriptionAttribute("״̬3ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State3_Time_l
        {
            set { _state3_time_l = value; }
            get { return _state3_time_l; }
        }

        private int _state4_time_l;
        [DescriptionAttribute("״̬4ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State4_Time_l
        {
            set { _state4_time_l = value; }
            get { return _state4_time_l; }
        }

        private int _state4i_time_l;
        [DescriptionAttribute("״̬4iʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State4i_Time_l
        {
            set { _state4i_time_l = value; }
            get { return _state4i_time_l; }
        }

        private int _state5_time_l;
        [DescriptionAttribute("״̬5ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State5_Time_l
        {
            set { _state5_time_l = value; }
            get { return _state5_time_l; }
        }

        private int _state6_time_l;
        [DescriptionAttribute("״̬6ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State6_Time_l
        {
            set { _state6_time_l = value; }
            get { return _state6_time_l; }
        }

        private int _state7_time_l;
        [DescriptionAttribute("״̬7ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State7_Time_l
        {
            set { _state7_time_l = value; }
            get { return _state7_time_l; }
        }

        private int _state8_time_l;
        [DescriptionAttribute("״̬8ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State8_Time_l
        {
            set { _state8_time_l = value; }
            get { return _state8_time_l; }
        }

        private int _state9_time_l;
        [DescriptionAttribute("״̬9ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State9_Time_l
        {
            set { _state9_time_l = value; }
            get { return _state9_time_l; }
        }

        private int _state10_time_l;
        [DescriptionAttribute("״̬10ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State10_Time_l
        {
            set { _state10_time_l = value; }
            get { return _state10_time_l; }
        }


        private int _state11_time_l;
        [DescriptionAttribute("״̬11ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State11_Time_l
        {
            set { _state11_time_l = value; }
            get { return _state11_time_l; }
        }

        private int _state12_time_l;
        [DescriptionAttribute("״̬12ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State12_Time_l
        {
            set { _state12_time_l = value; }
            get { return _state12_time_l; }
        }

        private int _state13_time_l;
        [DescriptionAttribute("״̬13ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State13_Time_l
        {
            set { _state13_time_l = value; }
            get { return _state13_time_l; }
        }

        private int _state14_time_l;
        [DescriptionAttribute("״̬14ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State14_Time_l
        {
            set { _state14_time_l = value; }
            get { return _state14_time_l; }
        }

        private int _state14i_time_l;
        [DescriptionAttribute("״̬14iʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State14i_Time_l
        {
            set { _state14i_time_l = value; }
            get { return _state14i_time_l; }
        }

        private int _state15_time_l;
        [DescriptionAttribute("״̬15ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State15_Time_l
        {
            set { _state15_time_l = value; }
            get { return _state15_time_l; }
        }

        private int _state16_time_l;
        [DescriptionAttribute("״̬16ʱ�䡣"), CategoryAttribute("�󳵿���״̬ʱ������")]
        public int State16_Time_l
        {
            set { _state16_time_l = value; }
            get { return _state16_time_l; }
        }

        private int _maxstopcount;
        [DescriptionAttribute("�����ͣ���������ѷ�����")]
        public int MaxStopCount
        {
            set 
            {
                if (value < 2)
                {
                    _maxstopcount = 2;
                }
                else
                {
                    _maxstopcount = value;
                }
            }
            get{ return _maxstopcount;}
        }

        private string _locallinkstr;
        [DescriptionAttribute("���������ַ�����"), CategoryAttribute("���ݿ�����")]
        public string LocalLinkStr
        {
            set { _locallinkstr = value; }
            get { return _locallinkstr; }
        }

        private string _soundksks;//��ʼ����
        public string SoundKsks
        {
            set { _soundksks = value; }
            get { return _soundksks; }
        }

        private int _state8delay;
        [DescriptionAttribute("״̬8��ʱʱ�䡣"), CategoryAttribute("��ʱ����")]
        public int State8delay
        {
            get { return _state8delay; }
            set { _state8delay = value; }
        }


        private int _delaytime;
        [DescriptionAttribute("��ȡ�źż����"), CategoryAttribute("��ʱ����")]
        public int Delaytime
        {
            get { return _delaytime; }
            set { _delaytime = value; }
        }

        private int _lvbodelaytime;
        [DescriptionAttribute("д��ַ�����ַ����ʱ������"), CategoryAttribute("��ʱ����")]
        public int Lvbodelaytime
        {
            get { return _lvbodelaytime; }
            set { _lvbodelaytime = value; }
        }

        private int _gan_s;
        [DescriptionAttribute("С�����ź�λ�ö���"), CategoryAttribute("���߸���������")]
        public int Gan_s
        {
            get { return _gan_s; }
            set { _gan_s = value; }
        }

        private int _gan_l;
        [DescriptionAttribute("�󳵸��ź�λ�ö���"), CategoryAttribute("���߸���������")]
        public int Gan_l
        {
            get { return _gan_l; }
            set { _gan_l = value; }
        }

        private int _xian_s;
        [DescriptionAttribute("С�����ź�λ�ö���"), CategoryAttribute("���߸���������")]
        public int Xian_s
        {
            get { return _xian_s; }
            set { _xian_s = value; }
        }

        private int _xian_l;
        [DescriptionAttribute("�����ź�λ�ö���"), CategoryAttribute("���߸���������")]
        public int Xian_l
        {
            get { return _xian_l; }
            set { _xian_l = value; }
        }

        private int _che;
        [DescriptionAttribute("���ź�λ�ö���"), CategoryAttribute("���߸���������")]
        public int Che
        {
            get { return _che; }
            set { _che = value; }
        }

        private string _ipaddress;
        [DescriptionAttribute("��������IP��ַ��"), CategoryAttribute("���ݿ�����")]
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        //t1,t2,t3ʱ������Ϊ��λ������������ʱ��1000תΪ����
        private int _t1;
        [DescriptionAttribute("���⵲8����ʱt1���ͬͣ����"), CategoryAttribute("��ʱ����")]
        public int T1
        {
            get { return _t1; }
            set { _t1 = value; }
        }
        
        private int _t2;
        public int T2
        {
            get { return _t2; }
            set { _t2 = value; }
        }

        private int _t3;
        [DescriptionAttribute("�����ˣ���8�������2�ߣ���ʱt3���ͬͣ����"), CategoryAttribute("��ʱ����")]
        public int T3
        {
            get { return _t3; }
            set { _t3 = value; }
        }
      
        private string _ksdd;
        [DescriptionAttribute("���Եص㡣")]
        public string Ksdd
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }

        private int _useidcardlogin; //�Ƿ���������֤��¼
        public int UseidcardLogin
        {
            get { return _useidcardlogin; }
            set { _useidcardlogin = value; }
        }

        //private int _useidcardexam;//�Ƿ���������֤���뿼��
        //public int UseidcardExam
        //{
        //    get { return _useidcardexam; }
        //    set { _useidcardexam = value; }
        //}

        private bool _isNetwork;
        [DescriptionAttribute("�Ƿ�ʹ�����硣")]
        public bool IsNetwork
        {
            get { return _isNetwork; }
            set { _isNetwork = value; }
        }

        private string _ServerIP;
        [DescriptionAttribute("�������ķ�����IP��ַ��")]
        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        private int _devnum;
        [DescriptionAttribute("�豸��ţ������Ƿ�0�Ĵ����֡�")]
        public int Devnum
        {
            get { return _devnum; }
            set { _devnum = value; }
        }

        private int _jifennum;
       // [DefaultValue(20)]
        [DescriptionAttribute("���ִ�����")]
        public int Jifennum
        {
            get { return _jifennum; }
            set { _jifennum = value; }
        }

        //----------��ӡ��������---------------------
        private int ksxm_x;
        [DescriptionAttribute("��������X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksxm_x
        {
            get { return ksxm_x; }
            set { ksxm_x = value; }
        }

        private int ksxm_y;
        [DescriptionAttribute("��������Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksxm_y
        {
            get { return ksxm_y; }
            set { ksxm_y = value; }
        }

        private int ksdd_x;
        [DescriptionAttribute("���Եص�X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksdd_x
        {
            get { return ksdd_x; }
            set { ksdd_x = value; }
        }

        private int ksdd_y;
        [DescriptionAttribute("���Եص�Y���ꡣ"),CategoryAttribute("��ӡ����")]
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
        }

        private int kscj_x;
        [DescriptionAttribute("���Գɼ�X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscj_x
        {
            get { return kscj_x; }
            set { kscj_x = value; }
        }

        private int kscj_y;
        [DescriptionAttribute("���Գɼ�Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscj_y
        {
            get { return kscj_y; }
            set { kscj_y = value; }
        }

        private int ksrq_x;
        [DescriptionAttribute("��������X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksrq_x
        {
            get { return ksrq_x; }
            set { ksrq_x = value; }
        }

        private int ksrq_y;
        [DescriptionAttribute("��������Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksrq_y
        {
            get { return ksrq_y; }
            set { ksrq_y = value; }
        }

        private int ksyxm_x;
        [DescriptionAttribute("����Ա����X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksyxm_x
        {
            get { return ksyxm_x; }
            set { ksyxm_x = value; }
        }

        private int ksyxm_y;
        [DescriptionAttribute("����Ա����Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksyxm_y
        {
            get { return ksyxm_y; }
            set { ksyxm_y = value; }
        }

        private int tiaomaimg_x;
        [DescriptionAttribute("������X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Tiaomaimg_x
        {
            get { return tiaomaimg_x; }
            set { tiaomaimg_x = value; }
        }

        private int tiaomaimg_y;
        [DescriptionAttribute("������Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Tiaomaimg_y
        {
            get { return tiaomaimg_y; }
            set { tiaomaimg_y = value; }
        }
        //----------��ӡ���ý���-----------------------------------------

        //----------�������ÿ�ʼ-----------------------------------------
        private int voiceIndex;
        [DescriptionAttribute("��������"), CategoryAttribute("����")]
        public int VoiceIndex
        {
            get { return voiceIndex; }
            set { voiceIndex = value; }
        }
        //----------�������ý���-----------------------------------------

        //----------��ʾ�����ÿ�ʼ---------------------------------------
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
        //------------��ʾ�����ý���-----------------------------------------------------------

        //----------����ͨ�����ÿ�ʼ-----------------------------------------
        private int _yuntaichannel;
        [DescriptionAttribute("��̨�����ͨ��"), CategoryAttribute("����")]
        public int YuntaiChannel
        {
            get { return _yuntaichannel; }
            set { _yuntaichannel = value; }
        }

        private int _gaochannel;
        [DescriptionAttribute("��̨�����ͨ��"), CategoryAttribute("����")]
        public int GaoChannel
        {
            get { return _gaochannel; }
            set { _gaochannel = value; }
        }
        //----------����ͨ�����ý���-----------------------------------------
    }

    #endregion 
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Util
{
    public class CSettings
    {
        //���Եص�
        private string _ksdd = string.Empty;
        [DescriptionAttribute("���Եص�")]
        public string KSDD
        {
            get { return _ksdd; }
            set { _ksdd = value; }
        }


        //�Ƿ��ü���ģ���ź�
        private bool _isSimulate;
        [DescriptionAttribute("�Ƿ��ü���ģ���ź�")]
        public bool IsSimulate
        {
            get { return _isSimulate; }
            set { _isSimulate = value; }
        }


        //��ȡ�źż����
        private int _delaytime;
        [DescriptionAttribute("��ȡ�źż��")]
        public int Delaytime
        {
            get { return _delaytime; }
            set { _delaytime = value; }
        }


        //д��ַ�����ַ����ʱ������
        private int _lvbodelaytime;
        [DescriptionAttribute("д��ַ�����ַ����ʱ����")]
        public int Lvbodelaytime
        {
            get { return _lvbodelaytime; }
            set { _lvbodelaytime = value; }
        }


        //�ź�����
        private SignalConfigures _signConfig = new SignalConfigures();
        [DescriptionAttribute("�ź�����")]
        public SignalConfigures SignConfig
        {
            get { return _signConfig; }
            set { _signConfig = value; }
        }


        //��ӡ����
        private PrintSettings _printSettings = new PrintSettings();
        [DescriptionAttribute("��ӡ����")]
        public PrintSettings PrintConfig
        {
            get { return _printSettings; }
            set { _printSettings = value; }
        }

        virtual public CSettings GetCommonSettings()
        {
            return this;
        }
    }


    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��λ��")]
    public class GanPosition
    {
       
        //���
        private int _index;
        [DescriptionAttribute("���")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //x����
        private int _x;
        [DescriptionAttribute("x����")]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        //y����
        private int _y;
        [DescriptionAttribute("y����")]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��λ��")]
    public class XianPosition
    {

       
        //���
        private int _index;
        [DescriptionAttribute("���")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //���x����
        private int _x1;
        [DescriptionAttribute("���x����")]
        public int X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }

        //���y����
        private int _y1;
        [DescriptionAttribute("���y����")]
        public int Y1
        {
            get { return _y1; }
            set { _y1 = value; }
        }

        //�յ�x����
        private int _x2;
        [DescriptionAttribute("�յ�x����")]
        public int X2
        {
            get { return _x2; }
            set { _x2 = value; }
        }

        //�յ�y����
        private int _y2;
        [DescriptionAttribute("�յ�y����")]
        public int Y2
        {
            get { return _y2; }
            set { _y2 = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter)), DescriptionAttribute("��λ��")]
    public class ChePosition
    {
        //��ʼ�Ƕ�
        private int _angle;
        [DescriptionAttribute("��ʼ�Ƕ�")]
        public int Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        //x����
        private int _x;
        [DescriptionAttribute("x����")]
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        //y����
        private int _y;
        [DescriptionAttribute("y����")]
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class GanAppearance
    {
        private string _normal = string.Empty;
        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
        private string _error = string.Empty;
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        private string _shield = string.Empty;
        public string Shield
        {
            get { return _shield; }
            set { _shield = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class XianAppearance
    {
        private string _normal = string.Empty;
        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
        private string _error = string.Empty;
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        private string _shield = string.Empty;
        public string Shield
        {
            get { return _shield; }
            set { _shield = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class CheAppearance
    {
        private string _normal = string.Empty;
        public string Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Appearance
    {
        private GanAppearance _gan = new GanAppearance();
        public GanAppearance Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }
        private XianAppearance _xian = new XianAppearance();
        public XianAppearance Xian
        {
            get { return _xian; }
            set { _xian = value; }
        }
        private CheAppearance _che = new CheAppearance();
        public CheAppearance Che
        {
            get { return _che; }
            set { _che = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SignalConfigures
    {
        //���߳��źŵ�λ��
        private int _ganpos;
        [DescriptionAttribute("���źŵ�λ��")]
        public int GanPosition
        {
            get { return _ganpos; }
            set { _ganpos = value; }
        }
        private int _xianpos;
        [DescriptionAttribute("���źŵ�λ��")]
        public int XianPosition
        {
            get { return _xianpos; }
            set { _xianpos = value; }
        }
        private int _chepos;
        [DescriptionAttribute("���źŵ�λ��")]
        public int ChePosition
        {
            get { return _chepos; }
            set { _chepos = value; }
        }

        //���߳��źų���
        private uint _ganlen;
        [DescriptionAttribute("���źų���")]
        public uint GanLength
        {
            get { return _ganlen; }
            set { _ganlen = value; }
        }
        private uint _xianlen;
        [DescriptionAttribute("���źų���")]
        public uint XianLength
        {
            get { return _xianlen; }
            set { _xianlen = value; }
        }
        private uint _chelen;
        [DescriptionAttribute("���źų���")]
        public uint CheLength
        {
            get { return _chelen; }
            set { _chelen = value; }
        }

        //�����źŻ��ִ���
        private int _ganjf;
        [DescriptionAttribute("���źŻ��ִ���")]
        public int GanJiFen
        {
            get { return _ganjf; }
            set { _ganjf = value; }
        }
        private int _xianjf;
        [DescriptionAttribute("���źŻ��ִ���")]
        public int XianJiFen
        {
            get { return _xianjf; }
            set { _xianjf = value; }
        }

        //����Աȡ������
        private int _adminQFGan;
        [DescriptionAttribute("����Ա��ȡ������")]
        public int AdminQFGan
        {
            get { return _adminQFGan; }
            set { _adminQFGan = value; }
        }
        private int _adminQFXian;
        [DescriptionAttribute("����Ա��ȡ������")]
        public int AdminQFXian
        {
            get { return _adminQFXian; }
            set { _adminQFXian = value; }
        }

        //����Ա��������
        private int _adminPBGan;
        [DescriptionAttribute("����Ա����������")]
        public int AdminPBGan
        {
            get { return _adminPBGan; }
            set { _adminPBGan = value; }
        }
        private int _adminPBXian;
        [DescriptionAttribute("����Ա����������")]
        public int AdminPBXian
        {
            get { return _adminPBXian; }
            set { _adminPBXian = value; }
        }

        //��ͨ�û���������
        private int _PBGan;
        [DescriptionAttribute("��ͨ�û�����������")]
        public int PBGan
        {
            get { return _PBGan; }
            set { _PBGan = value; }
        }
        private int _PBXian;
        [DescriptionAttribute("��ͨ�û�����������")]
        public int PBXian
        {
            get { return _PBXian; }
            set { _PBXian = value; }
        }
        private int _PBChe;
        [DescriptionAttribute("��ͨ�û�����������")]
        public int PBChe
        {
            get { return _PBChe; }
            set { _PBChe = value; }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class PrintSettings
    {
        private bool isprint;
        [DescriptionAttribute("�Ƿ���Ҫ��ӡ����"), CategoryAttribute("��ӡ����")]
        public bool Isprint
        {
            get { return isprint; }
            set { isprint = value; }
        }
        private bool isprintnopass;
        [DescriptionAttribute("�Ƿ��ӡ���ϸ񿼱�"), CategoryAttribute("��ӡ����")]
        public bool IsprintNopass
        {
            get { return isprintnopass; }
            set { isprintnopass = value; }
        }


        private int _fontSize;
        [DescriptionAttribute("��ӡ�����С��"), CategoryAttribute("��ӡ����")]
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

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
        [DescriptionAttribute("���Եص�Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Ksdd_y
        {
            get { return ksdd_y; }
            set { ksdd_y = value; }
        }


        private int kscx_x;
        [DescriptionAttribute("���Գ���X���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscx_x
        {
            get { return kscx_x; }
            set { kscx_x = value; }
        }

        private int kscx_y;
        [DescriptionAttribute("���Գ���Y���ꡣ"), CategoryAttribute("��ӡ����")]
        public int Kscx_y
        {
            get { return kscx_y; }
            set { kscx_y = value; }
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
    }



   



}

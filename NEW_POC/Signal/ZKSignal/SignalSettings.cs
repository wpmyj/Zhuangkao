using System;
using System.Collections.Generic;
using System.Text;
using Signal;

namespace Signal.ZKSignal
{
    public class SignalSettings : Util.CSettings 
    {
        //������
        private CheType _carType;
        public CheType CarType
        {
            get { return _carType; }
            set { _carType = value; }
        }

        //���ִ�����
        private int _jifennum;
        public int Jifennum
        {
            get { return _jifennum; }
            set { _jifennum = value; }
        }

        private Configures _bigCar = new Configures();
        public Configures BigCar
        {
            get { return _bigCar; }
            set { _bigCar = value; }
        }

        private Configures _smallCar = new Configures();
        public Configures SmallCar
        {
            get { return _smallCar; }
            set { _smallCar = value; }
        }
    }
    public class Configures
    {
        //���߳��źŵ�λ��
        private int _gan;
        public int Gan
        {
            get { return _gan; }
            set { _gan = value; }
        }
        private int _xian;
        public int Xian
        {
            get { return _xian; }
            set { _xian = value; }
        }
        int _che;
        public int Che
        {
            get { return _che; }
            set { _che = value; }
        }

        //����Աȡ������
        int _adminQFGan;
        public int AdminQFGan
        {
            get { return _adminQFGan; }
            set { _adminQFGan = value; }
        }
        int _adminQFXian;
        public int AdminQFXian
        {
            get { return _adminQFXian; }
            set { _adminQFXian = value; }
        }

        //����Ա��������
        int _adminPBGan;
        public int AdminPBGan
        {
            get { return _adminPBGan; }
            set { _adminPBGan = value; }
        }
        int _adminPBXian;
        public int AdminPBXian
        {
            get { return _adminPBXian; }
            set { _adminPBXian = value; }
        }

        //��ͨ�û���������
        int _PBGan;
        public int PBGan
        {
            get { return _PBGan; }
            set { _PBGan = value; }
        }
        int _PBXian;
        public int PBXian
        {
            get { return _PBXian; }
            set { _PBXian = value; }
        }
        int _PBChe;
        public int PBChe
        {
            get { return _PBChe; }
            set { _PBChe = value; }
        }
    }
}

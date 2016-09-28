using System;
using System.Collections.Generic;
using System.Text;
using Cn.Youdundianzi.Core.Signal;


namespace Cn.Youdundianzi.Share.Signal.JKY
{
    public class CJKYMonData : IMonData
    {
        private CSignals Gan;
        private CSignals Xian;
        private CSignals Che;
        private readonly uint GAN_LENGTH;
        private readonly uint XIAN_LENGTH;
        private readonly uint CHE_LENGTH;



        public CJKYMonData(SignLength signLen)
        {
            GAN_LENGTH = signLen.GAN_LENGTH;
            XIAN_LENGTH = signLen.XIAN_LENGTH;
            CHE_LENGTH = signLen.CHE_LENGTH;

            Gan = new CSignals(SignalType.GAN, GAN_LENGTH);
            Xian = new CSignals(SignalType.XIAN, XIAN_LENGTH);
            Che = new CSignals(SignalType.CHE, CHE_LENGTH);
        }

        public void Copy(IMonData src)
        {
            Gan = src.GetSignals(SignalType.GAN);
            Xian = src.GetSignals(SignalType.XIAN);
            Che = src.GetSignals(SignalType.CHE);
        }

        public bool Equals(IMonData src)
        {
            for (int i = 0; i < GAN_LENGTH; i++)
                if (Gan[i] != src.GetSignal(SignalType.GAN, i))
                    return false;
            for (int i = 0; i < XIAN_LENGTH; i++)
                if (Xian[i] != src.GetSignal(SignalType.XIAN, i))
                    return false;
            for (int i = 0; i < CHE_LENGTH; i++)
                if (Che[i] != src.GetSignal(SignalType.CHE, i))
                    return false;
            return true;
        }

        public sbyte GetSignal(SignalType type, int index)
        {
            switch (type)
            {
                case SignalType.GAN:
                    return Gan[index];
                case SignalType.XIAN:
                    return Xian[index];
                case SignalType.CHE:
                    return Che[index];
                default:
                    return 0;
            }
        }

        public CSignals GetSignals(SignalType type)
        {
            switch (type)
            {
                case SignalType.GAN:
                    return Gan;
                case SignalType.XIAN:
                    return Xian;
                case SignalType.CHE:
                    return Che;
                default:
                    return null;
            }
        }

        public void SetSignals(SignalType type, CSignals src)
        {
            switch (type)
            {
                case SignalType.GAN:
                    Gan = src;
                    break;
                case SignalType.XIAN:
                    Xian = src;
                    break;
                case SignalType.CHE:
                    Che = src;
                    break;
                default:
                    break;
            }
        }
    }
}

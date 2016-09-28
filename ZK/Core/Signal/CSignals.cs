using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Core.Signal
{
    public enum SignalType
    {
        GAN,
        XIAN,
        CHE
    }

    public enum BaseCarSignalEnum
    {
        FORWARD = 0,
        BACK = 1,
        STOP = 2,
        FLAMEOUT = 3
    }

    public struct SignLength
    {
        public uint GAN_LENGTH;
        public uint XIAN_LENGTH;
        public uint CHE_LENGTH;
    }

    public class CSignals
    {
        private SignalType _type;
        private sbyte[] _signals;
        private uint _length;

        public CSignals(SignalType type, uint length)
        {
            if (length == 0)
                throw new Exception("Invalid signal length.");
            this._type = type;
            this._length = length;
            this._signals = new sbyte[length];
            for (int i = 0; i < length; i++)
                this._signals[i] = 0;
        }

        public SignalType Type
        {
            get { return _type; }
        }

        public sbyte this[int ndx]
        {
            get { return _signals[ndx]; }
            set { _signals[ndx] = value; }
        }

        public uint Length
        {
            get { return _length; }
        }

        public sbyte[] SignalArray
        {
            get { return _signals; }
            set { _signals = value; }
        }
    }
}

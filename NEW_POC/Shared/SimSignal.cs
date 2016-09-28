using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class SimSignal
    {
        public const uint RAW_LENGTH = 6;
        byte[] signal = new byte[RAW_LENGTH];
        public void SetBit(int index, int position)
        {
            byte[] t ={ 1, 2, 4, 8, 16, 32, 64, 128 };
            byte temp = signal[index];
            temp = (byte)(temp | t[position]);
            signal[index] = temp;
        }

        public void UnSetBit(int index, int position)
        {
            byte[] t ={ 0xfe, 0xfd, 0xfb, 0xf7, 0xef, 0xdf, 0xbf, 0x7f };
            byte temp = signal[index];
            temp = (byte)(temp & t[position]);
            signal[index] = temp;
        }

        public void SwitchBit(int index, int position)
        {
            byte[] t ={ 1, 2, 4, 8, 16, 32, 64, 128 };
            byte temp = signal[index];
            if ((temp & t[position]) == 0)
                SetBit(index, position);
            else
                UnSetBit(index, position);
        }

        public byte GetByte(int index)
        {
            return signal[index];
        }
    }
}

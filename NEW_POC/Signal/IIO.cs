using System;
using System.Collections.Generic;
using System.Text;

namespace Signal
{
    public interface IIO
    {
        byte read(int addr);
        void write(int addr, byte data);
        void close();
    }
}

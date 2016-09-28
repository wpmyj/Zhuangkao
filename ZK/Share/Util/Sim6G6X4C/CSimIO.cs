using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Core.Signal;

namespace Cn.Youdundianzi.Share.Util.Sim6G6X4C
{
    class SimSignal
    {
        public const uint RAW_LENGTH = 6;
        byte[] signal = new byte[RAW_LENGTH];
        public void SetBit(int index, int position)
        {
            byte[] t ={ 1, 2, 4, 8, 16, 32, 64, 128 };
            byte temp = signal[index];
            //temp = (byte)(temp | t[position]);
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

    public class CSimIO : IIO, IHotKeyReceiver 
    {
        SignalConfigures settings;
        int gan_loc, xian_loc, che_loc;
        SimSignal signal = new SimSignal();
        byte returnVal;
        byte tempVal;
        CHotkeyApp _hkapp;

        public CSimIO(IntPtr HotKeyHandle, SignalConfigures sets)
        {
            settings = sets;
            gan_loc = settings.GanPosition;
            xian_loc = settings.XianPosition;
            che_loc = settings.ChePosition;
            
            _hkapp = new CHotkeyApp(HotKeyHandle, this);
            _hkapp.StartHotkey();
        }

        ~CSimIO()
        {
            if (_hkapp != null)
                _hkapp.StopHotkey();
        }

        #region IIO Members

        public byte read(int addr)
        {
            return returnVal;
        }

        public void write(int addr, byte data)
        {
            if (addr == 0x378)
                returnVal = signal.GetByte((int)data);
        }

        public void close()
        {
            signal = new SimSignal();
            returnVal = 0;
            if (_hkapp != null)
                _hkapp.StopHotkey();
        }

        #endregion

        private void SetCheSignal(int index)
        {
            signal.SetBit(index, che_loc);
        }

        private void UnSetCheSignal(int index)
        {
            signal.UnSetBit(index, che_loc);
        }

        private void SwitchXianSignal(int index)
        {
            signal.SwitchBit(index, xian_loc);
        }

        private void SwitchGanSignal(int index)
        {
            signal.SwitchBit(index, gan_loc);
        }

        #region IHotKeyReceiver Members

        public void ReceiveHotKey(System.Windows.Forms.Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    UnSetCheSignal(1);
                    UnSetCheSignal(2);
                    UnSetCheSignal(3);
                    SetCheSignal(0);
                    break;
                case Keys.Down:
                    UnSetCheSignal(0);
                    UnSetCheSignal(2);
                    UnSetCheSignal(3);
                    SetCheSignal(1);
                    break;
                case Keys.Space:
                    UnSetCheSignal(0);
                    UnSetCheSignal(1);
                    UnSetCheSignal(3);
                    SetCheSignal(2);
                    break;
                case Keys.X:
                    UnSetCheSignal(0);
                    UnSetCheSignal(1);
                    UnSetCheSignal(2);
                    SetCheSignal(3);
                    break;
                case Keys.D1:
                    SwitchXianSignal(0);
                    break;
                case Keys.D2:
                    SwitchXianSignal(1);
                    break;
                case Keys.D3:
                    SwitchXianSignal(2);
                    break;
                case Keys.D4:
                    SwitchXianSignal(3);
                    break;
                case Keys.D5:
                    SwitchXianSignal(4);
                    break;
                case Keys.D6:
                    SwitchXianSignal(5);
                    break;
                case Keys.Q:
                    SwitchGanSignal(0);
                    break;
                case Keys.W:
                    SwitchGanSignal(1);
                    break;
                case Keys.E:
                    SwitchGanSignal(2);
                    break;
                case Keys.A:
                    SwitchGanSignal(3);
                    break;
                case Keys.S:
                    SwitchGanSignal(4);
                    break;
                case Keys.D:
                    SwitchGanSignal(5);
                    break;
                case Keys.P:
                    break;
            }
        }

        #endregion
    }
}

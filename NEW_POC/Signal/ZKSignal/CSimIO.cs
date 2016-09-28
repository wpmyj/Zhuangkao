using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Util;
using Signal;

namespace Signal.ZKSignal
{
    public class CSimIO : IIO, IHotKeyReceiver 
    {
        SignalSettings settings = new SignalSettings();
        int b_gan_loc, s_gan_loc, b_xian_loc, s_xian_loc, b_che_loc, s_che_loc;
        CheType _carType;
        SimSignal signal = new SimSignal();
        byte returnVal;
        byte tempVal;
        CHotkeyApp _hkapp;

        public CSimIO(IntPtr HotKeyHandle)
        {
            settings = (SignalSettings)Util.ModuleConfig.GetSettings(settings.GetType(), "signal.config");
            b_gan_loc = settings.BigCar.Gan;
            b_xian_loc = settings.BigCar.Xian;
            b_che_loc = settings.BigCar.Che;
            s_gan_loc = settings.SmallCar.Gan;
            s_xian_loc = settings.SmallCar.Xian;
            s_che_loc = settings.SmallCar.Che;
            _carType = settings.CarType;
            
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
        }

        #endregion

        private class SimSignal
        {
            byte[] signal = new byte[6];
            public void SetBit(int index, int position)
            {
                byte[] t={ 1, 2, 4, 8, 16, 32, 64, 128 };
                byte temp = signal[index];
                temp =(byte)(temp | t[position]);
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

        private void SetCheSignal(int index)
        {
            if (_carType == CheType.BigCar)
                signal.SetBit(index, b_che_loc);
            else
                signal.SetBit(index, s_che_loc);
        }

        private void UnSetCheSignal(int index)
        {
            if (_carType == CheType.BigCar)
                signal.UnSetBit(index, b_che_loc);
            else
                signal.UnSetBit(index, s_che_loc);
        }

        private void SwitchXianSignal(int index)
        {
            if (_carType == CheType.BigCar)
                signal.SwitchBit(index, b_xian_loc);
            else
                signal.SwitchBit(index, s_xian_loc);
        }

        private void SwitchGanSignal(int index)
        {
            if (_carType == CheType.BigCar)
                signal.SwitchBit(index, b_gan_loc);
            else
                signal.SwitchBit(index, s_gan_loc);
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
                case Keys.D7:
                    SwitchXianSignal(6);
                    //if (_carType == CheType.BigCar)
                    //    signal.SwitchBit(3, s_gan_loc);
                    //else
                    //    signal.SwitchBit(3, s_gan_loc);
                    break;
                case Keys.D8:
                    SwitchXianSignal(7);
                    //if (_carType == CheType.BigCar)
                    //    signal.SwitchBit(5, b_gan_loc);
                    //else
                    //    signal.SwitchBit(5, s_gan_loc);
                    break;
                case Keys.D9:
                    SwitchXianSignal(8);
                    //if (_carType == CheType.BigCar)
                    //    signal.SwitchBit(3, b_gan_loc);
                    //else
                    //    signal.SwitchBit(3, b_gan_loc);
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

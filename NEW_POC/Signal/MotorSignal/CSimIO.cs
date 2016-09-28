using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Util;
using Shared;
using Signal;

namespace Signal.MotorSignal
{
    public class CSimIO : IIO, IHotKeyReceiver 
    {
        MotorSignalSettings settings;
        int gan_loc, xian_loc, che_loc;
        SimSignal signal = new SimSignal();
        byte returnVal;
        byte tempVal;
        CHotkeyApp _hkapp;

        public CSimIO(IntPtr HotKeyHandle, MotorSignalSettings sets)
        {
            settings = sets;
            gan_loc = settings.SignConfig.GanPosition;
            xian_loc = settings.SignConfig.XianPosition;
            che_loc = settings.SignConfig.ChePosition;
            
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

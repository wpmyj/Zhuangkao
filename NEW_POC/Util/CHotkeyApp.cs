using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class CHotkeyApp
    {
        private IHotKeyReceiver _receiver;
        private CHotKey _hotkey;
        private int _che_qj;
        private int _che_ht;
        private int _che_tc;
        private int _che_xh;
        private int _xian_1, _xian_2, _xian_3, _xian_4, _xian_5, _xian_6;
        private int _gan_1, _gan_2, _gan_3, _gan_4, _gan_5, _gan_6;
        private int _soundreplay;

        IntPtr hWnd;
       
        public CHotkeyApp(IntPtr hWnd,IHotKeyReceiver receiver)
        {
            _receiver = receiver;
            RegHotkey(hWnd);
        }


        private void RegHotkey(IntPtr phWnd)
        {
            hWnd = phWnd;
        }

        public void StartHotkey()
        {
            _hotkey = new CHotKey(hWnd);
            GC.Collect();
            _hotkey.OnHotkey += new HotkeyEventHandler(hot_key);
            _che_qj = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.Up, 0);
            _che_ht = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.Down, 0);
            _che_tc = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.Space, 0);
            _che_xh = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.X, 0);

            _xian_1 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D1, 0);
            _xian_2 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D2, 0);
            _xian_3 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D3, 0);
            _xian_4 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D4, 0);
            _xian_5 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D5, 0);
            _xian_6 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D6, 0);

            _gan_1 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.Q, 0);
            _gan_2 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.W, 0);
            _gan_3 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.E, 0);
            _gan_4 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.A, 0);
            _gan_5 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.S, 0);
            _gan_6 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D, 0);
            _soundreplay = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.P, 0);
        }

        public void StopHotkey()
        {
            try
            {
                _hotkey.OnHotkey -= new HotkeyEventHandler(hot_key);
                _hotkey.UnregisterHotkeys();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("»»º¸π ’œ£°");
            }
        }

        public void hot_key(int HotKey)
        {
            if (HotKey == _che_qj)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.Up);
                return;
            }
            if (HotKey == _che_ht)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.Down);
                return;
            }
            if (HotKey == _che_tc)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.Space);
                return;
            }
            if (HotKey == _che_xh)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.X);
                return;
            }
            if (HotKey == _xian_1)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D1);
                return;
            }
            if (HotKey == _xian_2)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D2);
                return;
            }
            if (HotKey == _xian_3)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D3);
                return;
            }
            if (HotKey == _xian_4)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D4);
                return;
            }
            if (HotKey == _xian_5)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D5);
                return;
            }
            if (HotKey == _xian_6)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D6);
                return;
            }

            if (HotKey == _gan_1)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.Q);
                return;
            }
            if (HotKey == _gan_2)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.W);
                return;
            }
            if (HotKey == _gan_3)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.E);
                return;
            }
            if (HotKey == _gan_4)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.A);
                return;
            }
            if (HotKey == _gan_5)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.S);
                return;
            }
            if (HotKey == _gan_6)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.D);
                return;
            }
            if (HotKey == _soundreplay)
            {
                this._receiver.ReceiveHotKey(System.Windows.Forms.Keys.P);
                return;
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace zhuangkao
{
    public class CHotkeyApp
    {
        private CHotKey _hotkey;
        private int _che_qj;
        private int _che_ht;
        private int _che_tc;
        private int _che_xh;
        private int _xian_2;
        private int _xian_4;
        private int _xian_7;
        private int _xian_8;
        private int _xian_9;
        private int _gan_3;
        private int _soundreplay;

        IntPtr hWnd;
       
        public CHotkeyApp(IntPtr hWnd)
        {
            RegHotkey(hWnd);
        }


        private void RegHotkey(IntPtr phWnd)
        {

            hWnd = phWnd;
            //_hotkey = new CHotKey(hWnd);
        }

        public void StartHotkey()
        {
            _hotkey = new CHotKey(hWnd);
            GC.Collect();
            _hotkey.OnHotkey += new HotkeyEventHandler(hot_key);
            _che_qj =_hotkey.RegisterHotkey(System.Windows.Forms.Keys.D1, 0);//定义快键(ALT + 1)
            _che_ht = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D2, 0);//定义快键((ALT + 2)
            _che_tc = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D3, 0);//定义快键(ALT + 3)
            _che_xh = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.D4, 0);//定义快键(ALT + 4)
            _xian_2 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.Q, 0);//定义快键(ALT + 4)
            _xian_4 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.W, 0);//定义快键(ALT + 4)

            _xian_7 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.E, 0);
            _xian_8 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.R, 0);
            _xian_9 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.T, 0);

            _gan_3 = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.F9, 0);
            _soundreplay  = _hotkey.RegisterHotkey(System.Windows.Forms.Keys.P, 0);
           
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
                System.Windows.Forms.MessageBox.Show("热键故障！");
            }
        }

        public void hot_key(int HotkeyID)
        {
            if (HotkeyID == _che_qj)
            {
                StateManager.CurrState.Che_qj();
                return;
            }
            if (HotkeyID == _che_ht)
            {
                StateManager.CurrState.Che_ht();
                return;
            }
            if (HotkeyID == _che_tc)
            {
                StateManager.CurrState.Che_tc();
                return;
            }
            if (HotkeyID == _che_xh)
            {
                StateManager.CurrState.Che_xh();
                return;
            }
            if (HotkeyID == _xian_2)
            {
                StateManager.CurrState.Xian2_Bump();
                return;
            }
            if (HotkeyID == _gan_3)
            {
                StateManager.CurrState.Gan3_Bump();
                return;
            }
  
            if (HotkeyID == _xian_4)
            {
                StateManager.CurrState.Xian4_Bump();
                return;
            }

            if (HotkeyID == _xian_7)
            {
                StateManager.CurrState.Xian7_Bump();
                return;
            }

            if (HotkeyID == _xian_8)
            {
                StateManager.CurrState.Xian8_Bump();
                return;
            }

            if (HotkeyID == _xian_9)
            {
                StateManager.CurrState.Xian9_Bump();
                return;
            }
            if (HotkeyID == _soundreplay)
            {
                CVoice.RePlay();
            }

        }


    }
}

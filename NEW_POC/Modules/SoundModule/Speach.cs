using System;
using System.Collections.Generic;
using System.Text;
using SpeechLib;

namespace Modules.SoundModule
{
    public class Speach
    {
        private static Speach _Instance = null;
        private SpeechLib.SpVoiceClass voice = null;

        private Speach()
        {
            BuildSpeach();
        }
        public static Speach instance()
        {
            if (_Instance == null)
                _Instance = new Speach();
            return _Instance;
        }

        /**
        private void SetChinaVoice()
        {
            voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(chinaindex);
        }
        private void SetEnglishVoice()
        {
            voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(englishindex);
        }
        private void SpeakChina(string strSpeak)
        {
            SetChinaVoice();
            Speak(strSpeak);
        }
        private void SpeakEnglishi(string strSpeak)
        {
            SetEnglishVoice();
            Speak(strSpeak);
        }
        public void AnalyseSpeak(string strSpeak)
        {
            int iCbeg = 0;
            int iEbeg = 0;
            bool IsChina = true;
            for (int i = 0; i < strSpeak.Length; i++)
            {
                char chr = strSpeak[i];
                if (IsChina)
                {
                    if (chr <= 122 && chr >= 65)
                    {
                        int iLen = i - iCbeg;
                        string strValue = strSpeak.Substring(iCbeg, iLen);
                        SpeakChina(strValue);
                        iEbeg = i;
                        IsChina = false;
                    }
                }
                else
                {
                    if (chr > 122 || chr < 65)
                    {
                        int iLen = i - iEbeg;
                        string strValue = strSpeak.Substring(iEbeg, iLen);
                        this.SpeakEnglishi(strValue);
                        iCbeg = i;
                        IsChina = true;
                    }
                }
            }//end for
            if (IsChina)
            {
                int iLen = strSpeak.Length - iCbeg;
                string strValue = strSpeak.Substring(iCbeg, iLen);
                SpeakChina(strValue);
            }
            else
            {
                int iLen = strSpeak.Length - iEbeg;
                string strValue = strSpeak.Substring(iEbeg, iLen);
                SpeakEnglishi(strValue);
            }
        }
         * **/

        public void SelectVoice(int index)
        {
            try
            {
                voice.Voice = voice.GetVoices("", "").Item(index);
            }
            catch
            {
            }
        }

        private void BuildSpeach()
        {
            if (voice == null)
                voice = new SpVoiceClass();
            //ModuleSettings settings = ModuleConfig.GetSettings();
            //int index = settings.VoiceIndex;
            SelectVoice(0);
        }
        public int Volume
        {
            get
            {
                return voice.Volume;
            }
            set
            {
                voice.SetVolume((ushort)(value));
            }
        }
        public int Rate
        {
            get
            {
                return voice.Rate;
            }
            set
            {
                voice.SetRate(value);
            }
        }
        private void Speak(string strSpeack)
        {
            try
            {
                voice.Speak(strSpeack, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            }
            catch (Exception err)
            {
                throw (new Exception("发生一个错误：" + err.Message));
            }
        }

        public void AnalyseSpeak(string strSpeak)
        {
            Speak(strSpeak);
        }

        public void Stop()
        {
            voice.Speak(string.Empty, SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
        }
        public void Pause()
        {
            voice.Pause();
        }
        public void Continue()
        {
            voice.Resume();
        }
　　 

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Threading;

namespace zhuangkao
{
    public class CVoice
    {
        private static Speach mysp = Speach.instance();
        private static SoundPlayer _voiceplayer = new SoundPlayer();
        private static Thread threadplay;
        private static  string _sound;
        public static string SoundfileName
        {
            get { return _sound; }
        }

        private static string _soundtext;
        public static string SoundText
        {
            get { return CVoice._soundtext; }
        }

        public static  void Playfile(string soundfile)
        {
            _sound = soundfile;
            threadplay = new Thread(mysoundplay);
            threadplay.Start();
        }

        public static void Play(string soundtext)
        {
            _soundtext = soundtext;
            mysp.AnalyseSpeak(soundtext);
        }

        public static void RePlay() //播放最后一次的语音
        {
            mysp.AnalyseSpeak(_soundtext); 
        }

        public static void Stop()
        {
            if (threadplay.ThreadState == ThreadState.Running)
            {
                threadplay.Abort();
            }
            mysp.Stop();
        }

        private static void mysoundplay()
        {
            try
            {
                _voiceplayer.SoundLocation = _sound;
                _voiceplayer.Play();
            }
            catch
            {
            }
        }

        public static Speach Speech
        {
            get
            {
                return mysp;
            }
        }

    }
}

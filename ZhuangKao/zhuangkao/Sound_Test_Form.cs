using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;

namespace zhuangkao
{
    public partial class Sound_Test_Form : Form
    {
        private SpVoiceClass voice;
        private ModuleSettings settings;
        private int tmpIndex;
        public Sound_Test_Form()
        {
            InitializeComponent();
        }

        private void Sound_Test_Form_Load(object sender, EventArgs e)
        {
            voice = new SpVoiceClass();
            ISpeechObjectTokens spObjs = voice.GetVoices("", "");
            int i = 0;
            foreach (ISpeechObjectToken spObj in spObjs)
            {
                this.comboBoxVoiceList.Items.Add(spObj.GetDescription(i++));
            }
            settings = ModuleConfig.GetSettings();
            try
            {
                this.comboBoxVoiceList.SelectedIndex = settings.VoiceIndex;
            }
            catch
            {
            }
            tmpIndex = settings.VoiceIndex;
        }

        private void comboBoxVoiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpIndex = comboBoxVoiceList.SelectedIndex;
            try
            {
                voice.Voice = voice.GetVoices("", "").Item(tmpIndex);
            }
            catch
            {
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (!textBoxPreLis.Text.Trim().Equals(string.Empty))
                voice.Speak(textBoxPreLis.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            CVoice.Speech.SelectVoice(tmpIndex);
            settings.VoiceIndex = tmpIndex;
            ModuleConfig.SaveSettings(settings);
            this.Close();
        }
    }
}
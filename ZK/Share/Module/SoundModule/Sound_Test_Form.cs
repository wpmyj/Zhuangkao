using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Module.Setup;
using Cn.Youdundianzi.Core.Util;
using DevComponents.DotNetBar;
using System.Collections;

namespace Cn.Youdundianzi.Share.Module.Sound
{
    public partial class Sound_Test_Form : Form
    {
        private SpVoiceClass voice;
        private ISpeechObjectTokens spObjs;

        private Dictionary<string, SettingPair> _configTable;
        public Dictionary<string, SettingPair> ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
        }

        private CSetup _currentSetup;

        private Dictionary<TabItem, CSetup> _tabTable;

        private int _currentVoiceIndex;
        private TextBox _currentTxtBox;

        public Sound_Test_Form()
        {
            InitializeComponent();
            voice = new SpVoiceClass();
            spObjs = voice.GetVoices("", "");
        }

        private void Sound_Test_Form_Load(object sender, EventArgs e)
        {
            if (_configTable != null)
            {
                _tabTable = new Dictionary<TabItem, CSetup>();
                IDictionaryEnumerator dicEnum = _configTable.GetEnumerator();
                while (dicEnum.MoveNext())
                {
                    DictionaryEntry ent = dicEnum.Entry;

                    TabItem tab = new TabItem();
                    tab.Text = (string)ent.Key;
                    tab.Click += new EventHandler(tabCtrl_Click);

                    SettingPair set = (SettingPair)ent.Value;
                    CSetup temp = new CSetup(set);

                    TabControlPanel tabControlPanel = new TabControlPanel();

                    tab.AttachedControl = tabControlPanel;

                    tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabControlPanel.Location = new System.Drawing.Point(0, 26);
                    tabControlPanel.Name = (string)ent.Key;
                    tabControlPanel.Size = new System.Drawing.Size(306, 150);
                    tabControlPanel.TabItem = tab;

                    //添加自己的控件
                    GroupBox tempGroupBox = new GroupBox();
                    tempGroupBox.Dock = DockStyle.Fill;
                    tempGroupBox.Name = "tempGroupBox";
                    tempGroupBox.Text = "语音设置";

                    Label tempLabel = new Label();
                    tempLabel.Location = new Point(10, 17);
                    tempLabel.Size = new Size(300, 20);
                    tempLabel.Text = "请选择声音，并输入测试语句。";
                    tempGroupBox.Controls.Add(tempLabel);

                    ComboBox tempComboBox = new ComboBox();
                    int i = 0;
                    foreach (ISpeechObjectToken spObj in spObjs)
                    {
                        tempComboBox.Items.Add(spObj.GetDescription(i++));
                    }
                    try
                    {
                        tempComboBox.SelectedIndex = ((CSettings)temp.Settings).SoundConfig.VoiceIndex;
                    }
                    catch
                    {}
                    tempComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    tempComboBox.Name = "comboBox";
                    tempComboBox.Location = new Point(20, 40);
                    tempComboBox.Size = new Size(260, 20);
                    tempComboBox.SelectedIndexChanged += new EventHandler(comboBoxVoiceList_SelectedIndexChanged);
                    tempGroupBox.Controls.Add(tempComboBox);

                    TextBox tempTxtBox = new TextBox();
                    tempTxtBox.Name = "txtBox";
                    tempTxtBox.Location = new Point(20, 80);
                    tempTxtBox.Size = new Size(260, 20);
                    tempGroupBox.Controls.Add(tempTxtBox);

                    Button previewBtn = new Button();
                    previewBtn.Location = new Point(220, 120);
                    previewBtn.Size = new Size(80, 25);
                    previewBtn.Text = "播放声音";
                    previewBtn.Click += new EventHandler(buttonPreview_Click);
                    tempGroupBox.Controls.Add(previewBtn);

                    //自己的控件添加完毕
                    tabControlPanel.Controls.Add(tempGroupBox);

                    tabCtrl.Controls.Add(tabControlPanel);

                    this.tabCtrl.Tabs.Add(tab);

                    _tabTable.Add(tab, temp);
                }

                if (this.tabCtrl.Tabs.Count > 0)
                {
                    _currentSetup = _tabTable[this.tabCtrl.SelectedTab];
                    _currentVoiceIndex = ((ComboBox)tabCtrl.SelectedPanel.Controls.Find("comboBox", true)[0]).SelectedIndex;
                    _currentTxtBox = (TextBox)tabCtrl.SelectedPanel.Controls.Find("txtBox", true)[0];
                }
            }
        }

        private void comboBoxVoiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentVoiceIndex = ((ComboBox)sender).SelectedIndex;
            try
            {
                voice.Voice = voice.GetVoices("", "").Item(_currentVoiceIndex);
            }
            catch
            {
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (!this._currentTxtBox.Text.Trim().Equals(string.Empty))
                voice.Speak(this._currentTxtBox.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (_currentSetup != null)
            {
                ((CSettings)_currentSetup.Settings).SoundConfig.VoiceIndex = _currentVoiceIndex;
                _currentSetup.SaveSettings();
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabCtrl_Click(object sender, EventArgs e)
        {
            _currentSetup = _tabTable[(TabItem)sender];
            _currentVoiceIndex = ((ComboBox)tabCtrl.SelectedPanel.Controls.Find("comboBox", true)[0]).SelectedIndex;
            _currentTxtBox = (TextBox)tabCtrl.SelectedPanel.Controls.Find("txtBox", true)[0];
        }
    }
}
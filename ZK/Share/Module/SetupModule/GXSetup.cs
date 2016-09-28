using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Signal;
using Cn.Youdundianzi.Share.Util;
using DevComponents.DotNetBar;
using System.Collections;

namespace Cn.Youdundianzi.Share.Module.Setup
{
    public enum SetupDialogType
    {
        QF,
        PB,
        ADMIN_PB
    }

    public partial class GXSetup : Form
    {
        private Dictionary<string, SettingPair> _configTable;
        public Dictionary<string, SettingPair> ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
        }

        private CSetup _currentSetup;
        private SignalConfigures _currentSigConf;

        private SetupDialogType _type;

        private Dictionary<TabItem, CSetup> _tabTable;

        public GXSetup(SetupDialogType type)
        {
            InitializeComponent();
            _type = type;
        }

        private void GXQufan_Load(object sender, EventArgs e)
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
                    tab.Click += new EventHandler(tab_Click);

                    SettingPair set = (SettingPair)ent.Value;
                    CSetup temp = new CSetup(set);

                    TabControlPanel tabControlPanel = new TabControlPanel();

                    tab.AttachedControl = tabControlPanel;

                    tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabControlPanel.Location = new System.Drawing.Point(0, 26);
                    tabControlPanel.Name = (string)ent.Key;
                    tabControlPanel.Size = new System.Drawing.Size(464, 300);
                    tabControlPanel.TabItem = tab;

                    GroupBox groupBoxGan = new GroupBox();
                    groupBoxGan.Location = new Point(12, 20);
                    groupBoxGan.Size = new Size(400, 90);
                    groupBoxGan.Text = "杆信号";
                    GroupBox groupBoxXian = new GroupBox();
                    groupBoxXian.Location = new Point(12, 125);
                    groupBoxXian.Size = new Size(400, 90);
                    groupBoxXian.Text = "线信号";

                    CheckBox[] gan;
                    CheckBox[] xian;

                    SignalConfigures tempSigConf = ((CSettings)temp.Settings).SignConfig;

                    gan = new CheckBox[tempSigConf.GanLength];
                    xian = new CheckBox[tempSigConf.XianLength];

                    int tempGanVal = 0;
                    int tempXianVal = 0;

                    switch (_type)
                    {
                        case SetupDialogType.QF:
                            this.Text = "取反";
                            tempGanVal = tempSigConf.AdminQFGan;
                            tempXianVal = tempSigConf.AdminQFXian;
                            break;
                        case SetupDialogType.PB:
                            this.Text = "屏蔽";
                            tempGanVal = tempSigConf.PBGan;
                            tempXianVal = tempSigConf.PBXian;
                            break;
                        case SetupDialogType.ADMIN_PB:
                            this.Text = "管理员屏蔽";
                            tempGanVal = tempSigConf.AdminPBGan;
                            tempXianVal = tempSigConf.AdminPBXian;
                            break;
                    }

                    for (int i = 0; i < gan.Length; i++)
                    {
                        gan[i] = new CheckBox();
                        groupBoxGan.Controls.Add(gan[i]);
                        gan[i].AutoSize = true;
                        gan[i].Location = new System.Drawing.Point(43 + i * 32, 38);
                        gan[i].Text = Convert.ToString(i + 1);
                        gan[i].Size = new System.Drawing.Size(36, 16);
                        gan[i].UseVisualStyleBackColor = true;
                        gan[i].Click += new System.EventHandler(Gan_Click);
                        if (((tempGanVal >> i) & 1) == 1)
                        {
                            gan[i].Checked = true;
                        }
                        else
                        {
                            gan[i].Checked = false;
                        }
                    }

                    for (int i = 0; i < xian.Length; i++)
                    {
                        xian[i] = new CheckBox();
                        groupBoxXian.Controls.Add(xian[i]);
                        xian[i].AutoSize = true;
                        xian[i].Location = new System.Drawing.Point(43 + i * 32, 38);
                        xian[i].Text = Convert.ToString(i + 1);
                        xian[i].Size = new System.Drawing.Size(36, 16);
                        xian[i].UseVisualStyleBackColor = true;
                        xian[i].Click += new System.EventHandler(Xian_Click);
                        if (((tempXianVal >> i) & 1) == 1)
                        {
                            xian[i].Checked = true;
                        }
                        else
                        {
                            xian[i].Checked = false;
                        }
                    }

                    tabControlPanel.Controls.Add(groupBoxGan);
                    tabControlPanel.Controls.Add(groupBoxXian);

                    tabCtrl.Controls.Add(tabControlPanel);

                    this.tabCtrl.Tabs.Add(tab);

                    _tabTable.Add(tab, temp);
                }

                if (this.tabCtrl.Tabs.Count > 0)
                {
                    _currentSetup = _tabTable[this.tabCtrl.SelectedTab];
                    _currentSigConf = ((CSettings)_currentSetup.Settings).SignConfig;
                }
            }
        }


        private void Gan_Click(object sender, EventArgs e)
        {
            int tmpi;
            tmpi = Convert.ToInt32(((CheckBox)sender).Text) - 1;
            AssignValue(tmpi, ((CheckBox)sender).Checked, SignalType.GAN);
        }

        private void Xian_Click(object sender, EventArgs e)
        {
            int tmpi;
            tmpi = Convert.ToInt32(((CheckBox)sender).Text) - 1;
            AssignValue(tmpi, ((CheckBox)sender).Checked, SignalType.XIAN);
        }

        private void AssignValue(int index, bool set, SignalType sigType)
        {
            if (set)
            {
                switch (_type)
                {
                    case SetupDialogType.QF:
                        switch (sigType)
                        {
                            case SignalType.GAN:
                                _currentSigConf.AdminQFGan = Set1(_currentSigConf.AdminQFGan, index);
                                break;
                            case SignalType.XIAN:
                                _currentSigConf.AdminQFXian = Set1(_currentSigConf.AdminQFXian, index);
                                break;
                        }
                        break;
                    case SetupDialogType.PB:
                        switch (sigType)
                        {
                            case SignalType.GAN:
                                _currentSigConf.PBGan = Set1(_currentSigConf.PBGan, index);
                                break;
                            case SignalType.XIAN:
                                _currentSigConf.PBXian = Set1(_currentSigConf.PBXian, index);
                                break;
                        }
                        break;
                    case SetupDialogType.ADMIN_PB:
                        switch (sigType)
                        {
                            case SignalType.GAN:
                                _currentSigConf.AdminPBGan = Set1(_currentSigConf.AdminPBGan, index);
                                break;
                            case SignalType.XIAN:
                                _currentSigConf.AdminPBXian = Set1(_currentSigConf.AdminPBXian, index);
                                break;
                        }
                        break;
                }
            }
            else
            {
                switch (_type)
                {
                    case SetupDialogType.QF:
                        switch (sigType)
                        {
                            case SignalType.GAN:
                                _currentSigConf.AdminQFGan = Set0(_currentSigConf.AdminQFGan, index);
                                break;
                            case SignalType.XIAN:
                                _currentSigConf.AdminQFXian = Set0(_currentSigConf.AdminQFXian, index);
                                break;
                        }
                        break;
                    case SetupDialogType.PB:
                        switch (sigType)
                        {
                            case SignalType.GAN:
                                _currentSigConf.PBGan = Set0(_currentSigConf.PBGan, index);
                                break;
                            case SignalType.XIAN:
                                _currentSigConf.PBXian = Set0(_currentSigConf.PBXian, index);
                                break;
                        }
                        break;
                    case SetupDialogType.ADMIN_PB:
                        switch (sigType)
                        {
                            case SignalType.GAN:
                                _currentSigConf.AdminPBGan = Set0(_currentSigConf.AdminPBGan, index);
                                break;
                            case SignalType.XIAN:
                                _currentSigConf.AdminPBXian = Set0(_currentSigConf.AdminPBXian, index);
                                break;
                        }
                        break;
                }
            }
        }

        private int Set1(int indata, int weizhi)
        {
            int tmp = 1;
            if ((weizhi < 0) || weizhi > 9)
            {
                return indata;
            }
            tmp = (tmp << (weizhi));
            return ((int)tmp | (int)indata);

        }

        private int Set0(int indata, int weizhi)
        {
            int tmp = 1;
            if ((weizhi < 0) || weizhi > 9)
            {
                return indata;
            }
            tmp = (tmp << (weizhi));
            return ((int)~tmp & (int)indata);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentSetup != null)
            {
                _currentSetup.SaveSettings();
            }
        }

        void tab_Click(object sender, EventArgs e)
        {
            _currentSetup = _tabTable[(TabItem)sender];
            _currentSigConf = ((CSettings)_currentSetup.Settings).SignConfig;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Signal;
using Cn.Youdundianzi.Share.Util;
using DevComponents.DotNetBar;

namespace Cn.Youdundianzi.Share.Module.Setup
{
    public partial class ExamSetup : Form
    {
        private Dictionary<string, SettingPair> _configTable;
        public Dictionary<string, SettingPair> ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
        }

        private CSetup _currentSetup;

        private Dictionary<TabItem, CSetup> _tabTable;

        public ExamSetup()
        {
            InitializeComponent();
        }

        private void ExamSetup_Load(object sender, EventArgs e)
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

                    PropertyGrid pg = new PropertyGrid();
                    pg.Dock = System.Windows.Forms.DockStyle.Fill;
                    pg.SelectedObject = temp.Settings;

                    TabControlPanel tabControlPanel = new TabControlPanel();

                    tab.AttachedControl = tabControlPanel;

                    tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabControlPanel.Location = new System.Drawing.Point(0, 26);
                    tabControlPanel.Name = (string)ent.Key;
                    //tabControlPanel.Padding = new System.Windows.Forms.Padding(1);
                    tabControlPanel.Size = new System.Drawing.Size(409, 440);
                    //tabControlPanel.TabIndex = 1;
                    tabControlPanel.TabItem = tab;

                    tabControlPanel.Controls.Add(pg);

                    tabCtrl.Controls.Add(tabControlPanel);

                    this.tabCtrl.Tabs.Add(tab);

                    _tabTable.Add(tab, temp);
                }
                
                if (this.tabCtrl.Tabs.Count > 0)
                    _currentSetup = _tabTable[this.tabCtrl.SelectedTab];
            }
        }

        void tab_Click(object sender, EventArgs e)
        {
            _currentSetup = _tabTable[(TabItem)sender];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentSetup != null)
            {
                _currentSetup.SaveSettings();
            }
        }
    }
}
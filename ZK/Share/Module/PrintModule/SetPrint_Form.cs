using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GenCode128;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Module.Setup;
using System.Collections;
using DevComponents.DotNetBar;

namespace Cn.Youdundianzi.Share.Module.Print
{
    public partial class SetPrint_Form : Form
    {
        private CTextPrintObjSet ksxmtxt;
        private CTextPrintObjSet ksddtxt;
        private CTextPrintObjSet kscjtxt;
        private CTextPrintObjSet ksrqtxt;
        private CTextPrintObjSet ksyxmtxt;
        private CTextPrintObjSet kscxtxt;
        private CImagePrintObjSet tiaomaimg;
        private CImagePrintObjSet traceimg;

        Print_form pf;

        private Dictionary<string, SettingPair> _configTable;
        public Dictionary<string, SettingPair> ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
        }

        private CSetup _currentSetup;
        private PrintSetupPanel _currentSetupPanel;

        private Dictionary<TabItem, CSetup> _tabTable;

        public SetPrint_Form()
        {
            InitializeComponent();
        }

        private void InitializePrintFormComponent(PrintSettings settings)
        {
            pf = new Print_form(Convert.ToInt16(210 * 4), Convert.ToInt16(297 * 4));

            ksddtxt = new CTextPrintObjSet();
            ksddtxt.Printtext = "考试地点";
            ksddtxt.mmX = settings.Ksdd_x;
            ksddtxt.mmY = settings.Ksdd_y;
            pf.PrintRegister(ksddtxt);

            ksxmtxt = new CTextPrintObjSet();
            ksxmtxt.Printtext = "考生姓名";
            ksxmtxt.mmX = settings.Ksxm_x;
            ksxmtxt.mmY = settings.Ksxm_y;
            pf.PrintRegister(ksxmtxt);

            kscjtxt = new CTextPrintObjSet();
            kscjtxt.Printtext = "考试成绩";
            kscjtxt.mmX = settings.Kscj_x;
            kscjtxt.mmY = settings.Kscj_y;
            pf.PrintRegister(kscjtxt);

            kscxtxt = new CTextPrintObjSet();
            kscxtxt.Printtext = "考试车型";
            kscxtxt.mmX = settings.Kscx_x;
            kscxtxt.mmY = settings.Kscx_y;
            pf.PrintRegister(kscxtxt);


            ksrqtxt = new CTextPrintObjSet();
            ksrqtxt.Printtext = "考试日期";
            ksrqtxt.mmX = settings.Ksrq_x;
            ksrqtxt.mmY = settings.Ksrq_y;
            pf.PrintRegister(ksrqtxt);

            ksyxmtxt = new CTextPrintObjSet();
            ksyxmtxt.Printtext = "考试员姓名";
            ksyxmtxt.mmX = settings.Ksyxm_x;
            ksyxmtxt.mmY = settings.Ksyxm_y;
            pf.PrintRegister(ksyxmtxt);

            tiaomaimg = new CImagePrintObjSet();
            tiaomaimg.InImage = Code128Rendering.MakeBarcodeImage("测试员100", 1, true);
            tiaomaimg.mmX = settings.Tiaomaimg_x;
            tiaomaimg.mmY = settings.Tiaomaimg_y;
            pf.PrintRegister(tiaomaimg);

            traceimg = new CImagePrintObjSet();
            traceimg.InImage = new Bitmap("Imgs\\SampleTrace.bmp");
            traceimg.mmX = settings.TraceImg_X;
            traceimg.mmY = settings.TraceImg_Y;
            pf.PrintRegister(traceimg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pf.ShowDialog();

            _currentSetupPanel.Place_X = ksddtxt.mmX;
            _currentSetupPanel.Place_Y = ksddtxt.mmY;

            _currentSetupPanel.Name_X = ksxmtxt.mmX;
            _currentSetupPanel.Name_Y = ksxmtxt.mmY;

            _currentSetupPanel.Date_X = ksrqtxt.mmX;
            _currentSetupPanel.Date_Y = ksrqtxt.mmY;

            _currentSetupPanel.Result_X = kscjtxt.mmX;
            _currentSetupPanel.Result_Y = kscjtxt.mmY;

            _currentSetupPanel.Supervisor_X = ksyxmtxt.mmX;
            _currentSetupPanel.Supervisor_Y = ksyxmtxt.mmY;

            _currentSetupPanel.CarType_X = kscxtxt.mmX;
            _currentSetupPanel.CarType_Y = kscxtxt.mmY;

            _currentSetupPanel.BarCode_X = tiaomaimg.mmX;
            _currentSetupPanel.BarCode_Y = tiaomaimg.mmY;

            _currentSetupPanel.Trace_X = traceimg.mmX;
            _currentSetupPanel.Trace_Y = traceimg.mmY;
        }

        private void SetPrint_Form_Load(object sender, EventArgs e)
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

                    CSettings csetting = (CSettings)temp.Settings;
                    PrintSettings psetting = csetting.PrintConfig;
                    
                    TabControlPanel tabControlPanel = new TabControlPanel();

                    tab.AttachedControl = tabControlPanel;

                    tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    tabControlPanel.Location = new System.Drawing.Point(0, 26);
                    tabControlPanel.Name = (string)ent.Key;
                    tabControlPanel.Size = new System.Drawing.Size(409, 440);
                    tabControlPanel.TabItem = tab;

                    PrintSetupPanel prtSetPane = new PrintSetupPanel();

                    tabControlPanel.Controls.Add(prtSetPane);

                    tabCtrl.Controls.Add(tabControlPanel);

                    this.tabCtrl.Tabs.Add(tab);

                    _tabTable.Add(tab, temp);
                }

                if (this.tabCtrl.Tabs.Count > 0)
                {
                    _currentSetup = _tabTable[this.tabCtrl.SelectedTab];

                    _currentSetupPanel = (PrintSetupPanel)this.tabCtrl.SelectedPanel.Controls[0];

                    CSettings csetting = (CSettings)_currentSetup.Settings;
                    PrintSettings settings = csetting.PrintConfig;

                    _currentSetupPanel.SetValues(settings);
                    InitializePrintFormComponent(settings);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CSettings csetting = (CSettings)_currentSetup.Settings;
            csetting.PrintConfig = _currentSetupPanel.GetValues();

            ModuleConfig.SaveSettings(_currentSetup.Settings, _currentSetup.ConfigFilePath);
        }

        void tab_Click(object sender, EventArgs e)
        {
            _currentSetup = _tabTable[(TabItem)sender];
            _currentSetupPanel = (PrintSetupPanel)this.tabCtrl.SelectedPanel.Controls[0];

            CSettings csetting = (CSettings)_currentSetup.Settings;
            PrintSettings settings = csetting.PrintConfig;

            _currentSetupPanel.SetValues(settings);
            InitializePrintFormComponent(settings);
        }
    }
}
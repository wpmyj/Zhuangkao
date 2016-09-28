using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Cn.Youdundianzi.Core.Signal;
using Cn.Youdundianzi.Core.Util;
using Cn.Youdundianzi.Share.Signal;
using Cn.Youdundianzi.Share.Util;
using Cn.Youdundianzi.Share.Module.Sound;

namespace Cn.Youdundianzi.Share.Module.Setup
{
    public partial class GXTest : Form, IMonObserver
    {
        private Dictionary<string, SettingPair> _configTable;
        public Dictionary<string, SettingPair> ConfigTable
        {
            get { return _configTable; }
            set { _configTable = value; }
        }

        private CSetup _currentSetup;
        private SignalConfigures _currentSigConf;
        private SignLength sigLen;

        bool IsSignalGanXian = false; //是否是单杆线
        bool IsSiganlGan = false;//是单杆
        bool IsSignalXian = false;//是单线
        bool IsSignalCar = false;//是单车
        int gxNumber = 0;//杆线索引
        bool IsStartTest = false;

        private AssemblyInfoPair _monInfo;
        private ISignalMonitor monitor;

        PictureBox[] picBoxChe;
        PictureBox[] picBoxXian;
        PictureBox[] picBoxGan;

        public GXTest(Dictionary<string, SettingPair> configTable, AssemblyInfoPair monInfo)
        {
            if (configTable.Count <= 0)
                throw new Exception("Invalid Configuration Table!");
            InitializeComponent();
            _configTable = configTable;
            this._monInfo = monInfo;
        }

        private void GXTest_Load(object sender, EventArgs e)
        {
            IDictionaryEnumerator dicEnum = _configTable.GetEnumerator();
            while (dicEnum.MoveNext())
            {
                DictionaryEntry ent = dicEnum.Entry;
                comBoxType.Items.Add(ent.Key);
            }

            this.comBoxType.SelectedIndex = 0;
        }
        private bool alarm;//报警标志,在timer中控制报警
        #region IMonObserver Members

        public void Notify(IMonData data)
        {
            //Log.WriteCMonData(data);

            if (IsStartTest)
            {
                alarm = false;
                if (IsSignalGanXian)
                {
                    //车
                    if (IsSignalCar)
                    {
                        for (int i = 0; i < data.GetSignals(SignalType.CHE).Length; i++)
                            if (data.GetSignal(SignalType.CHE, i) == 1)
                                picBoxChe[i].BackColor = Color.Green;
                            else
                                picBoxChe[i].BackColor = Color.Red;
                    }


                    //杆
                    if (IsSiganlGan)
                    {

                        for (int i = 0; i < data.GetSignals(SignalType.GAN).Length; i++)
                            if (i == gxNumber - 1)
                            {
                                if (data.GetSignal(SignalType.GAN, i) == 1)
                                    picBoxGan[i].BackColor = Color.Green;
                                else
                                {
                                    picBoxGan[i].BackColor = Color.Red;
                                    alarm = true;
                                }
                            }
                    }

                    //线
                    if (IsSignalXian)
                    {

                        for (int i = 0; i < data.GetSignals(SignalType.XIAN).Length; i++)
                            if (i == gxNumber - 1)
                            {
                                if (data.GetSignal(SignalType.XIAN, i) == 1)
                                    picBoxXian[i].BackColor = Color.Green;
                                else
                                {
                                    picBoxXian[i].BackColor = Color.Red;
                                    alarm = true;
                                }
                            }
                    }
                }
                else
                {
                    //车
                    for (int i = 0; i < data.GetSignals(SignalType.CHE).Length; i++)
                        if (data.GetSignal(SignalType.CHE, i) == 1)
                            picBoxChe[i].BackColor = Color.Green;
                        else
                            picBoxChe[i].BackColor = Color.Red;

                    //杆
                    for (int i = 0; i < data.GetSignals(SignalType.GAN).Length; i++)
                        if (data.GetSignal(SignalType.GAN, i) == 1)
                            picBoxGan[i].BackColor = Color.Green;
                        else
                        {
                            picBoxGan[i].BackColor = Color.Red;
                            alarm = true;
                        }

                    //线
                    for (int i = 0; i < data.GetSignals(SignalType.XIAN).Length; i++)
                        if (data.GetSignal(SignalType.XIAN, i) == 1)
                            picBoxXian[i].BackColor = Color.Green;
                        else
                        {
                            picBoxXian[i].BackColor = Color.Red;
                            alarm = true;
                        }
                }

            }
        }

                
           
        

        #endregion


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (IsStartTest)
            {
                this.timer1.Stop();
                this.timer1.Enabled = false;
                monitor.Close();
                monitor.UnRegMonitor(this);
                monitor.HotKeyHandle = IntPtr.Zero;
                monitor.Dispose();
                monitor = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                this.btnStart.Text = "开始检测";
                this.comBoxType.Enabled = true;
                IsStartTest = false;
            }
            else
            {
                IsStartTest = true;
                this.btnStart.Text = "停止检测";
                CheckConfig();
                
                this.timer1.Enabled = true;
                this.timer1.Start();
                this.comBoxType.Enabled = false;

                try
                {
                    monitor = SignalMonitorFactory.CreateSignalMonitor(_monInfo, _currentSetup.Settings);
                    monitor.HotKeyHandle = this.Handle;
                    monitor.RegMonitor(this);
                    monitor.Start();
                }
                catch (InvalidCastException ice)
                {
                    MessageBox.Show("Monitor与Setting不配套。", "错误！");
                    this.Close();
                }
            }
        }

        private void rdoSignal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSignal.Checked == true)
            {
                this.groupBox3.Enabled = true;
                
            }
            else
            {
                this.groupBox3.Enabled = false;
            }

            if (IsStartTest)
            {
                CheckConfig();
            }

        }

        private void rdoType2wheel_CheckedChanged(object sender, EventArgs e)
        {
            if (IsStartTest)
            {
                CheckConfig();
            }
        }

        private void rdoSignalGan_CheckedChanged(object sender, EventArgs e)
        {
            if (IsStartTest)
            {
                CheckConfig();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsStartTest)
            {
               CheckConfig();
            }
        }


        private void CheckConfig()
        {
            IsSignalGanXian = false;
            IsSiganlGan = false;
            IsSignalXian = false;
            IsSignalCar = false;

            for (int i = 0; i < sigLen.CHE_LENGTH; i++)
                picBoxChe[i].BackColor = Color.DarkSeaGreen;

            for (int i = 0; i < sigLen.XIAN_LENGTH; i++)
                picBoxXian[i].BackColor = Color.DarkSeaGreen;

            for (int i = 0; i < sigLen.GAN_LENGTH; i++)
                picBoxGan[i].BackColor = Color.DarkSeaGreen;

            //检测方式
            if (this.rdoSignal.Checked == true)
                IsSignalGanXian = true;

            //单杆 线
            if (this.rdoSignalGan.Checked == true)
                IsSiganlGan = true;
            else
                IsSignalXian = true;

            //杆线索引
            string dd = this.comBoxIndex.Text;
            try
            {
                this.gxNumber = int.Parse(this.comBoxIndex.Text);
            }
            catch (FormatException fe)
            {
                this.gxNumber = 0;
            }

        }

        private void GXTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (monitor != null)
            {
                monitor.UnRegMonitor(this);
                monitor.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alarm)
            {
                CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
            }
        }

        private void comBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingPair setPair = _configTable[comBoxType.Text];
            _currentSetup = new CSetup(setPair);
            SignalConfigures sigConf = ((CSettings)_currentSetup.Settings).SignConfig;

            sigLen.GAN_LENGTH = sigConf.GanLength;
            sigLen.XIAN_LENGTH = sigConf.XianLength;
            sigLen.CHE_LENGTH = sigConf.CheLength;

            picBoxChe = new PictureBox[sigLen.CHE_LENGTH];
            this.carPane.Controls.Clear();
            for (int i = 0; i < sigLen.CHE_LENGTH; i++)
            {
                picBoxChe[i] = new PictureBox();
                picBoxChe[i].Width = 20;
                picBoxChe[i].Height = 20;
                picBoxChe[i].Top = 0;
                picBoxChe[i].BackColor = Color.DarkSeaGreen;
                picBoxChe[i].Left = i * 50;
                this.carPane.Controls.Add(picBoxChe[i]);
            }



            picBoxGan = new PictureBox[sigLen.GAN_LENGTH];
            this.ganPane.Controls.Clear();
            for (int i = 0; i < sigLen.GAN_LENGTH; i++)
            {
                picBoxGan[i] = new PictureBox();
                picBoxGan[i].Width = 20;
                picBoxGan[i].Height = 20;
                picBoxGan[i].Top = 0;
                picBoxGan[i].BackColor = Color.DarkSeaGreen;
                picBoxGan[i].Left = i * 50;
                picBoxGan[i].Show();

                this.ganPane.Controls.Add(picBoxGan[i]);
            }

            picBoxXian = new PictureBox[sigLen.XIAN_LENGTH];
            this.xianPane.Controls.Clear();
            for (int i = 0; i < sigLen.XIAN_LENGTH; i++)
            {
                picBoxXian[i] = new PictureBox();
                picBoxXian[i].Width = 20;
                picBoxXian[i].Height = 20;
                picBoxXian[i].Top = 0;
                picBoxXian[i].BackColor = Color.DarkSeaGreen;
                picBoxXian[i].Left = i * 50;
                picBoxXian[i].Show();

                this.xianPane.Controls.Add(picBoxXian[i]);
            }
        }

        private void groupBox3_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox3.Enabled)
            {
                comBoxIndex.Items.Clear();
                if (this.rdoSignalGan.Checked == true)
                    for (int i = 0; i < sigLen.GAN_LENGTH; i++)
                    {
                        comBoxIndex.Items.Add(i + 1);
                    }
                else
                    for (int i = 0; i < sigLen.XIAN_LENGTH; i++)
                    {
                        comBoxIndex.Items.Add(i + 1);
                    }
            }
        }

        
    }
}
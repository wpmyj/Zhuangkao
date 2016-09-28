using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Signal;
using Shared;

namespace Modules.SetupModule
{
    public partial class GXTest : Form, IMonObserver
    {
        Signal.MotorSignal.MotorSignalSettings settings2;
        Signal.MotorSignal.MotorSignalSettings settings3;
        Signal.MotorSignal.MotorSignalSettings settings;//车型所对应的配置对象
        bool IsSignalGanXian = false; //是否是单杆线
        bool IsSiganlGan = false;//是单杆
        bool IsSignalXian = false;//是单线
        bool IsSignalCar = false;//是单车
        int gxNumber = 0;//杆线索引
        bool IsStartTest = false;

        IMonitor monitor;

        PictureBox[] picBoxChe;
        PictureBox[] picBoxXian;
        PictureBox[] picBoxGan;

        public GXTest(Signal.MotorSignal.MotorSignalSettings set2, Signal.MotorSignal.MotorSignalSettings set3)
        {
            InitializeComponent();
            settings2 = set2;
            settings3 = set3;
            settings = settings2;
            this.comboBox1.SelectedIndex = 0;

        }

        private void GXTest_Load(object sender, EventArgs e)
        {
            picBoxChe = new PictureBox[SimSignal.RAW_LENGTH];
            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
            {
                picBoxChe[i] = new PictureBox();
                picBoxChe[i].Width = 20;
                picBoxChe[i].Height = 20;
                picBoxChe[i].Top = 10;
                picBoxChe[i].BackColor = Color.DarkSeaGreen;
                picBoxChe[i].Left = 80 + i * 50;
                this.Controls.Add(picBoxChe[i]);
            }

         

            picBoxGan = new PictureBox[SimSignal.RAW_LENGTH];
            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
            {
                picBoxGan[i] = new PictureBox();
                picBoxGan[i].Width = 20;
                picBoxGan[i].Height = 20;
                picBoxGan[i].Top = 50;
                picBoxGan[i].BackColor = Color.DarkSeaGreen;
                picBoxGan[i].Left = 80 + i * 50;
                picBoxGan[i].Show();
                
                this.Controls.Add(picBoxGan[i]);
            }

            picBoxXian = new PictureBox[SimSignal.RAW_LENGTH];
            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
            {
                picBoxXian[i] = new PictureBox();
                picBoxXian[i].Width = 20;
                picBoxXian[i].Height = 20;
                picBoxXian[i].Top = 90;
                picBoxXian[i].BackColor = Color.DarkSeaGreen;
                picBoxXian[i].Left = 80 + i * 50;
                picBoxXian[i].Show();
                this.Controls.Add(picBoxXian[i]);
            }



        }
        private bool alarm;//报警标志,在timer中控制报警
        #region IMonObserver Members

        public void Notify(CMonData data)
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
                        for (int i = 0; i < data.GetSignals(Shared.SignalType.CHE).Length; i++)
                            if (data.GetSignal(Shared.SignalType.CHE, i) == 1)
                                picBoxChe[i].BackColor = Color.Green;
                            else
                                picBoxChe[i].BackColor = Color.Red;
                    }


                    //杆
                    if (IsSiganlGan)
                    {

                        for (int i = 0; i < data.GetSignals(Shared.SignalType.GAN).Length; i++)
                            if (i == gxNumber - 1)
                            {
                                if (data.GetSignal(Shared.SignalType.GAN, i) == 1)
                                    picBoxGan[i].BackColor = Color.Green;
                                else
                                {
                                    picBoxGan[i].BackColor = Color.Red;
                                    if (i < 5)
                                    {
                                        alarm = true;
                                    }
                                }
                            }
                    }

                    //线
                    if (IsSignalXian)
                    {

                        for (int i = 0; i < data.GetSignals(Shared.SignalType.XIAN).Length; i++)
                            if (i == gxNumber - 1)
                            {
                                if (data.GetSignal(Shared.SignalType.XIAN, i) == 1)
                                    picBoxXian[i].BackColor = Color.Green;
                                else
                                {
                                    picBoxXian[i].BackColor = Color.Red;
                                    if (i < 5)
                                    {
                                        alarm = true;
                                    }
                                }
                            }
                    }
                }
                else
                {
                    //车
                    for (int i = 0; i < data.GetSignals(Shared.SignalType.CHE).Length; i++)
                        if (data.GetSignal(Shared.SignalType.CHE, i) == 1)
                            picBoxChe[i].BackColor = Color.Green;
                        else
                            picBoxChe[i].BackColor = Color.Red;

                    //杆
                    for (int i = 0; i < data.GetSignals(Shared.SignalType.GAN).Length; i++)
                        if (data.GetSignal(Shared.SignalType.GAN, i) == 1)
                            picBoxGan[i].BackColor = Color.Green;
                        else
                        {
                            picBoxGan[i].BackColor = Color.Red;
                            if (i < 5)
                            {
                                alarm = true;
                            }
                        }

                    //线
                    for (int i = 0; i < data.GetSignals(Shared.SignalType.XIAN).Length; i++)
                        if (data.GetSignal(Shared.SignalType.XIAN, i) == 1)
                            picBoxXian[i].BackColor = Color.Green;
                        else
                        {
                            picBoxXian[i].BackColor = Color.Red;
                            if (i < 5)
                            {
                                alarm = true;
                            }
                        }


                }

            }
        }

                
           
        

        #endregion


        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = false;
            CheckConfig();
            IsStartTest = true;
            this.timer1.Enabled = true;
            this.timer1.Start();
            this.rdoType2wheel.Enabled = false;
            this.rdoType3wheel.Enabled = false;


            monitor = new Signal.MotorSignal.MotorMonitor(settings);
            monitor.HotKeyHandle = this.Handle;
            monitor.RegMonitor(this);
            monitor.Start();
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


            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
                picBoxChe[i].BackColor = Color.DarkSeaGreen;

            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
                picBoxXian[i].BackColor = Color.DarkSeaGreen;

            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
                picBoxGan[i].BackColor = Color.DarkSeaGreen;


            //车型
            if (this.rdoType2wheel.Checked == true)
            {
                settings = settings2;
            }
            else
            {
                this.settings = settings3;
            }

            //检测方式
            if (this.rdoSignal.Checked == true)
                IsSignalGanXian = true;

            //单杆 线
            if (this.rdoSignalGan.Checked == true)
                IsSiganlGan = true;
            else
                IsSignalXian = true;

            //杆线索引
            string dd = this.comboBox1.Text;
            this.gxNumber = int.Parse(this.comboBox1.Text);

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
                Modules.SoundModule.CVoice.Playfile(Application.StartupPath + "\\sound\\ding.wav");
            }
        }

        
    }
}
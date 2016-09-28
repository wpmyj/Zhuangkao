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

namespace Signal.MotorSignal
{
    public partial class SimForm : Form, IMonObserver
    {
        PictureBox[] picBoxChe;
        PictureBox[] picBoxXian;
        PictureBox[] picBoxGan;

        public SimForm()
        {
            InitializeComponent();
        }

        private void SimForm_Load(object sender, EventArgs e)
        {
            picBoxChe = new PictureBox[SimSignal.RAW_LENGTH];
            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
            {
                picBoxChe[i] = new PictureBox();
                picBoxChe[i].Width = 20;
                picBoxChe[i].Height = 20;
                picBoxChe[i].Top = 10;
                picBoxChe[i].BackColor = Color.Red;
                picBoxChe[i].Left = 50 + i * 40;
                this.Controls.Add(picBoxChe[i]);
            }

            picBoxXian = new PictureBox[SimSignal.RAW_LENGTH];
            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
            {
                picBoxXian[i] = new PictureBox();
                picBoxXian[i].Width = 20;
                picBoxXian[i].Height = 20;
                picBoxXian[i].Top = 50;
                picBoxXian[i].BackColor = Color.Red;
                picBoxXian[i].Left = 50 + i * 40;
                picBoxXian[i].Show();
                this.Controls.Add(picBoxXian[i]);
            }

            picBoxGan = new PictureBox[SimSignal.RAW_LENGTH];
            for (int i = 0; i < SimSignal.RAW_LENGTH; i++)
            {
                picBoxGan[i] = new PictureBox();
                picBoxGan[i].Width = 20;
                picBoxGan[i].Height = 20;
                picBoxGan[i].Top = 90;
                picBoxGan[i].BackColor = Color.Red;
                picBoxGan[i].Left = 50 + i * 40;
                picBoxGan[i].Show();
                this.Controls.Add(picBoxGan[i]);
            }
        }

        #region IMonObserver Members

        public void Notify(CMonData data)
        {
            //Log.WriteCMonData(data);

            for (int i = 0; i < data.GetSignals(Shared.SignalType.CHE).Length; i++)
                if (data.GetSignal(Shared.SignalType.CHE, i) == 1)
                    picBoxChe[i].BackColor = Color.Green;
                else
                    picBoxChe[i].BackColor = Color.Red;
            for (int i = 0; i < data.GetSignals(Shared.SignalType.GAN).Length; i++)
                if (data.GetSignal(Shared.SignalType.GAN, i) == 1)
                    picBoxGan[i].BackColor = Color.Green;
                else
                    picBoxGan[i].BackColor = Color.Red;
            for (int i = 0; i < data.GetSignals(Shared.SignalType.XIAN).Length; i++)
                if (data.GetSignal(Shared.SignalType.XIAN, i) == 1)
                    picBoxXian[i].BackColor = Color.Green;
                else
                    picBoxXian[i].BackColor = Color.Red;
        }

        #endregion
    }
}
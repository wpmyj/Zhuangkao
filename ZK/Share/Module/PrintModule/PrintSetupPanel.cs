using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Share.Util;

namespace Cn.Youdundianzi.Share.Module.Print
{
    public partial class PrintSetupPanel : UserControl
    {
        public PrintSetupPanel()
        {
            InitializeComponent();
        }

        public int BarCode_Y
        {
            set { txtBoxBarCode_Y.Text = value.ToString(); }
            get { return int.Parse(txtBoxBarCode_Y.Text); }
        }
        public int BarCode_X
        {
            set { txtBoxBarCode_X.Text = value.ToString(); }
            get { return int.Parse(txtBoxBarCode_X.Text); }
        }
        public int Trace_Y
        {
            set { txtBoxTrace_Y.Text = value.ToString(); }
            get { return int.Parse(txtBoxTrace_Y.Text); }
        }
        public int Trace_X
        {
            set { txtBoxTrace_X.Text = value.ToString(); }
            get { return int.Parse(txtBoxTrace_X.Text); }
        }
        public int CarType_Y
        {
            set { kscx_y.Text = value.ToString(); }
            get { return int.Parse(kscx_y.Text); }
        }
        public int CarType_X
        {
            set { kscx_x.Text = value.ToString(); }
            get { return int.Parse(kscx_x.Text); }
        }

        public int Supervisor_Y
        {
            set { ksyxm_y.Text = value.ToString(); }
            get { return int.Parse(ksyxm_y.Text); }
        }
        public int Supervisor_X
        {
            set { ksyxm_x.Text = value.ToString(); }
            get { return int.Parse(ksyxm_x.Text); }
        }
        public int Date_Y
        {
            set { ksrq_y.Text = value.ToString(); }
            get { return int.Parse(ksrq_y.Text); }
        }
        public int Date_X
        {
            set { ksrq_x.Text = value.ToString(); }
            get { return int.Parse(ksrq_x.Text); }
        }
        public int Result_Y
        {
            set { kscj_y.Text = value.ToString(); }
            get { return int.Parse(kscj_y.Text); }
        }
        public int Result_X
        {
            set { kscj_x.Text = value.ToString(); }
            get { return int.Parse(kscj_x.Text); }
        }
        public int Place_Y
        {
            set { ksdd_y.Text = value.ToString(); }
            get { return int.Parse(ksdd_y.Text); }
        }
        public int Place_X
        {
            set { ksdd_x.Text = value.ToString(); }
            get { return int.Parse(ksdd_x.Text); }
        }
        public int Name_Y
        {
            set { ksxm_y.Text = value.ToString(); }
            get { return int.Parse(ksxm_y.Text); }
        }
        public int Name_X
        {
            set { ksxm_x.Text = value.ToString(); }
            get { return int.Parse(ksxm_x.Text); }
        }

        public void SetValues(PrintSettings psetting)
        {
            Name_X = psetting.Ksxm_x;
            Name_Y = psetting.Ksxm_y;
            Place_X = psetting.Ksdd_x;
            Place_Y = psetting.Ksdd_y;
            Result_X = psetting.Kscj_x;
            Result_Y = psetting.Kscj_y;
            Date_X = psetting.Ksrq_x;
            Date_Y = psetting.Ksrq_y;
            Supervisor_X = psetting.Ksyxm_x;
            Supervisor_Y = psetting.Ksyxm_y;
            CarType_X = psetting.Kscx_x;
            CarType_Y = psetting.Kscx_y;
            Trace_X = psetting.TraceImg_X;
            Trace_Y = psetting.TraceImg_Y;
            BarCode_X = psetting.Tiaomaimg_x;
            BarCode_Y = psetting.Tiaomaimg_y;
        }

        public PrintSettings GetValues()
        {
            PrintSettings settings = new PrintSettings();
            settings.Ksxm_x = this.Name_X;
            settings.Ksxm_y = this.Name_Y;

            settings.Ksdd_x = this.Place_X;
            settings.Ksdd_y = this.Place_Y;

            settings.Ksrq_x = this.Date_X;
            settings.Ksrq_y = this.Date_Y;

            settings.Kscj_x = this.Result_X;
            settings.Kscj_y = this.Result_Y;

            settings.Kscx_x = this.CarType_X;
            settings.Kscx_y = this.CarType_Y;

            settings.Ksyxm_x = this.Supervisor_X;
            settings.Ksyxm_y = this.Supervisor_Y;

            settings.Tiaomaimg_x = this.BarCode_X;
            settings.Tiaomaimg_y = this.BarCode_Y;

            settings.TraceImg_X = this.Trace_X;
            settings.TraceImg_Y = this.Trace_Y;

            return settings;
        }
    }
}

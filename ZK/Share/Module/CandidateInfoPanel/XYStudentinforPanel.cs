using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Share.Module.Score;
using Cn.Youdundianzi.Share.Module.Login;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    public partial class XYStudentinforPanel : CandExamCtrl
    {
       
        XYDALCandidate DALcand;

        public XYStudentinforPanel()
        {
            InitializeComponent();
        }

        protected override void ResetPanel()
        {
            cand = null;
            examTimes = 0;
            EnableAndSetText(this.TextBox_Input, true, string.Empty);
            EnableAndSetText(this.label_xm, true, "姓名：");
            EnableAndSetText(this.label_lsh, true, "流水号：");
            EnableAndSetText(this.label_zkzhm, true, "准考证：");
            EnableAndSetText(this.label_sfzhm, true, "身份证：");
            EnableAndSetText(this.label_kscx, true, "考试车型：");
            EnableAndSetText(this.label_kscs, true, "考试次数：");
            EnableAndSetText(this.label_jbr, true, "经办人：");
            EnableAndSetText(this.label_kchp, true, "考车号牌：");
            EnableCtrl(this.btnXReject, false);
            EnableCtrl(this.ButtonStart, false);
            if (this.ExamCtrl != null)
            {
                EnableCtrl(this.ExamCtrl, false);
            }

            LEDDisplayChange("准备考试");
            CameraChannelChange(settings.CameraConfig.YuntaiChannel);
            ExamResultReady(0, string.Empty);
        }


        private void btnXReject_Click(object sender, EventArgs e)
        {
            ResetPanel();
        }

        void ButtonStart_Click(object sender, System.EventArgs e)
        {
            if (this.ExamCtrl != null)
                this.ExamCtrl.Enabled = true;
            this.btnXReject.Enabled = false;
            this.ButtonStart.Enabled = false;
        }

        private void TextBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                getStudentInfoFromLocal();
            }

        }


        private void getStudentInfoFromLocal()
        {

            cand = DALcand.GetStudentInfo(TextBox_Input.Text);
            if (cand != null)
            {
                label_xm.Text = "姓名：" + cand.Xm;
                label_lsh.Text = "流水号：" + cand.Lsh;
                label_zkzhm.Text = "准考证：" + cand.Zkzmbh;
                label_sfzhm.Text = "身份证：" + cand.Sfzmhm;
                label_kscx.Text = "考试车型：" + cand.Kscx;
                label_kscs.Text = "考试次数：" + cand.Kscs.ToString();
                label_jbr.Text = "经办人：" + cand.Jbr;
                comboBox1.Text = CMyGlobal.G_Login_Username;
                cand.Ksy1 = comboBox1.Text;
                cand.Ksy2 = comboBox2.Text;

                LEDDisplayChange(cand.Xm);
                CameraChannelChange(settings.CameraConfig.YuntaiChannel);
                SoundChange(cand.Xm + "准备考试。");

                this.TextBox_Input.Enabled = false;
                this.btnXReject.Enabled = true;
                this.ButtonStart.Enabled = true;
            }
            else
            {
                MessageBox.Show("该考生不存在，请输入正确的考试证号！");
                TextBox_Input.Text = "";
                this.TextBox_Input.Focus();
            }
        }


        protected override void ExamStart()
        {
            if (cand != null)
            {
                LEDDisplayChange("正在考试");
                CameraChannelChange(settings.CameraConfig.GaoChannel);
                if (examTimes == 0)
                    SoundChange(cand.Xm + ",请上车,开始考试!");
                else
                    SoundChange(cand.Xm + ",第二回合开始考试!");

                if (examTimes == 0)
                {
                    EnableCtrl(this.btnXReject, false);
                    EnableCtrl(this.ButtonStart, false);
                }
                //EnableCtrl(this.TextBox_Input, false);
            }
        }

        protected override void ExamStop()
        {
            if (examTimes == 0)
            {
                //EnableCtrl(this.btnXReject, true);
                ResetPanel();
            }
        }

        protected override void ExamPass(string msg)
        {
            examTimes = examTimes + 1;
            if (cand != null)
            {
                cand.Kscs++;
                cand.Zt = "1";
                cand.Kscj = 1;

                if (examTimes == 1)
                    cand.KS1 = msg;
                if (examTimes == 2)
                    cand.KS2 = msg;

                //examResult.SetResultText(cand.HuiHeShu, msg);
                LEDDisplayChange(msg);
                SoundChange(cand.Xm + "," + msg + ",考试结束,请将车开到起点,下车换人。");
                ExamResultReady(examTimes, msg);

                StoreAndPrint(msg);
            }
            ResetPanel();
        }

      

        protected override void ExamFail(string msg)
        {
            LEDDisplayChange(msg);
            examTimes = examTimes + 1;
            if (cand != null)
            {
                if (examTimes == 1)
                {
                    cand.KS1 = msg;
                    SoundChange(cand.Xm + "," + msg + ",第一回合结束，请将车开到起点。");
                    ExamResultReady(examTimes, msg);

                    //ShowMsgBox(this, msg);
                }
                if (examTimes == 2)
                {
                    cand.Kscj = 0;
                    cand.Kscs++;
                    cand.Zt = "2";
                    cand.KS2 = msg;
                    SoundChange(cand.Xm + "," + msg + ",考试结束。,请将车开到起点，下车换人。");
                    ExamResultReady(examTimes, msg);

                    StoreAndPrint(msg);
                }
            }

            //examResult.SetResultText(cand.HuiHeShu, msg);
           
            if (examTimes == 2)
            {
                ResetPanel();
            }  
  
        }


        /*------------------------------------------------------------------------
         考试结束弹出对话框, 按确认按钮存盘并打印,按Ctrl+L快捷键取消本次存盘和打印
        --------------------------------------------------------------------------*/
        protected void  StoreAndPrint(string msg)
        {  
           XYfrmMessage  frmmsgbox=new XYfrmMessage(msg);
           frmmsgbox.ShowDialog();
           if (frmmsgbox.DialogResult == DialogResult.OK)
           {
               if (!DoStore())
               {
                   MessageBox.Show("数据库写错误！");
               }
               else
               {
                   DoPrint();
               }
           }
        }

      
        protected override bool DoStore()
        {
            try
            {
                bool result = DALcand.SaveInfo(cand);
                if (result)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        /*----------信阳成绩单打印格式--------------------------------------
            考生姓名：   XY考生：赵本山
            考试车型：   C1
            考试成绩：   合格/不合格
            考试日期：   090913
                  注：   只有第一次考试打印考生姓名和车型
        -------------------------------------------------------------------*/

        protected override void DoPrint()
        {
            try
            {
                if (settings.PrintConfig.Isprint)
                {
                    if (cand.Kscs == 1)
                    {
                        _printContent.kscxstr = cand.Kscx;
                        _printContent.ksxmstr = "XY考生：" + cand.Xm;
                    }
                    else
                    {
                        _printContent.kscxstr = "";
                        _printContent.ksxmstr = "";
                    }
                      
                    _printContent.ksrqstr = cand.Ksrq.ToString("yyMMdd");
                  
                    if (cand.Kscj == 1)
                        _printContent.kscjstr = "合格";
                    else
                        _printContent.kscjstr = "不合格";

                    _printContent.kscjtxt.mmX = settings.PrintConfig.Kscj_x + (cand.Kscs - 1) * 12;
                    _printContent.ksrqtxt.mmX = settings.PrintConfig.Kscj_x + (cand.Kscs - 1) * 12;

                    _printContent.tiaoma = GenCode128.Code128Rendering.MakeBarcodeImage(cand.Zkzmbh, 1, true);
                    _printContent.Print();  
                }
            }
            catch
            {
                MessageBox.Show("打印失败,请检查打印机是否连接好！");
            }
        }

        private void XYStudentinforPanel_Load(object sender, EventArgs e)
        {
            DALcand = new XYDALCandidate(settings);
        }
    }
}


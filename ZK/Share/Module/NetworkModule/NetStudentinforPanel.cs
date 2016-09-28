using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Cn.Youdundianzi.Share.Module.Network;
using Cn.Youdundianzi.Share.Module.Score;

namespace Cn.Youdundianzi.Share.Module.CandidateInfo
{
    public partial class NetStudentinforPanel : CandExamCtrl
    {
        public CNetClient Client;

        NetDALCandidate DALcand;

        CandidateQuery candQuery;
        public NetStudentinforPanel(CandidateQuery CandQuery)
        {
            InitializeComponent();
            candQuery = CandQuery;
            this.labelDevNum.Text = this.settings.Devnum.ToString();
        }

        //网络事件
        private void Client_Event_Devnetdata(CNetData data)
        {
            switch (data.cmdCommand)
            {
                case Command.Zkzhm:
                    cand=DALcand.GetStudentInfo(data.strZjbh);
                    if (cand != null)
                    {
                        EnableAndSetText(this.label_xm, true, "姓名：" + cand.Xm);
                        EnableAndSetText(this.label_lsh, true, "流水号：" + cand.Lsh);
                        EnableAndSetText(this.label_zkzhm, true, "准考证：" + cand.Zkzmbh);
                        EnableAndSetText(this.label_sfzhm, true, "身份证：" + cand.Sfzmhm);
                        EnableAndSetText(this.label_kscx, true, "考试车型：" + cand.Kscx);
                        EnableAndSetText(this.label_kscs, true, "考试次数：" + cand.Kscs.ToString());
                        EnableAndSetText(this.label_jbr, true, "经办人：" + cand.Jbr);
                        EnableAndSetText(this.label_kchp, true, "考车号牌：" + cand.Kchp);
                        EnableCtrl(this.btnXReject, true);
                        EnableCtrl(this.ButtonStart, false);
                      
                        if (this.ExamCtrl != null)
                        {
                            EnableCtrl(this.ExamCtrl, true);
                            LEDDisplayChange(cand.Xm);
                        }
                    }
                    break;
                case Command.AddStudent:
                    if (candQuery != null)
                    {
                        candQuery.AddCandidate(data.strZjbh, data.Xm);
                    }
                    break;
                case Command.DeleteStudent:
                    if (candQuery != null)
                    {
                        candQuery.DeleteCandidate(data.strZjbh);
                    }
                    break;
                case Command.ClearStudent:
                    if (candQuery != null)
                    {
                        candQuery.ClearCandidate();
                    }
                    break;
            }
        }

        protected override void ResetPanel()
        {
            cand = null;
            examTimes = 0;
            EnableAndSetText(this.label_xm, true, "姓名：");
            EnableAndSetText(this.label_lsh, true, "流水号：");
            EnableAndSetText(this.label_zkzhm, true, "准考证：");
            EnableAndSetText(this.label_sfzhm, true, "身份证：");
            EnableAndSetText(this.label_kscx, true, "考试车型：");
            EnableAndSetText(this.label_kscs, true, "考试次数：");
            EnableAndSetText(this.label_jbr, true, "经办人：");
            EnableAndSetText(this.label_kchp, true, "考车号牌：");
            EnableCtrl(this.btnXReject, false);
            EnableCtrl(this.ButtonStart, true);
            if (this.ExamCtrl != null)
            {
                EnableCtrl(this.ExamCtrl, false);
            }
            CameraChannelChange(settings.CameraConfig.YuntaiChannel);
            ExamResultReady(0, string.Empty);
        }


        //拒绝考生
        private void btnXReject_Click(object sender, EventArgs e)
        {
            CNetData data = new CNetData();
            data.cmdCommand = Command.Jjks;
            data.intDevnum = settings.Devnum;
            data.strZjbh = cand.Zkzmbh;
            Client.SendData(data);

            ResetPanel();
        }


        /*
         * 声音
         * 显示牌
         * 摄像
         * 用户界面
         * 网络中心
         */

        protected override void ExamStart()
        {
            if (cand != null)
            {
                cand.Ksy1 = comboBox1.Text;
                cand.Ksy2 = comboBox2.Text;

                if (examTimes == 0)
                    SoundChange(cand.Xm + ",请上车,开始考试!");
                else
                    SoundChange(cand.Xm + ",第二回合开始考试!");

                LEDDisplayChange("正在考试");

                CameraChannelChange(settings.CameraConfig.GaoChannel);

              
                if (examTimes == 0)
                    EnableCtrl(this.btnXReject, false);

                CNetData tmpdata = new CNetData();
                tmpdata.cmdCommand = Command.Ksks;
                tmpdata.intDevnum = settings.Devnum;
                Client.SendData(tmpdata);
            }
        }

        protected override void ExamStop()
        {
            if (examTimes == 0)
                EnableCtrl(this.btnXReject, true);

        }

        /*
         * 考生数据处理(次数+1、状态置为1、考试成绩、设置回合数、考试结果信息、)
         * 用户界面(考试合格提示框，更新结果信息面板)
         * 声音(姓名+考试结果+考试结束)
         * 显示牌(考试结果)
         * 存盘打印
         * 网络中心通信
         */
        protected override void ExamPass(string msg)
        {
            examTimes = examTimes + 1;
            if (cand != null)
            {
                cand.Kscs++;
                cand.Zt = "1";
                cand.Kscj = 100;

                if (examTimes == 1)
                    cand.KS1 = msg;
                if (examTimes == 2)
                    cand.KS2 = msg;

                SoundChange(cand.Xm + "," + msg + ",考试结束。");
                LEDDisplayChange(msg);
                ExamResultReady(examTimes, msg);
               
                ShowMsgBox(this,msg);
                StoreAndPrint();
               
                CNetData tmpdata = new CNetData();
                tmpdata.cmdCommand = Command.Kswc;
                tmpdata.intDevnum = settings.Devnum;
                tmpdata.strZjbh = cand.Zkzmbh;
                Client.SendData(tmpdata);
            }
          

            ResetPanel();
        }

 
        protected override void ExamFail(string msg)
        {
            examTimes = examTimes + 1;
            if (cand != null)
            { 
                if (examTimes == 1)
                {
                    cand.Kfxm = CKfxm.GetKfxm(msg);
                    cand.KS1 = msg;
                    SoundChange(cand.Xm + "," + msg + ",第一回合结束。");
                }
                if (examTimes == 2)
                {
                    cand.Kfxm = cand.Kfxm.Trim() + "," + CKfxm.GetKfxm(msg).Trim();
                    cand.Kscs++;
                    cand.Zt = "2";
                    cand.Kscj = 0;
                    cand.KS2 = msg;
                    SoundChange(cand.Xm + "," + msg + ",考试结束。");
                    StoreAndPrint();

                    CNetData tmpdata = new CNetData();
                    tmpdata.cmdCommand = Command.Kswc;
                    tmpdata.intDevnum = settings.Devnum;
                    tmpdata.strZjbh = cand.Zkzmbh;
                    Client.SendData(tmpdata);
                }
                LEDDisplayChange(msg);
                ExamResultReady(examTimes, msg);

                ShowMsgBox(this, msg);
            }

            if (examTimes == 2)
            {
                ResetPanel();
            }  
        }

       

        //申请考试
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            CNetData GetStudent_data = new CNetData();
            GetStudent_data.cmdCommand = Command.GetStudent;
            GetStudent_data.intDevnum = settings.Devnum;
            Client.SendData(GetStudent_data);

            
        }

        private void NetStudentinforPanel_Load(object sender, EventArgs e)
        {
            DALcand = new NetDALCandidate(settings);
            try
            {
                //准备客户端连接
                Client = new CNetClient(settings.ServerIP, settings.Devnum);
                Client.Connect();
                Client.Event_Devnetdata += new CNetClient.D_DEVNETDATA(Client_Event_Devnetdata);

                //更新排队列表
                CNetData data = new CNetData();
                data.cmdCommand = Command.Updatelist;
                data.intDevnum = settings.Devnum;
                Client.SendData(data); 
            }
            catch
            {
                MessageBox.Show("不能与点名中心建立网络连接", settings.Devnum.ToString());
            }

        }


    
        protected void StoreAndPrint()
        {
                if (!DoStore())
                {
                    MessageBox.Show("数据库写错误！");
                }
                else
                {
                    if(cand.Kscj==100)
                       DoPrint();
                }
            }
        


        protected override bool DoStore()
        {
            try
            {
                bool result=DALcand.SaveInfo(cand);
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


        /*----------郑州成绩单打印格式--------------------------------------
                    注：合格打印 不合格不打印
        -------------------------------------------------------------------*/

        protected override void DoPrint()
        {
            try
            {
                if (settings.PrintConfig.Isprint)
                {
                    _printContent.ksddstr = settings.KSDD;
                    _printContent.ksrqstr = cand.Ksrq.ToString();
                    _printContent.ksxmstr = cand.Xm;
                    _printContent.ksyxmstr = cand.Ksy1;
                    _printContent.kscjstr = "合格";
                    _printContent.tiaoma = GenCode128.Code128Rendering.MakeBarcodeImage(cand.Zkzmbh, 1, true);
                    _printContent.Print();  
                }
            }
            catch
            {
                MessageBox.Show("打印失败,请检查打印机是否连接好！");
            }
        }

        //关闭资源
        public override void CloseResources()
        {
            base.CloseResources();
            CNetData data = new CNetData();
            data.cmdCommand = Command.Logout;
            data.intDevnum = settings.Devnum;
            data.strZjbh = null;
            Client.SendData(data);
            Client.Close();

        }

      

    }
}


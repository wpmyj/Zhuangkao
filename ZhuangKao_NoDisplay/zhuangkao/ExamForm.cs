using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.IO;
using AviFile;
namespace zhuangkao
{
    public partial class ExamForm : Form, IMonObserve
    {



        public CNetClient Client;
        private bool isstart;//控制是否开始考试
        public  ModuleSettings settings;//系统配置类
        private CDisplayManager CDM;//控制模拟系统显示
        private CGanFairy[] gan; //杆类型，在CDisplayManager注册即可显示
        private CLineFairy[] xian;//线类型
        private CBmpFairy che;//车类型
        private Bitmap[] ganbm;//杆的显示图片，包含有信号无信号及屏蔽
        public  CMonitor cm;//信号接收控制
        private delegate void InvokeDelegate();
        private InvokeDelegate myInvoke;//PICTURE刷新处理
        private InvokeDelegate formInvoke;
        private StateManager statemanager;
        private CHotkeyApp Hkey;
        private CMonData form_mdata;
        public int[] StateTime;
        public  CStudent student;
        private bool _isExam;
        private CPrintContent myprint;
        private CIDCardInfo idcardinfo;//身份证识别
        private Trace myTrace;
        private zhuangkao.video.Camera camera;
        //private Displaycomm.CDisplaycomm displaycomm;
        //private System.Windows.Forms.Timer videoTimer;
        //private string tempBmpDir = string.Empty;
        //private Int32 bmpCounter = 0;


        public bool IsExam
        {
            get { return _isExam; }
        }

        public ExamForm(int chetype,bool isExam)
        {
            InitializeComponent();
            form_mdata = new CMonData();
            _isExam = isExam;
            settings = ModuleConfig.GetSettings();
            //tempBmpDir = Environment.CurrentDirectory + @"\Temp\";
            //if (!Directory.Exists(tempBmpDir))
            //    Directory.CreateDirectory(tempBmpDir);
            
            //显示牌初始化
            //displaycomm = new zhuangkao.Displaycomm.CDisplaycomm(settings);
            //displaycomm.Setdisplaytype = Displaycomm.DisplayType.Zhidisp;
            

            pictureBox_photo.ImageLocation = "img\\photonull.bmp";
            if (isExam)
            {
                //displaycomm.ShowText("准备考试");
                if (settings.IsNetwork)
                {
                    try
                    {
                        Client = new CNetClient(settings.ServerIP, settings.Devnum);
                        Client.Connect();
                        Client.Event_Devnetdata += new CNetClient.D_DEVNETDATA(netclient_Event_Devnetdata);
                    }
                    catch
                    {
                        MessageBox.Show("不能与点名中心建立网络连接", settings.Devnum.ToString() + "号库");
                    }
                }
		        else
                {
                    ButtonStart.Text = "开始考试";
                }
                //-------------身份证识别-------------------------
                idcardinfo = new CIDCardInfo();
                idcardinfo.InitIDcardDev();
                idcardinfo.Start();
                idcardinfo.OnIDCardReceived += new CIDCardInfo.IDCardRequest(idcardinfo_OnIDCardReceived);
                //----------------------------------------------------------------
                student = new CStudent(settings);//增加后台数据库连接时间所以将初始化学员信息前置
                //pictureBox2.Visible = false ;

                if (chetype == 0)
                {
                    this.Text = "小型车考试";
                }
                else
                {
                    this.Text = "大型车考试";
                }
                ToolTip toolTip1 = new ToolTip();
                //--------------鼠标悬停提示------------------------
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.showLinkState1, "本地数据库连接");
                toolTip1.SetToolTip(this.showLinkState2, "远端数据库连接");

                //-----------初始化考试信息文本框-------------------
                //StudentText = new TextBox[7];
                //for (int i = 0; i < 7; i++)
                //{
                //    StudentText[i] = new System.Windows.Forms.TextBox();
                //    this.navigationPanePanel1.Controls.Add(this.StudentText[i]);
                //    this.StudentText[i].Location = new System.Drawing.Point(65, 13 + i * 20);
                //    this.StudentText[i].Size = new System.Drawing.Size(115, 21);
                //    this.StudentText[i].TabIndex = i;
                //    this.StudentText[i].KeyPress += new KeyPressEventHandler(this.StudentText_KeyPress);
                //}
                //this.StudentText[0].Leave += new System.EventHandler(this.StudentText_Leave);
                //-----------数据库连接状态灯----------------------
                showLinkState1.init();
                showLinkState2.init();
                //-------------综合初始化-----------------------------
                //-------考验员信息----------
                string tmpconnstr = "Data Source="+ settings.Ipaddress +";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";//mssql数据库链接
                CDatabase tmpdb = new CMsSqlDatabase(tmpconnstr);
                //if (!tmpdb.OpenConnect())
                //{
                //    MessageBox.Show("数据库连接故障！");
                //    this.Close();
                //    return;
                //}
                while (!tmpdb.OpenConnect()) ;


                IDataReader dr = tmpdb.executeReader("select name from kyy");

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["name"]);
                    comboBox2.Items.Add(dr["name"]);
                }
                dr.Close();
                tmpdb.CloseConnect();
                comboBox1.Text = comboBox1.Items[0].ToString();
                comboBox2.Text = comboBox2.Items[0].ToString();
                // --------学员信息-----------
                // student = new CStudent(settings);
                //Thread.Sleep(500);
                student.GetKsNumber();
                label_pass.Text = "合格：" + student.PassNumber.ToString() + "人";
                label_nopass.Text = "不合格：" + student.NoPassNumber.ToString() + "人";
                label_sum.Text = "共计：" + Convert.ToString(student.PassNumber + student.NoPassNumber) + "人";

                showLinkState1.LinkState = student.LinkState1;//显示连接状态
                showLinkState2.LinkState = student.LinkState2;
                myprint = new CPrintContent();//初始化打印
                ButtonStart.Text = "申请考试";

                //初始化排队考生列表
                StudentlistView.GridLines = true;
                StudentlistView.FullRowSelect = true;//要选择就是一行 
                StudentlistView.View = View.Details;//定义列表显示的方式 
                StudentlistView.Scrollable = true;//需要时候显示滚动条 
                StudentlistView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                StudentlistView.Columns.Add("序号", StudentlistView.Width * 1 / 6 + 2, HorizontalAlignment.Left);
                StudentlistView.Columns.Add("姓名", StudentlistView.Width * 2 / 6 - 4, HorizontalAlignment.Left);
                StudentlistView.Columns.Add("证号", StudentlistView.Width * 3 / 6 - 3, HorizontalAlignment.Left);
            }
            else
            {
                
                if (chetype == 0)
                {
                    this.Text = "小型车练习";
                }
                else
                {
                    this.Text = "大型车练习";
                }
                //displaycomm.ShowText("准备练习");
                ButtonStart.Text = "开始考试";
            }
            myinit(chetype);
        }

        public void myinit(int chetype)
        {
           // Graphics g = this.pictureBox1.CreateGraphics();
           
        
            CDM = new CDisplayManager();
            cm = new CMonitor();
            cm.Che_Type = chetype;
            cm.RegMonitor(this);
            myInvoke = new InvokeDelegate(Invokefun);
            formInvoke = new InvokeDelegate(formInvokefun);

            //-----------初始化线数据-----------------------------
            xian = new CLineFairy[9];

            xian[0] = new CLineFairy(170, 125, 170, 370);
            xian[0].LineName = "1";
            xian[0].Linex = xian[0].X1-9;
            xian[0].Liney = xian[0].Y1 - 120;
            CDM.RegDisplay(xian[0]);


            xian[1] = new CLineFairy(260, 125, 260, 370);
            xian[1].LineName = "2";
            xian[1].Linex = xian[1].X1 - 9;
            xian[1].Liney = xian[1].Y1 - 120;
            CDM.RegDisplay(xian[1]);

            xian[2] = new CLineFairy(350, 125, 350, 370);
            xian[2].LineName = "3";
            xian[2].Linex = xian[2].X1 - 9;
            xian[2].Liney = xian[2].Y1 - 120;
            CDM.RegDisplay(xian[2]);

            xian[3] = new CLineFairy(20, 125, 170, 125);
            xian[3].LineName = "4";
            xian[3].Linex = xian[3].X1 - 20;
            xian[3].Liney = xian[3].Y1 - 7;
            CDM.RegDisplay(xian[3]);


            xian[6] = new CLineFairy(170, 125, 260, 125);
            CDM.RegDisplay(xian[6]);
            xian[7] = new CLineFairy(260, 125,350, 125);
            CDM.RegDisplay(xian[7]);
            xian[8] = new CLineFairy(350, 125, 508, 125);
            CDM.RegDisplay(xian[8]);


            xian[4] = new CLineFairy(170, 370, 350, 370);
            xian[4].LineName = "5";
            xian[4].Linex = xian[4].X1 - 30;
            xian[4].Liney = xian[4].Y1 - 7;
            CDM.RegDisplay(xian[4]);

            xian[5] = new CLineFairy(20, 30, 508, 30);
            xian[5].LineName = "6";
            xian[5].Linex = xian[5].X1 - 20;
            xian[5].Liney = xian[5].Y1 - 7;
            CDM.RegDisplay(xian[5]);


            //-----------线数据初始化结束-----------------------------
            // 车初始化
            if (chetype == 0)
            {
                che = new CBmpFairy(".\\img\\scar00.gif");
            }
            else
            {
                che = new CBmpFairy(".\\img\\car00.gif");
            }
            che.SetWeizhi(445, 75);
            CDM.RegDisplay(che);
            che.Speed = 1;
            che.RSpeed=3;;


            //-----------初始化杆数据-----------------------------
            ganbm = new Bitmap[3];
            ganbm[0] = new Bitmap(".\\img\\green2.gif");
            ganbm[1] = new Bitmap(".\\img\\red2.gif");
            ganbm[2] = new Bitmap(".\\img\\gray2.gif");
            for (int i = 0; i < 3; i++)
            {
                Color backcolor = ganbm[i].GetPixel(1, 1);
                ganbm[i].MakeTransparent(backcolor);
            }
            gan = new CGanFairy[6];
            for (int i = 0; i < 6; i++)
            {
                gan[i] = new CGanFairy(ganbm);
                CDM.RegDisplay(gan[i]);
                gan[i].GanName = Convert.ToString(i + 1);
            }

            gan[0].X = 160;
            gan[0].Y = 115;

            gan[1].X = 250;
            gan[1].Y = 115;

            gan[2].X = 340;
            gan[2].Y = 115;


            gan[3].X = 160;
            gan[3].Y = 360;

            gan[4].X = 250;
            gan[4].Y = 360;

            gan[5].X = 340;
            gan[5].Y = 360;

            //------杆数据初始化完成
            //---读配置文件屏蔽杆，线，车信号
            for (int i = 0; i < 6; i++)
            {
                if (((settings.PbGan_s >> i) & 1) == 1)
                {
                    cm.Shield(0, i+1);
                    gan[i].Stat = -1;
                }
                if (((settings.PbXian_s >> i) & 1) == 1)
                {
                    cm.Shield(1, i + 1);
                    xian[i].Stat = -1;
                }
                if (i < 4)
                {
                    if (((settings.PbChe_s>> i) & 1) == 1)
                    {
                        cm.Shield(2, i + 1);
                    }
                }
            }
         
          
           //--------各状态初始化----------
            double horRate = (double)pictureBoxTrace.Width / (double)pictureBox1.Width;
            double virRate = (double)pictureBoxTrace.Height / (double)pictureBox1.Height;
            
            myTrace = new Trace(horRate, virRate, che, xian);
            che.CarTrace = myTrace;
            statemanager = new StateManager(gan, xian, che, this);
            StateManager.SwitchState("State0");
            StateTime = new int[20];
            if (chetype == 0)
            {
                StateTime[2] = settings.State2_Time_s;
                StateTime[3] = settings.State3_Time_s;
                StateTime[4] = settings.State4_Time_s;
                StateTime[5] = settings.State5_Time_s;
                StateTime[6] = settings.State6_Time_s;
                StateTime[7] = settings.State7_Time_s;
                StateTime[8] = settings.State8_Time_s;
                StateTime[9] = settings.State9_Time_s;
                StateTime[10] = settings.State10_Time_s;
                StateTime[11] = settings.State11_Time_s;
                StateTime[12] = settings.State12_Time_s;
                StateTime[13] = settings.State13_Time_s;
                StateTime[14] = settings.State14_Time_s;
                StateTime[15] = settings.State15_Time_s;
                StateTime[16] = settings.State16_Time_s;
                StateTime[17] = settings.State4i_Time_s;
                StateTime[18] = settings.State14i_Time_s;
            }
            else
            {
                StateTime[2] = settings.State2_Time_l;
                StateTime[3] = settings.State3_Time_l;
                StateTime[4] = settings.State4_Time_l;
                StateTime[5] = settings.State5_Time_l;
                StateTime[6] = settings.State6_Time_l;
                StateTime[7] = settings.State7_Time_l;
                StateTime[8] = settings.State8_Time_l;
                StateTime[9] = settings.State9_Time_l;
                StateTime[10] = settings.State10_Time_l;
                StateTime[11] = settings.State11_Time_l;
                StateTime[12] = settings.State12_Time_l;
                StateTime[13] = settings.State13_Time_l;
                StateTime[14] = settings.State14_Time_l;
                StateTime[15] = settings.State15_Time_l;
                StateTime[16] = settings.State16_Time_l;
                StateTime[17] = settings.State4i_Time_l;
                StateTime[18] = settings.State14i_Time_l;
            }
            cm.Start();//接收信号线程启动
            isstart = false;
            timer1.Start();//屏幕刷新启动
            Hkey = new CHotkeyApp(this.Handle);//热键系统启动
            toolStripStatusLabel1.Text = "状态：准备考试";
            this.pictureBoxTrace.Paint += new PaintEventHandler(myTrace.DrawTrace);
       }

        //网络事件处理
        public delegate void Labelinvoke(CNetData data);
        private void netclient_Event_Devnetdata(CNetData data) 
        {
            switch (data.cmdCommand)
            {
                case Command.Zkzhm:
                    if (label_xm.InvokeRequired || label_lsh.InvokeRequired || label_zkzhm.InvokeRequired)
                    {
                        label_xm.BeginInvoke(new Labelinvoke(netclient_Event_Devnetdata), data);
                    }
                    else
                    {
                        if (student.GetStudentInfo(data.strZjbh))
                        {
                            label_xm.Text = "姓名：" + student.Xm;
                            label_lsh.Text = "流水号：" + student.Lsh;
                            label_zkzhm.Text = "准考证：" + student.Zkzmbh;
                            label_sfzhm.Text = "身份证：" + student.Sfzmhm;
                            label_kscx.Text = "考试车型：" + student.Kscx;
                            label_kscs.Text = "考试次数：" + student.Kscs.ToString();
                            label_jbr.Text = "经办人：" + student.Jbr;

                            ButtonStart.Text = "开始考试";
                            //displaycomm.ShowText(student.Xm);
                            buttonX2.Enabled = true;
                            ButtonStart.Focus();
                        }
                    }
                    break;
                case Command.AddStudent:
                    if (StudentlistView.InvokeRequired)
                    {
                        StudentlistView.BeginInvoke(new Labelinvoke(netclient_Event_Devnetdata), data);
                    }
                    else
                    {
                        AddStudentforlistview(data.strZjbh, data.Xm);
                    }
                    break;
                case Command.DeleteStudent:
                    if (StudentlistView.InvokeRequired)
                    {
                        StudentlistView.BeginInvoke(new Labelinvoke(netclient_Event_Devnetdata), data);
                    }
                    else
                    {
                        DeleteStudentforlistview(data.strZjbh);
                    }
                    break;
                case Command.ClearStudent:
                    if (StudentlistView.InvokeRequired)
                    {
                        StudentlistView.BeginInvoke(new Labelinvoke(netclient_Event_Devnetdata), data);
                    }
                    else
                    {
                        ClearStudentlistview();
                    }
                    break;
            }
        }

        private void ClearStudentlistview()
        {
            StudentlistView.Items.Clear();
        }

        private void DeleteStudentforlistview(string zkzmbh)
        {
            List<int> delitem = new List<int>();
            for (int i = 0; i < StudentlistView.Items.Count; i++)
            {
                if (StudentlistView.Items[i].SubItems[2].Text.Trim() == zkzmbh)
                {
                    delitem.Add(i);
                }
            }
            for (int i = 0; i < delitem.Count; i++)
            {
                StudentlistView.Items[i].Remove();
            }
        }

        private void AddStudentforlistview(string zkzmbh, string xm)
        {
            ListViewItem Item = new ListViewItem();
            Item.SubItems[0].Text = StudentlistView.Items.Count.ToString();
            Item.SubItems.Add(xm);
            Item.SubItems.Add(zkzmbh);
            if ((StudentlistView.Items.Count % 2) == 0)
            {
                Item.BackColor = Color.White;
            }
            else
            {
                Item.BackColor = Color.FromArgb(255, 214, 224, 236);
                Item.SubItems[1].BackColor = Color.FromArgb(255, 214, 224, 236);
                Item.SubItems[2].BackColor = Color.FromArgb(255, 214, 224, 236);

            }
            Item.ForeColor = Color.FromArgb(255, 69, 98, 135);
            Item.SubItems[1].ForeColor = Color.FromArgb(255, 69, 98, 135);
            Item.SubItems[2].ForeColor = Color.FromArgb(255, 69, 98, 135);
            StudentlistView.Items.Add(Item);
        }

       public void KaoShiEndFun(int kscj, string sm)//考试结束处理函数
       {
           //displaycomm.ShowText(sm);
           StateManager.Close();
           isstart = false;
           Hkey.StopHotkey();
            //MessageBox.Show(sm+"考试结束！");
           //button1.Enabled = true;
           if (_isExam)
           {
               //在此处添加摄像停止并保存功能
               //videoTimer.Stop();
               //string videoDir = Environment.CurrentDirectory + @"\Video\";
               //if (!Directory.Exists(videoDir))
               //    Directory.CreateDirectory(videoDir);
               //string destPath = videoDir + student.Lsh + Guid.NewGuid().ToString() + ".avi";
               
               //makeVideo(tempBmpDir, destPath);

               if ((kscj == 1) || (student.HuiHeShu == 2))
               {
                   //打印合格
                   //清除输入内容，解除输入框只读
                   //此处为河南省考表打印格式，需根据地方需求而改变

                   //myprint.ksddstr = settings.Ksdd;
                   //myprint.ksrqstr = System.DateTime.Now.ToString();
                   //myprint.ksxmstr = student.Xm;
                   //myprint.ksyxmstr = student.Ksy1;
                   //myprint.kscjstr = "1";
                   //myprint.Print();   //取消注释即可打印

                   //-----------写入考试结果到数据库--------------
                   if (student.HuiHeShu == 1)
                   {
                       student.KS1 = sm;
                       label_ks1.Text = "第一回合考试：" + sm;
                   }
                   else
                   {
                       student.KS2 = sm;
                       label_ks2.Text = "第二回合考试：" + sm;
                   }
                   //Bitmap bm = new Bitmap(pictureBoxTrace.Image);
                   //bm.Save(@"C:\" + Guid.NewGuid().ToString(null) + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                   student.Kscj = kscj;//写入考试成绩
                   student.Kscs++;   //考试次数加1
                   student.Ksy1 = comboBox1.Text;
                   student.Ksy2 = comboBox2.Text;

                   if (!student.SaveInfo())
                   {
                       MessageBox.Show("数据库写错误！");
                   }
                   else
                   {
                       //考试完成，发送kswc命令到点名中心
                       if (settings.IsNetwork)
                       {
                           CNetData tmpdata = new CNetData();
                           tmpdata.cmdCommand = Command.Kswc;
                           tmpdata.intDevnum = settings.Devnum;
                           tmpdata.strZjbh = student.Zkzmbh;
                           Client.SendData(tmpdata);
                           ButtonStart.Text = "申请考试";
                           ButtonStart.Enabled = true;
                       }
                       InitStudent();
                   }
                   CVoice.Play(student.Xm + "?" + sm + "?考试结束");
                   MessageBox.Show(sm + "! 考试结束！");
                 
                   //------------初始化输入信息----------------
                   //TextBox_Input.Enabled = true;
                   //TextBox_Input.Text = "";
                   //for (int i = 1; i < 7; i++)
                   //{
                   //    StudentText[i].ReadOnly = false;
                   //    StudentText[i].Text = "";
                   //}
                   //StudentText[0].Focus();
                   student.Clear();
                   label_ks1.Text = "第一回合考试：";
                   label_ks2.Text = "第二回合考试：";
                   student.GetKsNumber(); //得到考试人数
                   label_pass.Text = "合格：" + student.PassNumber.ToString() + "人";
                   label_nopass.Text = "不合格：" + student.NoPassNumber.ToString() + "人";
                   label_sum.Text = "共计：" + Convert.ToString(student.PassNumber + student.NoPassNumber) + "人";
               }
               else
               {
                   label_ks1.Text = "第一回合考试：" + sm;
                   CVoice.Play(student.Xm + "?" + sm + "?第一回合结束");
                   MessageBox.Show(sm + "! 第一回合结束！");
                   student.KS1 = sm;
                   student.HuiHeShu = 2;
                   ButtonStart.Enabled = true;
               }
               if (!Directory.Exists(Environment.CurrentDirectory + @"\Trace\"))
                   Directory.CreateDirectory(Environment.CurrentDirectory + @"\Trace\");
               SaveTrace(Environment.CurrentDirectory + @"\Trace\" + student.Sfzmhm + "_" + Guid.NewGuid().ToString(null) + ".bmp");
           }
           else
           {
               if (kscj == 1)
               {
                   MessageBox.Show(sm + "！");
               }
               else
               {
                   CVoice.Play(sm + "，练习考试不合格");
                   MessageBox.Show(sm + "，练习考试不合格！");
               }
               buttonX4.Enabled = false;
           }
           ChangDiInit();
       }

        private void ChangDiInit()
        {
            //---------------场地初始化-----------------
            che.SetWeizhi(445, 75);
            che.SetRangle(0);
            che.Speed = 1;
            che.RSpeed = 3;

            camera.Channel = settings.YuntaiChannel;
            myTrace.Initial(che);

            for (int i = 0; i < 9; i++)
            {
                xian[i].Visable = true;
            }
            statemanager = new StateManager(gan, xian, che, this);
            toolStripStatusLabel1.Text = "准备考试";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "中停 0 次";
            //displaycomm.ShowText("准备考试");
            ButtonStart.Enabled = true;
        }

        private void InitStudent()
        {
            label_xm.Text = "姓名：";
            label_lsh.Text = "流水号：";
            label_zkzhm.Text = "准考证：";
            label_sfzhm.Text = "身份证：";
            label_kscx.Text = "考试车型：";
            label_kscs.Text = "考试次数：";
            label_jbr.Text = "经办人：";
            student.Clear();
        }

       public void formInvokefun()//在得到IO通知的函数中调用，避免非线程安全
       {
           Event_CMondata(form_mdata);
       }


        private void Invokefun()
        {
            pictureBox1.Refresh();
        }

        public void Notify(CMonData mdata)
        {
            form_mdata.Copy(mdata);
            if (label_jbr.InvokeRequired)
            {
                label_jbr.BeginInvoke(formInvoke);
            }
            else
            {
                Event_CMondata(form_mdata);
            }
        }

        private  void Event_CMondata(CMonData mdata)
        {
            xian_label.Text  = "线：";
            gan_label.Text  = "杆：";

            for (int i = 0; i < 9; i++)
            {
                xian[i].Stat = mdata.xian[i];
                xian_label.Text  = xian_label.Text  +" "+ mdata.xian[i];
            }
            for (int i = 0; i < 6; i++)
            {
                gan[i].Stat = mdata.gan[i];
                gan_label.Text = gan_label.Text + " " + mdata.gan[i];
            }
            if (mdata.che[0] == 1)
            {
                che_label.Text = "车： 前进"; 
            }
            if (mdata.che[1] == 1)
            {
                che_label.Text =  "车： 后退";
            }
            if (mdata.che[2] == 1)
            {
                che_label.Text = "车： 停车";
            }
            if (mdata.che[3] == 1)
            {
                che_label.Text = "车： 熄火";
            }
            xian[6].Stat = mdata.xian[3];
            xian[7].Stat = mdata.xian[3];
            xian[8].Stat = mdata.xian[3];
            if (isstart) //考试时接收及处理IO信号
            {
                if (mdata.che[0] == 1)
                {
                    StateManager.CurrState.Che_qj();
                }
                if (mdata.che[1] == 1)
                {
                    StateManager.CurrState.Che_ht();
                }
                if (mdata.che[2] == 1)
                {
                    StateManager.CurrState.Che_tc();
                }
                if (mdata.che[3] == 1)
                {
                    StateManager.CurrState.Che_xh();
                }
                if (mdata.xian[0] == 0)
                {
                    StateManager.CurrState.Xian1_Bump();
                }
                if (mdata.xian[1] == 0)
                {
                    StateManager.CurrState.Xian2_Bump();
                }
                if (mdata.xian[2] == 0)
                {
                    StateManager.CurrState.Xian3_Bump();
                }
                if (mdata.xian[3] == 0)
                {
                    StateManager.CurrState.Xian4_Bump();
                }
                //else
                //{
                //    StateManager.CurrState.Xian4_Leave();
                //}
                if (mdata.xian[4] == 0)
                {
                    StateManager.CurrState.Xian5_Bump();
                }
                if (mdata.xian[5] == 0)
                {
                    StateManager.CurrState.Xian6_Bump();
                }
                
                //---增加线信号 7，8，9------------------------------
                if (mdata.xian[6] == 0)
                {
                    StateManager.CurrState.Xian7_Bump();
                }
                if (mdata.xian[7] == 0)
                {
                    StateManager.CurrState.Xian8_Bump();
                }
                //else
                //{
                //    StateManager.CurrState.Xian7_Leave();
                //}
                if (mdata.xian[8] == 0)
                {
                    StateManager.CurrState.Xian9_Bump();
                }
                //--------------------------------------------
                if (mdata.gan[0] == 0)
                {
                    StateManager.CurrState.Gan1_Bump();
                }
                if (mdata.gan[1] == 0)
                {
                    StateManager.CurrState.Gan2_Bump();
                }
                if (mdata.gan[2] == 0)
                {
                    StateManager.CurrState.Gan3_Bump();
                }
                if (mdata.gan[3] == 0)
                {
                    StateManager.CurrState.Gan4_Bump();
                }
                if (mdata.gan[4] == 0)
                {
                    StateManager.CurrState.Gan5_Bump();
                }
                if (mdata.gan[5] == 0)
                {
                    StateManager.CurrState.Gan6_Bump();
                }
            }

        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            CDM.DisplayAll(g);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (_isExam)
            {
                if (ButtonStart.Text == "申请考试")
                {
                    if (settings.IsNetwork)
                    {
                        CNetData GetStudent_data = new CNetData();
                        GetStudent_data.cmdCommand = Command.GetStudent;
                        GetStudent_data.intDevnum = settings.Devnum;
                        Client.SendData(GetStudent_data);
                    }
                    else
                    {
                        getStudentInfoFromLocal();
                    }
                    return;
                }
                //TextBox_Input.Enabled = false;
            }
           for (int i = 0; i < 6; i++)
           {
               //gan[i].Stat = cm.CurrData.gan[i];
               //xian[i].Stat = cm.CurrData.xian[i];

               //if (i == 3)
               //{
               //    xian[6].Stat = cm.CurrData.xian[3];//4线隔断的水平线段，只用于显示
               //    xian[7].Stat = cm.CurrData.xian[3];
               //    xian[8].Stat = cm.CurrData.xian[3];
               //}
               //if (cm.CurrData.gan[i] == 0)
               if (gan[i].Stat == 0)
               {
                   MessageBox.Show("请检查第" + (i + 1).ToString() + "杆信号是否正常！", "提示");
                   return;
               }
               //if (cm.CurrData.xian[i] == 0)
               if(xian [i].Stat ==0)
               {
                   MessageBox.Show("请检查第" + (i + 1).ToString() + "线信号是否正常！", "提示");
                   return;
               }
           }
           
           isstart = true;
           CState.stopcount = 0;
           toolStripStatusLabel1.Text = "状态：开始考试";
           myTrace.Initial(che);
           Hkey.StartHotkey();
           pictureBox1.Focus();
           if (_isExam)
           {
               CVoice.Play(student.Xm + "，请上车");
               ButtonStart.Enabled = false;
               //储存考生照片
               if (!Directory.Exists(Environment.CurrentDirectory + @"\ScreenShot\"))
                   Directory.CreateDirectory(Environment.CurrentDirectory + @"\ScreenShot\");
               if (!camera.CaptureImage(Environment.CurrentDirectory + @"\ScreenShot\" + student.Sfzmhm + "_" + Guid.NewGuid().ToString(null) + ".bmp"))
                   MessageBox.Show("拍照失败！");
               if (settings.IsNetwork)
               {
                   CNetData tmpdata = new CNetData();
                   tmpdata.cmdCommand = Command.Ksks;
                   tmpdata.intDevnum = settings.Devnum;
                   Client.SendData(tmpdata);
               }
               buttonX2.Enabled = false;
           }
           else
           {
               buttonX4.Enabled = true;
               CVoice.Play("请上车");
           }
           camera.Channel = settings.GaoChannel;
           
           if (_isExam)
           {
               //在此处加摄像开始
               //bmpCounter = 0;
               //if (Directory.Exists(tempBmpDir))
               //    foreach (string file in Directory.GetFiles(tempBmpDir))
               //        File.Delete(file);
               //videoTimer = new System.Windows.Forms.Timer();
               //videoTimer.Interval = 100;
               //videoTimer.Tick += new EventHandler(videoTimer_Tick);
               //videoTimer.Start();
           }

           //displaycomm.ShowText("正在考试");
           StateManager.CurrState = statemanager.State0;
           StateManager.CurrState.Start();
           ButtonStart.Enabled = false;
        }

        //void videoTimer_Tick(object sender, EventArgs e)
        //{
        //    camera.CaptureImage(tempBmpDir + bmpCounter + ".bmp");
        //    Application.DoEvents();
        //    bmpCounter++;
        //}

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{

            //    che.SetWeizhi(e.X, e.Y);
            //}
            //if (e.Button == MouseButtons.Right)
            //{
            //    che.SetRangle(che.Rangle + 5);
            //}
            //if (e.Button == MouseButtons.Middle)
            //{
            //    che.SetRangle(che.Rangle - 5);
            //}
            //StudentText[0].Text = e.X.ToString() + "  " + e.Y.ToString() + "  " + che.DestRangle.ToString();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBoxTrace.Refresh();
        }
        public void idcardinfo_OnIDCardReceived(string xm, string sfzhm)
        {
            if (student.GetStudentInfo(sfzhm))
            {
                label_xm.Text = "姓名：" + student.Xm;
                label_lsh.Text = "流水号：" + student.Lsh;
                label_zkzhm.Text = "准考证：" + student.Zkzmbh;
                label_sfzhm.Text = "身份证：" + student.Sfzmhm;
                label_kscx.Text = "考试车型：" + student.Kscx;
                label_kscs.Text = "考试次数：" + student.Kscs.ToString();
                label_jbr.Text = "经办人：" + student.Jbr;
                ButtonStart.Text = "开始考试";
                ButtonStart.Focus();
            }
    
            showLinkState1.LinkState = student.LinkState1;//显示连接状态
            showLinkState2.LinkState = student.LinkState2;
        }


   


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ReStart(object sender, EventArgs e)
        {
            StateManager.Close();
            ChangDiInit();
            isstart = false;
            Hkey.StopHotkey();
            ButtonStart.Enabled = true;
            //StartButton_Click(sender, e);
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            camera = new zhuangkao.video.Camera(settings.YuntaiChannel);
            camera.Dock = DockStyle.Fill;
            this.panelExCameraWhole.Controls.Add(camera);
            this.Move += camera.Camera_Move;
            this.Resize += camera.Camera_Resize;
            if (_isExam)
            {
                //同步排队列表
                if (settings.IsNetwork)
                {
                    CNetData data = new CNetData();
                    data.cmdCommand = Command.Updatelist;
                    data.intDevnum = settings.Devnum;
                    Client.SendData(data);
                }
            }
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
            if (student.GetStudentInfo(TextBox_Input.Text))
            {
                label_xm.Text = "姓名：" + student.Xm;
                label_lsh.Text = "流水号：" + student.Lsh;
                label_zkzhm.Text = "准考证：" + student.Zkzmbh;
                label_sfzhm.Text = "身份证：" + student.Sfzmhm;
                label_kscx.Text = "考试车型：" + student.Kscx;
                label_kscs.Text = "考试次数：" + student.Kscs.ToString();
                label_jbr.Text = "经办人：" + student.Jbr;

                ButtonStart.Text = "开始考试";
                ButtonStart.Focus();
            }
            showLinkState1.LinkState = student.LinkState1;//显示连接状态
            showLinkState2.LinkState = student.LinkState2;
        }

        private void ExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            //if (videoTimer != null)
            //    videoTimer.Stop();
            //if (Directory.Exists(tempBmpDir))
            //    foreach (string file in Directory.GetFiles(tempBmpDir))
            //        File.Delete(file);
            cm.Close();
            StateManager.Close();
            if (_isExam)
            {
                student.Close();
                idcardinfo.CloseIDcardDev();
                if (settings.IsNetwork)
                {
                    CNetData data = new CNetData();
                    data.cmdCommand = Command.Logout;
                    data.intDevnum = 0;
                    data.strZjbh = null;
                    Client.SendData(data);
                    Client.Close();
                }
            }
            this.camera.CloseCamera();
            //displaycomm.Close();
        }

        private void buttonXTmpStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void SaveTrace(string path)
        {
            Bitmap bm = new Bitmap(pictureBoxTrace.Width, pictureBoxTrace.Height);
            pictureBoxTrace.DrawToBitmap(bm, new Rectangle(0, 0, pictureBoxTrace.Width, pictureBoxTrace.Height));
            bm.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (isstart)
            {
                DialogResult dlgResult = MessageBox.Show("正在考试，是否确定要关闭？", "警告！", MessageBoxButtons.YesNo);
                if (dlgResult == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (settings.IsNetwork)
            {
                CNetData data = new CNetData();
                data.cmdCommand = Command.Jjks;
                data.intDevnum = settings.Devnum;
                data.strZjbh = student.Zkzmbh;
                Client.SendData(data);
            }
            InitStudent();
            ButtonStart.Text = "申请考试";
            buttonX2.Enabled = false;
            //displaycomm.ShowText("准备考试");
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (settings.IsNetwork)
            {
                CNetData data = new CNetData();
                data.cmdCommand = Command.Updatelist;
                data.intDevnum = settings.Devnum;
                Client.SendData(data);
            }
        }

        private void makeVideo(string bmpDir,string distFile)
        {
            double Rate = 10;
            Avi.AVICOMPRESSOPTIONS aviformat = new Avi.AVICOMPRESSOPTIONS();
            aviformat.cbFormat = 0;
            aviformat.cbParms = 4;
            aviformat.dwFlags = 8;
            aviformat.dwQuality = 7500;
            aviformat.fccHandler = 1668707181;

            AviManager aviManager = new AviManager(distFile, false);
            Bitmap bitmap0 = (Bitmap)Image.FromFile(@bmpDir + "0.bmp");
            VideoStream aviStream = aviManager.AddVideoStream(aviformat, Rate, bitmap0);

            string[] bmpFiles = Directory.GetFiles(bmpDir, "*.bmp");
            for (Int32 i = 1; i < bmpFiles.Length; i++)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(bmpFiles[i]);
                aviStream.AddFrame(bitmap);
                bitmap.Dispose();
                System.Threading.Thread.Sleep(5);
            }
            aviManager.Close();
        }
    }
}
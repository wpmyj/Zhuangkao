using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lukao
{
    public partial class main_view : Form
    {
        private  CController ctrl;
        private  CModel model;
        private  ksdevice.Ksdevice[] ksdev;
        private delegate void InvokeDelegate(CStudent student);
        private InvokeDelegate TextInvoke;
        private delegate void DataGridInvokeDelegate();
        private DataGridInvokeDelegate datagridinvoke;
        CMyMessageFuns message;
        byte[] data;
        public SqlConnection conn;
        Button[] reset_button; //复位按钮
        Button[] tongbu_button;//同步按钮
        int[] tmpkscj;
        private delegate void InvokeButtonEnable(int myindex);
        private InvokeButtonEnable invokebuttonenable1;

        public main_view(CModel model)
        {
            InitializeComponent();
            message = new CMyMessageFuns();
            data = new byte[30];

            this.model = model;
            ctrl = new CController(model,this);
            pictureBox1.ImageLocation = ".\\photonull.bmp";

            string connstr = "Data Source=" + model.settings.Ipaddress + ";Initial Catalog=zhuangkao;Persist Security Info=True;User ID=sa;Password=cgcsxb";//;Pooling=true;Max Pool Size=20;";
            conn = new SqlConnection(connstr);
            conn.Open();
           
            view_init();
           
            model.OnIDCardReceived += new CModel.IDCardRequest(model_OnIDCardReceived);
            TextInvoke = new InvokeDelegate(TextInvoke_fun);
            datagridinvoke = new DataGridInvokeDelegate(datagridinvokefun);
            string[] tmpstr = model.settings.Ksy.Split(',');
            for (int i = 0; i < tmpstr.Length; i++)
            {
               comboBox1.Items.Add(tmpstr[i]);
            }
           // comboBox1.Text = comboBox1.Items[0].ToString();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
             textBox1.Focus();
        }

        private void view_init()
        {
           string[] str = model.settings.DevInfo.Split(',');
            //Array.Sort(str);
            ksdev = new ksdevice.Ksdevice[str.Length];
            reset_button = new Button[str.Length];
            tongbu_button = new Button[str.Length];
            tmpkscj = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                string[] str1 = str[i].Split(':');
                ksdev[i] = new ksdevice.Ksdevice();
                this.panel3.Controls.Add(this.ksdev[i]);
                ksdev[i].Title = str1[1] + "(" + str1[0] + ")";
                ksdev[i].AllowDrop = true;
                ksdev[i].BackColor = System.Drawing.Color.White;
                ksdev[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                ksdev[i].Devicestat = "未知";
                ksdev[i].ForeColor = System.Drawing.SystemColors.ControlText;
                ksdev[i].Location = new System.Drawing.Point(3, 3);
                ksdev[i].Name = "ksdevice1";
                ksdev[i].Sfzhm = null;
                ksdev[i].Size = new System.Drawing.Size(198, 275);
                ksdev[i].Left = 205 * i;
                ksdev[i].Studentname = null;
                ksdev[i].TabIndex = 0;
                ksdev[i].Zkzhm = null;
                ksdev[i].TabStop = false;

                this.reset_button[i] = new Button();
                this.panel3.Controls.Add(this.reset_button[i]);
                //this.reset_button[i].Location = new System.Drawing.Point(ksdev[i].Left+ksdev[i].Width/2-this.reset_button[i].Width/2 , 285);
                this.reset_button[i].Location = new System.Drawing.Point(ksdev[i].Left+20, 285);
                this.reset_button[i].Name = "reset_button" + i.ToString();
                this.reset_button[i].Size = new System.Drawing.Size(75, 23);
                this.reset_button[i].TabIndex = 100;
                this.reset_button[i].TabStop = false;
                this.reset_button[i].Text = "复位";
                this.reset_button[i].UseVisualStyleBackColor = true;
                this.reset_button[i].Click += new System.EventHandler(this.reset_button_Click);

                this.tongbu_button[i] = new Button();
                this.panel3.Controls.Add(this.tongbu_button[i]);
                this.tongbu_button[i].Location = new System.Drawing.Point(ksdev[i].Left+100, 285);
                this.tongbu_button[i].Name = "tongbu_button" + i.ToString();
                this.tongbu_button[i].Size = new System.Drawing.Size(75, 23);
                this.tongbu_button[i].TabIndex = 100;
                this.tongbu_button[i].TabStop = false;
                this.tongbu_button[i].Text = "同步";
                this.tongbu_button[i].UseVisualStyleBackColor = true;
                this.tongbu_button[i].Click += new System.EventHandler(this.tongbu_button_Click);
                if (model.settings.Showbutton == 0)
                {
                    reset_button[i].Visible = false;
                    tongbu_button[i].Visible = false;
                }
                tmpkscj[i] = 0;
            }

           // model.initDataSet();
            //dataGridView1.DataSource = model.ds.Tables[0];
            datagridinvokefun();
            ctrl.OnButtonEnable += new CController.ButtonEnable(ButtonEnableFun);
            invokebuttonenable1 = new InvokeButtonEnable(Invokebuttonenablefun);
        }
        public void datagridinvokefun()
        {
 
            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                SqlDataAdapter da;
                if (model.settings.lkrqORzkrq == 0)
                {
                    da = new SqlDataAdapter("select xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩,KSRQ as 考试日期,KSY2 as 考试员,ISPRINT as 已经打印 from ready where (lkcs > 0) and (DATEDIFF(d,GETUTCDATE(),KSRQ)=0) order by kscj desc", conn);
                }
                else
                {
                    da = new SqlDataAdapter("select xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩,KSRQ as 考试日期,KSY2 as 考试员,ISPRINT as 已经打印 from ready where (lkcs > 0) and (DATEDIFF(d,GETUTCDATE(),LKKSRQ)=0) order by kscj desc", conn);
                }
                //SqlDataAdapter da = new SqlDataAdapter("select * from ready where lkcs > 0", conn);
                da.Fill(ds, "ready");
                BindingSource bg = new BindingSource();
                bg.DataSource = ds.Tables["ready"];
                dataGridView1.DataSource = bg;
                dataGridView1.Refresh();
                label10.Text = "今日考试人数：" + dataGridView1.Rows.Count.ToString();
                int hgrs = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value) > model.settings.Jgfs)
                    {
                        hgrs++;
                    }
                }
                label11.Text = "合格人数：" + hgrs.ToString();
                label12.Text = "不合格人数：" + Convert.ToString(dataGridView1.Rows.Count - hgrs);

            }
            catch
            {
            }
       
  
        }

        public void UpdateDataGrid()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(datagridinvoke);
            }
            else
            {
                //dataGridView1.DataSource = model.ds.Tables[0];
                //dataGridView1.Refresh();
                //dataGridView1.DataSource = null;
                System.Data.DataSet ds = new System.Data.DataSet();
                SqlDataAdapter da;
                if (model.settings.lkrqORzkrq == 0)
                {
                    da = new SqlDataAdapter("select xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩,KSRQ as 考试日期,KSY2 as 考试员,ISPRINT as 已经打印 from ready where (lkcs > 0) and (DATEDIFF(d,GETUTCDATE(),KSRQ)=0) order by kscj desc", conn);
                }
                else
                {
                    da = new SqlDataAdapter("select xm as 姓名,SFZMHM as 身份证号码,ZKZMBH as 准考证号码,KSCJ as 考试成绩,KSRQ as 考试日期,KSY2 as 考试员,ISPRINT as 已经打印 from ready where (lkcs > 0) and (DATEDIFF(d,GETUTCDATE(),LKKSRQ)=0) order by kscj desc", conn);
                }
               // SqlDataAdapter da = new SqlDataAdapter("select * from ready where lkcs > 0", conn);
                da.Fill(ds, "ready");
                BindingSource bg = new BindingSource();
                bg.DataSource = ds.Tables["ready"];
                dataGridView1.DataSource = bg;
                dataGridView1.Refresh();
                label10.Text = "今日考试人数：" + dataGridView1.Rows.Count.ToString();
                int hgrs = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value) > model.settings.Jgfs)
                    {
                        hgrs++;
                    }
                }
                label11.Text = "合格人数：" + hgrs.ToString();
                label12.Text = "不合格人数：" + Convert.ToString(dataGridView1.Rows.Count - hgrs);
            }
        }

        private void but_cfg_Click(object sender, EventArgs e)
        {
            Setting_Form set_form = new Setting_Form();
            set_form.ShowDialog(); 

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (model.djstudent != null)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("请选择考试员！");
                    return;
                }
                model.djstudent.ksy2 = comboBox1.Text;
                try
                {
                    model.djstudent.ksrq = Convert.ToDateTime(textBox5.Text);
                }
                catch
                {
                    MessageBox.Show("考试日期格式非法！");
                    return;
                }
                if (model.djstudent.lkcs > model.settings.Lkcs)
                {
                    MessageBox.Show("超过考试次数！");
                    return;
                }
                model.ksdevmanager.ksdevmodels[0].AddStudent(model.djstudent);
                KsdevRefresh(0);
                ClearInputText();
               model.ClearDqStudentInfo();
            }
            textBox1.Focus();
        }


        public void ClearInputText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            pictureBox1.ImageLocation = ".\\photonull.bmp";
        }

        void TextInvoke_fun(CStudent student)
        {
            if (student != null)
            {
                pictureBox1.ImageLocation = ".\\photo.bmp";
                textBox1.Text = student.zkzmbh;
                textBox2.Text = student.sfzmhm;
                textBox3.Text = student.xm;
                textBox4.Text = student.kscx;
                textBox5.Text = System.DateTime.Now.ToString();
                button1.Focus();

            }
            else
            {
                pictureBox1.ImageLocation = ".\\photonull.bmp";
                MessageBox.Show("没有考生信息！");
                ClearInputText();
                model.ClearDqStudentInfo();
            }

        }

        void model_OnIDCardReceived(object sender, CStudent  student)
        {

            textBox1.Invoke(TextInvoke, student);
       
        }


        private void Invokebuttonenablefun(int myindex)
        {
            reset_button[myindex].Enabled = true;
        }

        private void ButtonEnableFun(int myindex)
        {
            
            if (reset_button[myindex].InvokeRequired)
            {
                reset_button[myindex].Invoke(invokebuttonenable1, myindex);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CStudent student = new CStudent(model);
            if (e.KeyChar == 13)
            {
               student= model.GetStudentInfo(textBox1.Text);
               if (student != null)
               {
                   textBox1.Text = student.zkzmbh;
                   textBox2.Text = student.sfzmhm;
                   textBox3.Text = student.xm;
                   textBox4.Text = student.kscx;
                   textBox5.Text = System.DateTime.Now.ToString(); //student.zkrq.ToString();
                   model.djstudent.ksy2 = comboBox1.Text; 
                   button1.Focus();
               }
               else  
               {
                   MessageBox.Show("没有考生信息！");
               }
               pictureBox1.ImageLocation = ".\\photonull.bmp";
            }
        }




        public void KsdevRefresh(int devindex)
        {
            if ((devindex >model.ksdevmanager.KsDevCount - 1)||(devindex<0))
            {
                return;
            }

            ksdev[devindex].QueueClear();
            if (model.ksdevmanager.ksdevmodels[devindex].StudentList.Count > 0)
            {
                ksdev[devindex].Studentname = ((CStudent)(model.ksdevmanager.ksdevmodels[devindex].StudentList[0])).xm;
                ksdev[devindex].Zkzhm = ((CStudent)(model.ksdevmanager.ksdevmodels[devindex].StudentList[0])).zkzmbh;
                ksdev[devindex].Sfzhm = ((CStudent)(model.ksdevmanager.ksdevmodels[devindex].StudentList[0])).sfzmhm;
                for (int i = 1; i < model.ksdevmanager.ksdevmodels[devindex].StudentList.Count; i++)
                {
                    ksdev[devindex].QueueAdd
                                   (((CStudent)(model.ksdevmanager.ksdevmodels[devindex].StudentList[i])).xm,
                                   ((CStudent)(model.ksdevmanager.ksdevmodels[devindex].StudentList[i])).zkzmbh);

                }
            }
            else
            {
                //ksdev[devindex].Studentname = "";
                //ksdev[devindex].Zkzhm = "";
                //ksdev[devindex].Sfzhm = "";
                ksdev[devindex].KsdeviceClear();
            }
            ksdev[devindex].Devicestat = model.ksdevmanager.ksdevmodels[devindex].Status;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //message.InputData(data);
            //message.SetCmdHead();
            //message.SetKscj(100);
            //message.InputData(null);
            //textBox1.Text = data[0].ToString();
           // SetKsy_Form ksyform = new SetKsy_Form();
            //ksyform.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e) //打印
        {
            try
            {
                if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value) != true)
                {
                    model.PrintStr(model.settings.Ksdd,
                                   dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                                   dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                                   dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                                   dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                    model.SavePrintInfo(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                   // model.UpdateDataSet();
                    UpdateDataGrid();
                }
            }
            catch (System.InvalidCastException)
            {
                model.PrintStr(model.settings.Ksdd,
                                   dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                                   dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                                   dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                                   dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                model.SavePrintInfo(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
               // model.UpdateDataSet();
                UpdateDataGrid();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datagridinvokefun();
        }

        private void main_view_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // if (dataGridView1.Columns[e.ColumnIndex].Name == "LogType")
            //{
            //    if (e.Value.ToString() == "错误")
            //    {
            //        e.CellStyle.ForeColor = Color.Red;
            //    }
            //    if (e.Value.ToString() == "信息")
            //    {
            //        e.CellStyle.ForeColor = Color.Blue;
            //        dataGridView1.Rows[e.RowIndex].Cells["pic"].Value = new Bitmap("c:\\test\\CAR00.bmp");

            //    }
            //    if (e.Value.ToString() == "警告")
            //    {
            //        e.CellStyle.ForeColor = Color.Yellow;
                 
            //    }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "考试成绩")
            {
                if (Convert.ToInt16(e.Value) > model.settings.Jgfs)
                {
                  //  e.CellStyle.ForeColor = Color.Green;
                    for(int i=0;i<6;i++)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Green;
                    }
                }
                else
                {
                    //e.CellStyle.ForeColor = Color.Red;
                    for (int i = 0; i < 6; i++)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Red;
                    }
                }
            }

        }
        private void tongbu_button_Click(object sender, EventArgs e)
        {
            
            string tmpstr = ((Button)sender).Name;
            tmpstr = tmpstr.Substring(tmpstr.Length - 1, 1);
            int tmpi = Convert.ToInt16(tmpstr);
            if (model.ksdevmanager.ksdevmodels[tmpi].DqStudent != null)
            {
               
                tmpkscj[tmpi] = tmpkscj[tmpi] + 10;
            }
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            string tmpstr = ((Button)sender).Name;
            tmpstr = tmpstr.Substring(tmpstr.Length - 1, 1);
            //textBox1.Text = tmpstr;
            int tmpi = Convert.ToInt16(tmpstr);
            model.ksdevmanager.ksdevmodels[tmpi].Status = "复位";
            KsdevRefresh(tmpi);
            ((Button)sender).Enabled = false;


            if (model.ksdevmanager.ksdevmodels[tmpi].DqStudent != null)
            {
                model.ksdevmanager.ksdevmodels[tmpi].DqStudent.fxcj[tmpi] = tmpkscj[tmpi];
                model.ksdevmanager.ksdevmodels[tmpi].DqStudent.kscj =
                    model.ksdevmanager.ksdevmodels[tmpi].DqStudent.kscj - tmpkscj[tmpi];
                tmpkscj[tmpi] = 0;

                if (model.ksdevmanager.ksdevmodels[tmpi].DqStudent.kscj > model.settings.Jgfs)
                {
                    //考试及格处理
                    int i = 0;
                    while ((i < model.ksdevmanager.KsDevCount) && (model.ksdevmanager.ksdevmodels[tmpi].DqStudent.fxcj[i] != -1))
                    {
                        i++;
                    }
                    if (i >= model.ksdevmanager.KsDevCount)
                    {
                        //整体考试完成了
                        if (model.SaveStudentInfo(model.ksdevmanager.ksdevmodels[tmpi].DqStudent))
                        {
                            //model.UpdateDataSet();
                            System.Threading.Thread.Sleep(200);
                            this.UpdateDataGrid();
                            model.ksdevmanager.ksdevmodels[tmpi].RemoveStudent(model.ksdevmanager.ksdevmodels[tmpi].DqStudent);
                            this.KsdevRefresh(tmpi);
                        }
                    }
                    else
                    {
                        //继续未考试项目
                        model.ksdevmanager.ksdevmodels[i].AddStudent(model.ksdevmanager.ksdevmodels[tmpi].DqStudent);
                        model.ksdevmanager.ksdevmodels[tmpi].RemoveStudent(model.ksdevmanager.ksdevmodels[tmpi].DqStudent);
                        this.KsdevRefresh(i);
                        this.KsdevRefresh(tmpi);
                    }
                }
                else
                {
                    //考试不及格处理
                    if (model.SaveStudentInfo(model.ksdevmanager.ksdevmodels[tmpi].DqStudent))
                    {
                        //model.UpdateDataSet();
                        System.Threading.Thread.Sleep(200);
                        this.UpdateDataGrid();
                        model.ksdevmanager.ksdevmodels[tmpi].RemoveStudent(model.ksdevmanager.ksdevmodels[tmpi].DqStudent);
                        this.KsdevRefresh(tmpi);
                    }

                }
            }

        }

      
    }
}
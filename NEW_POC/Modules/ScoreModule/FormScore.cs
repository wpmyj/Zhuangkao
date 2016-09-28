using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Modules.ScoreModule
{
    public partial class FormScore : Form
    {

        protected Modules.PrintModule.CPrintContent _printContent;
        Util.CSettings settings;
        public FormScore(Util.CSettings set)
        {
            InitializeComponent();
            this.settings = set;
            _printContent = new Modules.PrintModule.CPrintContent(settings.PrintConfig);
        }

        private void FormScore_Load(object sender, EventArgs e)
        {
            this.txtDate.Text = DateTime.Now.Date.ToShortDateString();
            SearchBind();


        }

        //对表格数据进行格式化
        private void FormatTable()
        {
            this.dataGridView1.Columns[1].Width = 80;//姓名
            this.dataGridView1.Columns[2].Width = 100;//准考证号
            this.dataGridView1.Columns[3].Width = 150;//身份证号
            this.dataGridView1.Columns[4].Width = 80;//考试车型
            this.dataGridView1.Columns[5].Width = 150;//考试日期
            this.dataGridView1.Columns[7].Width = 83;
            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            //为克服 DataGridView BUG (只刷新可见字段部份)
            foreach (DataGridViewColumn d in this.dataGridView1.Columns)
            {
                if (d.Name.IndexOf("考试结果") != -1)
                {
                    if (this.dataGridView1.Rows[e.RowIndex].Cells[d.Index].Value != null)
                    {
                        if (this.dataGridView1.Rows[e.RowIndex].Cells[d.Index].Value.ToString() == "1")
                            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(171, 232, 181);
                    }
                }
            }

        }

        private void txtDate_Click(object sender, EventArgs e)
        {
            this.monthCalendarAdv1.Visible = true;
        }

        private void monthCalendarAdv1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtDate.Text = e.Start.Date.ToShortDateString();
            this.monthCalendarAdv1.Visible = false;
            SearchBind();


        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {
            this.monthCalendarAdv1.Visible = false;
        }

        //查询考试结果
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBind();
        }

        //单选按钮控制
        private void rdoManage()
        {
            this.txtSTZH.Text = "";
            this.txtName.Text = "";
            this.txtZKZH.Text = "";
            if (this.radioButton1.Checked == true)
            {
                this.txtName.Enabled = true;
                this.txtSTZH.Enabled = false;
                this.txtZKZH.Enabled = false;
            }
            if (this.radioButton2.Checked == true)
            {
                this.txtName.Enabled = false;
                this.txtSTZH.Enabled = true;
                this.txtZKZH.Enabled = false;
            }
            if (this.radioButton3.Checked == true)
            {
                this.txtName.Enabled = false;
                this.txtSTZH.Enabled = false;
                this.txtZKZH.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rdoManage();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rdoManage();
        }


        //有条件查询
        private void SearchBind()
        {
            lblTotel.Text = "总人数：";
            lblPass.Text = "合格人数：";
            lbkHGL.Text = "合格率：";

            bool flag = false;
            string strCond = "";
            if (this.checkBox1.Checked != true)
            {
                flag = true;
                strCond = " DATEDIFF(d,'" + this.txtDate.Text + "',KSRQ)=0 ";
            }
            //日期


            //姓名、身份证号、准考证号
            if (radioButton1.Checked == true && this.txtName.Text != "")
                if (flag)
                {
                    flag = true;
                    strCond += " and XM='" + this.txtName.Text.Trim() + "'";
                }
                else
                {
                    flag = true;
                    strCond += "  XM='" + this.txtName.Text.Trim() + "'";
                }
            if (radioButton2.Checked == true && this.txtSTZH.Text != "")
                if (flag)
                {
                    flag = true;
                    strCond += " and SFZMHM='" + this.txtSTZH.Text.Trim() + "'";
                }
                else
                {
                    flag = true;
                    strCond += "  SFZMHM='" + this.txtSTZH.Text.Trim() + "'";
                }
            if (radioButton3.Checked == true && this.txtZKZH.Text != "")
                if (flag)
                {
                    flag = true;
                    strCond += " and ZKZMBH='" + this.txtZKZH.Text.Trim() + "'";
                }
                else
                {
                    flag = true;
                    strCond += "  ZKZMBH='" + this.txtZKZH.Text.Trim() + "'";
                }

            DALStudent myStudent = new DALStudent();
            DataTable dt = null;
            try
            {
                dt = myStudent.ReadyQuery(strCond);
            }
            catch
            {
                this.dataGridView1.DataSource = null;
                MessageBox.Show("数据库读写错误");
                return;
            }

            if (dt.Rows.Count != 0)
            {
                this.dataGridView1.DataSource = dt;
                if (this.dataGridView1.Rows.Count != 0)
                {
                    if (checkBox1.Checked == false)
                    {
                        int ToltoKsrs = myStudent.getToltoKsrs(this.txtDate.Text);
                        int ToltohgKsrs = myStudent.getToltohgKsrs(this.txtDate.Text);
                        lblTotel.Text = "总人数：" + ToltoKsrs.ToString();
                        lblPass.Text = "合格人数：" + ToltohgKsrs.ToString();
                        if (ToltoKsrs != 0)
                            this.lbkHGL.Text = "合格率：" + ((ToltohgKsrs * 100) / (ToltoKsrs)).ToString() + "%";

                    }

                }
                FormatTable();
            }
            else
            {
                this.dataGridView1.DataSource = null;
            }
            this.txtSTZH.Text = "";
            this.txtName.Text = "";
            this.txtZKZH.Text = "";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == false)
            {
                this.txtDate.Enabled = true;
            }
            else
            {
                this.txtDate.Enabled = false;
            }
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
              
                int myorder = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DALStudent myStudent = new DALStudent();
                Candidate cand = myStudent.ReadyQueryWithKey(myorder.ToString());
                if (cand != null)
                {
                    DoPrint(cand);
                }
            }

        }


        protected virtual void DoPrint(Candidate cand)
        
        
        {
            try
            {

                //this._printContent.ksrqstr = cand.Ksrq.ToString("yyyy  MM  dd", DateTimeFormatInfo.InvariantInfo);

                this._printContent.ksrqstr = cand.Ksrq.ToString();
                if (cand.Kscj == 1)
                    this._printContent.kscjstr = "合格";
                else
                    this._printContent.kscjstr = "不合格";

                this._printContent.ksxmstr = "";
                this._printContent.ksyxmstr = "";

                switch (cand.Kscs)
                {
                    case 1:
                        this._printContent.ksddstr = settings.KSDD;
                        this._printContent.kscxstr = cand.Kscx;
                        this._printContent.ksxmstr = cand.Xm;
                        this._printContent.ksyxmstr = cand.Ksy1 + "  " + cand.Ksy2;
                        break;
                    case 2:
                        this._printContent.kscjtxt.mmY = settings.PrintConfig.Kscj_y + 8;
                        this._printContent.ksrqtxt.mmY = settings.PrintConfig.Ksrq_y + 8;
                        break;
                    case 3:
                        this._printContent.kscjtxt.mmY = settings.PrintConfig.Kscj_y + 16;
                        this._printContent.ksrqtxt.mmY = settings.PrintConfig.Ksrq_y + 16;
                        break;
                    case 4:
                        this._printContent.kscjtxt.mmY = settings.PrintConfig.Kscj_y + 24;
                        this._printContent.ksrqtxt.mmY = settings.PrintConfig.Ksrq_y + 24;
                        break;

                }

                this._printContent.Print();
            }
            catch
            {
                MessageBox.Show("打印失败，请检查打印机是否连接好！");
            }

        }
    }
}
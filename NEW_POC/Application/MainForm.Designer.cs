namespace App
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideBarMainMenu = new DevComponents.DotNetBar.SideBar();
            this.sideBarPanelItemScore = new DevComponents.DotNetBar.SideBarPanelItem();
            this.btnItemScore = new DevComponents.DotNetBar.ButtonItem();
            this.sideBarPanelItemExam = new DevComponents.DotNetBar.SideBarPanelItem();
            this.btnItem2wheelExam = new DevComponents.DotNetBar.ButtonItem();
            this.btnItem3wheelExam = new DevComponents.DotNetBar.ButtonItem();
            this.sideBarPanelItemSetup = new DevComponents.DotNetBar.SideBarPanelItem();
            this.btnItemSetupPrinter = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemSetup = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemTest = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemShield = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemShieldAdmin = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemQufan = new DevComponents.DotNetBar.ButtonItem();
            this.picBoxAd = new System.Windows.Forms.PictureBox();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelXMainTitle = new DevComponents.DotNetBar.LabelX();
            this.labelXTitle = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // sideBarMainMenu
            // 
            this.sideBarMainMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.sideBarMainMenu.BorderStyle = DevComponents.DotNetBar.eBorderType.None;
            this.sideBarMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarMainMenu.ExpandedPanel = this.sideBarPanelItemExam;
            this.sideBarMainMenu.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.sideBarMainMenu.Location = new System.Drawing.Point(0, 0);
            this.sideBarMainMenu.Name = "sideBarMainMenu";
            this.sideBarMainMenu.Panels.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sideBarPanelItemExam,
            this.sideBarPanelItemSetup,
            this.sideBarPanelItemScore});
            this.sideBarMainMenu.Size = new System.Drawing.Size(250, 575);
            this.sideBarMainMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.sideBarMainMenu.TabIndex = 0;
            // 
            // sideBarPanelItemScore
            // 
            this.sideBarPanelItemScore.FontBold = true;
            this.sideBarPanelItemScore.Name = "sideBarPanelItemScore";
            this.sideBarPanelItemScore.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnItemScore});
            this.sideBarPanelItemScore.Text = "成    绩";
            // 
            // btnItemScore
            // 
            this.btnItemScore.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemScore.ImagePaddingHorizontal = 8;
            this.btnItemScore.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemScore.Name = "btnItemScore";
            this.btnItemScore.Text = "查询统计";
            this.btnItemScore.Click += new System.EventHandler(this.btnItemScore_Click);
            // 
            // sideBarPanelItemExam
            // 
            this.sideBarPanelItemExam.FontBold = true;
            this.sideBarPanelItemExam.Name = "sideBarPanelItemExam";
            this.sideBarPanelItemExam.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnItem2wheelExam,
            this.btnItem3wheelExam});
            this.sideBarPanelItemExam.Text = "考    试";
            // 
            // btnItem2wheelExam
            // 
            this.btnItem2wheelExam.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItem2wheelExam.ImagePaddingHorizontal = 8;
            this.btnItem2wheelExam.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem2wheelExam.Name = "btnItem2wheelExam";
            this.btnItem2wheelExam.Text = "两轮摩托车考试";
            this.btnItem2wheelExam.Click += new System.EventHandler(this.btnItem2wheelExam_Click);
            // 
            // btnItem3wheelExam
            // 
            this.btnItem3wheelExam.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItem3wheelExam.ImagePaddingHorizontal = 8;
            this.btnItem3wheelExam.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItem3wheelExam.Name = "btnItem3wheelExam";
            this.btnItem3wheelExam.Text = "三轮摩托车考试";
            this.btnItem3wheelExam.Click += new System.EventHandler(this.btnItem3wheelExam_Click);
            // 
            // sideBarPanelItemSetup
            // 
            this.sideBarPanelItemSetup.FontBold = true;
            this.sideBarPanelItemSetup.Name = "sideBarPanelItemSetup";
            this.sideBarPanelItemSetup.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnItemSetupPrinter,
            this.btnItemSetup,
            this.btnItemTest,
            this.btnItemShield,
            this.btnItemShieldAdmin,
            this.btnItemQufan});
            this.sideBarPanelItemSetup.Text = "设    置";
            // 
            // btnItemSetupPrinter
            // 
            this.btnItemSetupPrinter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemSetupPrinter.ImagePaddingHorizontal = 8;
            this.btnItemSetupPrinter.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemSetupPrinter.Name = "btnItemSetupPrinter";
            this.btnItemSetupPrinter.Text = "打印参数设置";
            this.btnItemSetupPrinter.Click += new System.EventHandler(this.btnItemSetupPrinter_Click);
            // 
            // btnItemSetup
            // 
            this.btnItemSetup.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemSetup.ImagePaddingHorizontal = 8;
            this.btnItemSetup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemSetup.Name = "btnItemSetup";
            this.btnItemSetup.Text = "系统参数设置";
            this.btnItemSetup.Click += new System.EventHandler(this.btnItemSetup_Click);
            // 
            // btnItemTest
            // 
            this.btnItemTest.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemTest.ImagePaddingHorizontal = 8;
            this.btnItemTest.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemTest.Name = "btnItemTest";
            this.btnItemTest.Text = "系统信号检测";
            this.btnItemTest.Click += new System.EventHandler(this.btnItemTest_Click);
            // 
            // btnItemShield
            // 
            this.btnItemShield.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemShield.ImagePaddingHorizontal = 8;
            this.btnItemShield.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemShield.Name = "btnItemShield";
            this.btnItemShield.Text = "杆线信号屏蔽";
            this.btnItemShield.Click += new System.EventHandler(this.btnItemShield_Click);
            // 
            // btnItemShieldAdmin
            // 
            this.btnItemShieldAdmin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemShieldAdmin.ImagePaddingHorizontal = 8;
            this.btnItemShieldAdmin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemShieldAdmin.Name = "btnItemShieldAdmin";
            this.btnItemShieldAdmin.Text = "管理员信号屏蔽";
            this.btnItemShieldAdmin.Click += new System.EventHandler(this.btnItemShieldAdmin_Click);
            // 
            // btnItemQufan
            // 
            this.btnItemQufan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemQufan.ImagePaddingHorizontal = 8;
            this.btnItemQufan.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnItemQufan.Name = "btnItemQufan";
            this.btnItemQufan.Text = "杆线信号取反";
            this.btnItemQufan.Click += new System.EventHandler(this.btnItemQufan_Click);
            // 
            // picBoxAd
            // 
            this.picBoxAd.Image = global::App.Properties.Resources.bottom;
            this.picBoxAd.Location = new System.Drawing.Point(376, 269);
            this.picBoxAd.Name = "picBoxAd";
            this.picBoxAd.Size = new System.Drawing.Size(419, 306);
            this.picBoxAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxAd.TabIndex = 2;
            this.picBoxAd.TabStop = false;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Image = global::App.Properties.Resources.logo;
            this.picBoxLogo.Location = new System.Drawing.Point(256, 0);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(402, 178);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogo.TabIndex = 1;
            this.picBoxLogo.TabStop = false;
            // 
            // labelXMainTitle
            // 
            this.labelXMainTitle.Location = new System.Drawing.Point(257, 185);
            this.labelXMainTitle.Name = "labelXMainTitle";
            this.labelXMainTitle.Size = new System.Drawing.Size(75, 23);
            this.labelXMainTitle.TabIndex = 3;
            // 
            // labelXTitle
            // 
            this.labelXTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelXTitle.Location = new System.Drawing.Point(257, 185);
            this.labelXTitle.Name = "labelXTitle";
            this.labelXTitle.Size = new System.Drawing.Size(538, 54);
            this.labelXTitle.TabIndex = 4;
            this.labelXTitle.Text = "摩托车驾驶员桩考系统";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.labelXTitle);
            this.Controls.Add(this.labelXMainTitle);
            this.Controls.Add(this.picBoxAd);
            this.Controls.Add(this.picBoxLogo);
            this.Controls.Add(this.sideBarMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摩托车驾驶员桩考系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SideBar sideBarMainMenu;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.PictureBox picBoxAd;
        private DevComponents.DotNetBar.LabelX labelXMainTitle;
        private DevComponents.DotNetBar.LabelX labelXTitle;
        private DevComponents.DotNetBar.SideBarPanelItem sideBarPanelItemExam;
        private DevComponents.DotNetBar.ButtonItem btnItem2wheelExam;
        private DevComponents.DotNetBar.SideBarPanelItem sideBarPanelItemSetup;
        private DevComponents.DotNetBar.ButtonItem btnItemSetupPrinter;
        private DevComponents.DotNetBar.ButtonItem btnItem3wheelExam;
        private DevComponents.DotNetBar.ButtonItem btnItemSetup;
        private DevComponents.DotNetBar.ButtonItem btnItemTest;
        private DevComponents.DotNetBar.ButtonItem btnItemShield;
        private DevComponents.DotNetBar.ButtonItem btnItemShieldAdmin;
        private DevComponents.DotNetBar.ButtonItem btnItemQufan;
        private DevComponents.DotNetBar.SideBarPanelItem sideBarPanelItemScore;
        private DevComponents.DotNetBar.ButtonItem btnItemScore;
    }
}
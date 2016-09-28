namespace Cn.Youdundianzi.App
{
    partial class ExamFrm
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.paneXResult = new DevComponents.DotNetBar.PanelEx();
            this.paneXCandInfoTitle = new DevComponents.DotNetBar.PanelEx();
            this.paneXBtns = new DevComponents.DotNetBar.PanelEx();
            this.btnXExit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanelCandInfo = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.picBoxPhoto = new System.Windows.Forms.PictureBox();
            this.paneExamCtrl = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMid = new System.Windows.Forms.TableLayoutPanel();
            this.groupPanelVideo = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanelModelDisp = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.paneXStatus = new DevComponents.DotNetBar.PanelEx();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.paneXTrace = new DevComponents.DotNetBar.PanelEx();
            this.paneXQueueList = new DevComponents.DotNetBar.PanelEx();
            this.paneXExamInfoTitle = new DevComponents.DotNetBar.PanelEx();
            this.paneXSignalDisp = new DevComponents.DotNetBar.PanelEx();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.paneXBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPhoto)).BeginInit();
            this.tableLayoutPanelMid.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 530F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMid, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelRight, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1014, 730);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.paneXResult, 0, 4);
            this.tableLayoutPanelLeft.Controls.Add(this.paneXCandInfoTitle, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.paneXBtns, 0, 5);
            this.tableLayoutPanelLeft.Controls.Add(this.groupPanelCandInfo, 0, 2);
            this.tableLayoutPanelLeft.Controls.Add(this.picBoxPhoto, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.paneExamCtrl, 0, 3);
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 6;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(224, 724);
            this.tableLayoutPanelLeft.TabIndex = 0;
            // 
            // paneXResult
            // 
            this.paneXResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paneXResult.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXResult.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXResult.Location = new System.Drawing.Point(3, 554);
            this.paneXResult.Name = "paneXResult";
            this.paneXResult.Size = new System.Drawing.Size(218, 105);
            this.paneXResult.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXResult.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.paneXResult.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.paneXResult.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.paneXResult.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.paneXResult.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.paneXResult.Style.GradientAngle = 90;
            this.paneXResult.TabIndex = 7;
            // 
            // paneXCandInfoTitle
            // 
            this.paneXCandInfoTitle.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXCandInfoTitle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXCandInfoTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneXCandInfoTitle.Location = new System.Drawing.Point(3, 3);
            this.paneXCandInfoTitle.Name = "paneXCandInfoTitle";
            this.paneXCandInfoTitle.Size = new System.Drawing.Size(218, 19);
            this.paneXCandInfoTitle.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXCandInfoTitle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.paneXCandInfoTitle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.paneXCandInfoTitle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.paneXCandInfoTitle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.paneXCandInfoTitle.Style.GradientAngle = 90;
            this.paneXCandInfoTitle.TabIndex = 0;
            this.paneXCandInfoTitle.Text = "考生信息";
            // 
            // paneXBtns
            // 
            this.paneXBtns.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paneXBtns.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXBtns.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXBtns.Controls.Add(this.btnXExit);
            this.paneXBtns.Location = new System.Drawing.Point(3, 665);
            this.paneXBtns.Name = "paneXBtns";
            this.paneXBtns.Size = new System.Drawing.Size(218, 59);
            this.paneXBtns.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXBtns.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.paneXBtns.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.paneXBtns.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.paneXBtns.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.paneXBtns.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.paneXBtns.Style.GradientAngle = 90;
            this.paneXBtns.TabIndex = 3;
            // 
            // btnXExit
            // 
            this.btnXExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXExit.Location = new System.Drawing.Point(66, 14);
            this.btnXExit.Name = "btnXExit";
            this.btnXExit.Size = new System.Drawing.Size(86, 31);
            this.btnXExit.TabIndex = 0;
            this.btnXExit.Text = "退　出";
            this.btnXExit.Click += new System.EventHandler(this.btnXExit_Click);
            // 
            // groupPanelCandInfo
            // 
            this.groupPanelCandInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupPanelCandInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelCandInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelCandInfo.Location = new System.Drawing.Point(3, 148);
            this.groupPanelCandInfo.Name = "groupPanelCandInfo";
            this.groupPanelCandInfo.Size = new System.Drawing.Size(218, 363);
            // 
            // 
            // 
            this.groupPanelCandInfo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelCandInfo.Style.BackColorGradientAngle = 90;
            this.groupPanelCandInfo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelCandInfo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelCandInfo.Style.BorderBottomWidth = 1;
            this.groupPanelCandInfo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelCandInfo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelCandInfo.Style.BorderLeftWidth = 1;
            this.groupPanelCandInfo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelCandInfo.Style.BorderRightWidth = 1;
            this.groupPanelCandInfo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelCandInfo.Style.BorderTopWidth = 1;
            this.groupPanelCandInfo.Style.CornerDiameter = 4;
            this.groupPanelCandInfo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelCandInfo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelCandInfo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelCandInfo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanelCandInfo.TabIndex = 4;
            this.groupPanelCandInfo.Text = "考生信息输入";
            // 
            // picBoxPhoto
            // 
            this.picBoxPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBoxPhoto.Location = new System.Drawing.Point(63, 28);
            this.picBoxPhoto.Name = "picBoxPhoto";
            this.picBoxPhoto.Size = new System.Drawing.Size(97, 114);
            this.picBoxPhoto.TabIndex = 6;
            this.picBoxPhoto.TabStop = false;
            // 
            // paneExamCtrl
            // 
            this.paneExamCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneExamCtrl.Location = new System.Drawing.Point(3, 517);
            this.paneExamCtrl.Name = "paneExamCtrl";
            this.paneExamCtrl.Size = new System.Drawing.Size(218, 31);
            this.paneExamCtrl.TabIndex = 8;
            // 
            // tableLayoutPanelMid
            // 
            this.tableLayoutPanelMid.ColumnCount = 1;
            this.tableLayoutPanelMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMid.Controls.Add(this.groupPanelVideo, 0, 1);
            this.tableLayoutPanelMid.Controls.Add(this.groupPanelModelDisp, 0, 0);
            this.tableLayoutPanelMid.Controls.Add(this.paneXStatus, 0, 2);
            this.tableLayoutPanelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMid.Location = new System.Drawing.Point(233, 3);
            this.tableLayoutPanelMid.Name = "tableLayoutPanelMid";
            this.tableLayoutPanelMid.RowCount = 3;
            this.tableLayoutPanelMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tableLayoutPanelMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanelMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelMid.Size = new System.Drawing.Size(524, 724);
            this.tableLayoutPanelMid.TabIndex = 1;
            // 
            // groupPanelVideo
            // 
            this.groupPanelVideo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupPanelVideo.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelVideo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelVideo.Location = new System.Drawing.Point(3, 423);
            this.groupPanelVideo.Name = "groupPanelVideo";
            this.groupPanelVideo.Size = new System.Drawing.Size(518, 266);
            // 
            // 
            // 
            this.groupPanelVideo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelVideo.Style.BackColorGradientAngle = 90;
            this.groupPanelVideo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelVideo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelVideo.Style.BorderBottomWidth = 1;
            this.groupPanelVideo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelVideo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelVideo.Style.BorderLeftWidth = 1;
            this.groupPanelVideo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelVideo.Style.BorderRightWidth = 1;
            this.groupPanelVideo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelVideo.Style.BorderTopWidth = 1;
            this.groupPanelVideo.Style.CornerDiameter = 4;
            this.groupPanelVideo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelVideo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelVideo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelVideo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanelVideo.TabIndex = 1;
            this.groupPanelVideo.Text = "实时摄像";
            // 
            // groupPanelModelDisp
            // 
            this.groupPanelModelDisp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupPanelModelDisp.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelModelDisp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelModelDisp.Location = new System.Drawing.Point(3, 3);
            this.groupPanelModelDisp.Name = "groupPanelModelDisp";
            this.groupPanelModelDisp.Size = new System.Drawing.Size(518, 414);
            // 
            // 
            // 
            this.groupPanelModelDisp.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelModelDisp.Style.BackColorGradientAngle = 90;
            this.groupPanelModelDisp.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelModelDisp.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelModelDisp.Style.BorderBottomWidth = 1;
            this.groupPanelModelDisp.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelModelDisp.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelModelDisp.Style.BorderLeftWidth = 1;
            this.groupPanelModelDisp.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelModelDisp.Style.BorderRightWidth = 1;
            this.groupPanelModelDisp.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelModelDisp.Style.BorderTopWidth = 1;
            this.groupPanelModelDisp.Style.CornerDiameter = 4;
            this.groupPanelModelDisp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelModelDisp.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelModelDisp.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelModelDisp.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanelModelDisp.TabIndex = 0;
            this.groupPanelModelDisp.Text = "桩考设备运行监视";
            // 
            // paneXStatus
            // 
            this.paneXStatus.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXStatus.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneXStatus.Location = new System.Drawing.Point(3, 695);
            this.paneXStatus.Name = "paneXStatus";
            this.paneXStatus.Size = new System.Drawing.Size(518, 26);
            this.paneXStatus.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXStatus.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.paneXStatus.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.paneXStatus.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.paneXStatus.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.paneXStatus.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.paneXStatus.Style.GradientAngle = 90;
            this.paneXStatus.TabIndex = 2;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.paneXTrace, 0, 3);
            this.tableLayoutPanelRight.Controls.Add(this.paneXQueueList, 0, 2);
            this.tableLayoutPanelRight.Controls.Add(this.paneXExamInfoTitle, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.paneXSignalDisp, 0, 1);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(763, 3);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 4;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(248, 724);
            this.tableLayoutPanelRight.TabIndex = 2;
            // 
            // paneXTrace
            // 
            this.paneXTrace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paneXTrace.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXTrace.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXTrace.Location = new System.Drawing.Point(3, 407);
            this.paneXTrace.Name = "paneXTrace";
            this.paneXTrace.Size = new System.Drawing.Size(242, 314);
            this.paneXTrace.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXTrace.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.paneXTrace.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.paneXTrace.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.paneXTrace.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.paneXTrace.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.paneXTrace.Style.GradientAngle = 90;
            this.paneXTrace.TabIndex = 4;
            // 
            // paneXQueueList
            // 
            this.paneXQueueList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paneXQueueList.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXQueueList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXQueueList.Location = new System.Drawing.Point(3, 162);
            this.paneXQueueList.Name = "paneXQueueList";
            this.paneXQueueList.Size = new System.Drawing.Size(242, 239);
            this.paneXQueueList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXQueueList.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.paneXQueueList.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.paneXQueueList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.paneXQueueList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.paneXQueueList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.paneXQueueList.Style.GradientAngle = 90;
            this.paneXQueueList.TabIndex = 3;
            // 
            // paneXExamInfoTitle
            // 
            this.paneXExamInfoTitle.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXExamInfoTitle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXExamInfoTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneXExamInfoTitle.Location = new System.Drawing.Point(3, 3);
            this.paneXExamInfoTitle.Name = "paneXExamInfoTitle";
            this.paneXExamInfoTitle.Size = new System.Drawing.Size(242, 19);
            this.paneXExamInfoTitle.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXExamInfoTitle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.paneXExamInfoTitle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.paneXExamInfoTitle.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.paneXExamInfoTitle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.paneXExamInfoTitle.Style.GradientAngle = 90;
            this.paneXExamInfoTitle.TabIndex = 1;
            this.paneXExamInfoTitle.Text = "考试信息";
            // 
            // paneXSignalDisp
            // 
            this.paneXSignalDisp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paneXSignalDisp.CanvasColor = System.Drawing.SystemColors.Control;
            this.paneXSignalDisp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.paneXSignalDisp.Location = new System.Drawing.Point(3, 28);
            this.paneXSignalDisp.Name = "paneXSignalDisp";
            this.paneXSignalDisp.Size = new System.Drawing.Size(242, 128);
            this.paneXSignalDisp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.paneXSignalDisp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.paneXSignalDisp.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.paneXSignalDisp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.paneXSignalDisp.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.paneXSignalDisp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.paneXSignalDisp.Style.GradientAngle = 90;
            this.paneXSignalDisp.TabIndex = 2;
            // 
            // ExamFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 730);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ExamFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamFrm";
            this.Load += new System.EventHandler(this.ExamFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExamFrm_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExamFrm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExamFrm_KeyDown);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.paneXBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPhoto)).EndInit();
            this.tableLayoutPanelMid.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private DevComponents.DotNetBar.PanelEx paneXCandInfoTitle;
        private DevComponents.DotNetBar.PanelEx paneXBtns;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelCandInfo;
        private System.Windows.Forms.PictureBox picBoxPhoto;
        private DevComponents.DotNetBar.PanelEx paneXResult;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelModelDisp;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelVideo;
        private DevComponents.DotNetBar.PanelEx paneXStatus;
        private DevComponents.DotNetBar.PanelEx paneXExamInfoTitle;
        private DevComponents.DotNetBar.PanelEx paneXSignalDisp;
        private DevComponents.DotNetBar.PanelEx paneXTrace;
        private DevComponents.DotNetBar.PanelEx paneXQueueList;
        private System.Windows.Forms.Panel paneExamCtrl;
        private DevComponents.DotNetBar.ButtonX btnXExit;

    }
}
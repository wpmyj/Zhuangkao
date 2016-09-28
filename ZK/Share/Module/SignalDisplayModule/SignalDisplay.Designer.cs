namespace Cn.Youdundianzi.Share.Module.SignalDisplay
{
    partial class SignalDisplay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.che_label = new System.Windows.Forms.Label();
            this.xian_label = new System.Windows.Forms.Label();
            this.gan_label = new System.Windows.Forms.Label();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel1.Controls.Add(this.lblNumber);
            this.expandablePanel1.Controls.Add(this.che_label);
            this.expandablePanel1.Controls.Add(this.xian_label);
            this.expandablePanel1.Controls.Add(this.gan_label);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(222, 144);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 38;
            this.expandablePanel1.TitleHeight = 28;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "系统信号显示";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(58, 41);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(100, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "1  2  3  4  5  6  7  8 ";
            // 
            // che_label
            // 
            this.che_label.AutoSize = true;
            this.che_label.Location = new System.Drawing.Point(23, 115);
            this.che_label.Name = "che_label";
            this.che_label.Size = new System.Drawing.Size(31, 13);
            this.che_label.TabIndex = 2;
            this.che_label.Text = "车：";
            // 
            // xian_label
            // 
            this.xian_label.AutoSize = true;
            this.xian_label.Location = new System.Drawing.Point(23, 65);
            this.xian_label.Name = "xian_label";
            this.xian_label.Size = new System.Drawing.Size(127, 13);
            this.xian_label.TabIndex = 0;
            this.xian_label.Text = "线：  0  0  0  0  0  0  0  0";
            // 
            // gan_label
            // 
            this.gan_label.AutoSize = true;
            this.gan_label.Location = new System.Drawing.Point(23, 89);
            this.gan_label.Name = "gan_label";
            this.gan_label.Size = new System.Drawing.Size(103, 13);
            this.gan_label.TabIndex = 1;
            this.gan_label.Text = "杆：  0  0  0  0  0  0";
            // 
            // SignalDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expandablePanel1);
            this.Name = "SignalDisplay";
            this.Size = new System.Drawing.Size(222, 144);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label che_label;
        private System.Windows.Forms.Label xian_label;
        private System.Windows.Forms.Label gan_label;
    }
}

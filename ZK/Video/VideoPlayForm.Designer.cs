namespace Cn.Youdundianzi.Share.Module.Video
{
    partial class VideoPlayForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.slider1 = new DevComponents.DotNetBar.Controls.Slider();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.slider1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 386);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(450, 22);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "panelEx1";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(1, 2);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(39, 18);
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "||";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // slider1
            // 
            this.slider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.slider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slider1.Location = new System.Drawing.Point(0, 0);
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(450, 22);
            this.slider1.TabIndex = 2;
            this.slider1.Value = 0;
            this.slider1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider1_MouseDown);
            this.slider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider1_MouseUp);
            // 
            // VideoPlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 408);
            this.Controls.Add(this.panelEx1);
            this.Name = "VideoPlayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频回放";
            this.Load += new System.EventHandler(this.VideoPlay_Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPlay_Form_FormClosing);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.Slider slider1;

    }
}
namespace DemoForm
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowWeb = new System.Windows.Forms.Button();
            this.webVeiw = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // ShowWeb
            // 
            this.ShowWeb.Location = new System.Drawing.Point(12, 12);
            this.ShowWeb.Name = "ShowWeb";
            this.ShowWeb.Size = new System.Drawing.Size(203, 127);
            this.ShowWeb.TabIndex = 0;
            this.ShowWeb.Text = "显示网页";
            this.ShowWeb.UseVisualStyleBackColor = true;
            this.ShowWeb.Click += new System.EventHandler(this.ShowWeb_Click);
            // 
            // webVeiw
            // 
            this.webVeiw.Location = new System.Drawing.Point(259, 12);
            this.webVeiw.MinimumSize = new System.Drawing.Size(20, 20);
            this.webVeiw.Name = "webVeiw";
            this.webVeiw.Size = new System.Drawing.Size(1049, 736);
            this.webVeiw.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 774);
            this.Controls.Add(this.webVeiw);
            this.Controls.Add(this.ShowWeb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowWeb;
        private System.Windows.Forms.WebBrowser webVeiw;
    }
}


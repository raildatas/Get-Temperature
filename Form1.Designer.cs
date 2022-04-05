namespace wdj
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
            this.components = new System.ComponentModel.Container();
            this.lbltmp = new System.Windows.Forms.Label();
            this.lblnum = new System.Windows.Forms.Label();
            this.lblcity = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbltmp
            // 
            this.lbltmp.AutoSize = true;
            this.lbltmp.Font = new System.Drawing.Font("微软雅黑", 26.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltmp.Location = new System.Drawing.Point(597, 51);
            this.lbltmp.Name = "lbltmp";
            this.lbltmp.Size = new System.Drawing.Size(135, 113);
            this.lbltmp.TabIndex = 0;
            this.lbltmp.Text = "℃";
            // 
            // lblnum
            // 
            this.lblnum.AutoSize = true;
            this.lblnum.Font = new System.Drawing.Font("微软雅黑", 26.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnum.Location = new System.Drawing.Point(442, 51);
            this.lblnum.Name = "lblnum";
            this.lblnum.Size = new System.Drawing.Size(162, 113);
            this.lblnum.TabIndex = 1;
            this.lblnum.Text = "---";
            // 
            // lblcity
            // 
            this.lblcity.AutoSize = true;
            this.lblcity.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcity.Location = new System.Drawing.Point(12, 9);
            this.lblcity.Name = "lblcity";
            this.lblcity.Size = new System.Drawing.Size(357, 181);
            this.lblcity.TabIndex = 2;
            this.lblcity.Text = "城市";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 197);
            this.Controls.Add(this.lblcity);
            this.Controls.Add(this.lblnum);
            this.Controls.Add(this.lbltmp);
            this.Name = "Form1";
            this.Text = "温度查询系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltmp;
        private System.Windows.Forms.Label lblnum;
        private System.Windows.Forms.Label lblcity;
        private System.Windows.Forms.Timer timer1;
    }
}


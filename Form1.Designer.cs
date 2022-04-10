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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbltmp = new System.Windows.Forms.Label();
            this.lblnum = new System.Windows.Forms.Label();
            this.lblwt = new System.Windows.Forms.Label();
            this.lblWind = new System.Windows.Forms.Label();
            this.lblWindLv = new System.Windows.Forms.Label();
            this.lbltxt3 = new System.Windows.Forms.Label();
            this.lblzyx = new System.Windows.Forms.Label();
            this.weatherDate = new System.Windows.Forms.DateTimePicker();
            this.lbltxt2 = new System.Windows.Forms.Label();
            this.lblwd = new System.Windows.Forms.Label();
            this.lblto = new System.Windows.Forms.Label();
            this.lblcd = new System.Windows.Forms.Label();
            this.lblfrom = new System.Windows.Forms.Label();
            this.lbltxt1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblcity = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltmp
            // 
            resources.ApplyResources(this.lbltmp, "lbltmp");
            this.lbltmp.Name = "lbltmp";
            // 
            // lblnum
            // 
            resources.ApplyResources(this.lblnum, "lblnum");
            this.lblnum.Name = "lblnum";
            // 
            // lblwt
            // 
            resources.ApplyResources(this.lblwt, "lblwt");
            this.lblwt.ForeColor = System.Drawing.Color.Black;
            this.lblwt.Name = "lblwt";
            // 
            // lblWind
            // 
            resources.ApplyResources(this.lblWind, "lblWind");
            this.lblWind.ForeColor = System.Drawing.Color.Turquoise;
            this.lblWind.Name = "lblWind";
            // 
            // lblWindLv
            // 
            resources.ApplyResources(this.lblWindLv, "lblWindLv");
            this.lblWindLv.ForeColor = System.Drawing.Color.Black;
            this.lblWindLv.Name = "lblWindLv";
            // 
            // lbltxt3
            // 
            resources.ApplyResources(this.lbltxt3, "lbltxt3");
            this.lbltxt3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbltxt3.Name = "lbltxt3";
            // 
            // lblzyx
            // 
            resources.ApplyResources(this.lblzyx, "lblzyx");
            this.lblzyx.ForeColor = System.Drawing.Color.Black;
            this.lblzyx.Name = "lblzyx";
            // 
            // weatherDate
            // 
            this.weatherDate.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            resources.ApplyResources(this.weatherDate, "weatherDate");
            this.weatherDate.Name = "weatherDate";
            this.weatherDate.ValueChanged += new System.EventHandler(this.weatherDate_ValueChanged);
            // 
            // lbltxt2
            // 
            resources.ApplyResources(this.lbltxt2, "lbltxt2");
            this.lbltxt2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lbltxt2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbltxt2.Name = "lbltxt2";
            // 
            // lblwd
            // 
            resources.ApplyResources(this.lblwd, "lblwd");
            this.lblwd.ForeColor = System.Drawing.Color.Black;
            this.lblwd.Name = "lblwd";
            // 
            // lblto
            // 
            resources.ApplyResources(this.lblto, "lblto");
            this.lblto.Name = "lblto";
            // 
            // lblcd
            // 
            resources.ApplyResources(this.lblcd, "lblcd");
            this.lblcd.Name = "lblcd";
            // 
            // lblfrom
            // 
            resources.ApplyResources(this.lblfrom, "lblfrom");
            this.lblfrom.Name = "lblfrom";
            // 
            // lbltxt1
            // 
            resources.ApplyResources(this.lbltxt1, "lbltxt1");
            this.lbltxt1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbltxt1.Name = "lbltxt1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblcity);
            this.groupBox1.Controls.Add(this.lbltmp);
            this.groupBox1.Controls.Add(this.lblnum);
            this.groupBox1.Controls.Add(this.lblwt);
            this.groupBox1.Controls.Add(this.lblWind);
            this.groupBox1.Controls.Add(this.lblWindLv);
            this.groupBox1.Controls.Add(this.lbltxt3);
            this.groupBox1.Controls.Add(this.lblzyx);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.BurlyWood;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblcity
            // 
            resources.ApplyResources(this.lblcity, "lblcity");
            this.lblcity.ForeColor = System.Drawing.Color.Tan;
            this.lblcity.Name = "lblcity";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.weatherDate);
            this.groupBox2.Controls.Add(this.lbltxt2);
            this.groupBox2.Controls.Add(this.lblcd);
            this.groupBox2.Controls.Add(this.lbltxt1);
            this.groupBox2.Controls.Add(this.lblto);
            this.groupBox2.Controls.Add(this.lblfrom);
            this.groupBox2.Controls.Add(this.lblwd);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.SandyBrown;
            this.label1.Name = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.ForeColor = System.Drawing.Color.LightCoral;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltmp;
        private System.Windows.Forms.Label lblnum;
        private System.Windows.Forms.Label lblwt;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.Label lblWindLv;
        private System.Windows.Forms.Label lbltxt3;
        private System.Windows.Forms.Label lblzyx;
        private System.Windows.Forms.DateTimePicker weatherDate;
        private System.Windows.Forms.Label lbltxt2;
        private System.Windows.Forms.Label lblwd;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.Label lblcd;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.Label lbltxt1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblcity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


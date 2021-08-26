namespace OnlineDataDownloadeer.Forms
{
    partial class FrmMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitor));
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.buttonLaunch = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonList = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelFileQty = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.labelCycles = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prompt
            // 
            this.prompt.BackColor = System.Drawing.Color.Black;
            this.prompt.ForeColor = System.Drawing.Color.Lime;
            this.prompt.Location = new System.Drawing.Point(2, 232);
            this.prompt.Name = "prompt";
            this.prompt.Size = new System.Drawing.Size(616, 96);
            this.prompt.TabIndex = 0;
            this.prompt.Text = "";
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.Location = new System.Drawing.Point(12, 46);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(141, 42);
            this.buttonLaunch.TabIndex = 1;
            this.buttonLaunch.Text = "Launch";
            this.buttonLaunch.UseVisualStyleBackColor = true;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(12, 172);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(141, 42);
            this.buttonQuit.TabIndex = 1;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(12, 110);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(141, 46);
            this.buttonReport.TabIndex = 2;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(248, 46);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(136, 42);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "List files in folder";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // labelFileQty
            // 
            this.labelFileQty.AutoSize = true;
            this.labelFileQty.Location = new System.Drawing.Point(245, 125);
            this.labelFileQty.Name = "labelFileQty";
            this.labelFileQty.Size = new System.Drawing.Size(41, 17);
            this.labelFileQty.TabIndex = 4;
            this.labelFileQty.Text = "Files:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 182);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 22);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Process File";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(441, 182);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 7;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // labelCycles
            // 
            this.labelCycles.AutoSize = true;
            this.labelCycles.Location = new System.Drawing.Point(247, 13);
            this.labelCycles.Name = "labelCycles";
            this.labelCycles.Size = new System.Drawing.Size(122, 17);
            this.labelCycles.TabIndex = 8;
            this.labelCycles.Text = "Cycles completed:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(464, 211);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(56, 17);
            this.labelVersion.TabIndex = 9;
            this.labelVersion.Text = "Version";
            // 
            // FrmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 332);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelCycles);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelFileQty);
            this.Controls.Add(this.buttonList);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonLaunch);
            this.Controls.Add(this.prompt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMonitor";
            this.Text = "Online Capture Data Downloader";
            this.Load += new System.EventHandler(this.FrmMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox prompt;
        private System.Windows.Forms.Button buttonLaunch;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelFileQty;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Label labelCycles;
        private System.Windows.Forms.Label labelVersion;
    }
}
namespace IMSDataMergeSplit
{
    partial class SettingsForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnLoadSetting = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSourceCatalog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDestCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDestInstance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDestComputerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(131, 220);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(261, 5);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(107, 23);
            this.btnLoadSetting.TabIndex = 1;
            this.btnLoadSetting.Text = "Load Setting File";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(6, 7);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(249, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(212, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(293, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtSourceCatalog);
            this.groupBox2.Location = new System.Drawing.Point(6, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 47);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Catalog";
            // 
            // txtSourceCatalog
            // 
            this.txtSourceCatalog.Location = new System.Drawing.Point(95, 19);
            this.txtSourceCatalog.Name = "txtSourceCatalog";
            this.txtSourceCatalog.Size = new System.Drawing.Size(248, 20);
            this.txtSourceCatalog.TabIndex = 1;
            this.txtSourceCatalog.TextChanged += new System.EventHandler(this.txtSourceCatalog_TextChanged);
            this.txtSourceCatalog.Validating += new System.ComponentModel.CancelEventHandler(this.txtSourceCatalog_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDestCatalog);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 47);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination";
            // 
            // txtDestCatalog
            // 
            this.txtDestCatalog.Location = new System.Drawing.Point(96, 19);
            this.txtDestCatalog.Name = "txtDestCatalog";
            this.txtDestCatalog.Size = new System.Drawing.Size(247, 20);
            this.txtDestCatalog.TabIndex = 1;
            this.txtDestCatalog.TextChanged += new System.EventHandler(this.txtDestCatalog_TextChanged);
            this.txtDestCatalog.Validating += new System.ComponentModel.CancelEventHandler(this.txtDestCatalog_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Catalog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SQL Instance";
            // 
            // txtDestInstance
            // 
            this.txtDestInstance.Location = new System.Drawing.Point(127, 36);
            this.txtDestInstance.Name = "txtDestInstance";
            this.txtDestInstance.Size = new System.Drawing.Size(241, 20);
            this.txtDestInstance.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "SQL Port";
            // 
            // txtDestPort
            // 
            this.txtDestPort.Location = new System.Drawing.Point(127, 62);
            this.txtDestPort.Name = "txtDestPort";
            this.txtDestPort.Size = new System.Drawing.Size(241, 20);
            this.txtDestPort.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Computer Name";
            // 
            // txtDestComputerName
            // 
            this.txtDestComputerName.Location = new System.Drawing.Point(126, 88);
            this.txtDestComputerName.Name = "txtDestComputerName";
            this.txtDestComputerName.Size = new System.Drawing.Size(242, 20);
            this.txtDestComputerName.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 252);
            this.Controls.Add(this.txtDestComputerName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDestPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDestInstance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnLoadSetting);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnLoadSetting;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSourceCatalog;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDestCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestComputerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDestInstance;
        private System.Windows.Forms.Label label1;
    }
}
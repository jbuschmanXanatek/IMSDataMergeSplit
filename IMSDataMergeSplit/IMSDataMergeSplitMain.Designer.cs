namespace IMSDataMergeSplit
{
    partial class IMSDataMergeSplitMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAgencyUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadSetup = new System.Windows.Forms.Button();
            this.txtCurrentSettingFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoMerge = new System.Windows.Forms.RadioButton();
            this.rdoSplit = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAgencies = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.chkProducers = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblAgencies = new System.Windows.Forms.Label();
            this.lblProducers = new System.Windows.Forms.Label();
            this.btnUpdateScripts = new System.Windows.Forms.Button();
            this.chkExcludeAgencyAndMerge = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAgencies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProducers.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(411, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.editToolStripMenuItem,
            this.addAgencyUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.setupToolStripMenuItem.Text = "Settings";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // addAgencyUpdateToolStripMenuItem
            // 
            this.addAgencyUpdateToolStripMenuItem.Name = "addAgencyUpdateToolStripMenuItem";
            this.addAgencyUpdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAgencyUpdateToolStripMenuItem.Text = "Add Agency Update";
            this.addAgencyUpdateToolStripMenuItem.Visible = false;
            this.addAgencyUpdateToolStripMenuItem.Click += new System.EventHandler(this.addAgencyUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnLoadSetup
            // 
            this.btnLoadSetup.Location = new System.Drawing.Point(305, 27);
            this.btnLoadSetup.Name = "btnLoadSetup";
            this.btnLoadSetup.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSetup.TabIndex = 3;
            this.btnLoadSetup.Text = "Load Setting";
            this.btnLoadSetup.UseVisualStyleBackColor = true;
            this.btnLoadSetup.Click += new System.EventHandler(this.btnLoadSetup_Click);
            // 
            // txtCurrentSettingFile
            // 
            this.txtCurrentSettingFile.Enabled = false;
            this.txtCurrentSettingFile.Location = new System.Drawing.Point(106, 29);
            this.txtCurrentSettingFile.Name = "txtCurrentSettingFile";
            this.txtCurrentSettingFile.Size = new System.Drawing.Size(190, 20);
            this.txtCurrentSettingFile.TabIndex = 2;
            this.txtCurrentSettingFile.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Setup File:";
            // 
            // rdoMerge
            // 
            this.rdoMerge.AutoSize = true;
            this.rdoMerge.Checked = true;
            this.rdoMerge.Location = new System.Drawing.Point(9, 59);
            this.rdoMerge.Name = "rdoMerge";
            this.rdoMerge.Size = new System.Drawing.Size(55, 17);
            this.rdoMerge.TabIndex = 4;
            this.rdoMerge.TabStop = true;
            this.rdoMerge.Text = "Merge";
            this.rdoMerge.UseVisualStyleBackColor = true;
            this.rdoMerge.CheckedChanged += new System.EventHandler(this.rdoMerge_CheckedChanged);
            // 
            // rdoSplit
            // 
            this.rdoSplit.AutoSize = true;
            this.rdoSplit.Location = new System.Drawing.Point(70, 59);
            this.rdoSplit.Name = "rdoSplit";
            this.rdoSplit.Size = new System.Drawing.Size(45, 17);
            this.rdoSplit.TabIndex = 5;
            this.rdoSplit.Text = "Split";
            this.rdoSplit.UseVisualStyleBackColor = true;
            this.rdoSplit.CheckedChanged += new System.EventHandler(this.rdoSplit_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(324, 473);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 14;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(9, 165);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(390, 23);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "N/A";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 191);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 23);
            this.progressBar.TabIndex = 12;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 231);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(387, 226);
            this.txtInfo.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(243, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAgencies
            // 
            this.chkAgencies.Location = new System.Drawing.Point(70, 91);
            this.chkAgencies.Name = "chkAgencies";
            this.chkAgencies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkAgencies.Properties.ItemAutoHeight = true;
            this.chkAgencies.Properties.ShowButtons = false;
            this.chkAgencies.Size = new System.Drawing.Size(310, 20);
            this.chkAgencies.TabIndex = 8;
            this.chkAgencies.EditValueChanged += new System.EventHandler(this.chkAgencies_EditValueChanged);
            // 
            // chkProducers
            // 
            this.chkProducers.Location = new System.Drawing.Point(70, 130);
            this.chkProducers.Name = "chkProducers";
            this.chkProducers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkProducers.Properties.ItemAutoHeight = true;
            this.chkProducers.Properties.ShowButtons = false;
            this.chkProducers.Size = new System.Drawing.Size(310, 20);
            this.chkProducers.TabIndex = 10;
            this.chkProducers.EditValueChanged += new System.EventHandler(this.chkProducers_EditValueChanged);
            // 
            // lblAgencies
            // 
            this.lblAgencies.AutoSize = true;
            this.lblAgencies.Location = new System.Drawing.Point(6, 94);
            this.lblAgencies.Name = "lblAgencies";
            this.lblAgencies.Size = new System.Drawing.Size(54, 13);
            this.lblAgencies.TabIndex = 7;
            this.lblAgencies.Text = "Agencies:";
            // 
            // lblProducers
            // 
            this.lblProducers.AutoSize = true;
            this.lblProducers.Location = new System.Drawing.Point(6, 133);
            this.lblProducers.Name = "lblProducers";
            this.lblProducers.Size = new System.Drawing.Size(58, 13);
            this.lblProducers.TabIndex = 9;
            this.lblProducers.Text = "Producers:";
            // 
            // btnUpdateScripts
            // 
            this.btnUpdateScripts.Location = new System.Drawing.Point(13, 472);
            this.btnUpdateScripts.Name = "btnUpdateScripts";
            this.btnUpdateScripts.Size = new System.Drawing.Size(102, 23);
            this.btnUpdateScripts.TabIndex = 16;
            this.btnUpdateScripts.Text = "Update Scripts";
            this.btnUpdateScripts.UseVisualStyleBackColor = true;
            this.btnUpdateScripts.Click += new System.EventHandler(this.btnUpdateScripts_Click);
            // 
            // chkExcludeAgencyAndMerge
            // 
            this.chkExcludeAgencyAndMerge.AutoSize = true;
            this.chkExcludeAgencyAndMerge.Location = new System.Drawing.Point(160, 60);
            this.chkExcludeAgencyAndMerge.Name = "chkExcludeAgencyAndMerge";
            this.chkExcludeAgencyAndMerge.Size = new System.Drawing.Size(220, 17);
            this.chkExcludeAgencyAndMerge.TabIndex = 6;
            this.chkExcludeAgencyAndMerge.Text = "Exclude agency records and Merge Data";
            this.chkExcludeAgencyAndMerge.UseVisualStyleBackColor = true;
            // 
            // IMSDataMergeSplitMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 505);
            this.Controls.Add(this.chkExcludeAgencyAndMerge);
            this.Controls.Add(this.btnUpdateScripts);
            this.Controls.Add(this.lblProducers);
            this.Controls.Add(this.lblAgencies);
            this.Controls.Add(this.chkProducers);
            this.Controls.Add(this.chkAgencies);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.rdoSplit);
            this.Controls.Add(this.rdoMerge);
            this.Controls.Add(this.btnLoadSetup);
            this.Controls.Add(this.txtCurrentSettingFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IMSDataMergeSplitMain";
            this.Text = "IMS Data Mege/Split";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAgencies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProducers.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadSetup;
        private System.Windows.Forms.TextBox txtCurrentSettingFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoMerge;
        private System.Windows.Forms.RadioButton rdoSplit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkAgencies;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkProducers;
        private System.Windows.Forms.Label lblAgencies;
        private System.Windows.Forms.Label lblProducers;
        private System.Windows.Forms.Button btnUpdateScripts;
        private System.Windows.Forms.ToolStripMenuItem addAgencyUpdateToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkExcludeAgencyAndMerge;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}


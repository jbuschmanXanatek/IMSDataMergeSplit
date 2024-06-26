namespace IMSDataMergeSplit
{
    partial class AgencyUpdate
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
            this.btnRunAgency = new System.Windows.Forms.Button();
            this.txtAgency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRunAgency
            // 
            this.btnRunAgency.Location = new System.Drawing.Point(291, 3);
            this.btnRunAgency.Name = "btnRunAgency";
            this.btnRunAgency.Size = new System.Drawing.Size(75, 23);
            this.btnRunAgency.TabIndex = 2;
            this.btnRunAgency.Text = "Load Setting";
            this.btnRunAgency.UseVisualStyleBackColor = true;
            this.btnRunAgency.Click += new System.EventHandler(this.btnRunAgency_Click);
            // 
            // txtAgency
            // 
            this.txtAgency.Enabled = false;
            this.txtAgency.Location = new System.Drawing.Point(95, 6);
            this.txtAgency.Name = "txtAgency";
            this.txtAgency.Size = new System.Drawing.Size(190, 20);
            this.txtAgency.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agency Name:";
            // 
            // AgencyUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 41);
            this.Controls.Add(this.btnRunAgency);
            this.Controls.Add(this.txtAgency);
            this.Controls.Add(this.label1);
            this.Name = "AgencyUpdate";
            this.Text = "AgencyUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunAgency;
        private System.Windows.Forms.TextBox txtAgency;
        private System.Windows.Forms.Label label1;
    }
}
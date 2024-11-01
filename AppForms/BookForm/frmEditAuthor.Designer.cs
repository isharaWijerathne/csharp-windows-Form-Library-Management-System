namespace LibSys.AppForms.BookForm
{
    partial class frmEditAuthor
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthorInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthorEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthorweb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuherName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuthorID = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnEnableEdit = new System.Windows.Forms.Button();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(771, 532);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(690, 532);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Info";
            // 
            // txtAuthorInfo
            // 
            this.txtAuthorInfo.Location = new System.Drawing.Point(117, 185);
            this.txtAuthorInfo.Multiline = true;
            this.txtAuthorInfo.Name = "txtAuthorInfo";
            this.txtAuthorInfo.Size = new System.Drawing.Size(318, 179);
            this.txtAuthorInfo.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email";
            // 
            // txtAuthorEmail
            // 
            this.txtAuthorEmail.Location = new System.Drawing.Point(117, 128);
            this.txtAuthorEmail.Name = "txtAuthorEmail";
            this.txtAuthorEmail.Size = new System.Drawing.Size(315, 20);
            this.txtAuthorEmail.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Author WebSite";
            // 
            // txtAuthorweb
            // 
            this.txtAuthorweb.Location = new System.Drawing.Point(117, 74);
            this.txtAuthorweb.Name = "txtAuthorweb";
            this.txtAuthorweb.Size = new System.Drawing.Size(315, 20);
            this.txtAuthorweb.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Author Name";
            // 
            // txtAuherName
            // 
            this.txtAuherName.Location = new System.Drawing.Point(117, 28);
            this.txtAuherName.Name = "txtAuherName";
            this.txtAuherName.Size = new System.Drawing.Size(315, 20);
            this.txtAuherName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Author ID";
            // 
            // txtAuthorID
            // 
            this.txtAuthorID.Location = new System.Drawing.Point(504, 19);
            this.txtAuthorID.Name = "txtAuthorID";
            this.txtAuthorID.Size = new System.Drawing.Size(217, 20);
            this.txtAuthorID.TabIndex = 20;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(744, 19);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 22;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.label1);
            this.grpBox.Controls.Add(this.txtAuherName);
            this.grpBox.Controls.Add(this.txtAuthorweb);
            this.grpBox.Controls.Add(this.label2);
            this.grpBox.Controls.Add(this.txtAuthorEmail);
            this.grpBox.Controls.Add(this.label3);
            this.grpBox.Controls.Add(this.label4);
            this.grpBox.Controls.Add(this.txtAuthorInfo);
            this.grpBox.Enabled = false;
            this.grpBox.Location = new System.Drawing.Point(387, 103);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(507, 402);
            this.grpBox.TabIndex = 23;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Author Data";
            // 
            // btnEnableEdit
            // 
            this.btnEnableEdit.Location = new System.Drawing.Point(405, 52);
            this.btnEnableEdit.Name = "btnEnableEdit";
            this.btnEnableEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEnableEdit.TabIndex = 24;
            this.btnEnableEdit.Text = "Enable Edit";
            this.btnEnableEdit.UseVisualStyleBackColor = true;
            this.btnEnableEdit.Click += new System.EventHandler(this.btnEnableEdit_Click);
            // 
            // frmEditAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 604);
            this.Controls.Add(this.btnEnableEdit);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtAuthorID);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditAuthor";
            this.Text = "frmEditAuthor";
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthorInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthorEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthorweb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuherName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAuthorID;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnEnableEdit;
    }
}
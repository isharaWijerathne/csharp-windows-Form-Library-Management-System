namespace LibSys.AppForms.MemberForm
{
    partial class frmMebUpgrade
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
            this.btnVerifyId = new System.Windows.Forms.Button();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPreviousAccType = new System.Windows.Forms.TextBox();
            this.cmdNewAccountType = new System.Windows.Forms.ComboBox();
            this.btnUpgrate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtMemberShipUpgrateLetter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMmberName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerifyId
            // 
            this.btnVerifyId.Location = new System.Drawing.Point(409, 194);
            this.btnVerifyId.Name = "btnVerifyId";
            this.btnVerifyId.Size = new System.Drawing.Size(145, 23);
            this.btnVerifyId.TabIndex = 24;
            this.btnVerifyId.Text = "Verifiy ";
            this.btnVerifyId.UseVisualStyleBackColor = true;
            this.btnVerifyId.Click += new System.EventHandler(this.btnVerifyId_Click);
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(239, 195);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(154, 20);
            this.txtMemberId.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Membership Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Previoues Account Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "New Account Type";
            // 
            // txtPreviousAccType
            // 
            this.txtPreviousAccType.Location = new System.Drawing.Point(239, 271);
            this.txtPreviousAccType.Name = "txtPreviousAccType";
            this.txtPreviousAccType.ReadOnly = true;
            this.txtPreviousAccType.Size = new System.Drawing.Size(315, 20);
            this.txtPreviousAccType.TabIndex = 29;
            // 
            // cmdNewAccountType
            // 
            this.cmdNewAccountType.Enabled = false;
            this.cmdNewAccountType.FormattingEnabled = true;
            this.cmdNewAccountType.Items.AddRange(new object[] {
            "PLATINUM",
            "GOLD",
            "SILVER"});
            this.cmdNewAccountType.Location = new System.Drawing.Point(239, 314);
            this.cmdNewAccountType.Name = "cmdNewAccountType";
            this.cmdNewAccountType.Size = new System.Drawing.Size(315, 21);
            this.cmdNewAccountType.TabIndex = 30;
            // 
            // btnUpgrate
            // 
            this.btnUpgrate.Location = new System.Drawing.Point(443, 364);
            this.btnUpgrate.Name = "btnUpgrate";
            this.btnUpgrate.Size = new System.Drawing.Size(111, 23);
            this.btnUpgrate.TabIndex = 31;
            this.btnUpgrate.Text = "Upgrade";
            this.btnUpgrate.UseVisualStyleBackColor = true;
            this.btnUpgrate.Click += new System.EventHandler(this.btnUpgrate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(966, 569);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 23);
            this.btnPrint.TabIndex = 33;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtMemberShipUpgrateLetter
            // 
            this.txtMemberShipUpgrateLetter.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtMemberShipUpgrateLetter.Location = new System.Drawing.Point(661, 12);
            this.txtMemberShipUpgrateLetter.Multiline = true;
            this.txtMemberShipUpgrateLetter.Name = "txtMemberShipUpgrateLetter";
            this.txtMemberShipUpgrateLetter.ReadOnly = true;
            this.txtMemberShipUpgrateLetter.Size = new System.Drawing.Size(567, 541);
            this.txtMemberShipUpgrateLetter.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Member Name";
            // 
            // txtMmberName
            // 
            this.txtMmberName.Location = new System.Drawing.Point(239, 235);
            this.txtMmberName.Name = "txtMmberName";
            this.txtMmberName.ReadOnly = true;
            this.txtMmberName.Size = new System.Drawing.Size(315, 20);
            this.txtMmberName.TabIndex = 35;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(326, 364);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 23);
            this.btnClear.TabIndex = 36;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(855, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMebUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 604);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtMmberName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtMemberShipUpgrateLetter);
            this.Controls.Add(this.btnUpgrate);
            this.Controls.Add(this.cmdNewAccountType);
            this.Controls.Add(this.txtPreviousAccType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerifyId);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMebUpgrade";
            this.Text = "frmMebUpgrade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerifyId;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPreviousAccType;
        private System.Windows.Forms.ComboBox cmdNewAccountType;
        private System.Windows.Forms.Button btnUpgrate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtMemberShipUpgrateLetter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMmberName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
    }
}
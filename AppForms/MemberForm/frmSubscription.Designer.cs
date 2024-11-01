namespace LibSys.AppForms.MemberForm
{
    partial class frmSubscription
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtMemberShipUpgrateLetter = new System.Windows.Forms.TextBox();
            this.btnVerifyId = new System.Windows.Forms.Button();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastSubData = new System.Windows.Forms.TextBox();
            this.gbNewSub = new System.Windows.Forms.GroupBox();
            this.btncheckPay = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNewSubEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtNewSubDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPaymentComplete = new System.Windows.Forms.Button();
            this.gbNewSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(919, 561);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 23);
            this.btnPrint.TabIndex = 35;
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
            this.txtMemberShipUpgrateLetter.TabIndex = 34;
            // 
            // btnVerifyId
            // 
            this.btnVerifyId.Location = new System.Drawing.Point(414, 40);
            this.btnVerifyId.Name = "btnVerifyId";
            this.btnVerifyId.Size = new System.Drawing.Size(145, 23);
            this.btnVerifyId.TabIndex = 36;
            this.btnVerifyId.Text = "Verifiy ";
            this.btnVerifyId.UseVisualStyleBackColor = true;
            this.btnVerifyId.Click += new System.EventHandler(this.btnVerifyId_Click);
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(244, 41);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(154, 20);
            this.txtMemberId.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Membership Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Last Subscription";
            // 
            // txtLastSubData
            // 
            this.txtLastSubData.Location = new System.Drawing.Point(244, 104);
            this.txtLastSubData.Multiline = true;
            this.txtLastSubData.Name = "txtLastSubData";
            this.txtLastSubData.ReadOnly = true;
            this.txtLastSubData.Size = new System.Drawing.Size(315, 61);
            this.txtLastSubData.TabIndex = 40;
            this.txtLastSubData.Text = "\r\n";
            // 
            // gbNewSub
            // 
            this.gbNewSub.Controls.Add(this.btnPaymentComplete);
            this.gbNewSub.Controls.Add(this.btncheckPay);
            this.gbNewSub.Controls.Add(this.btnClear);
            this.gbNewSub.Controls.Add(this.txtPayment);
            this.gbNewSub.Controls.Add(this.label4);
            this.gbNewSub.Controls.Add(this.dtpNewSubEndDate);
            this.gbNewSub.Controls.Add(this.txtNewSubDate);
            this.gbNewSub.Controls.Add(this.label3);
            this.gbNewSub.Controls.Add(this.label2);
            this.gbNewSub.Location = new System.Drawing.Point(79, 189);
            this.gbNewSub.Name = "gbNewSub";
            this.gbNewSub.Size = new System.Drawing.Size(480, 379);
            this.gbNewSub.TabIndex = 41;
            this.gbNewSub.TabStop = false;
            this.gbNewSub.Text = "New subscripion";
            // 
            // btncheckPay
            // 
            this.btncheckPay.Location = new System.Drawing.Point(124, 275);
            this.btncheckPay.Name = "btncheckPay";
            this.btncheckPay.Size = new System.Drawing.Size(105, 23);
            this.btncheckPay.TabIndex = 47;
            this.btncheckPay.Text = "Check Payment";
            this.btncheckPay.UseVisualStyleBackColor = true;
            this.btncheckPay.Click += new System.EventHandler(this.btncheckPay_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(10, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 23);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(175, 163);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.ReadOnly = true;
            this.txtPayment.Size = new System.Drawing.Size(279, 20);
            this.txtPayment.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Payment";
            // 
            // dtpNewSubEndDate
            // 
            this.dtpNewSubEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNewSubEndDate.Location = new System.Drawing.Point(175, 112);
            this.dtpNewSubEndDate.Name = "dtpNewSubEndDate";
            this.dtpNewSubEndDate.Size = new System.Drawing.Size(279, 20);
            this.dtpNewSubEndDate.TabIndex = 44;
            // 
            // txtNewSubDate
            // 
            this.txtNewSubDate.Location = new System.Drawing.Point(175, 65);
            this.txtNewSubDate.Name = "txtNewSubDate";
            this.txtNewSubDate.ReadOnly = true;
            this.txtNewSubDate.Size = new System.Drawing.Size(279, 20);
            this.txtNewSubDate.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "New Subscription End Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "New Subscription Start Date :";
            // 
            // btnPaymentComplete
            // 
            this.btnPaymentComplete.Enabled = false;
            this.btnPaymentComplete.Location = new System.Drawing.Point(369, 275);
            this.btnPaymentComplete.Name = "btnPaymentComplete";
            this.btnPaymentComplete.Size = new System.Drawing.Size(105, 23);
            this.btnPaymentComplete.TabIndex = 48;
            this.btnPaymentComplete.Text = "Pay";
            this.btnPaymentComplete.UseVisualStyleBackColor = true;
            this.btnPaymentComplete.Click += new System.EventHandler(this.btnPaymentComplete_Click);
            // 
            // frmSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 604);
            this.Controls.Add(this.gbNewSub);
            this.Controls.Add(this.txtLastSubData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerifyId);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtMemberShipUpgrateLetter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubscription";
            this.Text = "frmSubscription";
            this.gbNewSub.ResumeLayout(false);
            this.gbNewSub.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtMemberShipUpgrateLetter;
        private System.Windows.Forms.Button btnVerifyId;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastSubData;
        private System.Windows.Forms.GroupBox gbNewSub;
        private System.Windows.Forms.Button btncheckPay;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNewSubEndDate;
        private System.Windows.Forms.TextBox txtNewSubDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPaymentComplete;
    }
}
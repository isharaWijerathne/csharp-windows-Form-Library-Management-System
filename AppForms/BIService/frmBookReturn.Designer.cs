namespace LibSys.AppForms.BIService
{
    partial class frmBookReturn
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
            this.btnRetunProcess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLibraryCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIssuedID = new System.Windows.Forms.TextBox();
            this.btnVefiry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtIssuedDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFineAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddition = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRetunProcess
            // 
            this.btnRetunProcess.Location = new System.Drawing.Point(117, 463);
            this.btnRetunProcess.Name = "btnRetunProcess";
            this.btnRetunProcess.Size = new System.Drawing.Size(106, 23);
            this.btnRetunProcess.TabIndex = 27;
            this.btnRetunProcess.Text = "Return Process";
            this.btnRetunProcess.UseVisualStyleBackColor = true;
            this.btnRetunProcess.Click += new System.EventHandler(this.butRetunProcess_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Issued Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Library Code";
            // 
            // txtLibraryCode
            // 
            this.txtLibraryCode.Location = new System.Drawing.Point(116, 96);
            this.txtLibraryCode.Name = "txtLibraryCode";
            this.txtLibraryCode.ReadOnly = true;
            this.txtLibraryCode.Size = new System.Drawing.Size(337, 20);
            this.txtLibraryCode.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Member ID";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(116, 47);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.ReadOnly = true;
            this.txtMemberID.Size = new System.Drawing.Size(337, 20);
            this.txtMemberID.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Issued ID";
            // 
            // txtIssuedID
            // 
            this.txtIssuedID.Location = new System.Drawing.Point(151, 23);
            this.txtIssuedID.Name = "txtIssuedID";
            this.txtIssuedID.Size = new System.Drawing.Size(204, 20);
            this.txtIssuedID.TabIndex = 29;
            // 
            // btnVefiry
            // 
            this.btnVefiry.Location = new System.Drawing.Point(373, 21);
            this.btnVefiry.Name = "btnVefiry";
            this.btnVefiry.Size = new System.Drawing.Size(94, 23);
            this.btnVefiry.TabIndex = 31;
            this.btnVefiry.Text = "Search";
            this.btnVefiry.UseVisualStyleBackColor = true;
            this.btnVefiry.Click += new System.EventHandler(this.btnVefiry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPay);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtIssuedDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMemberID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRetunProcess);
            this.groupBox1.Controls.Add(this.txtFineAmount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLibraryCode);
            this.groupBox1.Controls.Add(this.txtAddition);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(35, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 492);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book Return";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(17, 463);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 23);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(116, 289);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(337, 109);
            this.txtNote.TabIndex = 7;
            // 
            // txtIssuedDate
            // 
            this.txtIssuedDate.Location = new System.Drawing.Point(116, 143);
            this.txtIssuedDate.Name = "txtIssuedDate";
            this.txtIssuedDate.ReadOnly = true;
            this.txtIssuedDate.Size = new System.Drawing.Size(337, 20);
            this.txtIssuedDate.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fine Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Note";
            // 
            // txtFineAmount
            // 
            this.txtFineAmount.Location = new System.Drawing.Point(116, 191);
            this.txtFineAmount.Name = "txtFineAmount";
            this.txtFineAmount.ReadOnly = true;
            this.txtFineAmount.Size = new System.Drawing.Size(337, 20);
            this.txtFineAmount.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Addition";
            // 
            // txtAddition
            // 
            this.txtAddition.Location = new System.Drawing.Point(116, 238);
            this.txtAddition.Name = "txtAddition";
            this.txtAddition.ReadOnly = true;
            this.txtAddition.Size = new System.Drawing.Size(337, 20);
            this.txtAddition.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(919, 572);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 23);
            this.btnPrint.TabIndex = 39;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtBill
            // 
            this.txtBill.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBill.Location = new System.Drawing.Point(661, 23);
            this.txtBill.Multiline = true;
            this.txtBill.Name = "txtBill";
            this.txtBill.ReadOnly = true;
            this.txtBill.Size = new System.Drawing.Size(567, 541);
            this.txtBill.TabIndex = 38;
            // 
            // btnPay
            // 
            this.btnPay.Enabled = false;
            this.btnPay.Location = new System.Drawing.Point(366, 463);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(136, 23);
            this.btnPay.TabIndex = 36;
            this.btnPay.Text = "Make Payment to Return";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // frmBookReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 604);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtBill);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVefiry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIssuedID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBookReturn";
            this.Text = "frmBookReturn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRetunProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLibraryCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIssuedID;
        private System.Windows.Forms.Button btnVefiry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIssuedDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFineAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddition;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.Button btnPay;
    }
}
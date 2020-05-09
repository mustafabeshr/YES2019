namespace YES.Forms
{
    partial class frm_PrintVote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PrintVote));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEntryDocNo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblreason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblreasonid = new System.Windows.Forms.Label();
            this.coreason = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShares = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCertCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Print = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_Min);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 41);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(172, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(404, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  طباعة ورقة الاقتراع";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(644, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(12, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.TabStop = false;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_Min
            // 
            this.btn_Min.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btn_Min.ForeColor = System.Drawing.Color.White;
            this.btn_Min.Location = new System.Drawing.Point(57, 12);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(30, 23);
            this.btn_Min.TabIndex = 0;
            this.btn_Min.TabStop = false;
            this.btn_Min.Text = "-";
            this.btn_Min.UseVisualStyleBackColor = true;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.49533F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.50467F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 408);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.txtUserInfo);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 371);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(671, 34);
            this.panel5.TabIndex = 8;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.BackColor = System.Drawing.Color.Black;
            this.txtUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(9, 9);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(623, 18);
            this.txtUserInfo.TabIndex = 6;
            this.txtUserInfo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(638, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtEntryDocNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 63);
            this.panel2.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(393, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 18);
            this.label17.TabIndex = 10;
            this.label17.Text = "رقم الحضور :";
            // 
            // txtEntryDocNo
            // 
            this.txtEntryDocNo.BackColor = System.Drawing.Color.White;
            this.txtEntryDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntryDocNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtEntryDocNo.Location = new System.Drawing.Point(181, 9);
            this.txtEntryDocNo.MaxLength = 10;
            this.txtEntryDocNo.Name = "txtEntryDocNo";
            this.txtEntryDocNo.Size = new System.Drawing.Size(206, 27);
            this.txtEntryDocNo.TabIndex = 9;
            this.txtEntryDocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEntryDocNo.TextChanged += new System.EventHandler(this.txtEntryDocNo_TextChanged);
            this.txtEntryDocNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntryDocNo_KeyDown);
            this.txtEntryDocNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_H_IdNo_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblreason);
            this.panel3.Controls.Add(this.txtReason);
            this.panel3.Controls.Add(this.lblreasonid);
            this.panel3.Controls.Add(this.coreason);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtShares);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtCertCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtHolderName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtClassName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(671, 246);
            this.panel3.TabIndex = 1;
            // 
            // lblreason
            // 
            this.lblreason.AutoSize = true;
            this.lblreason.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblreason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblreason.Location = new System.Drawing.Point(477, 186);
            this.lblreason.Name = "lblreason";
            this.lblreason.Size = new System.Drawing.Size(61, 18);
            this.lblreason.TabIndex = 22;
            this.lblreason.Text = "السبب :";
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Enabled = false;
            this.txtReason.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtReason.Location = new System.Drawing.Point(54, 182);
            this.txtReason.MaxLength = 250;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(417, 60);
            this.txtReason.TabIndex = 21;
            this.txtReason.TabStop = false;
            // 
            // lblreasonid
            // 
            this.lblreasonid.AutoSize = true;
            this.lblreasonid.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblreasonid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblreasonid.Location = new System.Drawing.Point(477, 153);
            this.lblreasonid.Name = "lblreasonid";
            this.lblreasonid.Size = new System.Drawing.Size(129, 18);
            this.lblreasonid.TabIndex = 20;
            this.lblreasonid.Text = "سبب اعادة الطباعة";
            // 
            // coreason
            // 
            this.coreason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coreason.Font = new System.Drawing.Font("Tahoma", 11F);
            this.coreason.FormattingEnabled = true;
            this.coreason.Location = new System.Drawing.Point(54, 150);
            this.coreason.Name = "coreason";
            this.coreason.Size = new System.Drawing.Size(417, 26);
            this.coreason.TabIndex = 19;
            this.coreason.SelectedIndexChanged += new System.EventHandler(this.coreason_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(477, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "عدد الاصوات :";
            // 
            // txtShares
            // 
            this.txtShares.BackColor = System.Drawing.Color.White;
            this.txtShares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShares.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtShares.Location = new System.Drawing.Point(54, 117);
            this.txtShares.MaxLength = 100;
            this.txtShares.Name = "txtShares";
            this.txtShares.ReadOnly = true;
            this.txtShares.Size = new System.Drawing.Size(417, 27);
            this.txtShares.TabIndex = 17;
            this.txtShares.TabStop = false;
            this.txtShares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(477, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "عدد الشهادات :";
            // 
            // txtCertCount
            // 
            this.txtCertCount.BackColor = System.Drawing.Color.White;
            this.txtCertCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCertCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCertCount.Location = new System.Drawing.Point(54, 84);
            this.txtCertCount.MaxLength = 100;
            this.txtCertCount.Name = "txtCertCount";
            this.txtCertCount.ReadOnly = true;
            this.txtCertCount.Size = new System.Drawing.Size(417, 27);
            this.txtCertCount.TabIndex = 15;
            this.txtCertCount.TabStop = false;
            this.txtCertCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(477, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "الاســــــــــــم :";
            // 
            // txtHolderName
            // 
            this.txtHolderName.BackColor = System.Drawing.Color.White;
            this.txtHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHolderName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHolderName.Location = new System.Drawing.Point(54, 51);
            this.txtHolderName.MaxLength = 255;
            this.txtHolderName.Name = "txtHolderName";
            this.txtHolderName.ReadOnly = true;
            this.txtHolderName.Size = new System.Drawing.Size(417, 27);
            this.txtHolderName.TabIndex = 13;
            this.txtHolderName.TabStop = false;
            this.txtHolderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(477, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "الفــئـــــــــــة :";
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.White;
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtClassName.Location = new System.Drawing.Point(54, 18);
            this.txtClassName.MaxLength = 200;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(417, 27);
            this.txtClassName.TabIndex = 11;
            this.txtClassName.TabStop = false;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_Print);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 324);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(671, 41);
            this.panel4.TabIndex = 2;
            // 
            // btn_Print
            // 
            this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Print.Enabled = false;
            this.btn_Print.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btn_Print.ForeColor = System.Drawing.Color.Blue;
            this.btn_Print.ImageKey = "commit2.png";
            this.btn_Print.Location = new System.Drawing.Point(181, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(206, 35);
            this.btn_Print.TabIndex = 14;
            this.btn_Print.Text = "طباعة  (F10)";
            this.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // frm_PrintVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 449);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frm_PrintVote";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frm_PrintVote_Activated);
            this.Load += new System.EventHandler(this.frm_PrintVote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PrintVote_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEntryDocNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShares;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCertCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHolderName;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.ComboBox coreason;
        private System.Windows.Forms.Label lblreasonid;
        private System.Windows.Forms.Label lblreason;
        private System.Windows.Forms.TextBox txtReason;
    }
}
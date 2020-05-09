namespace YES.Forms
{
    partial class frm_VotePaperQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_VotePaperQuery));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chOnlyMine = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHolderName = new System.Windows.Forms.TextBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntryDocNo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Vote = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_reprint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalRows = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.coType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Vote)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_Min);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 41);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(428, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(510, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  الاستعلام عن اوراق الاقتراع الم" +
    "طبوعة";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(961, 0);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.29956F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.70044F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(994, 528);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.txtUserInfo);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 496);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(988, 29);
            this.panel5.TabIndex = 9;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.BackColor = System.Drawing.Color.Black;
            this.txtUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(9, 5);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(923, 18);
            this.txtUserInfo.TabIndex = 6;
            this.txtUserInfo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(955, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.coType);
            this.panel2.Controls.Add(this.chOnlyMine);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtHolderName);
            this.panel2.Controls.Add(this.btn_Query);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtEntryDocNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 68);
            this.panel2.TabIndex = 0;
            // 
            // chOnlyMine
            // 
            this.chOnlyMine.AutoSize = true;
            this.chOnlyMine.Font = new System.Drawing.Font("Tahoma", 11F);
            this.chOnlyMine.Location = new System.Drawing.Point(726, 38);
            this.chOnlyMine.Name = "chOnlyMine";
            this.chOnlyMine.Size = new System.Drawing.Size(227, 22);
            this.chOnlyMine.TabIndex = 35;
            this.chOnlyMine.Text = "العمليات التي قمت بانشائها فقط";
            this.chOnlyMine.UseVisualStyleBackColor = true;
            this.chOnlyMine.CheckedChanged += new System.EventHandler(this.chOnlyMine_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(621, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "الاسم :";
            // 
            // txtHolderName
            // 
            this.txtHolderName.BackColor = System.Drawing.Color.White;
            this.txtHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHolderName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHolderName.Location = new System.Drawing.Point(268, 5);
            this.txtHolderName.MaxLength = 150;
            this.txtHolderName.Name = "txtHolderName";
            this.txtHolderName.Size = new System.Drawing.Size(347, 27);
            this.txtHolderName.TabIndex = 33;
            this.txtHolderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Query
            // 
            this.btn_Query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Query.ForeColor = System.Drawing.Color.Blue;
            this.btn_Query.ImageKey = "commit2.png";
            this.btn_Query.Location = new System.Drawing.Point(54, 9);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(106, 51);
            this.btn_Query.TabIndex = 32;
            this.btn_Query.Text = "استعلام (F9)";
            this.btn_Query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(869, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "رقم الحضور :";
            // 
            // txtEntryDocNo
            // 
            this.txtEntryDocNo.BackColor = System.Drawing.Color.White;
            this.txtEntryDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntryDocNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtEntryDocNo.Location = new System.Drawing.Point(684, 5);
            this.txtEntryDocNo.MaxLength = 10;
            this.txtEntryDocNo.Name = "txtEntryDocNo";
            this.txtEntryDocNo.Size = new System.Drawing.Size(179, 27);
            this.txtEntryDocNo.TabIndex = 30;
            this.txtEntryDocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEntryDocNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntryDocNo_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Vote);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 374);
            this.panel3.TabIndex = 1;
            // 
            // dgv_Vote
            // 
            this.dgv_Vote.AllowUserToAddRows = false;
            this.dgv_Vote.AllowUserToDeleteRows = false;
            this.dgv_Vote.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Vote.ColumnHeadersHeight = 35;
            this.dgv_Vote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Vote.Location = new System.Drawing.Point(0, 0);
            this.dgv_Vote.Name = "dgv_Vote";
            this.dgv_Vote.ReadOnly = true;
            this.dgv_Vote.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Vote.RowTemplate.Height = 28;
            this.dgv_Vote.Size = new System.Drawing.Size(988, 374);
            this.dgv_Vote.TabIndex = 3;
            this.dgv_Vote.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Vote_CellFormatting);
            this.dgv_Vote.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Vote_RowEnter);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_reprint);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtTotalRows);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 457);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(988, 33);
            this.panel4.TabIndex = 2;
            // 
            // btn_reprint
            // 
            this.btn_reprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_reprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reprint.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_reprint.ForeColor = System.Drawing.Color.Blue;
            this.btn_reprint.ImageKey = "commit2.png";
            this.btn_reprint.Location = new System.Drawing.Point(794, 2);
            this.btn_reprint.Name = "btn_reprint";
            this.btn_reprint.Size = new System.Drawing.Size(190, 30);
            this.btn_reprint.TabIndex = 33;
            this.btn_reprint.Text = "إعادة طباعة ورقة الاقتراع";
            this.btn_reprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_reprint.UseVisualStyleBackColor = false;
            this.btn_reprint.Visible = false;
            this.btn_reprint.Click += new System.EventHandler(this.btn_reprint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(542, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "العدد :";
            // 
            // txtTotalRows
            // 
            this.txtTotalRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRows.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtTotalRows.Location = new System.Drawing.Point(398, 4);
            this.txtTotalRows.MaxLength = 14;
            this.txtTotalRows.Name = "txtTotalRows";
            this.txtTotalRows.ReadOnly = true;
            this.txtTotalRows.Size = new System.Drawing.Size(138, 25);
            this.txtTotalRows.TabIndex = 26;
            this.txtTotalRows.TabStop = false;
            this.txtTotalRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(621, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = "النوع :";
            // 
            // coType
            // 
            this.coType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coType.Font = new System.Drawing.Font("Tahoma", 11F);
            this.coType.FormattingEnabled = true;
            this.coType.Location = new System.Drawing.Point(268, 39);
            this.coType.Name = "coType";
            this.coType.Size = new System.Drawing.Size(347, 26);
            this.coType.TabIndex = 36;
            // 
            // frm_VotePaperQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 569);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frm_VotePaperQuery";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_VotePaperQuery_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_VotePaperQuery_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Vote)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEntryDocNo;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHolderName;
        private System.Windows.Forms.CheckBox chOnlyMine;
        private System.Windows.Forms.DataGridView dgv_Vote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalRows;
        private System.Windows.Forms.Button btn_reprint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox coType;
    }
}
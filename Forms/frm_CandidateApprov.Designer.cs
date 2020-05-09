namespace YES.Forms
{
    partial class frm_CandidateApprov
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CandidateApprov));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalRows = new System.Windows.Forms.TextBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.coClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.txtDetailsCandName = new System.Windows.Forms.TextBox();
            this.txtDetailsCandNo = new System.Windows.Forms.TextBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.btnCloseDetails = new System.Windows.Forms.Button();
            this.dgv_Cand = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtLastDay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOldStatusId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCandName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCandNo = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gbNewStatus = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.coNewStatus = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cand)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.gbNewStatus.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(719, 41);
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
            this.label5.Location = new System.Drawing.Point(256, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(399, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  إعتماد المرشحين";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(675, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 41);
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
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.53672F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.46328F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 624);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Controls.Add(this.txtUserInfo);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 588);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(713, 33);
            this.panel6.TabIndex = 12;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.BackColor = System.Drawing.Color.Black;
            this.txtUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(27, 9);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(638, 18);
            this.txtUserInfo.TabIndex = 6;
            this.txtUserInfo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(672, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTotalRows);
            this.panel2.Controls.Add(this.btn_Query);
            this.panel2.Controls.Add(this.coClass);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 49);
            this.panel2.TabIndex = 1;
            // 
            // txtTotalRows
            // 
            this.txtTotalRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRows.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtTotalRows.Location = new System.Drawing.Point(9, 15);
            this.txtTotalRows.MaxLength = 14;
            this.txtTotalRows.Name = "txtTotalRows";
            this.txtTotalRows.ReadOnly = true;
            this.txtTotalRows.Size = new System.Drawing.Size(138, 25);
            this.txtTotalRows.TabIndex = 15;
            this.txtTotalRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Query
            // 
            this.btn_Query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Query.ForeColor = System.Drawing.Color.Blue;
            this.btn_Query.ImageKey = "commit2.png";
            this.btn_Query.Location = new System.Drawing.Point(197, 13);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(106, 27);
            this.btn_Query.TabIndex = 14;
            this.btn_Query.Text = "استعلام (F9)";
            this.btn_Query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // coClass
            // 
            this.coClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coClass.Font = new System.Drawing.Font("Tahoma", 11F);
            this.coClass.FormattingEnabled = true;
            this.coClass.Location = new System.Drawing.Point(341, 13);
            this.coClass.Name = "coClass";
            this.coClass.Size = new System.Drawing.Size(273, 26);
            this.coClass.TabIndex = 1;
            this.coClass.SelectedIndexChanged += new System.EventHandler(this.coClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(620, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "الـفــئــــة :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlDetails);
            this.panel3.Controls.Add(this.dgv_Cand);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 293);
            this.panel3.TabIndex = 2;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Red;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.txtDetailsCandName);
            this.pnlDetails.Controls.Add(this.txtDetailsCandNo);
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Controls.Add(this.btnCloseDetails);
            this.pnlDetails.Location = new System.Drawing.Point(17, 34);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(672, 221);
            this.pnlDetails.TabIndex = 3;
            this.pnlDetails.Visible = false;
            // 
            // txtDetailsCandName
            // 
            this.txtDetailsCandName.BackColor = System.Drawing.Color.White;
            this.txtDetailsCandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailsCandName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDetailsCandName.ForeColor = System.Drawing.Color.Silver;
            this.txtDetailsCandName.Location = new System.Drawing.Point(36, 3);
            this.txtDetailsCandName.MaxLength = 255;
            this.txtDetailsCandName.Name = "txtDetailsCandName";
            this.txtDetailsCandName.ReadOnly = true;
            this.txtDetailsCandName.Size = new System.Drawing.Size(505, 27);
            this.txtDetailsCandName.TabIndex = 11;
            this.txtDetailsCandName.TabStop = false;
            this.txtDetailsCandName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDetailsCandNo
            // 
            this.txtDetailsCandNo.BackColor = System.Drawing.Color.White;
            this.txtDetailsCandNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailsCandNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDetailsCandNo.ForeColor = System.Drawing.Color.Silver;
            this.txtDetailsCandNo.Location = new System.Drawing.Point(542, 3);
            this.txtDetailsCandNo.MaxLength = 20;
            this.txtDetailsCandNo.Name = "txtDetailsCandNo";
            this.txtDetailsCandNo.ReadOnly = true;
            this.txtDetailsCandNo.Size = new System.Drawing.Size(125, 27);
            this.txtDetailsCandNo.TabIndex = 10;
            this.txtDetailsCandNo.TabStop = false;
            this.txtDetailsCandNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.ColumnHeadersHeight = 35;
            this.dgvDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDetails.Location = new System.Drawing.Point(6, 31);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetails.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.dgvDetails.RowTemplate.Height = 25;
            this.dgvDetails.Size = new System.Drawing.Size(661, 183);
            this.dgvDetails.TabIndex = 3;
            // 
            // btnCloseDetails
            // 
            this.btnCloseDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseDetails.BackgroundImage")));
            this.btnCloseDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseDetails.FlatAppearance.BorderSize = 0;
            this.btnCloseDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDetails.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btnCloseDetails.ForeColor = System.Drawing.Color.White;
            this.btnCloseDetails.Location = new System.Drawing.Point(3, 3);
            this.btnCloseDetails.Name = "btnCloseDetails";
            this.btnCloseDetails.Size = new System.Drawing.Size(30, 23);
            this.btnCloseDetails.TabIndex = 2;
            this.btnCloseDetails.TabStop = false;
            this.btnCloseDetails.UseVisualStyleBackColor = true;
            this.btnCloseDetails.Click += new System.EventHandler(this.btnCloseDetails_Click);
            // 
            // dgv_Cand
            // 
            this.dgv_Cand.AllowUserToAddRows = false;
            this.dgv_Cand.AllowUserToDeleteRows = false;
            this.dgv_Cand.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Cand.ColumnHeadersHeight = 35;
            this.dgv_Cand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Cand.Location = new System.Drawing.Point(0, 0);
            this.dgv_Cand.Name = "dgv_Cand";
            this.dgv_Cand.ReadOnly = true;
            this.dgv_Cand.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Cand.RowTemplate.Height = 80;
            this.dgv_Cand.Size = new System.Drawing.Size(713, 293);
            this.dgv_Cand.TabIndex = 2;
            this.dgv_Cand.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Cand_CellContentClick);
            this.dgv_Cand.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Cand_DataError);
            this.dgv_Cand.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Cand_RowEnter);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtLastDay);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtOldStatusId);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtOldStatus);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtCandName);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.txtCandNo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 357);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(713, 114);
            this.panel4.TabIndex = 3;
            // 
            // txtLastDay
            // 
            this.txtLastDay.BackColor = System.Drawing.Color.White;
            this.txtLastDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastDay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtLastDay.ForeColor = System.Drawing.Color.Red;
            this.txtLastDay.Location = new System.Drawing.Point(27, 50);
            this.txtLastDay.MaxLength = 255;
            this.txtLastDay.Name = "txtLastDay";
            this.txtLastDay.ReadOnly = true;
            this.txtLastDay.Size = new System.Drawing.Size(234, 27);
            this.txtLastDay.TabIndex = 18;
            this.txtLastDay.TabStop = false;
            this.txtLastDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(27, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "آخر موعد لقبول تغيير حالة المرشحين";
            // 
            // txtOldStatusId
            // 
            this.txtOldStatusId.BackColor = System.Drawing.Color.White;
            this.txtOldStatusId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldStatusId.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtOldStatusId.Location = new System.Drawing.Point(341, 84);
            this.txtOldStatusId.MaxLength = 255;
            this.txtOldStatusId.Name = "txtOldStatusId";
            this.txtOldStatusId.ReadOnly = true;
            this.txtOldStatusId.Size = new System.Drawing.Size(112, 27);
            this.txtOldStatusId.TabIndex = 16;
            this.txtOldStatusId.TabStop = false;
            this.txtOldStatusId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOldStatusId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(644, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "الحالة :";
            // 
            // txtOldStatus
            // 
            this.txtOldStatus.BackColor = System.Drawing.Color.White;
            this.txtOldStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldStatus.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtOldStatus.Location = new System.Drawing.Point(326, 65);
            this.txtOldStatus.MaxLength = 255;
            this.txtOldStatus.Name = "txtOldStatus";
            this.txtOldStatus.ReadOnly = true;
            this.txtOldStatus.Size = new System.Drawing.Size(312, 27);
            this.txtOldStatus.TabIndex = 13;
            this.txtOldStatus.TabStop = false;
            this.txtOldStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(644, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "الاسم :";
            // 
            // txtCandName
            // 
            this.txtCandName.BackColor = System.Drawing.Color.White;
            this.txtCandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCandName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCandName.Location = new System.Drawing.Point(326, 35);
            this.txtCandName.MaxLength = 255;
            this.txtCandName.Name = "txtCandName";
            this.txtCandName.ReadOnly = true;
            this.txtCandName.Size = new System.Drawing.Size(312, 27);
            this.txtCandName.TabIndex = 11;
            this.txtCandName.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(644, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 18);
            this.label17.TabIndex = 10;
            this.label17.Text = "الرقم :";
            // 
            // txtCandNo
            // 
            this.txtCandNo.BackColor = System.Drawing.Color.White;
            this.txtCandNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCandNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCandNo.Location = new System.Drawing.Point(326, 6);
            this.txtCandNo.MaxLength = 20;
            this.txtCandNo.Name = "txtCandNo";
            this.txtCandNo.ReadOnly = true;
            this.txtCandNo.Size = new System.Drawing.Size(312, 27);
            this.txtCandNo.TabIndex = 9;
            this.txtCandNo.TabStop = false;
            this.txtCandNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gbNewStatus);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 477);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(713, 105);
            this.panel5.TabIndex = 4;
            // 
            // gbNewStatus
            // 
            this.gbNewStatus.Controls.Add(this.label6);
            this.gbNewStatus.Controls.Add(this.txtNote);
            this.gbNewStatus.Controls.Add(this.label4);
            this.gbNewStatus.Controls.Add(this.btnCommit);
            this.gbNewStatus.Controls.Add(this.coNewStatus);
            this.gbNewStatus.Enabled = false;
            this.gbNewStatus.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gbNewStatus.Location = new System.Drawing.Point(27, 3);
            this.gbNewStatus.Name = "gbNewStatus";
            this.gbNewStatus.Size = new System.Drawing.Size(670, 95);
            this.gbNewStatus.TabIndex = 15;
            this.gbNewStatus.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(190, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "ملاحظات";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNote.Location = new System.Drawing.Point(0, 36);
            this.txtNote.MaxLength = 255;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(426, 27);
            this.txtNote.TabIndex = 17;
            this.txtNote.TabStop = false;
            this.txtNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(493, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "الحالة الجديدة";
            // 
            // btnCommit
            // 
            this.btnCommit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCommit.ForeColor = System.Drawing.Color.Blue;
            this.btnCommit.ImageKey = "commit2.png";
            this.btnCommit.Location = new System.Drawing.Point(235, 66);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(206, 27);
            this.btnCommit.TabIndex = 15;
            this.btnCommit.Text = "تغيير الحالة";
            this.btnCommit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // coNewStatus
            // 
            this.coNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coNewStatus.Font = new System.Drawing.Font("Tahoma", 11F);
            this.coNewStatus.FormattingEnabled = true;
            this.coNewStatus.Location = new System.Drawing.Point(432, 37);
            this.coNewStatus.Name = "coNewStatus";
            this.coNewStatus.Size = new System.Drawing.Size(206, 26);
            this.coNewStatus.TabIndex = 2;
            // 
            // frm_CandidateApprov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 665);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frm_CandidateApprov";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_CandidateApprov_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_CandidateApprov_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cand)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.gbNewStatus.ResumeLayout(false);
            this.gbNewStatus.PerformLayout();
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
        private System.Windows.Forms.TextBox txtTotalRows;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.ComboBox coClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgv_Cand;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCandNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCandName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldStatus;
        private System.Windows.Forms.GroupBox gbNewStatus;
        private System.Windows.Forms.ComboBox coNewStatus;
        private System.Windows.Forms.TextBox txtOldStatusId;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtLastDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnCloseDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.TextBox txtDetailsCandName;
        private System.Windows.Forms.TextBox txtDetailsCandNo;
    }
}
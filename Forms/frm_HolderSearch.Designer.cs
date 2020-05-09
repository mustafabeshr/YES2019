namespace YES.Forms
{
    partial class frm_HolderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_HolderSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCerts = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuHolderCerts = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_inverseSelect = new System.Windows.Forms.Button();
            this.btn_deselectall = new System.Windows.Forms.Button();
            this.btn_selectall = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ch_ExcludePresents = new System.Windows.Forms.CheckBox();
            this.ch_IncludebyHolderNo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IdNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_HolderName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_CertNo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_addtolist = new System.Windows.Forms.Button();
            this.txt_CertCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSameName = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCerts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(942, 41);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(563, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -   بحث";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(899, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 41);
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
            this.tableLayoutPanel1.Controls.Add(this.dgvCerts, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.44374F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.55627F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 653);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // dgvCerts
            // 
            this.dgvCerts.AllowUserToAddRows = false;
            this.dgvCerts.AllowUserToDeleteRows = false;
            this.dgvCerts.ColumnHeadersHeight = 43;
            this.dgvCerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            this.dgvCerts.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCerts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCerts.Location = new System.Drawing.Point(3, 133);
            this.dgvCerts.Name = "dgvCerts";
            this.dgvCerts.RowTemplate.Height = 30;
            this.dgvCerts.Size = new System.Drawing.Size(936, 470);
            this.dgvCerts.TabIndex = 1;
            this.dgvCerts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCerts_CellFormatting);
            this.dgvCerts.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCerts_CellValidating);
            this.dgvCerts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCerts_CellValueChanged);
            // 
            // select
            // 
            this.select.HeaderText = "تحديد";
            this.select.Name = "select";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHolderCerts,
            this.toolStripSeparator1,
            this.mnuSameName});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(311, 104);
            // 
            // mnuHolderCerts
            // 
            this.mnuHolderCerts.BackColor = System.Drawing.Color.White;
            this.mnuHolderCerts.Font = new System.Drawing.Font("Traditional Arabic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHolderCerts.ForeColor = System.Drawing.Color.Maroon;
            this.mnuHolderCerts.Name = "mnuHolderCerts";
            this.mnuHolderCerts.Size = new System.Drawing.Size(310, 36);
            this.mnuHolderCerts.Text = "عرض جميع الشهادات لنفس المساهم";
            this.mnuHolderCerts.Click += new System.EventHandler(this.mnuHolderCerts_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_inverseSelect);
            this.panel2.Controls.Add(this.btn_deselectall);
            this.panel2.Controls.Add(this.btn_selectall);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_IdNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_HolderName);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txt_CertNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(936, 124);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(15, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "البحث في سجل المساهمين");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btn_inverseSelect
            // 
            this.btn_inverseSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_inverseSelect.BackgroundImage")));
            this.btn_inverseSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inverseSelect.Location = new System.Drawing.Point(811, 98);
            this.btn_inverseSelect.Name = "btn_inverseSelect";
            this.btn_inverseSelect.Size = new System.Drawing.Size(24, 23);
            this.btn_inverseSelect.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btn_inverseSelect, "عكس التحديد");
            this.btn_inverseSelect.UseVisualStyleBackColor = true;
            this.btn_inverseSelect.Click += new System.EventHandler(this.btn_inverseSelect_Click);
            // 
            // btn_deselectall
            // 
            this.btn_deselectall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_deselectall.BackgroundImage")));
            this.btn_deselectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deselectall.Location = new System.Drawing.Point(835, 98);
            this.btn_deselectall.Name = "btn_deselectall";
            this.btn_deselectall.Size = new System.Drawing.Size(24, 23);
            this.btn_deselectall.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btn_deselectall, "الغاء تحديد الكل");
            this.btn_deselectall.UseVisualStyleBackColor = true;
            this.btn_deselectall.Click += new System.EventHandler(this.btn_deselectall_Click);
            // 
            // btn_selectall
            // 
            this.btn_selectall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_selectall.BackgroundImage")));
            this.btn_selectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectall.Location = new System.Drawing.Point(859, 98);
            this.btn_selectall.Name = "btn_selectall";
            this.btn_selectall.Size = new System.Drawing.Size(24, 23);
            this.btn_selectall.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btn_selectall, "تحديد الكل");
            this.btn_selectall.UseVisualStyleBackColor = true;
            this.btn_selectall.Click += new System.EventHandler(this.btn_selectall_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Query);
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(83, 84);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btn_Query
            // 
            this.btn_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Query.FlatAppearance.BorderSize = 3;
            this.btn_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_Query.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Query.ImageKey = "search.png";
            this.btn_Query.ImageList = this.imageList1;
            this.btn_Query.Location = new System.Drawing.Point(3, 14);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 63);
            this.btn_Query.TabIndex = 2;
            this.btn_Query.Text = "استعلام (F9)";
            this.btn_Query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            this.btn_Query.MouseLeave += new System.EventHandler(this.btn_Query_MouseLeave);
            this.btn_Query.MouseHover += new System.EventHandler(this.btn_Query_MouseHover);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search.png");
            this.imageList1.Images.SetKeyName(1, "approved2.png");
            this.imageList1.Images.SetKeyName(2, "ok.png");
            this.imageList1.Images.SetKeyName(3, "cancel.png");
            this.imageList1.Images.SetKeyName(4, "add4.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ch_ExcludePresents);
            this.groupBox1.Controls.Add(this.ch_IncludebyHolderNo);
            this.groupBox1.Location = new System.Drawing.Point(98, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 84);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // ch_ExcludePresents
            // 
            this.ch_ExcludePresents.AutoSize = true;
            this.ch_ExcludePresents.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ch_ExcludePresents.Location = new System.Drawing.Point(194, 47);
            this.ch_ExcludePresents.Name = "ch_ExcludePresents";
            this.ch_ExcludePresents.Size = new System.Drawing.Size(210, 22);
            this.ch_ExcludePresents.TabIndex = 1;
            this.ch_ExcludePresents.Text = "استبعاد الشهادات الغير متاحة";
            this.ch_ExcludePresents.UseVisualStyleBackColor = true;
            this.ch_ExcludePresents.CheckedChanged += new System.EventHandler(this.ch_ExcludePresents_CheckedChanged);
            // 
            // ch_IncludebyHolderNo
            // 
            this.ch_IncludebyHolderNo.AutoSize = true;
            this.ch_IncludebyHolderNo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ch_IncludebyHolderNo.Location = new System.Drawing.Point(130, 19);
            this.ch_IncludebyHolderNo.Name = "ch_IncludebyHolderNo";
            this.ch_IncludebyHolderNo.Size = new System.Drawing.Size(274, 22);
            this.ch_IncludebyHolderNo.TabIndex = 0;
            this.ch_IncludebyHolderNo.Text = "تضمين جميع الشهادات لنفس المساهم";
            this.ch_IncludebyHolderNo.UseVisualStyleBackColor = true;
            this.ch_IncludebyHolderNo.CheckedChanged += new System.EventHandler(this.ch_IncludebyHolderNo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(841, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "رقم الهوية :";
            // 
            // txt_IdNo
            // 
            this.txt_IdNo.BackColor = System.Drawing.Color.White;
            this.txt_IdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IdNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_IdNo.Location = new System.Drawing.Point(653, 63);
            this.txt_IdNo.MaxLength = 20;
            this.txt_IdNo.Name = "txt_IdNo";
            this.txt_IdNo.Size = new System.Drawing.Size(187, 27);
            this.txt_IdNo.TabIndex = 9;
            this.txt_IdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(841, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "الإســـــــــم :";
            // 
            // txt_HolderName
            // 
            this.txt_HolderName.BackColor = System.Drawing.Color.White;
            this.txt_HolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HolderName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_HolderName.Location = new System.Drawing.Point(523, 34);
            this.txt_HolderName.MaxLength = 100;
            this.txt_HolderName.Name = "txt_HolderName";
            this.txt_HolderName.Size = new System.Drawing.Size(317, 27);
            this.txt_HolderName.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(841, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 17);
            this.label22.TabIndex = 6;
            this.label22.Text = "رقم الشهادة :";
            // 
            // txt_CertNo
            // 
            this.txt_CertNo.BackColor = System.Drawing.Color.White;
            this.txt_CertNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CertNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CertNo.Location = new System.Drawing.Point(653, 4);
            this.txt_CertNo.MaxLength = 10;
            this.txt_CertNo.Name = "txt_CertNo";
            this.txt_CertNo.Size = new System.Drawing.Size(187, 27);
            this.txt_CertNo.TabIndex = 5;
            this.txt_CertNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_addtolist);
            this.panel3.Controls.Add(this.txt_CertCount);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Controls.Add(this.btn_OK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 609);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(936, 41);
            this.panel3.TabIndex = 2;
            // 
            // btn_addtolist
            // 
            this.btn_addtolist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_addtolist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addtolist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addtolist.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_addtolist.ForeColor = System.Drawing.Color.Blue;
            this.btn_addtolist.ImageKey = "add4.png";
            this.btn_addtolist.ImageList = this.imageList1;
            this.btn_addtolist.Location = new System.Drawing.Point(759, 0);
            this.btn_addtolist.Name = "btn_addtolist";
            this.btn_addtolist.Size = new System.Drawing.Size(175, 41);
            this.btn_addtolist.TabIndex = 11;
            this.btn_addtolist.Text = "إضافة";
            this.btn_addtolist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_addtolist.UseVisualStyleBackColor = false;
            this.btn_addtolist.Click += new System.EventHandler(this.btn_addtolist_Click);
            // 
            // txt_CertCount
            // 
            this.txt_CertCount.BackColor = System.Drawing.Color.White;
            this.txt_CertCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CertCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txt_CertCount.Location = new System.Drawing.Point(3, 8);
            this.txt_CertCount.MaxLength = 20;
            this.txt_CertCount.Name = "txt_CertCount";
            this.txt_CertCount.ReadOnly = true;
            this.txt_CertCount.Size = new System.Drawing.Size(172, 27);
            this.txt_CertCount.TabIndex = 10;
            this.txt_CertCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(175, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "العدد :";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Cancel.ImageKey = "cancel.png";
            this.btn_Cancel.ImageList = this.imageList1;
            this.btn_Cancel.Location = new System.Drawing.Point(258, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(175, 41);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "الغاء الأمر";
            this.btn_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_OK.ForeColor = System.Drawing.Color.Green;
            this.btn_OK.ImageKey = "ok.png";
            this.btn_OK.ImageList = this.imageList1;
            this.btn_OK.Location = new System.Drawing.Point(454, 0);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(175, 41);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "اضافة و العودة";
            this.btn_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(307, 6);
            // 
            // mnuSameName
            // 
            this.mnuSameName.Font = new System.Drawing.Font("Traditional Arabic", 15.75F, System.Drawing.FontStyle.Bold);
            this.mnuSameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mnuSameName.Name = "mnuSameName";
            this.mnuSameName.Size = new System.Drawing.Size(310, 36);
            this.mnuSameName.Text = "عرض جميع الشهادات التي بنفس الاسم";
            this.mnuSameName.Click += new System.EventHandler(this.mnuSameName_Click);
            // 
            // frm_HolderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 694);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_HolderSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_HolderSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_HolderSearch_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCerts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_CertNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_HolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IdNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ch_IncludebyHolderNo;
        private System.Windows.Forms.CheckBox ch_ExcludePresents;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgvCerts;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CertCount;
        private System.Windows.Forms.Button btn_selectall;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_deselectall;
        private System.Windows.Forms.Button btn_inverseSelect;
        private System.Windows.Forms.Button btn_addtolist;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHolderCerts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSameName;
    }
}
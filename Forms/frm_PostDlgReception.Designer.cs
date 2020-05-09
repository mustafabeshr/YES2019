namespace YES.Forms
{
    partial class frm_PostDlgReception
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PostDlgReception));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPost = new System.Windows.Forms.Button();
            this.btn_inverseSelect = new System.Windows.Forms.Button();
            this.btn_deselectall = new System.Windows.Forms.Button();
            this.btn_selectall = new System.Windows.Forms.Button();
            this.btn_Query = new System.Windows.Forms.Button();
            this.chOnlyMine = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEntryDocNo = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Reception = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalReceptionRows = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chQuerySource = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reception)).BeginInit();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1739, 50);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(615, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(473, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  إعتماد التوكيلات";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1680, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 50);
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
            this.btn_close.Location = new System.Drawing.Point(16, 15);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(40, 28);
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
            this.btn_Min.Location = new System.Drawing.Point(76, 15);
            this.btn_Min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(40, 28);
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.46154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.53846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1739, 808);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.chQuerySource);
            this.panel2.Controls.Add(this.btnPost);
            this.panel2.Controls.Add(this.btn_inverseSelect);
            this.panel2.Controls.Add(this.btn_deselectall);
            this.panel2.Controls.Add(this.btn_selectall);
            this.panel2.Controls.Add(this.btn_Query);
            this.panel2.Controls.Add(this.chOnlyMine);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCardNo);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtEntryDocNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1731, 125);
            this.panel2.TabIndex = 0;
            // 
            // btnPost
            // 
            this.btnPost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.Enabled = false;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPost.ForeColor = System.Drawing.Color.Black;
            this.btnPost.ImageKey = "commit2.png";
            this.btnPost.Location = new System.Drawing.Point(79, 32);
            this.btnPost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(317, 46);
            this.btnPost.TabIndex = 22;
            this.btnPost.Text = "إعتماد البطاقات المحددة (F10)";
            this.btnPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btn_inverseSelect
            // 
            this.btn_inverseSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_inverseSelect.BackgroundImage")));
            this.btn_inverseSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inverseSelect.Location = new System.Drawing.Point(1625, 91);
            this.btn_inverseSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_inverseSelect.Name = "btn_inverseSelect";
            this.btn_inverseSelect.Size = new System.Drawing.Size(32, 28);
            this.btn_inverseSelect.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btn_inverseSelect, "عكس التحديد");
            this.btn_inverseSelect.UseVisualStyleBackColor = true;
            this.btn_inverseSelect.Click += new System.EventHandler(this.btn_inverseSelect_Click);
            // 
            // btn_deselectall
            // 
            this.btn_deselectall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_deselectall.BackgroundImage")));
            this.btn_deselectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deselectall.Location = new System.Drawing.Point(1657, 91);
            this.btn_deselectall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_deselectall.Name = "btn_deselectall";
            this.btn_deselectall.Size = new System.Drawing.Size(32, 28);
            this.btn_deselectall.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btn_deselectall, "الغاء تحديد الكل");
            this.btn_deselectall.UseVisualStyleBackColor = true;
            this.btn_deselectall.Click += new System.EventHandler(this.btn_deselectall_Click);
            // 
            // btn_selectall
            // 
            this.btn_selectall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_selectall.BackgroundImage")));
            this.btn_selectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectall.Location = new System.Drawing.Point(1689, 91);
            this.btn_selectall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_selectall.Name = "btn_selectall";
            this.btn_selectall.Size = new System.Drawing.Size(32, 28);
            this.btn_selectall.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btn_selectall, "تحديد الكل");
            this.btn_selectall.UseVisualStyleBackColor = true;
            this.btn_selectall.Click += new System.EventHandler(this.btn_selectall_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Query.ForeColor = System.Drawing.Color.Black;
            this.btn_Query.ImageKey = "commit2.png";
            this.btn_Query.Location = new System.Drawing.Point(404, 32);
            this.btn_Query.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(317, 46);
            this.btn_Query.TabIndex = 18;
            this.btn_Query.Text = "استعلام (F9)";
            this.btn_Query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // chOnlyMine
            // 
            this.chOnlyMine.AutoSize = true;
            this.chOnlyMine.Font = new System.Drawing.Font("Tahoma", 11F);
            this.chOnlyMine.Location = new System.Drawing.Point(1143, 92);
            this.chOnlyMine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chOnlyMine.Name = "chOnlyMine";
            this.chOnlyMine.Size = new System.Drawing.Size(290, 27);
            this.chOnlyMine.TabIndex = 17;
            this.chOnlyMine.Text = "العمليات التي قمت بانشائها فقط";
            this.chOnlyMine.UseVisualStyleBackColor = true;
            this.chOnlyMine.CheckedChanged += new System.EventHandler(this.chOnlyMine_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(1453, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "اسم الوكيل او المفوض :";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Location = new System.Drawing.Point(813, 52);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(631, 32);
            this.txtName.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(1064, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "رقم الكرت :";
            // 
            // txtCardNo
            // 
            this.txtCardNo.BackColor = System.Drawing.Color.White;
            this.txtCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCardNo.Location = new System.Drawing.Point(813, 11);
            this.txtCardNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCardNo.MaxLength = 10;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(242, 32);
            this.txtCardNo.TabIndex = 11;
            this.txtCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(1453, 16);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 23);
            this.label17.TabIndex = 10;
            this.label17.Text = "رقم الحضور :";
            // 
            // txtEntryDocNo
            // 
            this.txtEntryDocNo.BackColor = System.Drawing.Color.White;
            this.txtEntryDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntryDocNo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtEntryDocNo.Location = new System.Drawing.Point(1203, 11);
            this.txtEntryDocNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEntryDocNo.MaxLength = 10;
            this.txtEntryDocNo.Name = "txtEntryDocNo";
            this.txtEntryDocNo.Size = new System.Drawing.Size(242, 32);
            this.txtEntryDocNo.TabIndex = 9;
            this.txtEntryDocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.txtUserInfo);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 764);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1731, 40);
            this.panel5.TabIndex = 12;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.BackColor = System.Drawing.Color.Black;
            this.txtUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(12, 4);
            this.txtUserInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(1125, 23);
            this.txtUserInfo.TabIndex = 6;
            this.txtUserInfo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1676, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Reception);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 137);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1731, 580);
            this.panel3.TabIndex = 13;
            // 
            // dgv_Reception
            // 
            this.dgv_Reception.AllowUserToAddRows = false;
            this.dgv_Reception.AllowUserToDeleteRows = false;
            this.dgv_Reception.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Reception.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Reception.ColumnHeadersHeight = 35;
            this.dgv_Reception.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            this.dgv_Reception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reception.GridColor = System.Drawing.Color.Silver;
            this.dgv_Reception.Location = new System.Drawing.Point(0, 0);
            this.dgv_Reception.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_Reception.Name = "dgv_Reception";
            this.dgv_Reception.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Reception.RowTemplate.Height = 25;
            this.dgv_Reception.Size = new System.Drawing.Size(1731, 580);
            this.dgv_Reception.TabIndex = 2;
            this.dgv_Reception.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Reception_CellFormatting);
            this.dgv_Reception.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgv_Reception_ColumnAdded);
            // 
            // select
            // 
            this.select.HeaderText = "تحديد";
            this.select.Name = "select";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.btnPrintReport);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtTotalReceptionRows);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 725);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1731, 31);
            this.panel4.TabIndex = 14;
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnEdit.ForeColor = System.Drawing.Color.Blue;
            this.btnEdit.ImageKey = "commit2.png";
            this.btnEdit.Location = new System.Drawing.Point(808, -5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(405, 42);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "تعديل بطاقة الحضور";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnPrintReport.ForeColor = System.Drawing.Color.Blue;
            this.btnPrintReport.ImageKey = "commit2.png";
            this.btnPrintReport.Location = new System.Drawing.Point(404, -5);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(405, 42);
            this.btnPrintReport.TabIndex = 35;
            this.btnPrintReport.Text = "طباعة تقرير للمراجعة";
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1629, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "العدد :";
            // 
            // txtTotalReceptionRows
            // 
            this.txtTotalReceptionRows.BackColor = System.Drawing.Color.Maroon;
            this.txtTotalReceptionRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalReceptionRows.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtTotalReceptionRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTotalReceptionRows.Location = new System.Drawing.Point(1309, 4);
            this.txtTotalReceptionRows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalReceptionRows.MaxLength = 14;
            this.txtTotalReceptionRows.Name = "txtTotalReceptionRows";
            this.txtTotalReceptionRows.ReadOnly = true;
            this.txtTotalReceptionRows.Size = new System.Drawing.Size(311, 30);
            this.txtTotalReceptionRows.TabIndex = 16;
            this.txtTotalReceptionRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chQuerySource
            // 
            this.chQuerySource.AutoSize = true;
            this.chQuerySource.Checked = true;
            this.chQuerySource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chQuerySource.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chQuerySource.Location = new System.Drawing.Point(511, 91);
            this.chQuerySource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chQuerySource.Name = "chQuerySource";
            this.chQuerySource.Size = new System.Drawing.Size(210, 22);
            this.chQuerySource.TabIndex = 23;
            this.chQuerySource.Text = "قبل الترحيل (موظفين ، افراد)";
            this.chQuerySource.UseVisualStyleBackColor = true;
            this.chQuerySource.CheckedChanged += new System.EventHandler(this.chQuerySource_CheckedChanged);
            // 
            // frm_PostDlgReception
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1739, 858);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_PostDlgReception";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_PostDlgReception_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PostDlgReception_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reception)).EndInit();
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
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.CheckBox chOnlyMine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEntryDocNo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_Reception;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalReceptionRows;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.Button btn_inverseSelect;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_deselectall;
        private System.Windows.Forms.Button btn_selectall;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.CheckBox chQuerySource;
    }
}
namespace YES.Forms
{
    partial class frm_RoleItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_RoleItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btn_Query = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.coRole = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Item = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_Permission = new System.Windows.Forms.DataGridView();
            this.dgv_Subitem = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_PerInverseSelect = new System.Windows.Forms.Button();
            this.btn_PerDeselectAll = new System.Windows.Forms.Button();
            this.btn_PerSelectAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_inverseSelect = new System.Windows.Forms.Button();
            this.btn_deselectall = new System.Windows.Forms.Button();
            this.btn_selectall = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Permission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Subitem)).BeginInit();
            this.panel6.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(939, 41);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(278, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(373, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  منح صلاحيات";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(899, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(0, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 41);
            this.btn_close.TabIndex = 1;
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
            this.btn_Min.Location = new System.Drawing.Point(36, 12);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(30, 23);
            this.btn_Min.TabIndex = 0;
            this.btn_Min.Text = "-";
            this.btn_Min.UseVisualStyleBackColor = true;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.02899F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.97102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 597);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btn_Query);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.coRole);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 37);
            this.panel2.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.ImageKey = "commit2.png";
            this.btnSave.Location = new System.Drawing.Point(7, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 31);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "حفظ (F10)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Query.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Query.ForeColor = System.Drawing.Color.Blue;
            this.btn_Query.ImageKey = "commit2.png";
            this.btn_Query.Location = new System.Drawing.Point(224, 3);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(106, 31);
            this.btn_Query.TabIndex = 28;
            this.btn_Query.Text = "استعلام (F9)";
            this.btn_Query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(566, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "المجموعة :";
            // 
            // coRole
            // 
            this.coRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coRole.Font = new System.Drawing.Font("Tahoma", 11F);
            this.coRole.FormattingEnabled = true;
            this.coRole.Location = new System.Drawing.Point(350, 6);
            this.coRole.Name = "coRole";
            this.coRole.Size = new System.Drawing.Size(211, 26);
            this.coRole.TabIndex = 25;
            this.coRole.SelectedIndexChanged += new System.EventHandler(this.coRole_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Item);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(933, 207);
            this.panel3.TabIndex = 1;
            // 
            // dgv_Item
            // 
            this.dgv_Item.AllowUserToAddRows = false;
            this.dgv_Item.AllowUserToDeleteRows = false;
            this.dgv_Item.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Item.ColumnHeadersHeight = 35;
            this.dgv_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Item.Location = new System.Drawing.Point(0, 0);
            this.dgv_Item.Name = "dgv_Item";
            this.dgv_Item.ReadOnly = true;
            this.dgv_Item.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Item.RowTemplate.Height = 28;
            this.dgv_Item.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Item.Size = new System.Drawing.Size(933, 207);
            this.dgv_Item.TabIndex = 3;
            this.dgv_Item.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Item_RowEnter);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.txtUserInfo);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 561);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(933, 33);
            this.panel5.TabIndex = 12;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.BackColor = System.Drawing.Color.Black;
            this.txtUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(9, 8);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(846, 18);
            this.txtUserInfo.TabIndex = 6;
            this.txtUserInfo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(892, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_Permission);
            this.panel4.Controls.Add(this.dgv_Subitem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 294);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(933, 261);
            this.panel4.TabIndex = 2;
            // 
            // dgv_Permission
            // 
            this.dgv_Permission.AllowUserToAddRows = false;
            this.dgv_Permission.AllowUserToDeleteRows = false;
            this.dgv_Permission.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Permission.ColumnHeadersHeight = 35;
            this.dgv_Permission.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_Permission.Location = new System.Drawing.Point(0, 0);
            this.dgv_Permission.Name = "dgv_Permission";
            this.dgv_Permission.RowHeadersVisible = false;
            this.dgv_Permission.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Permission.RowTemplate.Height = 28;
            this.dgv_Permission.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Permission.Size = new System.Drawing.Size(449, 261);
            this.dgv_Permission.TabIndex = 5;
            // 
            // dgv_Subitem
            // 
            this.dgv_Subitem.AllowUserToAddRows = false;
            this.dgv_Subitem.AllowUserToDeleteRows = false;
            this.dgv_Subitem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Subitem.ColumnHeadersHeight = 35;
            this.dgv_Subitem.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_Subitem.Location = new System.Drawing.Point(455, 0);
            this.dgv_Subitem.Name = "dgv_Subitem";
            this.dgv_Subitem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Subitem.RowTemplate.Height = 28;
            this.dgv_Subitem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Subitem.Size = new System.Drawing.Size(478, 261);
            this.dgv_Subitem.TabIndex = 4;
            this.dgv_Subitem.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Subitem_RowEnter);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_PerInverseSelect);
            this.panel6.Controls.Add(this.btn_PerDeselectAll);
            this.panel6.Controls.Add(this.btn_PerSelectAll);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.btn_inverseSelect);
            this.panel6.Controls.Add(this.btn_deselectall);
            this.panel6.Controls.Add(this.btn_selectall);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 259);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(933, 29);
            this.panel6.TabIndex = 13;
            // 
            // btn_PerInverseSelect
            // 
            this.btn_PerInverseSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PerInverseSelect.BackgroundImage")));
            this.btn_PerInverseSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PerInverseSelect.Location = new System.Drawing.Point(148, 3);
            this.btn_PerInverseSelect.Name = "btn_PerInverseSelect";
            this.btn_PerInverseSelect.Size = new System.Drawing.Size(24, 23);
            this.btn_PerInverseSelect.TabIndex = 31;
            this.toolTip1.SetToolTip(this.btn_PerInverseSelect, "عكس التحديد");
            this.btn_PerInverseSelect.UseVisualStyleBackColor = true;
            this.btn_PerInverseSelect.Click += new System.EventHandler(this.btn_PerInverseSelect_Click);
            // 
            // btn_PerDeselectAll
            // 
            this.btn_PerDeselectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PerDeselectAll.BackgroundImage")));
            this.btn_PerDeselectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PerDeselectAll.Location = new System.Drawing.Point(172, 3);
            this.btn_PerDeselectAll.Name = "btn_PerDeselectAll";
            this.btn_PerDeselectAll.Size = new System.Drawing.Size(24, 23);
            this.btn_PerDeselectAll.TabIndex = 30;
            this.toolTip1.SetToolTip(this.btn_PerDeselectAll, "الغاء تحديد الكل");
            this.btn_PerDeselectAll.UseVisualStyleBackColor = true;
            this.btn_PerDeselectAll.Click += new System.EventHandler(this.btn_PerDeselectAll_Click);
            // 
            // btn_PerSelectAll
            // 
            this.btn_PerSelectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PerSelectAll.BackgroundImage")));
            this.btn_PerSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PerSelectAll.Location = new System.Drawing.Point(196, 3);
            this.btn_PerSelectAll.Name = "btn_PerSelectAll";
            this.btn_PerSelectAll.Size = new System.Drawing.Size(24, 23);
            this.btn_PerSelectAll.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btn_PerSelectAll, "تحديد الكل");
            this.btn_PerSelectAll.UseVisualStyleBackColor = true;
            this.btn_PerSelectAll.Click += new System.EventHandler(this.btn_PerSelectAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(329, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "صلاحيات تفصيلية";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(831, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "شاشات النظام";
            // 
            // btn_inverseSelect
            // 
            this.btn_inverseSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_inverseSelect.BackgroundImage")));
            this.btn_inverseSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inverseSelect.Location = new System.Drawing.Point(621, 6);
            this.btn_inverseSelect.Name = "btn_inverseSelect";
            this.btn_inverseSelect.Size = new System.Drawing.Size(24, 23);
            this.btn_inverseSelect.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btn_inverseSelect, "عكس التحديد");
            this.btn_inverseSelect.UseVisualStyleBackColor = true;
            this.btn_inverseSelect.Click += new System.EventHandler(this.btn_inverseSelect_Click);
            // 
            // btn_deselectall
            // 
            this.btn_deselectall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_deselectall.BackgroundImage")));
            this.btn_deselectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_deselectall.Location = new System.Drawing.Point(645, 6);
            this.btn_deselectall.Name = "btn_deselectall";
            this.btn_deselectall.Size = new System.Drawing.Size(24, 23);
            this.btn_deselectall.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btn_deselectall, "الغاء تحديد الكل");
            this.btn_deselectall.UseVisualStyleBackColor = true;
            this.btn_deselectall.Click += new System.EventHandler(this.btn_deselectall_Click);
            // 
            // btn_selectall
            // 
            this.btn_selectall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_selectall.BackgroundImage")));
            this.btn_selectall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectall.Location = new System.Drawing.Point(669, 6);
            this.btn_selectall.Name = "btn_selectall";
            this.btn_selectall.Size = new System.Drawing.Size(24, 23);
            this.btn_selectall.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btn_selectall, "تحديد الكل");
            this.btn_selectall.UseVisualStyleBackColor = true;
            this.btn_selectall.Click += new System.EventHandler(this.btn_selectall_Click);
            // 
            // frm_RoleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 638);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frm_RoleItem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_RoleItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_RoleItem_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Permission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Subitem)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox coRole;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.DataGridView dgv_Item;
        private System.Windows.Forms.DataGridView dgv_Subitem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_inverseSelect;
        private System.Windows.Forms.Button btn_deselectall;
        private System.Windows.Forms.Button btn_selectall;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgv_Permission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_PerInverseSelect;
        private System.Windows.Forms.Button btn_PerDeselectAll;
        private System.Windows.Forms.Button btn_PerSelectAll;
    }
}
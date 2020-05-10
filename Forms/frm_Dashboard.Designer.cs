using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    partial class frm_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.pnl_Item = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnl_reception = new System.Windows.Forms.Panel();
            this.btnReceptionCompany = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnReceptionEmployee = new System.Windows.Forms.Button();
            this.btn_rec_query = new System.Windows.Forms.Button();
            this.btnReceptionSingle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnl_Container = new System.Windows.Forms.Panel();
            this.pnl_report = new System.Windows.Forms.Panel();
            this.btnAgentReport1 = new System.Windows.Forms.Button();
            this.pnl_about = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.pnl_settings = new System.Windows.Forms.Panel();
            this.btnAssignPrinter = new System.Windows.Forms.Button();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.btnRoleItem = new System.Windows.Forms.Button();
            this.btn_st_ChangePassword = new System.Windows.Forms.Button();
            this.btn_st_UserQuery = new System.Windows.Forms.Button();
            this.btn_st_users = new System.Windows.Forms.Button();
            this.pnl_info = new System.Windows.Forms.Panel();
            this.btn_info_resultCompany = new System.Windows.Forms.Button();
            this.btn_info_resultEmployee = new System.Windows.Forms.Button();
            this.btn_info_resultSingle = new System.Windows.Forms.Button();
            this.btn_info_canCompany = new System.Windows.Forms.Button();
            this.btn_info_canEmployee = new System.Windows.Forms.Button();
            this.btn_info_canSingle = new System.Windows.Forms.Button();
            this.btn_info_attendance = new System.Windows.Forms.Button();
            this.pnl_collect = new System.Windows.Forms.Panel();
            this.btn_col_company = new System.Windows.Forms.Button();
            this.btn_col_emplyee = new System.Windows.Forms.Button();
            this.btn_col_single = new System.Windows.Forms.Button();
            this.pnl_vote = new System.Windows.Forms.Panel();
            this.btn_vote_reprint = new System.Windows.Forms.Button();
            this.btn_vote_query = new System.Windows.Forms.Button();
            this.btn_vote_print = new System.Windows.Forms.Button();
            this.pnl_candidate = new System.Windows.Forms.Panel();
            this.btn_can_query = new System.Windows.Forms.Button();
            this.btn_can_approved = new System.Windows.Forms.Button();
            this.btn_can_edit = new System.Windows.Forms.Button();
            this.btn_can_new = new System.Windows.Forms.Button();
            this.pnl_HoldersInfo = new System.Windows.Forms.Panel();
            this.btn_rec_search = new System.Windows.Forms.Button();
            this.pnl_Delegate = new System.Windows.Forms.Panel();
            this.btnDelApproved = new System.Windows.Forms.Button();
            this.btn_Del_ReceptionFounder = new System.Windows.Forms.Button();
            this.btn_Del_ReceptionCompany = new System.Windows.Forms.Button();
            this.btn_Del_ReceptionEmployee = new System.Windows.Forms.Button();
            this.btn_Del_Query = new System.Windows.Forms.Button();
            this.btn_Del_ReceptionSingle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_reception.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnl_Container.SuspendLayout();
            this.pnl_report.SuspendLayout();
            this.pnl_about.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.pnl_settings.SuspendLayout();
            this.pnl_info.SuspendLayout();
            this.pnl_collect.SuspendLayout();
            this.pnl_vote.SuspendLayout();
            this.pnl_candidate.SuspendLayout();
            this.pnl_HoldersInfo.SuspendLayout();
            this.pnl_Delegate.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1028, 51);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(509, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(487, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  الشاشة الرئيسية";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(987, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 43);
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
            this.btn_close.Location = new System.Drawing.Point(14, 15);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(35, 29);
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
            this.btn_Min.Location = new System.Drawing.Point(67, 15);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(35, 29);
            this.btn_Min.TabIndex = 0;
            this.btn_Min.TabStop = false;
            this.btn_Min.Text = "-";
            this.btn_Min.UseVisualStyleBackColor = true;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click);
            // 
            // pnl_Item
            // 
            this.pnl_Item.AutoScroll = true;
            this.pnl_Item.BackColor = System.Drawing.Color.Navy;
            this.pnl_Item.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_Item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Item.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Item.Location = new System.Drawing.Point(757, 51);
            this.pnl_Item.Name = "pnl_Item";
            this.pnl_Item.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.pnl_Item.Size = new System.Drawing.Size(271, 558);
            this.pnl_Item.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "man2.png");
            this.imageList1.Images.SetKeyName(1, "delegate2.png");
            this.imageList1.Images.SetKeyName(2, "book3.png");
            this.imageList1.Images.SetKeyName(3, "king.png");
            this.imageList1.Images.SetKeyName(4, "vote.png");
            this.imageList1.Images.SetKeyName(5, "court.png");
            this.imageList1.Images.SetKeyName(6, "info4.png");
            this.imageList1.Images.SetKeyName(7, "vote6.png");
            this.imageList1.Images.SetKeyName(8, "setting1.png");
            this.imageList1.Images.SetKeyName(9, "rep1.png");
            this.imageList1.Images.SetKeyName(10, "rep3.png");
            this.imageList1.Images.SetKeyName(11, "about1.png");
            this.imageList1.Images.SetKeyName(12, "help1.png");
            // 
            // pnl_reception
            // 
            this.pnl_reception.BackColor = System.Drawing.Color.White;
            this.pnl_reception.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_reception.Controls.Add(this.btnReceptionCompany);
            this.pnl_reception.Controls.Add(this.btnReceptionEmployee);
            this.pnl_reception.Controls.Add(this.btn_rec_query);
            this.pnl_reception.Controls.Add(this.btnReceptionSingle);
            this.pnl_reception.Location = new System.Drawing.Point(0, 6);
            this.pnl_reception.Name = "pnl_reception";
            this.pnl_reception.Size = new System.Drawing.Size(737, 31);
            this.pnl_reception.TabIndex = 5;
            // 
            // btnReceptionCompany
            // 
            this.btnReceptionCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceptionCompany.FlatAppearance.BorderSize = 0;
            this.btnReceptionCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReceptionCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReceptionCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceptionCompany.ImageKey = "receprioncompany.png";
            this.btnReceptionCompany.ImageList = this.imageList2;
            this.btnReceptionCompany.Location = new System.Drawing.Point(25, 19);
            this.btnReceptionCompany.Name = "btnReceptionCompany";
            this.btnReceptionCompany.Size = new System.Drawing.Size(194, 136);
            this.btnReceptionCompany.TabIndex = 3;
            this.btnReceptionCompany.Text = "استقبال المساهمين الشركات";
            this.btnReceptionCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceptionCompany.UseVisualStyleBackColor = true;
            this.btnReceptionCompany.Visible = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "receprion3.png");
            this.imageList2.Images.SetKeyName(1, "search9.png");
            this.imageList2.Images.SetKeyName(2, "delegation.png");
            this.imageList2.Images.SetKeyName(3, "searchinlist.png");
            this.imageList2.Images.SetKeyName(4, "NewCandidate.png");
            this.imageList2.Images.SetKeyName(5, "EditCandidate.png");
            this.imageList2.Images.SetKeyName(6, "ApprovedCandidate.png");
            this.imageList2.Images.SetKeyName(7, "print_vote.png");
            this.imageList2.Images.SetKeyName(8, "collect_company.png");
            this.imageList2.Images.SetKeyName(9, "collect_emplyee.png");
            this.imageList2.Images.SetKeyName(10, "collect_single.png");
            this.imageList2.Images.SetKeyName(11, "attendance2.png");
            this.imageList2.Images.SetKeyName(12, "show_can_company.png");
            this.imageList2.Images.SetKeyName(13, "show_can_employee.png");
            this.imageList2.Images.SetKeyName(14, "show_can_single.png");
            this.imageList2.Images.SetKeyName(15, "voteresult_company.png");
            this.imageList2.Images.SetKeyName(16, "voteresult_employee.png");
            this.imageList2.Images.SetKeyName(17, "voteresult_single.png");
            this.imageList2.Images.SetKeyName(18, "delegationcompany.png");
            this.imageList2.Images.SetKeyName(19, "delegationemployee.png");
            this.imageList2.Images.SetKeyName(20, "delegationfounder.png");
            this.imageList2.Images.SetKeyName(21, "delegationsingle.png");
            this.imageList2.Images.SetKeyName(22, "receprioncompany.png");
            this.imageList2.Images.SetKeyName(23, "receprionemployee.png");
            this.imageList2.Images.SetKeyName(24, "receprionsingle.png");
            this.imageList2.Images.SetKeyName(25, "man2.jpg");
            this.imageList2.Images.SetKeyName(26, "changepass2.png");
            this.imageList2.Images.SetKeyName(27, "user_new.png");
            this.imageList2.Images.SetKeyName(28, "user_query.png");
            this.imageList2.Images.SetKeyName(29, "authorized.png");
            this.imageList2.Images.SetKeyName(30, "reprint4.png");
            this.imageList2.Images.SetKeyName(31, "logoff.png");
            this.imageList2.Images.SetKeyName(32, "stamp.png");
            this.imageList2.Images.SetKeyName(33, "delegate.png");
            this.imageList2.Images.SetKeyName(34, "reprint2.png");
            this.imageList2.Images.SetKeyName(35, "printer2.png");
            // 
            // btnReceptionEmployee
            // 
            this.btnReceptionEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceptionEmployee.FlatAppearance.BorderSize = 0;
            this.btnReceptionEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReceptionEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReceptionEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceptionEmployee.ImageKey = "receprionemployee.png";
            this.btnReceptionEmployee.ImageList = this.imageList2;
            this.btnReceptionEmployee.Location = new System.Drawing.Point(268, 19);
            this.btnReceptionEmployee.Name = "btnReceptionEmployee";
            this.btnReceptionEmployee.Size = new System.Drawing.Size(194, 136);
            this.btnReceptionEmployee.TabIndex = 2;
            this.btnReceptionEmployee.Text = "استقبال المساهمين الموظفين";
            this.btnReceptionEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceptionEmployee.UseVisualStyleBackColor = true;
            this.btnReceptionEmployee.Click += new System.EventHandler(this.btnReceptionEmployee_Click);
            // 
            // btn_rec_query
            // 
            this.btn_rec_query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_rec_query.FlatAppearance.BorderSize = 0;
            this.btn_rec_query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_rec_query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_rec_query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rec_query.ImageKey = "search9.png";
            this.btn_rec_query.ImageList = this.imageList2;
            this.btn_rec_query.Location = new System.Drawing.Point(530, 202);
            this.btn_rec_query.Name = "btn_rec_query";
            this.btn_rec_query.Size = new System.Drawing.Size(198, 136);
            this.btn_rec_query.TabIndex = 1;
            this.btn_rec_query.Text = "الاستعلام عن الحاضرين";
            this.btn_rec_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_rec_query.UseVisualStyleBackColor = true;
            this.btn_rec_query.Click += new System.EventHandler(this.btn_rec_query_Click);
            // 
            // btnReceptionSingle
            // 
            this.btnReceptionSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceptionSingle.FlatAppearance.BorderSize = 0;
            this.btnReceptionSingle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReceptionSingle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReceptionSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceptionSingle.ImageKey = "receprionsingle.png";
            this.btnReceptionSingle.ImageList = this.imageList2;
            this.btnReceptionSingle.Location = new System.Drawing.Point(558, 19);
            this.btnReceptionSingle.Name = "btnReceptionSingle";
            this.btnReceptionSingle.Size = new System.Drawing.Size(166, 136);
            this.btnReceptionSingle.TabIndex = 0;
            this.btnReceptionSingle.Text = "استقبال المساهمين الافراد";
            this.btnReceptionSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceptionSingle.UseVisualStyleBackColor = true;
            this.btnReceptionSingle.Click += new System.EventHandler(this.btnReception_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtUserInfo);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 564);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 45);
            this.panel2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "2019";
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.BackColor = System.Drawing.Color.Black;
            this.txtUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserInfo.ForeColor = System.Drawing.Color.White;
            this.txtUserInfo.Location = new System.Drawing.Point(8, 11);
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(702, 23);
            this.txtUserInfo.TabIndex = 6;
            this.txtUserInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(716, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pnl_Container
            // 
            this.pnl_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnl_Container.Controls.Add(this.pnl_report);
            this.pnl_Container.Controls.Add(this.pnl_about);
            this.pnl_Container.Controls.Add(this.pnl_settings);
            this.pnl_Container.Controls.Add(this.pnl_info);
            this.pnl_Container.Controls.Add(this.pnl_collect);
            this.pnl_Container.Controls.Add(this.pnl_vote);
            this.pnl_Container.Controls.Add(this.pnl_candidate);
            this.pnl_Container.Controls.Add(this.pnl_HoldersInfo);
            this.pnl_Container.Controls.Add(this.pnl_Delegate);
            this.pnl_Container.Controls.Add(this.pnl_reception);
            this.pnl_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Container.Location = new System.Drawing.Point(0, 51);
            this.pnl_Container.Name = "pnl_Container";
            this.pnl_Container.Size = new System.Drawing.Size(757, 513);
            this.pnl_Container.TabIndex = 7;
            // 
            // pnl_report
            // 
            this.pnl_report.BackColor = System.Drawing.Color.White;
            this.pnl_report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_report.Controls.Add(this.btnAgentReport1);
            this.pnl_report.Location = new System.Drawing.Point(12, 97);
            this.pnl_report.Name = "pnl_report";
            this.pnl_report.Size = new System.Drawing.Size(733, 28);
            this.pnl_report.TabIndex = 14;
            // 
            // btnAgentReport1
            // 
            this.btnAgentReport1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgentReport1.FlatAppearance.BorderSize = 0;
            this.btnAgentReport1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAgentReport1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAgentReport1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgentReport1.ImageKey = "delegate.png";
            this.btnAgentReport1.ImageList = this.imageList2;
            this.btnAgentReport1.Location = new System.Drawing.Point(474, 24);
            this.btnAgentReport1.Name = "btnAgentReport1";
            this.btnAgentReport1.Size = new System.Drawing.Size(227, 179);
            this.btnAgentReport1.TabIndex = 2;
            this.btnAgentReport1.Text = "جدول احصائي للتوكيلات";
            this.btnAgentReport1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgentReport1.UseVisualStyleBackColor = true;
            this.btnAgentReport1.Click += new System.EventHandler(this.btnAgentReport1_Click);
            // 
            // pnl_about
            // 
            this.pnl_about.BackColor = System.Drawing.Color.White;
            this.pnl_about.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_about.Controls.Add(this.tableLayoutPanel);
            this.pnl_about.Location = new System.Drawing.Point(8, 209);
            this.pnl_about.Name = "pnl_about";
            this.pnl_about.Size = new System.Drawing.Size(733, 37);
            this.pnl_about.TabIndex = 13;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.90521F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.81042F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(731, 35);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(493, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(235, 27);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelProductName.Location = new System.Drawing.Point(3, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(480, 3);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "نظام ادارة انتخابات الجمعية العمومية";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelVersion.Location = new System.Drawing.Point(3, 3);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(480, 3);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "الاصدار 2015";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelCopyright.Location = new System.Drawing.Point(3, 6);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(480, 3);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "جميع الحقوق محفوظة";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelCompanyName.Location = new System.Drawing.Point(3, 9);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(480, 6);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "يمن موبايل للهاتف النقال";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(3, 18);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(480, 7);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "تم إعداد و تصميم النظام من قبل إدارة تقنية المعلومات في الشركة بالتعاون مع إدارة " +
    "شئون المساهمين";
            // 
            // pnl_settings
            // 
            this.pnl_settings.BackColor = System.Drawing.Color.White;
            this.pnl_settings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_settings.Controls.Add(this.btnAssignPrinter);
            this.pnl_settings.Controls.Add(this.btnLogOff);
            this.pnl_settings.Controls.Add(this.btnRoleItem);
            this.pnl_settings.Controls.Add(this.btn_st_ChangePassword);
            this.pnl_settings.Controls.Add(this.btn_st_UserQuery);
            this.pnl_settings.Controls.Add(this.btn_st_users);
            this.pnl_settings.Location = new System.Drawing.Point(8, 285);
            this.pnl_settings.Name = "pnl_settings";
            this.pnl_settings.Size = new System.Drawing.Size(733, 223);
            this.pnl_settings.TabIndex = 12;
            // 
            // btnAssignPrinter
            // 
            this.btnAssignPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignPrinter.FlatAppearance.BorderSize = 0;
            this.btnAssignPrinter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAssignPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAssignPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignPrinter.ImageKey = "printer2.png";
            this.btnAssignPrinter.ImageList = this.imageList2;
            this.btnAssignPrinter.Location = new System.Drawing.Point(132, 184);
            this.btnAssignPrinter.Name = "btnAssignPrinter";
            this.btnAssignPrinter.Size = new System.Drawing.Size(176, 157);
            this.btnAssignPrinter.TabIndex = 5;
            this.btnAssignPrinter.Text = "تعيين الطابعة";
            this.btnAssignPrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAssignPrinter.UseVisualStyleBackColor = true;
            this.btnAssignPrinter.Click += new System.EventHandler(this.btnAssignPrinter_Click);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOff.FlatAppearance.BorderSize = 0;
            this.btnLogOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOff.ImageKey = "logoff.png";
            this.btnLogOff.ImageList = this.imageList2;
            this.btnLogOff.Location = new System.Drawing.Point(324, 184);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(176, 157);
            this.btnLogOff.TabIndex = 4;
            this.btnLogOff.Text = "تسجيل خروج";
            this.btnLogOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // btnRoleItem
            // 
            this.btnRoleItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleItem.FlatAppearance.BorderSize = 0;
            this.btnRoleItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRoleItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRoleItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleItem.ImageKey = "authorized.png";
            this.btnRoleItem.ImageList = this.imageList2;
            this.btnRoleItem.Location = new System.Drawing.Point(532, 184);
            this.btnRoleItem.Name = "btnRoleItem";
            this.btnRoleItem.Size = new System.Drawing.Size(176, 157);
            this.btnRoleItem.TabIndex = 3;
            this.btnRoleItem.Text = "منح صلاحيات";
            this.btnRoleItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRoleItem.UseVisualStyleBackColor = true;
            this.btnRoleItem.Click += new System.EventHandler(this.btnRoleItem_Click);
            // 
            // btn_st_ChangePassword
            // 
            this.btn_st_ChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_st_ChangePassword.FlatAppearance.BorderSize = 0;
            this.btn_st_ChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_st_ChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_st_ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_st_ChangePassword.ImageKey = "changepass2.png";
            this.btn_st_ChangePassword.ImageList = this.imageList2;
            this.btn_st_ChangePassword.Location = new System.Drawing.Point(128, 3);
            this.btn_st_ChangePassword.Name = "btn_st_ChangePassword";
            this.btn_st_ChangePassword.Size = new System.Drawing.Size(176, 157);
            this.btn_st_ChangePassword.TabIndex = 2;
            this.btn_st_ChangePassword.Text = "تغيير كلمة المرور";
            this.btn_st_ChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_st_ChangePassword.UseVisualStyleBackColor = true;
            this.btn_st_ChangePassword.Click += new System.EventHandler(this.btn_st_ChangePassword_Click);
            // 
            // btn_st_UserQuery
            // 
            this.btn_st_UserQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_st_UserQuery.FlatAppearance.BorderSize = 0;
            this.btn_st_UserQuery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_st_UserQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_st_UserQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_st_UserQuery.ImageKey = "user_query.png";
            this.btn_st_UserQuery.ImageList = this.imageList2;
            this.btn_st_UserQuery.Location = new System.Drawing.Point(324, 3);
            this.btn_st_UserQuery.Name = "btn_st_UserQuery";
            this.btn_st_UserQuery.Size = new System.Drawing.Size(176, 157);
            this.btn_st_UserQuery.TabIndex = 1;
            this.btn_st_UserQuery.Text = "الاستعلام عن المستخدمين";
            this.btn_st_UserQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_st_UserQuery.UseVisualStyleBackColor = true;
            this.btn_st_UserQuery.Click += new System.EventHandler(this.btn_st_UserQuery_Click);
            // 
            // btn_st_users
            // 
            this.btn_st_users.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_st_users.FlatAppearance.BorderSize = 0;
            this.btn_st_users.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_st_users.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_st_users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_st_users.ImageKey = "user_new.png";
            this.btn_st_users.ImageList = this.imageList2;
            this.btn_st_users.Location = new System.Drawing.Point(520, 3);
            this.btn_st_users.Name = "btn_st_users";
            this.btn_st_users.Size = new System.Drawing.Size(176, 157);
            this.btn_st_users.TabIndex = 0;
            this.btn_st_users.Text = "انشاء مستخدم جديد";
            this.btn_st_users.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_st_users.UseVisualStyleBackColor = true;
            this.btn_st_users.Click += new System.EventHandler(this.btn_st_users_Click);
            // 
            // pnl_info
            // 
            this.pnl_info.BackColor = System.Drawing.Color.White;
            this.pnl_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_info.Controls.Add(this.btn_info_resultCompany);
            this.pnl_info.Controls.Add(this.btn_info_resultEmployee);
            this.pnl_info.Controls.Add(this.btn_info_resultSingle);
            this.pnl_info.Controls.Add(this.btn_info_canCompany);
            this.pnl_info.Controls.Add(this.btn_info_canEmployee);
            this.pnl_info.Controls.Add(this.btn_info_canSingle);
            this.pnl_info.Controls.Add(this.btn_info_attendance);
            this.pnl_info.Location = new System.Drawing.Point(7, 256);
            this.pnl_info.Name = "pnl_info";
            this.pnl_info.Size = new System.Drawing.Size(733, 21);
            this.pnl_info.TabIndex = 11;
            // 
            // btn_info_resultCompany
            // 
            this.btn_info_resultCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_resultCompany.FlatAppearance.BorderSize = 0;
            this.btn_info_resultCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_resultCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_resultCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_resultCompany.ImageKey = "voteresult_company.png";
            this.btn_info_resultCompany.ImageList = this.imageList2;
            this.btn_info_resultCompany.Location = new System.Drawing.Point(65, 337);
            this.btn_info_resultCompany.Name = "btn_info_resultCompany";
            this.btn_info_resultCompany.Size = new System.Drawing.Size(184, 159);
            this.btn_info_resultCompany.TabIndex = 6;
            this.btn_info_resultCompany.Text = "عرض نتائج التصويت فئة الشركات";
            this.btn_info_resultCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_resultCompany.UseVisualStyleBackColor = true;
            // 
            // btn_info_resultEmployee
            // 
            this.btn_info_resultEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_resultEmployee.FlatAppearance.BorderSize = 0;
            this.btn_info_resultEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_resultEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_resultEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_resultEmployee.ImageKey = "voteresult_employee.png";
            this.btn_info_resultEmployee.ImageList = this.imageList2;
            this.btn_info_resultEmployee.Location = new System.Drawing.Point(308, 337);
            this.btn_info_resultEmployee.Name = "btn_info_resultEmployee";
            this.btn_info_resultEmployee.Size = new System.Drawing.Size(184, 159);
            this.btn_info_resultEmployee.TabIndex = 5;
            this.btn_info_resultEmployee.Text = "عرض نتائج التصويت فئة الموظفين";
            this.btn_info_resultEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_resultEmployee.UseVisualStyleBackColor = true;
            // 
            // btn_info_resultSingle
            // 
            this.btn_info_resultSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_resultSingle.FlatAppearance.BorderSize = 0;
            this.btn_info_resultSingle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_resultSingle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_resultSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_resultSingle.ImageKey = "voteresult_single.png";
            this.btn_info_resultSingle.ImageList = this.imageList2;
            this.btn_info_resultSingle.Location = new System.Drawing.Point(529, 337);
            this.btn_info_resultSingle.Name = "btn_info_resultSingle";
            this.btn_info_resultSingle.Size = new System.Drawing.Size(184, 159);
            this.btn_info_resultSingle.TabIndex = 4;
            this.btn_info_resultSingle.Text = "عرض نتائج التصويت فئة الافراد";
            this.btn_info_resultSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_resultSingle.UseVisualStyleBackColor = true;
            // 
            // btn_info_canCompany
            // 
            this.btn_info_canCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_canCompany.FlatAppearance.BorderSize = 0;
            this.btn_info_canCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_canCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_canCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_canCompany.ImageKey = "show_can_company.png";
            this.btn_info_canCompany.ImageList = this.imageList2;
            this.btn_info_canCompany.Location = new System.Drawing.Point(65, 171);
            this.btn_info_canCompany.Name = "btn_info_canCompany";
            this.btn_info_canCompany.Size = new System.Drawing.Size(184, 159);
            this.btn_info_canCompany.TabIndex = 3;
            this.btn_info_canCompany.Text = "عرض مرشحين فئة الشركات";
            this.btn_info_canCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_canCompany.UseVisualStyleBackColor = true;
            this.btn_info_canCompany.Click += new System.EventHandler(this.btn_info_canCompany_Click);
            // 
            // btn_info_canEmployee
            // 
            this.btn_info_canEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_canEmployee.FlatAppearance.BorderSize = 0;
            this.btn_info_canEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_canEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_canEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_canEmployee.ImageKey = "show_can_employee.png";
            this.btn_info_canEmployee.ImageList = this.imageList2;
            this.btn_info_canEmployee.Location = new System.Drawing.Point(292, 171);
            this.btn_info_canEmployee.Name = "btn_info_canEmployee";
            this.btn_info_canEmployee.Size = new System.Drawing.Size(184, 159);
            this.btn_info_canEmployee.TabIndex = 2;
            this.btn_info_canEmployee.Text = "عرض مرشحين فئة الموظفين";
            this.btn_info_canEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_canEmployee.UseVisualStyleBackColor = true;
            this.btn_info_canEmployee.Click += new System.EventHandler(this.btn_info_canEmployee_Click);
            // 
            // btn_info_canSingle
            // 
            this.btn_info_canSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_canSingle.FlatAppearance.BorderSize = 0;
            this.btn_info_canSingle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_canSingle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_canSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_canSingle.ImageKey = "show_can_single.png";
            this.btn_info_canSingle.ImageList = this.imageList2;
            this.btn_info_canSingle.Location = new System.Drawing.Point(520, 171);
            this.btn_info_canSingle.Name = "btn_info_canSingle";
            this.btn_info_canSingle.Size = new System.Drawing.Size(184, 159);
            this.btn_info_canSingle.TabIndex = 1;
            this.btn_info_canSingle.Text = "عرض مرشحين فئة الافراد";
            this.btn_info_canSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_canSingle.UseVisualStyleBackColor = true;
            this.btn_info_canSingle.Click += new System.EventHandler(this.btn_info_canSingle_Click);
            // 
            // btn_info_attendance
            // 
            this.btn_info_attendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_info_attendance.FlatAppearance.BorderSize = 0;
            this.btn_info_attendance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_info_attendance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_info_attendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info_attendance.ImageKey = "attendance2.png";
            this.btn_info_attendance.ImageList = this.imageList2;
            this.btn_info_attendance.Location = new System.Drawing.Point(520, -5);
            this.btn_info_attendance.Name = "btn_info_attendance";
            this.btn_info_attendance.Size = new System.Drawing.Size(176, 157);
            this.btn_info_attendance.TabIndex = 0;
            this.btn_info_attendance.Text = "عرض نسبة الحضور";
            this.btn_info_attendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_info_attendance.UseVisualStyleBackColor = true;
            this.btn_info_attendance.Click += new System.EventHandler(this.btn_info_attendance_Click);
            // 
            // pnl_collect
            // 
            this.pnl_collect.BackColor = System.Drawing.Color.White;
            this.pnl_collect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_collect.Controls.Add(this.btn_col_company);
            this.pnl_collect.Controls.Add(this.btn_col_emplyee);
            this.pnl_collect.Controls.Add(this.btn_col_single);
            this.pnl_collect.Location = new System.Drawing.Point(8, 171);
            this.pnl_collect.Name = "pnl_collect";
            this.pnl_collect.Size = new System.Drawing.Size(733, 26);
            this.pnl_collect.TabIndex = 10;
            // 
            // btn_col_company
            // 
            this.btn_col_company.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_col_company.FlatAppearance.BorderSize = 0;
            this.btn_col_company.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_col_company.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_col_company.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_col_company.ImageKey = "collect_company.png";
            this.btn_col_company.ImageList = this.imageList2;
            this.btn_col_company.Location = new System.Drawing.Point(3, 22);
            this.btn_col_company.Name = "btn_col_company";
            this.btn_col_company.Size = new System.Drawing.Size(227, 179);
            this.btn_col_company.TabIndex = 2;
            this.btn_col_company.Text = "فرز أصوات فئة الشركات";
            this.btn_col_company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_col_company.UseVisualStyleBackColor = true;
            // 
            // btn_col_emplyee
            // 
            this.btn_col_emplyee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_col_emplyee.FlatAppearance.BorderSize = 0;
            this.btn_col_emplyee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_col_emplyee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_col_emplyee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_col_emplyee.ImageKey = "collect_emplyee.png";
            this.btn_col_emplyee.ImageList = this.imageList2;
            this.btn_col_emplyee.Location = new System.Drawing.Point(250, 22);
            this.btn_col_emplyee.Name = "btn_col_emplyee";
            this.btn_col_emplyee.Size = new System.Drawing.Size(227, 179);
            this.btn_col_emplyee.TabIndex = 1;
            this.btn_col_emplyee.Text = "فرز أصوات فئة الموظفين";
            this.btn_col_emplyee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_col_emplyee.UseVisualStyleBackColor = true;
            // 
            // btn_col_single
            // 
            this.btn_col_single.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_col_single.FlatAppearance.BorderSize = 0;
            this.btn_col_single.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_col_single.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_col_single.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_col_single.ImageKey = "collect_single.png";
            this.btn_col_single.ImageList = this.imageList2;
            this.btn_col_single.Location = new System.Drawing.Point(485, 22);
            this.btn_col_single.Name = "btn_col_single";
            this.btn_col_single.Size = new System.Drawing.Size(227, 179);
            this.btn_col_single.TabIndex = 0;
            this.btn_col_single.Text = "فرز أصوات فئة الأفراد";
            this.btn_col_single.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_col_single.UseVisualStyleBackColor = true;
            // 
            // pnl_vote
            // 
            this.pnl_vote.BackColor = System.Drawing.Color.White;
            this.pnl_vote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_vote.Controls.Add(this.btn_vote_reprint);
            this.pnl_vote.Controls.Add(this.btn_vote_query);
            this.pnl_vote.Controls.Add(this.btn_vote_print);
            this.pnl_vote.Location = new System.Drawing.Point(8, 141);
            this.pnl_vote.Name = "pnl_vote";
            this.pnl_vote.Size = new System.Drawing.Size(733, 21);
            this.pnl_vote.TabIndex = 9;
            // 
            // btn_vote_reprint
            // 
            this.btn_vote_reprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_vote_reprint.FlatAppearance.BorderSize = 0;
            this.btn_vote_reprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_vote_reprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_vote_reprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vote_reprint.ImageKey = "reprint4.png";
            this.btn_vote_reprint.ImageList = this.imageList2;
            this.btn_vote_reprint.Location = new System.Drawing.Point(469, 218);
            this.btn_vote_reprint.Name = "btn_vote_reprint";
            this.btn_vote_reprint.Size = new System.Drawing.Size(227, 179);
            this.btn_vote_reprint.TabIndex = 2;
            this.btn_vote_reprint.Text = "إعادة طباعة ورقة الاقتراع";
            this.btn_vote_reprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_vote_reprint.UseVisualStyleBackColor = true;
            this.btn_vote_reprint.Click += new System.EventHandler(this.btn_vote_reprint_Click);
            // 
            // btn_vote_query
            // 
            this.btn_vote_query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_vote_query.FlatAppearance.BorderSize = 0;
            this.btn_vote_query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_vote_query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_vote_query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vote_query.ImageKey = "search9.png";
            this.btn_vote_query.ImageList = this.imageList2;
            this.btn_vote_query.Location = new System.Drawing.Point(170, 22);
            this.btn_vote_query.Name = "btn_vote_query";
            this.btn_vote_query.Size = new System.Drawing.Size(227, 179);
            this.btn_vote_query.TabIndex = 1;
            this.btn_vote_query.Text = "الاستعلام عن ورقة الاقتراع";
            this.btn_vote_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_vote_query.UseVisualStyleBackColor = true;
            this.btn_vote_query.Click += new System.EventHandler(this.btn_vote_query_Click);
            // 
            // btn_vote_print
            // 
            this.btn_vote_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_vote_print.FlatAppearance.BorderSize = 0;
            this.btn_vote_print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_vote_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_vote_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vote_print.ImageKey = "print_vote.png";
            this.btn_vote_print.ImageList = this.imageList2;
            this.btn_vote_print.Location = new System.Drawing.Point(469, 22);
            this.btn_vote_print.Name = "btn_vote_print";
            this.btn_vote_print.Size = new System.Drawing.Size(227, 179);
            this.btn_vote_print.TabIndex = 0;
            this.btn_vote_print.Text = "طباعة ورقة الاقتراع";
            this.btn_vote_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_vote_print.UseVisualStyleBackColor = true;
            this.btn_vote_print.Click += new System.EventHandler(this.btn_vote_print_Click);
            // 
            // pnl_candidate
            // 
            this.pnl_candidate.BackColor = System.Drawing.Color.White;
            this.pnl_candidate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_candidate.Controls.Add(this.btn_can_query);
            this.pnl_candidate.Controls.Add(this.btn_can_approved);
            this.pnl_candidate.Controls.Add(this.btn_can_edit);
            this.pnl_candidate.Controls.Add(this.btn_can_new);
            this.pnl_candidate.Location = new System.Drawing.Point(5, 97);
            this.pnl_candidate.Name = "pnl_candidate";
            this.pnl_candidate.Size = new System.Drawing.Size(733, 33);
            this.pnl_candidate.TabIndex = 8;
            // 
            // btn_can_query
            // 
            this.btn_can_query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_can_query.FlatAppearance.BorderSize = 0;
            this.btn_can_query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_can_query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_can_query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_can_query.ImageKey = "search9.png";
            this.btn_can_query.ImageList = this.imageList2;
            this.btn_can_query.Location = new System.Drawing.Point(567, 195);
            this.btn_can_query.Name = "btn_can_query";
            this.btn_can_query.Size = new System.Drawing.Size(152, 179);
            this.btn_can_query.TabIndex = 3;
            this.btn_can_query.Text = "الاستعلام عن المرشحين";
            this.btn_can_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_can_query.UseVisualStyleBackColor = true;
            this.btn_can_query.Click += new System.EventHandler(this.btn_can_query_Click);
            // 
            // btn_can_approved
            // 
            this.btn_can_approved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_can_approved.FlatAppearance.BorderSize = 0;
            this.btn_can_approved.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_can_approved.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_can_approved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_can_approved.ImageKey = "ApprovedCandidate.png";
            this.btn_can_approved.ImageList = this.imageList2;
            this.btn_can_approved.Location = new System.Drawing.Point(62, -1);
            this.btn_can_approved.Name = "btn_can_approved";
            this.btn_can_approved.Size = new System.Drawing.Size(152, 179);
            this.btn_can_approved.TabIndex = 2;
            this.btn_can_approved.Text = "إعتماد المرشحين";
            this.btn_can_approved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_can_approved.UseVisualStyleBackColor = true;
            this.btn_can_approved.Click += new System.EventHandler(this.btn_can_approved_Click);
            // 
            // btn_can_edit
            // 
            this.btn_can_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_can_edit.FlatAppearance.BorderSize = 0;
            this.btn_can_edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_can_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_can_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_can_edit.ImageKey = "EditCandidate.png";
            this.btn_can_edit.ImageList = this.imageList2;
            this.btn_can_edit.Location = new System.Drawing.Point(296, -1);
            this.btn_can_edit.Name = "btn_can_edit";
            this.btn_can_edit.Size = new System.Drawing.Size(152, 179);
            this.btn_can_edit.TabIndex = 1;
            this.btn_can_edit.Text = "تعديل بيانات مرشح";
            this.btn_can_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_can_edit.UseVisualStyleBackColor = true;
            this.btn_can_edit.Click += new System.EventHandler(this.btn_can_edit_Click);
            // 
            // btn_can_new
            // 
            this.btn_can_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_can_new.FlatAppearance.BorderSize = 0;
            this.btn_can_new.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_can_new.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_can_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_can_new.ImageKey = "NewCandidate.png";
            this.btn_can_new.ImageList = this.imageList2;
            this.btn_can_new.Location = new System.Drawing.Point(567, 3);
            this.btn_can_new.Name = "btn_can_new";
            this.btn_can_new.Size = new System.Drawing.Size(152, 179);
            this.btn_can_new.TabIndex = 0;
            this.btn_can_new.Text = "تسجيل مرشح جديد";
            this.btn_can_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_can_new.UseVisualStyleBackColor = true;
            this.btn_can_new.Click += new System.EventHandler(this.btn_can_new_Click);
            // 
            // pnl_HoldersInfo
            // 
            this.pnl_HoldersInfo.BackColor = System.Drawing.Color.White;
            this.pnl_HoldersInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_HoldersInfo.Controls.Add(this.btn_rec_search);
            this.pnl_HoldersInfo.Location = new System.Drawing.Point(5, 74);
            this.pnl_HoldersInfo.Name = "pnl_HoldersInfo";
            this.pnl_HoldersInfo.Size = new System.Drawing.Size(733, 15);
            this.pnl_HoldersInfo.TabIndex = 7;
            // 
            // btn_rec_search
            // 
            this.btn_rec_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_rec_search.FlatAppearance.BorderSize = 0;
            this.btn_rec_search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_rec_search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_rec_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rec_search.ImageKey = "searchinlist.png";
            this.btn_rec_search.ImageList = this.imageList2;
            this.btn_rec_search.Location = new System.Drawing.Point(264, 24);
            this.btn_rec_search.Name = "btn_rec_search";
            this.btn_rec_search.Size = new System.Drawing.Size(227, 179);
            this.btn_rec_search.TabIndex = 0;
            this.btn_rec_search.Text = "البحث في سجل المساهمين";
            this.btn_rec_search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_rec_search.UseVisualStyleBackColor = true;
            this.btn_rec_search.Click += new System.EventHandler(this.btn_rec_search_Click);
            // 
            // pnl_Delegate
            // 
            this.pnl_Delegate.BackColor = System.Drawing.Color.White;
            this.pnl_Delegate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Delegate.Controls.Add(this.btnDelApproved);
            this.pnl_Delegate.Controls.Add(this.btn_Del_ReceptionFounder);
            this.pnl_Delegate.Controls.Add(this.btn_Del_ReceptionCompany);
            this.pnl_Delegate.Controls.Add(this.btn_Del_ReceptionEmployee);
            this.pnl_Delegate.Controls.Add(this.btn_Del_Query);
            this.pnl_Delegate.Controls.Add(this.btn_Del_ReceptionSingle);
            this.pnl_Delegate.Location = new System.Drawing.Point(3, 43);
            this.pnl_Delegate.Name = "pnl_Delegate";
            this.pnl_Delegate.Size = new System.Drawing.Size(733, 24);
            this.pnl_Delegate.TabIndex = 6;
            // 
            // btnDelApproved
            // 
            this.btnDelApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelApproved.FlatAppearance.BorderSize = 0;
            this.btnDelApproved.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelApproved.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelApproved.ImageKey = "stamp.png";
            this.btnDelApproved.ImageList = this.imageList2;
            this.btnDelApproved.Location = new System.Drawing.Point(25, 211);
            this.btnDelApproved.Name = "btnDelApproved";
            this.btnDelApproved.Size = new System.Drawing.Size(198, 155);
            this.btnDelApproved.TabIndex = 5;
            this.btnDelApproved.Text = "إعتماد التوكيلات";
            this.btnDelApproved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelApproved.UseVisualStyleBackColor = true;
            this.btnDelApproved.Click += new System.EventHandler(this.btnDelApproved_Click);
            // 
            // btn_Del_ReceptionFounder
            // 
            this.btn_Del_ReceptionFounder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del_ReceptionFounder.FlatAppearance.BorderSize = 0;
            this.btn_Del_ReceptionFounder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionFounder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionFounder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del_ReceptionFounder.ImageKey = "delegationfounder.png";
            this.btn_Del_ReceptionFounder.ImageList = this.imageList2;
            this.btn_Del_ReceptionFounder.Location = new System.Drawing.Point(543, 205);
            this.btn_Del_ReceptionFounder.Name = "btn_Del_ReceptionFounder";
            this.btn_Del_ReceptionFounder.Size = new System.Drawing.Size(180, 155);
            this.btn_Del_ReceptionFounder.TabIndex = 4;
            this.btn_Del_ReceptionFounder.Text = "استقبال التوكيلات للمؤسسين";
            this.btn_Del_ReceptionFounder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Del_ReceptionFounder.UseVisualStyleBackColor = true;
            this.btn_Del_ReceptionFounder.Click += new System.EventHandler(this.btn_Del_ReceptionFounder_Click);
            // 
            // btn_Del_ReceptionCompany
            // 
            this.btn_Del_ReceptionCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del_ReceptionCompany.FlatAppearance.BorderSize = 0;
            this.btn_Del_ReceptionCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del_ReceptionCompany.ImageKey = "delegationcompany.png";
            this.btn_Del_ReceptionCompany.ImageList = this.imageList2;
            this.btn_Del_ReceptionCompany.Location = new System.Drawing.Point(25, 29);
            this.btn_Del_ReceptionCompany.Name = "btn_Del_ReceptionCompany";
            this.btn_Del_ReceptionCompany.Size = new System.Drawing.Size(180, 155);
            this.btn_Del_ReceptionCompany.TabIndex = 3;
            this.btn_Del_ReceptionCompany.Text = "استقبال التوكيلات للشركات";
            this.btn_Del_ReceptionCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Del_ReceptionCompany.UseVisualStyleBackColor = true;
            this.btn_Del_ReceptionCompany.Click += new System.EventHandler(this.btn_Del_ReceptionCompany_Click);
            // 
            // btn_Del_ReceptionEmployee
            // 
            this.btn_Del_ReceptionEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del_ReceptionEmployee.FlatAppearance.BorderSize = 0;
            this.btn_Del_ReceptionEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del_ReceptionEmployee.ImageKey = "delegationemployee.png";
            this.btn_Del_ReceptionEmployee.ImageList = this.imageList2;
            this.btn_Del_ReceptionEmployee.Location = new System.Drawing.Point(277, 29);
            this.btn_Del_ReceptionEmployee.Name = "btn_Del_ReceptionEmployee";
            this.btn_Del_ReceptionEmployee.Size = new System.Drawing.Size(180, 155);
            this.btn_Del_ReceptionEmployee.TabIndex = 2;
            this.btn_Del_ReceptionEmployee.Text = "استقبال التوكيلات للموظفين";
            this.btn_Del_ReceptionEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Del_ReceptionEmployee.UseVisualStyleBackColor = true;
            this.btn_Del_ReceptionEmployee.Click += new System.EventHandler(this.btn_Del_ReceptionEmployee_Click);
            // 
            // btn_Del_Query
            // 
            this.btn_Del_Query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del_Query.FlatAppearance.BorderSize = 0;
            this.btn_Del_Query.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Del_Query.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Del_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del_Query.ImageKey = "search9.png";
            this.btn_Del_Query.ImageList = this.imageList2;
            this.btn_Del_Query.Location = new System.Drawing.Point(277, 211);
            this.btn_Del_Query.Name = "btn_Del_Query";
            this.btn_Del_Query.Size = new System.Drawing.Size(198, 155);
            this.btn_Del_Query.TabIndex = 1;
            this.btn_Del_Query.Text = "الاستعلام عن التوكيلات";
            this.btn_Del_Query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Del_Query.UseVisualStyleBackColor = true;
            this.btn_Del_Query.Click += new System.EventHandler(this.btn_Del_Query_Click);
            // 
            // btn_Del_ReceptionSingle
            // 
            this.btn_Del_ReceptionSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del_ReceptionSingle.FlatAppearance.BorderSize = 0;
            this.btn_Del_ReceptionSingle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionSingle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_Del_ReceptionSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del_ReceptionSingle.ImageKey = "delegationsingle.png";
            this.btn_Del_ReceptionSingle.ImageList = this.imageList2;
            this.btn_Del_ReceptionSingle.Location = new System.Drawing.Point(558, 19);
            this.btn_Del_ReceptionSingle.Name = "btn_Del_ReceptionSingle";
            this.btn_Del_ReceptionSingle.Size = new System.Drawing.Size(166, 155);
            this.btn_Del_ReceptionSingle.TabIndex = 0;
            this.btn_Del_ReceptionSingle.Text = "استقبال التوكيلات للأفراد";
            this.btn_Del_ReceptionSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Del_ReceptionSingle.UseVisualStyleBackColor = true;
            this.btn_Del_ReceptionSingle.Click += new System.EventHandler(this.btn_Del_ReceptionSingle_Click);
            // 
            // frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_Container);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_Item);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Dashboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Dashboard_KeyDown_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_reception.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnl_Container.ResumeLayout(false);
            this.pnl_report.ResumeLayout(false);
            this.pnl_about.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.pnl_settings.ResumeLayout(false);
            this.pnl_info.ResumeLayout(false);
            this.pnl_collect.ResumeLayout(false);
            this.pnl_vote.ResumeLayout(false);
            this.pnl_candidate.ResumeLayout(false);
            this.pnl_HoldersInfo.ResumeLayout(false);
            this.pnl_Delegate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.Panel pnl_Item;
        private System.Windows.Forms.Panel pnl_reception;
        private System.Windows.Forms.ImageList imageList1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private TextBox txtUserInfo;
        private Button btnReceptionSingle;
        private ImageList imageList2;
        private Button btn_rec_query;
        private Panel pnl_Container;
        private Panel pnl_Delegate;
        private Button btn_Del_Query;
        private Button btn_Del_ReceptionSingle;
        private Panel pnl_HoldersInfo;
        private Button btn_rec_search;
        private Panel pnl_candidate;
        private Button btn_can_new;
        private Button btn_can_edit;
        private Button btn_can_approved;
        private Button btn_can_query;
        private Panel pnl_vote;
        private Button btn_vote_print;
        private Button btn_vote_query;
        private Panel pnl_collect;
        private Button btn_col_company;
        private Button btn_col_emplyee;
        private Button btn_col_single;
        private Panel pnl_info;
        private Button btn_info_attendance;
        private Button btn_info_canSingle;
        private Button btn_info_canCompany;
        private Button btn_info_canEmployee;
        private Button btn_info_resultCompany;
        private Button btn_info_resultEmployee;
        private Button btn_info_resultSingle;
        private Button btnReceptionCompany;
        private Button btnReceptionEmployee;
        private Button btn_Del_ReceptionFounder;
        private Button btn_Del_ReceptionCompany;
        private Button btn_Del_ReceptionEmployee;
        private Panel pnl_settings;
        private Button btn_st_users;
        private Button btn_st_UserQuery;
        private Button btn_st_ChangePassword;
        private Button btnRoleItem;
        private Button btn_vote_reprint;
        private Panel pnl_about;
        private TableLayoutPanel tableLayoutPanel;
        private PictureBox logoPictureBox;
        private Label labelProductName;
        private Label labelVersion;
        private Label labelCopyright;
        private Label labelCompanyName;
        private TextBox textBoxDescription;
        private Button btnLogOff;
        private Button btnDelApproved;
        private Panel pnl_report;
        private Button btnAgentReport1;
        private Button btnAssignPrinter;
        private Label label6;
    }
}
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YES.Forms
{
    partial class frm_test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_test));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.btnEnc = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSim = new System.Windows.Forms.Label();
            this.lblrandomPass = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 50);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(552, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(464, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  شاشة الدخول";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1066, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
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
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(40, 28);
            this.btn_close.TabIndex = 1;
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_Min
            // 
            this.btn_Min.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btn_Min.ForeColor = System.Drawing.Color.White;
            this.btn_Min.Location = new System.Drawing.Point(75, 15);
            this.btn_Min.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(40, 28);
            this.btn_Min.TabIndex = 0;
            this.btn_Min.Text = "-";
            this.btn_Min.UseVisualStyleBackColor = true;
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
            // txt1
            // 
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt1.Location = new System.Drawing.Point(259, 102);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(652, 30);
            this.txt1.TabIndex = 4;
            this.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKey
            // 
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtKey.Location = new System.Drawing.Point(259, 157);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(652, 30);
            this.txtKey.TabIndex = 5;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Text 1 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text 2 :";
            // 
            // txt2
            // 
            this.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt2.Location = new System.Drawing.Point(259, 266);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(652, 30);
            this.txt2.TabIndex = 8;
            this.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEnc
            // 
            this.btnEnc.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnc.Location = new System.Drawing.Point(350, 214);
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.Size = new System.Drawing.Size(142, 30);
            this.btnEnc.TabIndex = 10;
            this.btnEnc.Text = "Encrypt";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btnEnc_Click);
            // 
            // btnDec
            // 
            this.btnDec.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDec.Location = new System.Drawing.Point(618, 214);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(142, 30);
            this.btnDec.TabIndex = 11;
            this.btnDec.Text = "Decrypt";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(274, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "similarity";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // lblSim
            // 
            this.lblSim.AutoSize = true;
            this.lblSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSim.Location = new System.Drawing.Point(450, 363);
            this.lblSim.Name = "lblSim";
            this.lblSim.Size = new System.Drawing.Size(39, 25);
            this.lblSim.TabIndex = 13;
            this.lblSim.Text = "0.0";
            // 
            // lblrandomPass
            // 
            this.lblrandomPass.AutoSize = true;
            this.lblrandomPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrandomPass.Location = new System.Drawing.Point(450, 420);
            this.lblrandomPass.Name = "lblrandomPass";
            this.lblrandomPass.Size = new System.Drawing.Size(39, 25);
            this.lblrandomPass.TabIndex = 15;
            this.lblrandomPass.Text = "0.0";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(274, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 30);
            this.button2.TabIndex = 14;
            this.button2.Text = "random pass";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // frm_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 594);
            this.Controls.Add(this.lblrandomPass);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblSim);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnEnc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_test";
            this.Load += new System.EventHandler(this.frm_test_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void BuildControls(string roleid)
        {
            string strSQL = "SELECT  TOP (100) PERCENT dbo.Role_Items.roleid, dbo.Dashboad_item.itemid"
                           + ", dbo.Dashboad_item.itemname1, dbo.Dashboad_item.itemname2, "
                           + " dbo.Dashboad_item.itemorder, dbo.Dashboad_item.imagename "
                           + " FROM   dbo.Dashboad_item INNER JOIN "
                           + " dbo.Role_Items ON dbo.Dashboad_item.itemid = dbo.Role_Items.itemid "
                           + " WHERE dbo.Role_Items.roleid=@RoleId"
                           + " ORDER BY dbo.Dashboad_item.itemorder desc";

            using (SqlConnection con = appcode.Db.GetSQLConnection())
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("RoleId", roleid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "RolesItems");
                foreach (DataRow Dr in ds.Tables["RolesItems"].Rows)
                {
                    Button btn = new Button();
                    btn.Name = Dr["itemname1"].ToString();
                    btn.Text = Dr["itemname2"].ToString();
                    btn.BackColor = System.Drawing.Color.Transparent;
                    btn.Cursor = Cursors.Hand;
                    btn.Dock = DockStyle.Top;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new System.Drawing.Font("Tahoma", 12F);
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.ImageKey = Dr["imagename"].ToString();
                    btn.ImageList = this.imageList1;
                    btn.Location = new System.Drawing.Point(0, 10);
                    btn.Size = new System.Drawing.Size(231, 40);
                    btn.TabIndex = 0;
                    btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    btn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    btn.UseVisualStyleBackColor = false;
                }
            }
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.ImageList imageList1;
        private TextBox txt1;
        private TextBox txtKey;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt2;
        private Button btnEnc;
        private Button btnDec;
        private Button button1;
        private Label lblSim;
        private Label lblrandomPass;
        private Button button2;
    }
}
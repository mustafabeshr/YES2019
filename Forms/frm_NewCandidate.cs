using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_NewCandidate : Form
    {
       
        DataTable dt_CandQualifications;
        DataTable dt_CandCerts;
        DataTable dt_CandExperience;
        DataTable dt_CandLastJobs;
        private bool mouseIsDown = false;
        private Point firstPoint;
        OpenFileDialog imageOpenDialog = new OpenFileDialog();
        string Operation_Type = string.Empty;
        string TargetCanNo = string.Empty;
        string TargetClass = string.Empty;
        public frm_NewCandidate(string OperationType,string Title,string CandNo,string Cand_Class)
        {
            InitializeComponent();
            Operation_Type = OperationType;
            lblTitle.Text = Title;
            TargetCanNo = CandNo;
            TargetClass = Cand_Class;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_NewCandidate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.F10)
            {
                btn_Commit_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                btn_Delete_Click(sender, e);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void frm_NewCandidate_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            //dgv_Qual.DataSource = cnd_qual_list;
            PrepareGrids();
            PopulateIdTypesLists();
            if (Operation_Type=="new")
            {
                txtCandNo.ReadOnly = true;
                btn_Delete.Visible = false;
                frm_CandCertChecking frm = new frm_CandCertChecking();
                frm.ShowDialog();
                if (frm.Answer=="close")
                {
                    this.Close();
                }
                if (frm.Answer=="data")
                {
                    DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "Holders", "CertNo", frm.AnswerCertNo, "HolderClass", frm.AnswerHolderClassId, "status", "-2");
                    if (dt != null)
                    {
                        DataRow HDR = dt.Rows[0];
                        coClass.SelectedValue = HDR["holder_class"].ToString();
                        coClass.Enabled = false;
                        txtfullname.Text = HDR["holder_name"].ToString();
                        txtIdNo.Text = HDR["id_no"].ToString();
                        txtIdDate.Text = HDR["id_date"].ToString();
                        txtIdPlace.Text = HDR["id_place"].ToString();
                        coIdType.SelectedValue= HDR["id_type"].ToString();
                        if (frm.AnswerHolderNo>0)
                        {
                            string strsql = "SELECT * FROM dbo.v_Holders WHERE holder_no=" + frm.AnswerHolderNo.ToString() + " AND status<>5" + Environment.NewLine
                                + "AND NOT EXISTS (SELECT 1 FROM [dbo].[candidate_certs] " + Environment.NewLine
                                + "WHERE [dbo].[candidate_certs].cert_no=dbo.v_Holders.cert_no)";
                            DataTable dt2 = Db.GetDataAsDataTable(strsql);
                            if (dt2 != null)
                            {
                                foreach (DataRow dr in dt2.Rows)
                                {
                                    dt_CandCerts.Rows.Add(dr["cert_no"].ToString(), dr["share_qty"].ToString(), dr["holder_name"].ToString(), dr["class_name"].ToString(), dr["holder_class"].ToString());
                                }
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            dt_CandCerts.Rows.Add(HDR["cert_no"].ToString(), HDR["share_qty"].ToString(), HDR["holder_name"].ToString(), HDR["class_name"].ToString(), HDR["holder_class"].ToString());
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else if (Operation_Type == "edit")
            {
                btn_Delete.Visible = true;
                txtCandNo.ReadOnly = true;
                LoadCandidateData(TargetCanNo, TargetClass);
                txtfullname.Focus();
            }
            else if (Operation_Type == "query")
            {
                btn_Delete.Visible = true;
                btn_Commit.Visible = false;
                btn_Delete.Visible = false;
                txtCandNo.ReadOnly = true;
                LoadCandidateData(TargetCanNo,TargetClass);
            }
        }
        void ClearAllData()
        {
            ClearTextBoxesData(tabPage1);
            ClearTextBoxesData(tabPage6);
            if (!object.ReferenceEquals(dt_CandQualifications, null)) { dt_CandQualifications.Rows.Clear(); }
            if (!object.ReferenceEquals(dt_CandCerts, null)) { dt_CandCerts.Rows.Clear(); }
            if (!object.ReferenceEquals(dt_CandExperience, null)) { dt_CandExperience.Rows.Clear(); }
            if (!object.ReferenceEquals(dt_CandLastJobs, null)) { dt_CandLastJobs.Rows.Clear(); }
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NewCandidate));
            this.cand_pic.Image = ((System.Drawing.Image)(resources.GetObject("cand_pic.Image")));
            lblPicFileName.Text = string.Empty;
            lblpicfullname.Text = string.Empty;
        }
        void ClearTextBoxesData(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.GetType().Name == "TextBox")
                {
                    ctrl.Text = string.Empty;
                }
                else if (ctrl.GetType().Name == "GroupBox" )
               {
                    ClearTextBoxesData(ctrl);
                }

            }
        }
        void LoadCandidateData(string candidateno,string CandClass)
        {
            try {
                string strsql = "select TOP 1 * from candidate where cand_no=@candno and cand_class=@candclass";
                DataTable CandTable = Db.GetDataAsDataTable(strsql, "candidate", "candno", candidateno,"candclass",CandClass);
                if (CandTable != null)
                {
                    coClass.SelectedValue = CandTable.Rows[0]["cand_class"];
                    txtCandNo.Text = CandTable.Rows[0]["cand_no"].ToString();
                    txtfullname.Text = CandTable.Rows[0]["cand_name"].ToString();
                    txtDOB.Text = DBNull.Value.Equals(CandTable.Rows[0]["DOB"]) ? string.Empty : DateTime.Parse(CandTable.Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                    txtBirthPlace.Text = CandTable.Rows[0]["birth_place"].ToString();
                    txtAddress.Text = CandTable.Rows[0]["address"].ToString();
                    coIdType.SelectedValue = CandTable.Rows[0]["id_type"];
                    txtIdNo.Text = CandTable.Rows[0]["id_no"].ToString();
                    txtIdDate.Text = DBNull.Value.Equals(CandTable.Rows[0]["id_date"]) ? string.Empty : DateTime.Parse(CandTable.Rows[0]["id_date"].ToString()).ToString("dd/MM/yyyy");
                    txtIdPlace.Text = CandTable.Rows[0]["id_place"].ToString();
                    txtJobOrg.Text = CandTable.Rows[0]["work_org"].ToString();
                    txtJob.Text = CandTable.Rows[0]["job"].ToString();
                    txtMobileNo.Text = CandTable.Rows[0]["mobile_no"].ToString();
                    txtHomeTel.Text = CandTable.Rows[0]["home_tel"].ToString();
                    txtWorkTel.Text = CandTable.Rows[0]["work_tel"].ToString();
                    txtFax.Text = CandTable.Rows[0]["fax"].ToString();
                    txtEmail.Text = CandTable.Rows[0]["email"].ToString();
                    txtWebsite.Text = CandTable.Rows[0]["website"].ToString();
                    txtLegalName.Text = CandTable.Rows[0]["legal_name"].ToString();
                    txtMainActivity.Text = CandTable.Rows[0]["main_activity"].ToString();
                    txtLegalForm.Text = CandTable.Rows[0]["legal_form"].ToString();
                    txtLicenceNo.Text = CandTable.Rows[0]["licence_no"].ToString();
                    txtLicenceDate.Text = DBNull.Value.Equals(CandTable.Rows[0]["licence_date"]) ? string.Empty : DateTime.Parse(CandTable.Rows[0]["licence_date"].ToString()).ToString("dd/MM/yyyy");
                    txtLicencePlace.Text = CandTable.Rows[0]["licence_place"].ToString();
                    txtcompanyaddress.Text = CandTable.Rows[0]["company_address"].ToString();
                    lblPicFileName.Text = CandTable.Rows[0]["cand_pic_name"].ToString();
                    // begin load image ...
                    if (!CandTable.Rows[0]["cand_pic"].Equals(DBNull.Value))
                    {
                        try {
                            MemoryStream stream = new MemoryStream();
                            byte[] image = (byte[])CandTable.Rows[0]["cand_pic"];
                            stream.Write(image, 0, image.Length);
                            Bitmap bitmap = new Bitmap(stream);
                            cand_pic.Image = bitmap;
                            cand_pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            cand_pic.Refresh();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.GetType().Name);
                        }
                    }
                    // end load image ...
                    strsql = "SELECT cert_no certno,share_qty shareqty,holder_name holdername "
                             + "   ,dbo.GetClassName(class_id)  classname,class_id classid "
                             + "   FROM dbo.candidate_certs where cand_no=@candno  and cand_class=@candclass";
                    dt_CandCerts = Db.GetDataAsDataTable(strsql, "candidatecerts", "candno", candidateno, "candclass",CandClass);
                    if (dt_CandCerts != null)
                    {
                        dgv_Certs.DataSource = dt_CandCerts;
                    }

                    strsql = "SELECT qualification qual FROM candidate_qualification where cand_no=@candno and cand_class=@candclass order by line_no";
                    dt_CandQualifications = Db.GetDataAsDataTable(strsql, "candidatequal", "candno", candidateno,"candclass",CandClass);
                    if (dt_CandQualifications != null)
                    {
                        dgv_Qual.DataSource = dt_CandQualifications;
                    }

                    strsql = "SELECT experience exp FROM candidate_experience where cand_no=@candno and cand_class=@candclass order by line_no";
                    dt_CandExperience = Db.GetDataAsDataTable(strsql, "candidateexp", "candno", candidateno,"candclass",CandClass);
                    if (dt_CandExperience != null)
                    {
                        dgv_Exp.DataSource = dt_CandExperience;
                    }
                    strsql = "SELECT job,start_date startdate,end_date enddate,org_name orgname FROM candidate_lastjobs where cand_no=@candno  and cand_class=@candclass order by line_no";
                    dt_CandLastJobs = Db.GetDataAsDataTable(strsql, "candidatelast", "candno", candidateno,"candclass",CandClass);
                    if (dt_CandLastJobs != null)
                    {
                        dgv_LastJobs.DataSource = dt_CandLastJobs;
                    }
                }
                else
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("لا يوجد مرشح بهذا الرقم ، يرجى التأكد و المحاولة لاحقا");
                    frm.ShowDialog();
                    txtCandNo.Focus();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrepareGrids()
        {
            dt_CandQualifications = new DataTable();
            dt_CandQualifications.Columns.Add("qual");
            dgv_Qual.DataSource = dt_CandQualifications.DefaultView;
            //dgv_Qual.RowCount = 20;
            dgv_Qual.RowTemplate.Height = 35;
            dgv_Qual.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Qual.Columns["qual"].HeaderText = "المــــؤهــــلات";
            dgv_Qual.Columns["qual"].Width = 700;
            dgv_Qual.Columns["qual"].DisplayIndex = 0;
            dgv_Qual.Columns["qual"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Qual.Columns["qual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //---------------------------------------------------------------------------------------------
            dt_CandCerts = new DataTable();
            dt_CandCerts.Columns.Add("certno");
            dt_CandCerts.Columns.Add("shareqty");
            dt_CandCerts.Columns.Add("holdername");
            dt_CandCerts.Columns.Add("classname");
            dt_CandCerts.Columns.Add("classid");
            dgv_Certs.DataSource = dt_CandCerts;
            dgv_Certs.RowTemplate.Height = 30;
            dgv_Certs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Certs.Columns["certno"].HeaderText = "رقم الشهادة";
            dgv_Certs.Columns["certno"].Width = 150;
            dgv_Certs.Columns["certno"].DisplayIndex = 0;
            dgv_Certs.Columns["certno"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Certs.Columns["certno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Certs.Columns["shareqty"].HeaderText = "عدد الاسهم";
            dgv_Certs.Columns["shareqty"].Width = 150;
            dgv_Certs.Columns["shareqty"].ReadOnly = true;
            dgv_Certs.Columns["shareqty"].DisplayIndex = 1;
            dgv_Certs.Columns["shareqty"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Certs.Columns["shareqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Certs.Columns["holdername"].HeaderText = "اسم المساهم";
            dgv_Certs.Columns["holdername"].Width = 400;
            dgv_Certs.Columns["holdername"].ReadOnly = true;
            dgv_Certs.Columns["holdername"].DisplayIndex =2;
            dgv_Certs.Columns["holdername"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Certs.Columns["holdername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_Certs.Columns["classname"].HeaderText = "الفئة";
            dgv_Certs.Columns["classname"].Width = 100;
            dgv_Certs.Columns["classname"].ReadOnly = true;
            dgv_Certs.Columns["classname"].DisplayIndex = 2;
            dgv_Certs.Columns["classname"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Certs.Columns["classname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_Certs.Columns["classid"].HeaderText = "الفئة";
            dgv_Certs.Columns["classid"].Width = 100;
            dgv_Certs.Columns["classid"].ReadOnly = true;
            dgv_Certs.Columns["classid"].DisplayIndex = 3;
            dgv_Certs.Columns["classid"].Visible = false;
            dgv_Certs.Columns["classid"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Certs.Columns["classid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //---------------------------------------------------------------------------------------------
            dt_CandExperience = new DataTable();
            dt_CandExperience.Columns.Add("exp");
            dgv_Exp.DataSource = dt_CandExperience;
            dgv_Exp.RowTemplate.Height = 35;
            dgv_Exp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Exp.Columns["exp"].HeaderText = "الــخــبـــرات";
            dgv_Exp.Columns["exp"].Width = 700;
            dgv_Exp.Columns["exp"].DisplayIndex = 0;
            dgv_Exp.Columns["exp"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_Exp.Columns["exp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //---------------------------------------------------------------------------------------------
            dt_CandLastJobs = new DataTable();
            dt_CandLastJobs.Columns.Add("job");
            dt_CandLastJobs.Columns.Add("startdate");
            dt_CandLastJobs.Columns.Add("enddate");
            dt_CandLastJobs.Columns.Add("orgname");
            dgv_LastJobs.DataSource = dt_CandLastJobs;
            dgv_LastJobs.RowTemplate.Height = 30;
            dgv_LastJobs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_LastJobs.Columns["job"].HeaderText = "الوظيفة";
            dgv_LastJobs.Columns["job"].Width = 300;
            dgv_LastJobs.Columns["job"].DisplayIndex = 0;
            dgv_LastJobs.Columns["job"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_LastJobs.Columns["job"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_LastJobs.Columns["startdate"].HeaderText = "تاريخ البداية";
            dgv_LastJobs.Columns["startdate"].Width = 100;
            dgv_LastJobs.Columns["startdate"].DisplayIndex = 1;
            dgv_LastJobs.Columns["startdate"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_LastJobs.Columns["startdate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_LastJobs.Columns["enddate"].HeaderText = "تاريخ النهاية";
            dgv_LastJobs.Columns["enddate"].Width = 100;
            dgv_LastJobs.Columns["enddate"].DisplayIndex = 2;
            dgv_LastJobs.Columns["enddate"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_LastJobs.Columns["enddate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_LastJobs.Columns["orgname"].HeaderText = "الجهة";
            dgv_LastJobs.Columns["orgname"].Width = 300;
            dgv_LastJobs.Columns["orgname"].DisplayIndex = 3;
            dgv_LastJobs.Columns["orgname"].DefaultCellStyle.ForeColor = Color.Black;
            dgv_LastJobs.Columns["orgname"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //---------------------------------------------------------------------------------------------
        }
        bool CheckRequiredFields()
        {
            if (string.IsNullOrEmpty(txtfullname.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال اسم المرشح كاملا");
                frm.ShowDialog();
                txtfullname.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txtDOB.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("تاريخ الميلاد خاطئ!");
                frm.ShowDialog();
                txtDOB.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtBirthPlace.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب تحديد مكان الميلاد و عدم تركه فارغاً");
                frm.ShowDialog();
                txtBirthPlace.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال محل الاقامة الحالية");
                frm.ShowDialog();
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtIdNo.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال محل الاقامة الحالية");
                frm.ShowDialog();
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtIdPlace.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال محل الاقامة الحالية");
                frm.ShowDialog();
                txtAddress.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txtIdDate.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("تاريخ اصدار الهوية غير صحيح!");
                frm.ShowDialog();
                txtIdDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtIdPlace.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال مكان اصدار الهوية");
                frm.ShowDialog();
                txtIdPlace.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtJobOrg.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال محل جهة العمل");
                frm.ShowDialog();
                txtJobOrg.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtJob.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال بيانات الوظيفة");
                frm.ShowDialog();
                txtJob.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMobileNo.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال رقم الموبايل");
                frm.ShowDialog();
                txtMobileNo.Focus();
                return false;
            }
            if (coClass.SelectedValue.ToString()==SharedParam.COMPANY_HOLDER_CLASS)
            {
                if (string.IsNullOrEmpty(txtLegalName.Text))
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال الاسم الاعتباري");
                    frm.ShowDialog();
                    txtLegalName.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMainActivity.Text))
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال النشاط الرئيسي");
                    frm.ShowDialog();
                    txtMainActivity.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtLegalForm.Text))
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال الشكل القانوني");
                    frm.ShowDialog();
                    txtLegalForm.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtLicenceNo.Text))
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال رقم السجل التجاري");
                    frm.ShowDialog();
                    txtLicenceNo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtLicencePlace.Text))
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال مكان اصدر السجل التجاري");
                    frm.ShowDialog();
                    txtLicencePlace.Focus();
                    return false;
                }
                if (!Utility.IsValidDate(txtLicenceDate.Text))
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("تاريخ اصدار السجل التجاري غير صحيح!");
                    frm.ShowDialog();
                    txtLicenceDate.Focus();
                    return false;
                }
            }
            for (int i = 0; i < dgv_LastJobs.Rows.Count; ++i)
                {
                    if (!object.ReferenceEquals(dgv_LastJobs["job", i].Value, null) && !string.IsNullOrEmpty(dgv_LastJobs["job", i].Value.ToString()))
                    {
                        if (!Utility.IsValidDate(dgv_LastJobs["startdate", i].Value.ToString())
                            ||
                            !Utility.IsValidDate(dgv_LastJobs["enddate", i].Value.ToString()))
                        {
                            Dialogs.Dg_Error frm = new Dialogs.Dg_Error("تاريخ بداية او نهاية الوظائف التي شغلها"
                                +Environment.NewLine+"المرشح خلال الثلاث السنوات الاخيرة خاطئ "
                                + Environment.NewLine + "يرجى مراجعة التاريخ  والمحاولة لاحقا ");
                            frm.ShowDialog();
                            txtLicenceDate.Focus();
                            return false;
                        }
                    }
                }
               
           
            if (!HasShares())
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("المرشح لا يمتلك شهادات ملكية اسهم");
                frm.ShowDialog();
                dgv_Certs.Focus();
                return false;
            }
            return true;
        }
        bool HasShares()
        {
            int shares = 0;
            int TotalShares = 0;
            try {

                foreach (DataRow dr in dt_CandCerts.Rows)
                {
                    if (int.TryParse(dr["shareqty"].ToString(), out shares))
                    {
                        TotalShares += shares;
                    }
                }
                if (TotalShares > 0)
                { return true; }
                else
                { return false; }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
        private void btn_Commit_Click(object sender, EventArgs e)
        {
            if (Operation_Type == "new")
            {
                
                #region Start Add New Candidate ...

                if (CheckRequiredFields())
                {
                    byte[] picbyte  = new byte[0];
                    if (!string.IsNullOrEmpty(lblpicfullname.Text))
                    {
                        FileStream fs;
                        fs = new FileStream(lblpicfullname.Text, FileMode.Open, FileAccess.Read);
                        //a byte array to read the image
                        picbyte = new byte[fs.Length];
                        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                        fs.Close();
                    }
                    
                    int result = Db.CreateCandidate(coClass.SelectedValue.ToString(), txtfullname.Text, string.Empty, DateTime.Parse(txtDOB.Text)
                        , txtBirthPlace.Text, txtAddress.Text, coIdType.SelectedValue.ToString(), txtIdNo.Text, DateTime.Parse(txtIdDate.Text)
                        , txtIdPlace.Text, txtJobOrg.Text, txtJob.Text, txtMobileNo.Text, txtHomeTel.Text, txtWorkTel.Text
                        , txtFax.Text, txtEmail.Text, txtWebsite.Text, SharedParam.CurrentUser.UserID, txtLegalName.Text
                        , txtMainActivity.Text, txtLegalForm.Text, txtcompanyaddress.Text, txtLicenceNo.Text, string.IsNullOrEmpty(txtLicenceDate.Text) ? DateTime.MinValue : DateTime.Parse(txtLicenceDate.Text)
                        , txtLicencePlace.Text, string.Empty, picbyte,lblPicFileName.Text);
                    if (result > 0)
                    {
                        for (int i = 0; i < dgv_Certs.Rows.Count; ++i)
                        {
                            if (!object.ReferenceEquals(dgv_Certs["shareqty", i].Value, null))
                            {
                                if (!string.IsNullOrEmpty(dgv_Certs["shareqty", i].Value.ToString()))
                                {
                                    Db.InsertCandidateCerts(result, dgv_Certs["certno", i].Value.ToString(), int.Parse(dgv_Certs["shareqty", i].Value.ToString())
                                        , dgv_Certs["holdername", i].Value.ToString(), coClass.SelectedValue.ToString(), string.Empty, coClass.SelectedValue.ToString());
                                }
                            }
                        }
                        for (int i = 0; i < dgv_Qual.Rows.Count; ++i)
                        {
                            if (!object.ReferenceEquals(dgv_Qual["qual", i].Value, null))
                            {
                                if (!string.IsNullOrEmpty(dgv_Qual["qual", i].Value.ToString()))
                                {
                                    Db.InsertCandidateQualification(result, i + 1, dgv_Qual["qual", i].Value.ToString(), coClass.SelectedValue.ToString());
                                }
                            }
                        }
                        for (int i = 0; i < dgv_Exp.Rows.Count; ++i)
                        {
                            if (!object.ReferenceEquals(dgv_Exp["exp", i].Value, null))
                            {
                                if (!string.IsNullOrEmpty(dgv_Exp["exp", i].Value.ToString()))
                                {
                                    Db.InsertCandidateExperience(result, i + 1, dgv_Exp["exp", i].Value.ToString(), coClass.SelectedValue.ToString());
                                }
                            }
                        }
                        for (int i = 0; i < dgv_LastJobs.Rows.Count; ++i)
                        {
                            if (!object.ReferenceEquals(dgv_LastJobs["job", i].Value, null))
                            {
                                if (!string.IsNullOrEmpty(dgv_LastJobs["job", i].Value.ToString()))
                                {
                                    Db.InsertCandidateLastJob(result, i + 1, dgv_LastJobs["job", i].Value.ToString()
                                        , DateTime.Parse(dgv_LastJobs["startdate", i].Value.ToString())
                                        , DateTime.Parse(dgv_LastJobs["enddate", i].Value.ToString())
                                        , dgv_LastJobs["orgname", i].Value.ToString(), coClass.SelectedValue.ToString());
                                }
                            }
                        }
                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم اضافة طلب الترشيح برقم " + result.ToString());
                        frm.ShowDialog();
                        ClearAllData();
                    }
                }
                #endregion
            }

            if (Operation_Type == "edit")
            {
                #region Start Update Candidate ...

                if (CheckRequiredFields())
                {
                    byte[] picbyte = new byte[0]; 
                    if (!string.IsNullOrEmpty(lblpicfullname.Text))
                    {
                        FileStream fs;
                        fs = new FileStream(lblpicfullname.Text, FileMode.Open, FileAccess.Read);
                        //a byte array to read the image
                        picbyte = new byte[fs.Length];
                        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                        fs.Close();
                    }
                    string Msg = "هل تريد بالتأكيد تعديل البيانات؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد التعديل.";
                    if (new Dialogs.Dg_ComfirmMessage("الحفظ", Msg).MessageResult() == DialogResult.Yes)
                    {
                        int result = Db.UpdateCandidate(TargetCanNo, coClass.SelectedValue.ToString(), txtfullname.Text, string.Empty, DateTime.Parse(txtDOB.Text)
                        , txtBirthPlace.Text, txtAddress.Text, coIdType.SelectedValue.ToString(), txtIdNo.Text, DateTime.Parse(txtIdDate.Text)
                        , txtIdPlace.Text, txtJobOrg.Text, txtJob.Text, txtMobileNo.Text, txtHomeTel.Text, txtWorkTel.Text
                        , txtFax.Text, txtEmail.Text, txtWebsite.Text, SharedParam.CurrentUser.UserID, txtLegalName.Text
                        , txtMainActivity.Text, txtLegalForm.Text, txtcompanyaddress.Text, txtLicenceNo.Text, string.IsNullOrEmpty(txtLicenceDate.Text) ? DateTime.MinValue : DateTime.Parse(txtLicenceDate.Text)
                        , txtLicencePlace.Text,string.Empty, picbyte,lblPicFileName.Text);
                        if (result > 0)
                        {
                            int CndNO = 0;
                            if (Operation_Type == "new")
                            {
                                CndNO = result;
                            }
                            else if (Operation_Type == "edit")
                            {
                                CndNO = int.Parse(TargetCanNo);
                            }
                                Db.ExecuteSQLCommand("DELETE FROM candidate_certs where cand_no=" + TargetCanNo +" AND cand_class='"+TargetClass+"'");
                            // Add Candidate's Certificates ...
                            for (int i = 0; i < dgv_Certs.Rows.Count; ++i)
                            {
                                if (!object.ReferenceEquals(dgv_Certs["shareqty", i].Value, null))
                                {
                                    if (!string.IsNullOrEmpty(dgv_Certs["shareqty", i].Value.ToString()))
                                    {
                                            Db.InsertCandidateCerts(CndNO, dgv_Certs["certno", i].Value.ToString(), int.Parse(dgv_Certs["shareqty", i].Value.ToString())
                                                , dgv_Certs["holdername", i].Value.ToString(), coClass.SelectedValue.ToString(), string.Empty, coClass.SelectedValue.ToString());
                                    }
                                }
                            }
                            Db.ExecuteSQLCommand("DELETE FROM candidate_qualification where cand_no=" + TargetCanNo + " AND cand_class='" + TargetClass + "'");
                            // Add Candidate's Qualification ...
                            for (int i = 0; i < dgv_Qual.Rows.Count; ++i)
                            {
                                if (!object.ReferenceEquals(dgv_Qual["qual", i].Value, null))
                                {
                                    if (!string.IsNullOrEmpty(dgv_Qual["qual", i].Value.ToString()))
                                    {
                                        Db.InsertCandidateQualification(CndNO, i + 1, dgv_Qual["qual", i].Value.ToString(), coClass.SelectedValue.ToString());
                                    }
                                }
                            }
                            Db.ExecuteSQLCommand("DELETE FROM candidate_experience where cand_no=" + TargetCanNo + " AND cand_class='" + TargetClass + "'");
                            // Add Candidate's Experiences ...
                            for (int i = 0; i < dgv_Exp.Rows.Count; ++i)
                            {
                                if (!object.ReferenceEquals(dgv_Exp["exp", i].Value, null))
                                {
                                    if (!string.IsNullOrEmpty(dgv_Exp["exp", i].Value.ToString()))
                                    {
                                        Db.InsertCandidateExperience(CndNO, i + 1, dgv_Exp["exp", i].Value.ToString(), coClass.SelectedValue.ToString());
                                    }
                                }
                            }
                            Db.ExecuteSQLCommand("DELETE FROM candidate_lastjobs where cand_no=" + TargetCanNo + " AND cand_class='" + TargetClass + "'");
                            // Add Candidate's Last Jobs ...
                            for (int i = 0; i < dgv_LastJobs.Rows.Count; ++i)
                            {
                                if (!object.ReferenceEquals(dgv_LastJobs["job", i].Value, null))
                                {
                                    if (!string.IsNullOrEmpty(dgv_LastJobs["job", i].Value.ToString()))
                                    {
                                        Db.InsertCandidateLastJob(CndNO, i + 1, dgv_LastJobs["job", i].Value.ToString()
                                            , DateTime.Parse(dgv_LastJobs["startdate", i].Value.ToString())
                                            , DateTime.Parse(dgv_LastJobs["enddate", i].Value.ToString())
                                            , dgv_LastJobs["orgname", i].Value.ToString(), coClass.SelectedValue.ToString());
                                    }
                                }
                            }
                            Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم التعديل بنجاح ");
                            frm.ShowDialog();
                            this.Close();
                            //ClearAllData();
                        }
                    }
                }
                #endregion
            }

        }
        void PopulateIdTypesLists()
        {
            string strsql = "select class_id,class_name from holder_class where has_Candidate=1 order by class_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coClass.DataSource = dt;
                coClass.DisplayMember = "class_name";
                coClass.ValueMember = "class_id";
            }

            strsql = "select id_type,id_type_name,id_order from IDs where attend_allow=1 order by id_order";
             dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coIdType.DataSource = dt;
                coIdType.DisplayMember = "id_type_name";
                coIdType.ValueMember = "id_type";
            }
        }

        private void txtDOB_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidDate(txtDOB.Text))
            {
                txtDOB.ForeColor = Color.Black;
            }
            else
            {
                txtDOB.ForeColor = Color.Red;
            }
        }

        private void txtLicenceDate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidDate(txtLicenceDate.Text))
            {
                txtLicenceDate.ForeColor = Color.Black;
            }
            else
            {
                txtLicenceDate.ForeColor = Color.Red;
            }
        }

        private void txtIdDate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidDate(txtIdDate.Text))
            {
                txtIdDate.ForeColor = Color.Black;
            }
            else
            {
                txtIdDate.ForeColor = Color.Red;
            }
        }

        private void dgv_Certs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Certs.Columns[e.ColumnIndex].Name == "certno")
            {
                if (!object.ReferenceEquals(dgv_Certs["certno", e.RowIndex].Value, null))
                {
                    if (!string.IsNullOrEmpty(dgv_Certs["certno", e.RowIndex].Value.ToString()))
                    {
                        if (dgv_Certs["certno", e.RowIndex].Value.ToString().Length == Config.CertNoLength)
                        {
                            DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "certs", "CertNo", dgv_Certs["certno", e.RowIndex].Value.ToString()
                                , "HolderClass", coClass.SelectedValue.ToString(), "status", "-1");
                            if (dt != null)
                            {
                                if (dt.Rows[0]["status"].ToString() != "5")
                                {
                                    
                                    dgv_Certs["shareqty", e.RowIndex].Value = dt.Rows[0]["share_qty"].ToString();
                                    dgv_Certs["holdername", e.RowIndex].Value = dt.Rows[0]["holder_name"].ToString();
                                    dgv_Certs["classname", e.RowIndex].Value = dt.Rows[0]["class_name"].ToString();
                                    dgv_Certs["classid", e.RowIndex].Value = dt.Rows[0]["holder_class"].ToString();
                                    if (object.ReferenceEquals(dt_CandCerts, null))
                                    {
                                        dt_CandCerts = new DataTable();
                                        dt_CandCerts.Columns.Add("certno");
                                        dt_CandCerts.Columns.Add("shareqty");
                                        dt_CandCerts.Columns.Add("holdername");
                                        dt_CandCerts.Columns.Add("classname");
                                        dt_CandCerts.Columns.Add("classid");
                                    }
                                    dt_CandCerts.Rows.Add(dt.Rows[0]["cert_no"].ToString()
                                        , dt.Rows[0]["share_qty"].ToString()
                                        , dt.Rows[0]["holder_name"].ToString()
                                        , dt.Rows[0]["class_name"].ToString()
                                        , dt.Rows[0]["holder_class"].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dgv_Certs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgv_Certs["certno", e.RowIndex].Value.ToString()))
            {
                dgv_Certs["shareqty", e.RowIndex].Value = string.Empty;
                dgv_Certs["holdername", e.RowIndex].Value = string.Empty;
                dgv_Certs["classname", e.RowIndex].Value = string.Empty;
                dgv_Certs["classid", e.RowIndex].Value = string.Empty;
            }
        }

        private void cand_pic_Click(object sender, EventArgs e)
        {
            if (Operation_Type != "query")
            {
                imageOpenDialog.Filter = "Image Files(*.png;*.jpg; *.jpeg; *.gif; *.bmp)|*.png;*.jpg; *.jpeg; *.gif; *.bmp";
                if (imageOpenDialog.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    cand_pic.Image = new Bitmap(imageOpenDialog.FileName);
                    // image file path
                    lblPicFileName.Text = Path.GetFileName(imageOpenDialog.FileName);
                    lblpicfullname.Text = imageOpenDialog.FileName;
                }
            }

        }

        private void txtCandNo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode==Keys.Enter && !string.IsNullOrEmpty(txtCandNo.Text) && Operation_Type=="edit")
            //{
            //    TargetCanNo = txtCandNo.Text;
            //    ClearAllData();
            //    LoadCandidateData(TargetCanNo);
            //}
        }

        private void btn_changepic_Click(object sender, EventArgs e)
        {
            cand_pic_Click(sender, e);
        }

        private void txtCandNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utility.OnlyNumber(e.KeyChar, false, sender);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 4, 2, "Allow_Delete_Candidate"))
            {
                if (Operation_Type == "edit")
                {
                    string Msg = "هل تريد بالتأكيد حذف البيانات؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع عن الحذف.";
                    if (new Dialogs.Dg_ComfirmMessage("حذف", Msg).MessageResult() == DialogResult.Yes)
                    {
                        string CurrentStatus = Db.GetFieldData("status"
                            , "select status from candidate where cand_no=@candno", "candno", string.IsNullOrEmpty(TargetCanNo) ? "0" : TargetCanNo);
                        if (!string.IsNullOrEmpty(CurrentStatus))
                        {
                            if (CurrentStatus == "request")
                            {
                                if (Db.ExecuteSQLCommand("DELETE FROM candidate where cand_no=" + TargetCanNo + " AND cand_class='" + TargetClass + "'"))
                                {
                                    Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم الحذف بنجاح ");
                                    frm.ShowDialog();
                                    ClearAllData();
                                }
                            }
                            else
                            {
                                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("لا يمكن حذف المرشح الحالي بسبب حالته ");
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
            else
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("ليس لديك الصلاحية الكافية");
                frm.ShowDialog();
            }
           
        }

        private void btn_deletepic_Click(object sender, EventArgs e)
        {
            if (Operation_Type != "query")
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NewCandidate));
                this.cand_pic.Image = ((System.Drawing.Image)(resources.GetObject("cand_pic.Image")));
                lblPicFileName.Text = string.Empty;
                lblpicfullname.Text = string.Empty;
            }
        }

        private void txt_Q_CertNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Q_Next_Click(object sender, EventArgs e)
        {

        }

       
    }
}

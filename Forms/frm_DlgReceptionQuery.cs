using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_DlgReceptionQuery : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private string QuerySource = "pending";

        public frm_DlgReceptionQuery()
        {
            InitializeComponent();
   
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_DlgReceptionQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.F9)
            {
                btn_Query_Click(sender, e);
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

        private void frm_DlgReceptionQuery_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
        }

        private void chOnlyMine_CheckedChanged(object sender, EventArgs e)
        {
            if (chOnlyMine.Checked)
            {
                chOnlyMine.ForeColor = Color.Blue;
            }
            else
            {
                chOnlyMine.ForeColor = Color.Black;
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            dgv_Reception.DataSource = null;
            dgv_ReceptionDetails.DataSource = null;
            txtTotalReceptionRows.Text = "0";
            txtTotalReceptionDetailsRows.Text = "0";
            txtTotalShares.Text = "0";
            string WhereClause = string.Empty;
            List<string> parameters = new List<string>();
            #region Build Where Clause ...
            if (!string.IsNullOrEmpty(txtEntryDocNo.Text))
            {
                WhereClause = " WHERE Entry_doc_no=@entrydocno";
                parameters.Add("entrydocno");
                parameters.Add(txtEntryDocNo.Text);
            }
            
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE TotalSharesQty>0 ";
                }
                else
                {
                    WhereClause += " AND  TotalSharesQty>0 ";
                }

            if (!string.IsNullOrEmpty(txtCardNo.Text))
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE Entry_card_no=@entrycardno";
                    parameters.Add("entrycardno");
                    parameters.Add(txtCardNo.Text);
                }
                else
                {
                    WhereClause += " AND Entry_card_no=@entrycardno";
                    parameters.Add("entrycardno");
                    parameters.Add(txtCardNo.Text);
                }
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE holder_name=@holdername";
                    parameters.Add("holdername");
                    parameters.Add(txtName.Text);
                }
                else
                {
                    WhereClause += " AND holder_name like '%' + @holdername + '%'";
                    parameters.Add("holdername");
                    parameters.Add(txtName.Text);
                }
            }
            if (coDataType.SelectedValue.ToString() != "all")
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE reception_type=@receptiontype";
                    parameters.Add("receptiontype");
                    parameters.Add(coDataType.SelectedValue.ToString());
                }
                else
                {
                    WhereClause += " AND reception_type=@receptiontype";
                    parameters.Add("receptiontype");
                    parameters.Add(coDataType.SelectedValue.ToString());
                }
            }

            if (chOnlyMine.Checked)
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE userid=@userid";
                    parameters.Add("userid");
                    parameters.Add(SharedParam.CurrentUser.UserID);
                }
                else
                {
                    WhereClause += " AND userid=@userid";
                    parameters.Add("userid");
                    parameters.Add(SharedParam.CurrentUser.UserID);
                }
            }

            if (!string.IsNullOrEmpty(txtCertNo.Text))
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE @certno IN (SELECT cert_no from "+ (QuerySource == "pending" ? "DlgReception_Details" : "Reception_Details")  
                        +" where "+ (QuerySource == "pending" ? "DlgReception_Details.Entry_doc_no=v_DlgReception.Entry_doc_no" : "Reception_Details.Entry_doc_no=v_Reception.Entry_doc_no")  + ")";
                    parameters.Add("certno");
                    parameters.Add(txtCertNo.Text);
                }
                else
                {
                    WhereClause += " AND @certno IN (SELECT cert_no from "+ (QuerySource == "pending" ? "DlgReception_Details" : "Reception_Details") 
                        + " where "+(QuerySource == "pending" ? "DlgReception_Details.Entry_doc_no=v_DlgReception.Entry_doc_no" : "Reception_Details.Entry_doc_no=v_Reception.Entry_doc_no") +")";
                    parameters.Add("certno");
                    parameters.Add(txtCertNo.Text);
                }
            }
            string strsql = "SELECT TOP 300 [Entry_doc_no],[Entry_date],[holder_name],[TotalSharesQty],[TotalHolderSharesQty],[TotalHolderDelagateSharesQty]+[TotalOrgDelegateSharesQty] as TotalDelagateSharesQty,[entry_card_no],[holder_class_name]"
                     + ",[id_type_name],[id_no],[id_date],[id_place],[username],[status_name],[statustime],[postusername],[status],[holder_class],[userid],[reception_type]"
                     +(QuerySource == "pending" ? ", Rec_Doc_No" : "")
                     + " FROM  " + (QuerySource == "pending" ? " [dbo].[v_DlgReception] " : " [dbo].[v_Reception] ")
                     + WhereClause;
            #endregion
            if (object.ReferenceEquals(parameters,null))
              {
                DataTable dt = Db.GetDataAsDataTable(strsql);
                dgv_Reception.DataSource = dt;
                PrepareReceptionGrid();
            }
            else
            {
                DataTable dt = Db.GetDataAsDataTable(strsql, parameters.ToArray());
                dgv_Reception.DataSource = dt;
                PrepareReceptionGrid();
            }
         }
        private void PrepareReceptionGrid()
        {
            try
            {
                dgv_Reception.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Reception.Columns["Entry_doc_no"].HeaderText = "رقم الحضور";
                dgv_Reception.Columns["Entry_doc_no"].Width = 80;
                dgv_Reception.Columns["Entry_doc_no"].DisplayIndex = 0;
                dgv_Reception.Columns["Entry_doc_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["Entry_doc_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["Entry_date"].HeaderText = "وقت الحضور";
                dgv_Reception.Columns["Entry_date"].Width = 140;
                dgv_Reception.Columns["Entry_date"].DisplayIndex = 1;
                dgv_Reception.Columns["Entry_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["Entry_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["holder_name"].HeaderText = "اسم المساهم";
                dgv_Reception.Columns["holder_name"].Width = 230;
                dgv_Reception.Columns["holder_name"].DisplayIndex = 2;
                dgv_Reception.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_Reception.Columns["entry_card_no"].HeaderText = "رقم الكرت";
                dgv_Reception.Columns["entry_card_no"].Width = 60;
                dgv_Reception.Columns["entry_card_no"].DisplayIndex = 3;
                dgv_Reception.Columns["entry_card_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["entry_card_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["holder_class_name"].HeaderText = "الـفـئـة";
                dgv_Reception.Columns["holder_class_name"].Width = 100;
                dgv_Reception.Columns["holder_class_name"].DisplayIndex = 4;
                dgv_Reception.Columns["holder_class_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["holder_class_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_type_name"].HeaderText = "نوع الهوية";
                dgv_Reception.Columns["id_type_name"].Width = 100;
                dgv_Reception.Columns["id_type_name"].DisplayIndex = 12;
                dgv_Reception.Columns["id_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_no"].HeaderText = "رقم الهوية";
                dgv_Reception.Columns["id_no"].Width = 100;
                dgv_Reception.Columns["id_no"].DisplayIndex = 13;
                dgv_Reception.Columns["id_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_date"].HeaderText = "تاريخ الهوية";
                dgv_Reception.Columns["id_date"].Width = 100;
                dgv_Reception.Columns["id_date"].DisplayIndex = 14;
                dgv_Reception.Columns["id_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_place"].HeaderText = "مكان الهوية";
                dgv_Reception.Columns["id_place"].Width = 100;
                dgv_Reception.Columns["id_place"].DisplayIndex = 15;
                dgv_Reception.Columns["id_place"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_place"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["TotalSharesQty"].HeaderText = "عدد الاسهم";
                dgv_Reception.Columns["TotalSharesQty"].Width = 70;
                dgv_Reception.Columns["TotalSharesQty"].DisplayIndex = 5;
                dgv_Reception.Columns["TotalSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["TotalSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["TotalHolderSharesQty"].HeaderText = "عدد الاسهم المالك لها";
                dgv_Reception.Columns["TotalHolderSharesQty"].Width = 70;
                dgv_Reception.Columns["TotalHolderSharesQty"].DisplayIndex = 6;
                dgv_Reception.Columns["TotalHolderSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["TotalHolderSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["TotalDelagateSharesQty"].HeaderText = "عدد الاسهم الموكل بها";
                dgv_Reception.Columns["TotalDelagateSharesQty"].Width = 70;
                dgv_Reception.Columns["TotalDelagateSharesQty"].DisplayIndex = 7;
                dgv_Reception.Columns["TotalDelagateSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["TotalDelagateSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["username"].HeaderText = "المستخدم";
                dgv_Reception.Columns["username"].Width = 120;
                dgv_Reception.Columns["username"].DisplayIndex = 8;
                dgv_Reception.Columns["username"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_Reception.Columns["status_name"].HeaderText = "الحالة";
                dgv_Reception.Columns["status_name"].Width = 100;
                dgv_Reception.Columns["status_name"].DisplayIndex = 9;
                dgv_Reception.Columns["status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["Rec_Doc_No"].HeaderText = "مرحل برقم";
                dgv_Reception.Columns["Rec_Doc_No"].Width = 60;
                dgv_Reception.Columns["Rec_Doc_No"].DisplayIndex = 9;
                dgv_Reception.Columns["Rec_Doc_No"].DefaultCellStyle.ForeColor = Color.Blue;
                dgv_Reception.Columns["Rec_Doc_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["statustime"].HeaderText = "تاريخ الحالة";
                dgv_Reception.Columns["statustime"].Width = 130;
                dgv_Reception.Columns["statustime"].DisplayIndex = 10;
                dgv_Reception.Columns["statustime"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["statustime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["postusername"].HeaderText = "مستخدم الحالة";
                dgv_Reception.Columns["postusername"].Width = 130;
                dgv_Reception.Columns["postusername"].DisplayIndex = 11;
                dgv_Reception.Columns["postusername"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["postusername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Reception.Columns["status"].Visible = false;
                dgv_Reception.Columns["holder_class"].Visible = false;
                dgv_Reception.Columns["userid"].Visible = false;
                dgv_Reception.Columns["reception_type"].Visible = false;
                txtTotalReceptionRows.Text = dgv_Reception.RowCount.ToString();
            }
            catch
            {
                txtTotalReceptionRows.Text = "0";
            }
        }
        private void dgv_Reception_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string strsql= "SELECT [line_no],[cert_no],[holder_name],[share_qty],[holder_class_name],[Delagate],[Dlg_Name],[Dlg_no]"
                           + "   ,[Dlg_date],[Approved_no],[Approved_date],[Approved_org],[Delegate_Type_Name],[reception_type_name],[username]"
                           + (QuerySource == "pending" ? ", DuplicateCount" : "")
                          + " FROM  " + (QuerySource == "pending" ? "[dbo].[v_DlgReception_Details]" : "[dbo].[v_Reception_Details]")
                          + " WHERE entry_doc_no=" + dgv_Reception["Entry_doc_no", e.RowIndex].Value.ToString()
                          + " order by [line_no]";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            dgv_ReceptionDetails.DataSource = dt;
            PrepareReceptionDetailsGrid();

            // -------------------------------------------------------

            dgv_Print.DataSource = null;
            string WhereClause = string.Empty;
            List<string> parameters = new List<string>();
            #region Build Where Clause ...
            WhereClause = " WHERE document_type='entry'  AND [document_no]=@document  ";
            parameters.Add("document");
            parameters.Add(dgv_Reception["Entry_doc_no", e.RowIndex].Value.ToString());
            #endregion
             strsql = "SELECT TOP 1000 [document_no],[document_type_name],[print_type_name],[print_time],[printusername],[print_reason]"
                            + "  ,[reason],[CertsCount],[TotalSharesQty],[holder_name],[Entry_date],[DetailsClassName]"
                            + "  ,[receptionusername],[reception_type_name],[PrintRowId],[DetailsClass]"
                            + " FROM [dbo].[v_Print_Reception]  "
                            + WhereClause;
            if (object.ReferenceEquals(parameters, null))
            {
                dt = Db.GetDataAsDataTable(strsql);
                dgv_Print.DataSource = dt;
                PreparePrintGrid();
            }
            else
            {
                dt = Db.GetDataAsDataTable(strsql, parameters.ToArray());
                dgv_Print.DataSource = dt;
                PreparePrintGrid();
            }
        }
        private void PreparePrintGrid()
        {
            try
            {
                dgv_Print.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["document_no"].HeaderText = "رقم الحضور";
                dgv_Print.Columns["document_no"].Width = 50;
                dgv_Print.Columns["document_no"].DisplayIndex = 0;
                dgv_Print.Columns["document_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["document_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["document_type_name"].HeaderText = "النـــوع";
                dgv_Print.Columns["document_type_name"].Width = 100;
                dgv_Print.Columns["document_type_name"].DisplayIndex = 1;
                dgv_Print.Columns["document_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["document_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["print_type_name"].HeaderText = "نوع الطباعة";
                dgv_Print.Columns["print_type_name"].Width = 100;
                dgv_Print.Columns["print_type_name"].DisplayIndex = 2;
                dgv_Print.Columns["print_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["print_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["print_time"].HeaderText = "تاريخ الطباعة";
                dgv_Print.Columns["print_time"].Width = 144;
                dgv_Print.Columns["print_time"].DisplayIndex = 3;
                dgv_Print.Columns["print_time"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["print_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["printusername"].HeaderText = "المستخدم";
                dgv_Print.Columns["printusername"].Width = 130;
                dgv_Print.Columns["printusername"].DisplayIndex = 4;
                dgv_Print.Columns["printusername"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["printusername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["print_reason"].HeaderText = "السبب";
                dgv_Print.Columns["print_reason"].Width = 140;
                dgv_Print.Columns["print_reason"].DisplayIndex = 5;
                dgv_Print.Columns["print_reason"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["print_reason"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["reason"].HeaderText = "سبب اخر";
                dgv_Print.Columns["reason"].Width = 170;
                dgv_Print.Columns["reason"].DisplayIndex = 6;
                dgv_Print.Columns["reason"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["reason"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["CertsCount"].HeaderText = "عدد الشهادات";
                dgv_Print.Columns["CertsCount"].Width = 80;
                dgv_Print.Columns["CertsCount"].DisplayIndex = 7;
                dgv_Print.Columns["CertsCount"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["CertsCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["TotalSharesQty"].HeaderText = "عدد الاسهم";
                dgv_Print.Columns["TotalSharesQty"].Width = 80;
                dgv_Print.Columns["TotalSharesQty"].DisplayIndex = 8;
                dgv_Print.Columns["TotalSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["TotalSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["holder_name"].HeaderText = "الاســـــــم";
                dgv_Print.Columns["holder_name"].Width = 200;
                dgv_Print.Columns["holder_name"].DisplayIndex = 9;
                dgv_Print.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["Entry_date"].HeaderText = "تاريخ الحضور";
                dgv_Print.Columns["Entry_date"].Width = 130;
                dgv_Print.Columns["Entry_date"].DisplayIndex = 10;
                dgv_Print.Columns["Entry_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["Entry_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["DetailsClassName"].HeaderText = "الـفـئــة";
                dgv_Print.Columns["DetailsClassName"].Width = 100;
                dgv_Print.Columns["DetailsClassName"].DisplayIndex = 11;
                dgv_Print.Columns["DetailsClassName"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["DetailsClassName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Print.Columns["receptionusername"].HeaderText = "مستخدم الحضور";
                dgv_Print.Columns["receptionusername"].Width = 100;
                dgv_Print.Columns["receptionusername"].DisplayIndex = 12;
                dgv_Print.Columns["receptionusername"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["receptionusername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Print.Columns["reception_type_name"].HeaderText = "نوع التمثيل";
                dgv_Print.Columns["reception_type_name"].Width = 130;
                dgv_Print.Columns["reception_type_name"].DisplayIndex = 12;
                dgv_Print.Columns["reception_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Print.Columns["reception_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_Print.Columns["PrintRowId"].Visible = false;
                dgv_Print.Columns["DetailsClass"].Visible = false;
            }
            catch
            {
            }
        }


        private void PrepareReceptionDetailsGrid()
        {
            try
            {
                dgv_ReceptionDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_ReceptionDetails.Columns["line_no"].HeaderText = "م";
                dgv_ReceptionDetails.Columns["line_no"].Width = 30;
                dgv_ReceptionDetails.Columns["line_no"].DisplayIndex = 0;
                dgv_ReceptionDetails.Columns["line_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["line_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["cert_no"].HeaderText = "رقم الشهادة";
                dgv_ReceptionDetails.Columns["cert_no"].Width = 100;
                dgv_ReceptionDetails.Columns["cert_no"].DisplayIndex = 1;
                dgv_ReceptionDetails.Columns["cert_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["cert_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["holder_name"].HeaderText = "اسم المساهم";
                dgv_ReceptionDetails.Columns["holder_name"].Width = 230;
                dgv_ReceptionDetails.Columns["holder_name"].DisplayIndex = 2;
                dgv_ReceptionDetails.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_ReceptionDetails.Columns["share_qty"].HeaderText = "عدد الاسهم";
                dgv_ReceptionDetails.Columns["share_qty"].Width = 80;
                dgv_ReceptionDetails.Columns["share_qty"].DisplayIndex = 3;
                dgv_ReceptionDetails.Columns["share_qty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["share_qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["Delagate"].HeaderText = "وكالة";
                dgv_ReceptionDetails.Columns["Delagate"].Width = 40;
                dgv_ReceptionDetails.Columns["Delagate"].DisplayIndex = 5;
                dgv_ReceptionDetails.Columns["Delagate"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Delagate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["holder_class_name"].HeaderText = "الـفـئـة";
                dgv_ReceptionDetails.Columns["holder_class_name"].Width = 100;
                dgv_ReceptionDetails.Columns["holder_class_name"].DisplayIndex = 4;
                dgv_ReceptionDetails.Columns["holder_class_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["holder_class_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["Dlg_Name"].HeaderText = "اسم الوكيل";
                dgv_ReceptionDetails.Columns["Dlg_Name"].Width = 200;
                dgv_ReceptionDetails.Columns["Dlg_Name"].DisplayIndex = 6;
                dgv_ReceptionDetails.Columns["Dlg_Name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Dlg_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_ReceptionDetails.Columns["Dlg_no"].HeaderText = "رقم التوكيل";
                dgv_ReceptionDetails.Columns["Dlg_no"].Width = 80;
                dgv_ReceptionDetails.Columns["Dlg_no"].DisplayIndex = 7;
                dgv_ReceptionDetails.Columns["Dlg_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Dlg_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["Dlg_date"].HeaderText = "تاريخ التوكيل";
                dgv_ReceptionDetails.Columns["Dlg_date"].Width = 100;
                dgv_ReceptionDetails.Columns["Dlg_date"].DisplayIndex = 8;
                dgv_ReceptionDetails.Columns["Dlg_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Dlg_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["Approved_no"].HeaderText = "رقم الاعتماد";
                dgv_ReceptionDetails.Columns["Approved_no"].Width = 70;
                dgv_ReceptionDetails.Columns["Approved_no"].DisplayIndex = 10;
                dgv_ReceptionDetails.Columns["Approved_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Approved_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["Approved_date"].HeaderText = "تاريخ الاعتماد";
                dgv_ReceptionDetails.Columns["Approved_date"].Width = 100;
                dgv_ReceptionDetails.Columns["Approved_date"].DisplayIndex = 11;
                dgv_ReceptionDetails.Columns["Approved_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Approved_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_ReceptionDetails.Columns["Approved_org"].HeaderText = "جهة الاعتماد";
                dgv_ReceptionDetails.Columns["Approved_org"].Width = 120;
                dgv_ReceptionDetails.Columns["Approved_org"].DisplayIndex = 12;
                dgv_ReceptionDetails.Columns["Approved_org"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Approved_org"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_ReceptionDetails.Columns["Delegate_Type_Name"].HeaderText = "نوع التفويض";
                dgv_ReceptionDetails.Columns["Delegate_Type_Name"].Width = 80;
                dgv_ReceptionDetails.Columns["Delegate_Type_Name"].DisplayIndex = 9;
                dgv_ReceptionDetails.Columns["Delegate_Type_Name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["Delegate_Type_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_ReceptionDetails.Columns["reception_type_name"].HeaderText = "نوع التمثيل";
                dgv_ReceptionDetails.Columns["reception_type_name"].Width = 140;
                dgv_ReceptionDetails.Columns["reception_type_name"].DisplayIndex = 13;
                dgv_ReceptionDetails.Columns["reception_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["reception_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_ReceptionDetails.Columns["username"].HeaderText = "المستخدم";
                dgv_ReceptionDetails.Columns["username"].Width = 100;
                dgv_ReceptionDetails.Columns["username"].DisplayIndex = 14;
                dgv_ReceptionDetails.Columns["username"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_ReceptionDetails.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                if (dgv_ReceptionDetails.Columns["DuplicateCount"] != null)
                {
                    dgv_ReceptionDetails.Columns["DuplicateCount"].HeaderText = "التكرار";
                    dgv_ReceptionDetails.Columns["DuplicateCount"].Width = 80;
                    dgv_ReceptionDetails.Columns["DuplicateCount"].DisplayIndex = 9;
                    dgv_ReceptionDetails.Columns["DuplicateCount"].DefaultCellStyle.ForeColor = Color.Red;
                    dgv_ReceptionDetails.Columns["DuplicateCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                
                txtTotalReceptionDetailsRows.Text = dgv_ReceptionDetails.RowCount.ToString();
                int totalshares = 0;
                for (int i=0;i<dgv_ReceptionDetails.Rows.Count;++i)
                {
                    totalshares +=(int) dgv_ReceptionDetails["share_qty", i].Value;
                }
                txtTotalShares.Text = totalshares.ToString("N0");
            }
            catch (Exception ex)
            {
                txtTotalReceptionDetailsRows.Text = "0";
                txtTotalShares.Text = "0";
            }
        }
        void PopulateIdTypesLists()
        {
            string strsql = "SELECT 'all' reception_type_id,N'الكل' reception_type_name "
                            + "    UNION ALL "
                            + "    SELECT[reception_type_id],[reception_type_name]"
                            + "    FROM[dbo].[reception_type]";
        DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coDataType.DataSource = dt;
                coDataType.DisplayMember = "reception_type_name";
                coDataType.ValueMember = "reception_type_id";
            }
        }

        private void btn_reprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Config.PrintAdmissionDocument && Db.GetPrinterName(Utility.GetMACAddress()) == "N/A")
                {
                    MessageBox.Show("لم يتم تحديد الطابعة التي سيتم عبرها طباعة بطاقة الدخول", "خطأ"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                }
                else
                {
                    if (Config.PrintAdmissionDocument)
                    {
                        if (dgv_Reception["reception_type", dgv_Reception.CurrentRow.Index].Value.ToString() == "Holder"
                            || dgv_Reception["reception_type", dgv_Reception.CurrentRow.Index].Value.ToString() == "OrgDelegate")
                        {
                            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 1, 3, "ReprintEntryDoc"))
                            {
                                if (dgv_Reception["status", dgv_Reception.CurrentRow.Index].Value.ToString() == "post")
                                {
                                    frm_PrintVote frm = new frm_PrintVote("reprint", dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString(), "entry");
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("يجب اولا اعتماد بطاقة الدخول قبل طباعتها");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("ليس لديك الصلاحية الكافية");
                                return;
                            }
                        }
                        else if (dgv_Reception["reception_type", dgv_Reception.CurrentRow.Index].Value.ToString() == "HolderDelagate")
                        {
                            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 2, 5, "ReprintEntryDoc"))
                            {
                                if (dgv_Reception["status", dgv_Reception.CurrentRow.Index].Value.ToString() == "post")
                                {
                                    frm_PrintVote frm = new frm_PrintVote("reprint", dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString(), "entry");
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("يجب اولا اعتماد بطاقة الدخول قبل طباعتها");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("ليس لديك الصلاحية الكافية");
                                return;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("بحسب اعدادات النظام تم حظر طباعة بطاقة الدخول");
                        return;
                    }
                } // Check Printer ...
            }
            catch
            { }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Db.HasRight(SharedParam.CurrentUser.RoleId, 2, 5, "PrintAgentPreviewReport"))
                {
                    //ReportParameter[] ReportParams = new ReportParameter[]
                    //                   {
                    //                    new ReportParameter("EventDate",Config.EventDate),
                    //                    new ReportParameter("title",Config.EventName),
                    //                   };
                    frm_Report frm = new frm_Report();
                    if (QuerySource == "pending")
                    {
                        frm.PreviewEntireDlgReceptionInfoReport(dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString(), null);
                    }
                    else
                    {
                        frm.PreviewEntireReceptionInfoReport(dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString(), null);
                    }
                    
                }
                else
                {
                    MessageBox.Show("ليس لديك الصلاحية الكافية");
                    return;
                }
            }
            catch
            { }
            
        }

        private void dgv_Reception_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgv_Reception.Columns[e.ColumnIndex].Name == "TotalSharesQty" 
                    || dgv_Reception.Columns[e.ColumnIndex].Name == "TotalHolderSharesQty"
                    || dgv_Reception.Columns[e.ColumnIndex].Name == "TotalDelagateSharesQty")
                {
                    double tmp = double.Parse(e.Value.ToString());
                    e.Value = tmp.ToString("N0");
                }
                //if (e.ColumnIndex == 6)
                //{
                //    DateTime tmp = DateTime.Parse(e.Value.ToString());
                //    e.Value = tmp.ToString("dd/MM/yyyy HH:mm:ss");
                //}
            }
            catch (FormatException) { }
        }

        private void dgv_Reception_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name== "TotalSharesQty")
            {
                e.Column.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            }
            else if (e.Column.Name == "TotalHolderSharesQty")
            {
                e.Column.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
            }
            else if (e.Column.Name == "TotalDelagateSharesQty")
            {
                e.Column.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
            }
        }

        private void dgv_ReceptionDetails_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //if (e.Column.Name == "Delagate")
            //{
            //    e.Column.DefaultCellStyle.BackColor = Color.Navy;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Yellow;
            //    //e.Column.DefaultCellStyle.Font.Bold=true;
            //}
            //else if (e.Column.Name == "Dlg_Name")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
            //else if (e.Column.Name == "Delegate_Type_Name")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
            //else if (e.Column.Name == "Dlg_no")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
            //else if (e.Column.Name == "Dlg_date")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
            //else if (e.Column.Name == "Approved_no")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
            //else if (e.Column.Name == "Approved_date")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
            //else if (e.Column.Name == "Approved_org")
            //{
            //    //e.Column.DefaultCellStyle.BackColor = Color.Gold;
            //    e.Column.DefaultCellStyle.ForeColor = Color.Blue;
            //}
        }

        private void dgv_ReceptionDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try {
            //    if (dgv_ReceptionDetails.Columns[e.ColumnIndex].Name == "Dlg_date")
            //    {
            //        if (DateTime.Parse(e.Value.ToString()).Equals(DateTime.MinValue))
            //        {
            //            e.Value = string.Empty;
            //        }
            //    }
            //}
            //catch
            //{ }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Db.HasRight(SharedParam.CurrentUser.RoleId, 2, 5, "Allow_Edit_AnyDoc") ||
                    dgv_Reception["userid", dgv_Reception.CurrentRow.Index].Value.ToString() == SharedParam.CurrentUser.UserID)
                {
                    if (dgv_Reception["status", dgv_Reception.CurrentRow.Index].Value.ToString() == "pending")
                    {
                        if (!Db.HasRight(SharedParam.CurrentUser.RoleId, 2, 5, "Allow_Edit"))
                        {
                            string msg = "ليس لديك الصلاحية الكافية";
                            MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        }
                        else
                        {
                            string DetailsClass = Db.GetDlgHolderDetailsClass(dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString());
                            if (DetailsClass != "N/A")
                            {
                                if (DetailsClass == SharedParam.SINGLE_HOLDER_CLASS
                                    && SharedParam.CurrentUser.HasSingleHolderClass)
                                {
                                    frm_DlgReception frm = new frm_DlgReception(SharedParam.SINGLE_HOLDER_CLASS, "edit", dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString());
                                    frm.ShowDialog();
                                }
                                else if (DetailsClass == SharedParam.EMPLOYEE_HOLDER_CLASS
                                    && SharedParam.CurrentUser.HasEmployeeHolderClass)
                                {
                                    frm_DlgReception frm = new frm_DlgReception(SharedParam.EMPLOYEE_HOLDER_CLASS, "edit", dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString());
                                    frm.ShowDialog();
                                }
                                else if (DetailsClass == SharedParam.COMPANY_HOLDER_CLASS
                                    && SharedParam.CurrentUser.HasCompanyHolderClass)
                                { }
                                else if (DetailsClass == SharedParam.FOUNDER_HOLDER_CLASS
                                    && SharedParam.CurrentUser.HasFounderHolderClass)
                                { }
                                else
                                {
                                    string msg = "ليس لديك الصلاحية للتعامل مع بيانات المساهمين من فئة " + dgv_Reception["holder_class_name", dgv_Reception.CurrentRow.Index].Value.ToString();
                                    MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                }
                            }
                            else
                            {
                                string msg = "لا توجد بيانات تفصيلية لهذه البطاقة ";
                                MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            }
                        }
                    } // if status = pending
                    else
                    {
                        string msg = " لا يمكن تعديل بيانات بطاقة الحضور بعد اعتمادها " ;
                        MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                } // if the same user
                else
                {
                    string msg = "بطاقة الحضور المختارة تم انشائها من قبل مستخدم آخر" + Environment.NewLine
                        + "المستخدم "+dgv_Reception["username", dgv_Reception.CurrentRow.Index].Value.ToString() + Environment.NewLine
                        + " هو المخول فقط بتعديل بيانات هذه البطاقة " ;
                    MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
            }
            catch
            { }
        }

        private void btnAgentAdmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Db.HasRight(SharedParam.CurrentUser.RoleId, 2, 5, "PrintAgentAdmitReport"))
                {
                    string EntryDocNo = dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString();
                    string ReportTitle = string.Empty;
                    string ReportBegin = string.Empty;
                    string ReportEnd = string.Empty;
                    DataTable dt = Db.GetDataAsDataTable("SELECT * FROM "+(QuerySource == "pending" ? "[dbo].[v_DlgReception]" : "[dbo].[v_Reception]") + " WHERE [Entry_doc_no]=" + EntryDocNo);
                    if (dt != null)
                    {
                        DataTable dt2 = Db.GetDataAsDataTable("SELECT TOP 1 [holder_class_name] FROM "
                            + (QuerySource == "pending" ? "[dbo].[v_DlgReception_Details]" : "[dbo].[v_Reception_Details]") +" WHERE [Entry_doc_no]=" + EntryDocNo);
                        if (dt2 != null)
                        {
                            ReportTitle = "إستمارة تحديد الاسهم لمساهم بالاصالة و الانابة من فئة (" + dt2.Rows[0]["holder_class_name"].ToString() +")"+ Environment.NewLine
                                + "للمشاركة في "+ Config.EventName;
                            ReportBegin = @"حضر لدى اللجنة /" + dt.Rows[0]["holder_name"].ToString() + @"/"
                                        + " يحمل وثيقة اثبات الهوية نوعها (" + dt.Rows[0]["id_type_name"].ToString()+")"
                                        + " رقمها (" + dt.Rows[0]["id_no"].ToString() + ") تاريخها (" + (Utility.IsValidDate(dt.Rows[0]["id_date"].ToString())?DateTime.Parse(dt.Rows[0]["id_date"].ToString()).ToString("dd/MM/yyyy"):string.Empty)+")"
                                        + " صادرة من (" + dt.Rows[0]["id_place"].ToString() + ") وهو من مساهمي فئة (" + dt.Rows[0]["holder_class_name"].ToString()+")"
                                        + " و يمتلك عدد (" + dt.Rows[0]["share_qty"].ToString() + ") سهما مسجلة لدى الشركة برقم (" + dt.Rows[0]["Cert_No"].ToString()+")"
                                        + " ووكيلا عن الاخوة المساهمين الواردة اسماؤهم و اسهمهم في وثائق التوكيلات المحررة للوكيل المبينة في الجدول التالي :";
                            ReportEnd = "تم تحرير هذه الاستمارة لتحديد إجمالي الاسهم المملوكة للمساهم (الوكيل) و المساهمين (" + dt2.Rows[0]["holder_class_name"].ToString() + ") الواردة اسماؤهم في وثائق التوكيلات المذكورة اعلاه ليتم بموجبها منحة "
                                + "بطاقة المشاركة نموذج رقم (8/1) بجميع فعاليات الاجتماع التاسع للجميعة العامة العادية المقرر عقده يوم _______ الموافق :   /   /2016م في "
                                + " ...................................... الكائنة ......................................  بصنعاء ";
                            ReportParameter[] ReportParams = new ReportParameter[]
                                               {
                                        new ReportParameter("ReportTitle",ReportTitle),
                                        new ReportParameter("ReportBegin",ReportBegin),
                                        new ReportParameter("EntryNo",EntryDocNo),
                                        new ReportParameter("ReportEnd",ReportEnd)
                                               };
                            frm_Report frm = new frm_Report();
                            frm.PreviewAgentAdmit(EntryDocNo, ReportParams);
                        }
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك الصلاحية الكافية");
                    return;
                }
            }
            catch
            { }
        }

        private void chQuerySource_CheckedChanged(object sender, EventArgs e)
        {
            if (chQuerySource.Checked)
            {
                chQuerySource.ForeColor = Color.Blue;
                QuerySource = "pending";
                btn_reprint.Visible = false;
            }
            else
            {
                chQuerySource.ForeColor = Color.Black;
                QuerySource = "post";
                btn_reprint.Visible = true;
            }
        }
    }
}

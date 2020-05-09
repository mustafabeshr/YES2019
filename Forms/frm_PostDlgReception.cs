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
    public partial class frm_PostDlgReception : Form
    {

        private bool mouseIsDown = false;
        private Point firstPoint;
        private string QuerySource = "pending";

        public frm_PostDlgReception()
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

        private void frm_PostDlgReception_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode==Keys.F10)
            {
                btnPost_Click(sender, e);
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

        private void btn_Query_Click(object sender, EventArgs e)
        {
            dgv_Reception.DataSource = null;
            txtTotalReceptionRows.Text = "0";
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

            if (string.IsNullOrEmpty(WhereClause))
            {
                WhereClause = " WHERE status='pending' ";
            }
            else
            {
                WhereClause += " AND  status='pending'  ";
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
                    WhereClause = " AND userid=@userid";
                    parameters.Add("userid");
                    parameters.Add(SharedParam.CurrentUser.UserID);
                }
            }

           
            string strsql = "SELECT TOP 300 [Entry_doc_no],[Entry_date],[holder_name],[TotalSharesQty],[TotalHolderSharesQty],[TotalHolderDelagateSharesQty]+[TotalOrgDelegateSharesQty] as TotalDelagateSharesQty,[entry_card_no],[holder_class_name],[DetailsClassName]"
                     + ",[id_type_name],[id_no],[id_date],[id_place],[username],[status_name],[statustime],[postusername],[status],[holder_class],[userid],[CertsCount]"
                     + "FROM  " + (QuerySource == "pending" ? " [dbo].[v_DlgReception] " : " [dbo].[v_Reception] ")
                     + WhereClause;
            #endregion
            if (object.ReferenceEquals(parameters, null))
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
            btnPost.Enabled = true;
        }

        private void frm_PostDlgReception_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
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
        private void PrepareReceptionGrid()
        {
            try
            {
                dgv_Reception.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["select"].HeaderText = "تحديد";
                dgv_Reception.Columns["select"].DisplayIndex = 0;
                dgv_Reception.Columns["select"].Width = 50;
                dgv_Reception.Columns["select"].ReadOnly = false;
                dgv_Reception.Columns["select"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["Entry_doc_no"].HeaderText = "رقم الحضور";
                dgv_Reception.Columns["Entry_doc_no"].ReadOnly = true;
                dgv_Reception.Columns["Entry_doc_no"].Width = 80;
                dgv_Reception.Columns["Entry_doc_no"].DisplayIndex = 1;
                dgv_Reception.Columns["Entry_doc_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["Entry_doc_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["Entry_date"].HeaderText = "وقت الحضور";
                dgv_Reception.Columns["Entry_date"].Width = 140;
                dgv_Reception.Columns["Entry_date"].ReadOnly = true;
                dgv_Reception.Columns["Entry_date"].DisplayIndex = 2;
                dgv_Reception.Columns["Entry_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["Entry_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["holder_name"].HeaderText = "اسم المساهم";
                dgv_Reception.Columns["holder_name"].Width = 230;
                dgv_Reception.Columns["holder_name"].ReadOnly = true;
                dgv_Reception.Columns["holder_name"].DisplayIndex = 3;
                dgv_Reception.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_Reception.Columns["entry_card_no"].HeaderText = "رقم الكرت";
                dgv_Reception.Columns["entry_card_no"].Width = 30;
                dgv_Reception.Columns["entry_card_no"].ReadOnly = true;
                dgv_Reception.Columns["entry_card_no"].DisplayIndex = 4;
                dgv_Reception.Columns["entry_card_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["entry_card_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["holder_class_name"].HeaderText = "فئة الوكيل";
                dgv_Reception.Columns["holder_class_name"].Width = 50;
                dgv_Reception.Columns["holder_class_name"].ReadOnly = true;
                dgv_Reception.Columns["holder_class_name"].DisplayIndex = 5;
                dgv_Reception.Columns["holder_class_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["holder_class_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["DetailsClassName"].HeaderText = "فئة الموكلين";
                dgv_Reception.Columns["DetailsClassName"].Width = 50;
                dgv_Reception.Columns["DetailsClassName"].ReadOnly = true;
                dgv_Reception.Columns["DetailsClassName"].DisplayIndex = 6;
                dgv_Reception.Columns["DetailsClassName"].DefaultCellStyle.ForeColor = Color.Blue;
                dgv_Reception.Columns["DetailsClassName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_type_name"].HeaderText = "نوع الهوية";
                dgv_Reception.Columns["id_type_name"].Width = 100;
                dgv_Reception.Columns["id_type_name"].ReadOnly = true;
                dgv_Reception.Columns["id_type_name"].DisplayIndex = 15;
                dgv_Reception.Columns["id_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_no"].HeaderText = "رقم الهوية";
                dgv_Reception.Columns["id_no"].Width = 100;
                dgv_Reception.Columns["id_no"].ReadOnly = true;
                dgv_Reception.Columns["id_no"].DisplayIndex = 16;
                dgv_Reception.Columns["id_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_date"].HeaderText = "تاريخ الهوية";
                dgv_Reception.Columns["id_date"].Width = 100;
                dgv_Reception.Columns["id_date"].ReadOnly = true;
                dgv_Reception.Columns["id_date"].DisplayIndex = 17;
                dgv_Reception.Columns["id_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["id_place"].HeaderText = "مكان الهوية";
                dgv_Reception.Columns["id_place"].Width = 100;
                dgv_Reception.Columns["id_place"].ReadOnly = true;
                dgv_Reception.Columns["id_place"].DisplayIndex = 18;
                dgv_Reception.Columns["id_place"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["id_place"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["CertsCount"].HeaderText = "عدد الشهادات";
                dgv_Reception.Columns["CertsCount"].Width = 70;
                dgv_Reception.Columns["CertsCount"].ReadOnly = true;
                dgv_Reception.Columns["CertsCount"].DisplayIndex = 7;
                dgv_Reception.Columns["CertsCount"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["CertsCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["TotalSharesQty"].HeaderText = "عدد الاسهم";
                dgv_Reception.Columns["TotalSharesQty"].Width = 70;
                dgv_Reception.Columns["TotalSharesQty"].ReadOnly = true;
                dgv_Reception.Columns["TotalSharesQty"].DisplayIndex = 8;
                dgv_Reception.Columns["TotalSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["TotalSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["TotalHolderSharesQty"].HeaderText = "عدد الاسهم المالك لها";
                dgv_Reception.Columns["TotalHolderSharesQty"].Width = 70;
                dgv_Reception.Columns["TotalHolderSharesQty"].ReadOnly = true;
                dgv_Reception.Columns["TotalHolderSharesQty"].DisplayIndex = 9;
                dgv_Reception.Columns["TotalHolderSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["TotalHolderSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["TotalDelagateSharesQty"].HeaderText = "عدد الاسهم الموكل بها";
                dgv_Reception.Columns["TotalDelagateSharesQty"].Width = 70;
                dgv_Reception.Columns["TotalDelagateSharesQty"].ReadOnly = true;
                dgv_Reception.Columns["TotalDelagateSharesQty"].DisplayIndex = 10;
                dgv_Reception.Columns["TotalDelagateSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["TotalDelagateSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["username"].HeaderText = "المستخدم";
                dgv_Reception.Columns["username"].Width = 120;
                dgv_Reception.Columns["username"].ReadOnly = true;
                dgv_Reception.Columns["username"].DisplayIndex = 11;
                dgv_Reception.Columns["username"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_Reception.Columns["status_name"].HeaderText = "الحالة";
                dgv_Reception.Columns["status_name"].Width = 100;
                dgv_Reception.Columns["status_name"].ReadOnly = true;
                dgv_Reception.Columns["status_name"].DisplayIndex = 12;
                dgv_Reception.Columns["status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["statustime"].HeaderText = "تاريخ الحالة";
                dgv_Reception.Columns["statustime"].Width = 130;
                dgv_Reception.Columns["statustime"].ReadOnly = true;
                dgv_Reception.Columns["statustime"].DisplayIndex = 13;
                dgv_Reception.Columns["statustime"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["statustime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Reception.Columns["postusername"].HeaderText = "مستخدم الحالة";
                dgv_Reception.Columns["postusername"].Width = 130;
                dgv_Reception.Columns["postusername"].ReadOnly = true;
                dgv_Reception.Columns["postusername"].DisplayIndex = 14;
                dgv_Reception.Columns["postusername"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Reception.Columns["postusername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Reception.Columns["status"].Visible = false;
                dgv_Reception.Columns["holder_class"].Visible = false;
                dgv_Reception.Columns["userid"].Visible = false;
                txtTotalReceptionRows.Text = dgv_Reception.RowCount.ToString();
            }
            catch
            {
                txtTotalReceptionRows.Text = "0";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Reception["userid", dgv_Reception.CurrentRow.Index].Value.ToString() == SharedParam.CurrentUser.UserID)
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
                            if (dgv_Reception["holder_class", dgv_Reception.CurrentRow.Index].Value.ToString() == SharedParam.SINGLE_HOLDER_CLASS
                                && SharedParam.CurrentUser.HasSingleHolderClass)
                            {
                                frm_DlgReception frm = new frm_DlgReception(SharedParam.SINGLE_HOLDER_CLASS, "edit", dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString());
                                frm.ShowDialog();
                            }
                            else if (dgv_Reception["holder_class", dgv_Reception.CurrentRow.Index].Value.ToString() == SharedParam.EMPLOYEE_HOLDER_CLASS
                                && SharedParam.CurrentUser.HasEmployeeHolderClass)
                            {
                                frm_DlgReception frm = new frm_DlgReception(SharedParam.EMPLOYEE_HOLDER_CLASS, "edit", dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString());
                                frm.ShowDialog();
                            }
                            else if (dgv_Reception["holder_class", dgv_Reception.CurrentRow.Index].Value.ToString() == SharedParam.COMPANY_HOLDER_CLASS
                                && SharedParam.CurrentUser.HasCompanyHolderClass)
                            { }
                            else if (dgv_Reception["holder_class", dgv_Reception.CurrentRow.Index].Value.ToString() == SharedParam.FOUNDER_HOLDER_CLASS
                                && SharedParam.CurrentUser.HasFounderHolderClass)
                            { }
                            else
                            {
                                string msg = "ليس لديك الصلاحية للتعامل مع بيانات المساهمين من فئة " + dgv_Reception["holder_class_name", dgv_Reception.CurrentRow.Index].Value.ToString();
                                MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            }
                        }
                    } // if status = pending
                    else
                    {
                        string msg = " لا يمكن تعديل بيانات بطاقة الحضور بعد اعتمادها ";
                        MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    }
                } // if the same user
                else
                {
                    string msg = "بطاقة الحضور المختارة تم انشائها من قبل مستخدم آخر" + Environment.NewLine
                        + "المستخدم " + dgv_Reception["username", dgv_Reception.CurrentRow.Index].Value.ToString() + Environment.NewLine
                        + " هو المخول فقط بتعديل بيانات هذه البطاقة ";
                    MessageBox.Show(msg, "تعديل بطاقة حضور", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
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
                    frm.PreviewEntireReceptionInfoReport(dgv_Reception["Entry_doc_no", dgv_Reception.CurrentRow.Index].Value.ToString(), null);
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
                    || dgv_Reception.Columns[e.ColumnIndex].Name == "TotalDelagateSharesQty"
                    || dgv_Reception.Columns[e.ColumnIndex].Name == "CertsCount")
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
            if (e.Column.Name == "TotalSharesQty")
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
            else if (e.Column.Name == "CertsCount")
            {
                e.Column.DefaultCellStyle.BackColor = Color.Pink;
            }
            
        }

        private void btn_selectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Reception.Rows.Count; ++i)
            {
                dgv_Reception["select", i].Value = true;
            }
        }

        private void btn_deselectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Reception.Rows.Count; ++i)
            {
                dgv_Reception["select", i].Value = false;
            }
        }

        private void btn_inverseSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Reception.Rows.Count; ++i)
            {
                if (DBNull.Equals(dgv_Reception["select", i].Value, null) ||
                     Boolean.Parse(dgv_Reception["select", i].Value.ToString()) == true)
                {
                    dgv_Reception["select", i].Value = false;
                }
                else
                {
                    dgv_Reception["select", i].Value = true;
                }
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string Msg = "هل تريد بالتاكيد إعتماد جميع البطاقات المحددة؟";
            if (new Dialogs.Dg_ComfirmMessage("إعتماد", Msg).MessageResult() == DialogResult.Yes)
            {
                string EntryDocNo = string.Empty;
                for (int i = 0; i < dgv_Reception.Rows.Count; ++i)
                {
                    if (!DBNull.Equals(dgv_Reception["select", i].Value, null) &&
                        Boolean.Parse(dgv_Reception["select", i].Value.ToString()) == true)
                    {
                        EntryDocNo = dgv_Reception["Entry_doc_no", i].Value.ToString();
                        if (QuerySource == "pending")
                        {
                            Db.PostDlgReception(EntryDocNo, SharedParam.CurrentUser.UserID);
                        }
                        else
                        {
                            Db.PostReception(EntryDocNo, SharedParam.CurrentUser.UserID);
                        }
                    }
                }
                btn_Query_Click(sender, e);
            }
        }

        private void chQuerySource_CheckedChanged(object sender, EventArgs e)
        {
            if (chQuerySource.Checked)
            {
                chQuerySource.ForeColor = Color.Blue;
                QuerySource = "pending";
            }
            else
            {
                chQuerySource.ForeColor = Color.Black;
                QuerySource = "post";
            }
            btnPost.Enabled = false;
        }
    }
}

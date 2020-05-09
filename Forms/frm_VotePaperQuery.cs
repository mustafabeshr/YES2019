using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_VotePaperQuery : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_VotePaperQuery()
        {
            InitializeComponent();
        }

        private void txtEntryDocNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utility.OnlyNumber(e.KeyChar, false, sender);
        }

        private void btn_close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_VotePaperQuery_KeyDown(object sender, KeyEventArgs e)
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

        private void frm_VotePaperQuery_Load(object sender, System.EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
        }
        void PopulateIdTypesLists()
        {
            string strsql = "select * from "
                + "(select 'all' document_type_id,N'الـكــل' document_type_name,-1 document_type_order" +
                " UNION ALL " +
                "select document_type_id,document_type_name,document_type_order from [dbo].[Document_Type] ) v order by document_type_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coType.DataSource = dt;
                coType.DisplayMember = "document_type_name";
                coType.ValueMember = "document_type_id";
            }
        }
        private void btn_Query_Click(object sender, System.EventArgs e)
        {
            dgv_Vote.DataSource = null;
            txtTotalRows.Text = "0";
            string WhereClause = string.Empty;
            List<string> parameters = new List<string>();
            #region Build Where Clause ...
            string strClasses = string.Empty;
            if (SharedParam.CurrentUser.HasSingleHolderClass)
            {
                strClasses = "'" + SharedParam.SINGLE_HOLDER_CLASS +"'" ;
            }
            else if (SharedParam.CurrentUser.HasEmployeeHolderClass)
            {
                if (string.IsNullOrEmpty(strClasses))
                {
                    strClasses = "'" + SharedParam.EMPLOYEE_HOLDER_CLASS + "'";
                }
                else
                {
                    strClasses += ",'" + SharedParam.EMPLOYEE_HOLDER_CLASS + "'";
                }
            }
            else if (SharedParam.CurrentUser.HasCompanyHolderClass)
            {
                if (string.IsNullOrEmpty(strClasses))
                {
                    strClasses = "'" + SharedParam.COMPANY_HOLDER_CLASS + "'";
                }
                else
                {
                    strClasses += ",'" + SharedParam.COMPANY_HOLDER_CLASS + "'";
                }
            }
            else if (SharedParam.CurrentUser.HasFounderHolderClass)
            {
                if (string.IsNullOrEmpty(strClasses))
                {
                    strClasses = "'" + SharedParam.FOUNDER_HOLDER_CLASS + "'";
                }
                else
                {
                    strClasses += ",'" + SharedParam.FOUNDER_HOLDER_CLASS + "'";
                }
            }
            strClasses = " WHERE [holder_class] in (" + strClasses + ") ";
            //if (!string.IsNullOrEmpty(strClasses))
            //{
            //    WhereClause = strClasses + " AND document_type='vote' ";
            //}
            //else
            //{
            //    WhereClause = " WHERE document_type='vote' ";
            //}
            
            if (!string.IsNullOrEmpty(txtEntryDocNo.Text))
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE [document_no]=@document ";
                    parameters.Add("document");
                    parameters.Add(txtEntryDocNo.Text);
                }
                else
                {
                    WhereClause += " AND [document_no]=@document ";
                    parameters.Add("document");
                    parameters.Add(txtEntryDocNo.Text);
                }
            }

            if (!string.IsNullOrEmpty(txtHolderName.Text))
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE [holder_name] LIKE '%' + @holdername + '%' ";
                    parameters.Add("holdername");
                    parameters.Add(txtHolderName.Text);
                }
                else
                {
                    WhereClause += " AND  [holder_name] LIKE '%' + @holdername + '%' ";
                    parameters.Add("holdername");
                    parameters.Add(txtHolderName.Text);
                }
            }

            if (coType.SelectedValue.ToString() != "all")
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE document_type=@documenttype";
                    parameters.Add("documenttype");
                    parameters.Add(coType.SelectedValue.ToString());
                }
                else
                {
                    WhereClause += " AND document_type=@documenttype";
                    parameters.Add("documenttype");
                    parameters.Add(coType.SelectedValue.ToString());
                }
            }

            if (chOnlyMine.Checked)
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE [print_user]=@userid ";
                    parameters.Add("userid");
                    parameters.Add(SharedParam.CurrentUser.UserID);
                }
                else
                {
                    WhereClause += " AND [print_user]=@userid ";
                    parameters.Add("userid");
                    parameters.Add(SharedParam.CurrentUser.UserID);
                }
            }
            #endregion
            string strsql = "SELECT TOP 1000 [document_no],[document_type_name],[print_type_name],[print_time],[printusername],[print_reason]"
                            + "  ,[reason],[CertsCount],[TotalSharesQty],[holder_name],[Entry_date],[DetailsClassName]"
                            + "  ,[receptionusername],[reception_type_name],[PrintRowId],[DetailsClass],[document_type]"
                            + " FROM[dbo].[v_Print_Reception]  "
                            + WhereClause;
            if (object.ReferenceEquals(parameters, null))
            {
                DataTable dt = Db.GetDataAsDataTable(strsql);
                dgv_Vote.DataSource = dt;
                PrepareVoteGrid();
            }
            else
            {
                DataTable dt = Db.GetDataAsDataTable(strsql, parameters.ToArray());
                dgv_Vote.DataSource = dt;
                PrepareVoteGrid();
            }
        }
        private void PrepareVoteGrid()
        {
            try
            {
                dgv_Vote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["document_no"].HeaderText = "رقم الحضور";
                dgv_Vote.Columns["document_no"].Width = 50;
                dgv_Vote.Columns["document_no"].DisplayIndex = 0;
                dgv_Vote.Columns["document_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["document_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["document_type_name"].HeaderText = "النـــوع";
                dgv_Vote.Columns["document_type_name"].Width = 100;
                dgv_Vote.Columns["document_type_name"].DisplayIndex = 1;
                dgv_Vote.Columns["document_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["document_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["print_type_name"].HeaderText = "نوع الطباعة";
                dgv_Vote.Columns["print_type_name"].Width = 100;
                dgv_Vote.Columns["print_type_name"].DisplayIndex = 2;
                dgv_Vote.Columns["print_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["print_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["print_time"].HeaderText = "تاريخ الطباعة";
                dgv_Vote.Columns["print_time"].Width = 130;
                dgv_Vote.Columns["print_time"].DisplayIndex = 3;
                dgv_Vote.Columns["print_time"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["print_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["printusername"].HeaderText = "المستخدم";
                dgv_Vote.Columns["printusername"].Width = 130;
                dgv_Vote.Columns["printusername"].DisplayIndex = 4;
                dgv_Vote.Columns["printusername"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["printusername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["print_reason"].HeaderText = "السبب";
                dgv_Vote.Columns["print_reason"].Width = 140;
                dgv_Vote.Columns["print_reason"].DisplayIndex = 5;
                dgv_Vote.Columns["print_reason"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["print_reason"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["reason"].HeaderText = "سبب اخر";
                dgv_Vote.Columns["reason"].Width = 170;
                dgv_Vote.Columns["reason"].DisplayIndex = 6;
                dgv_Vote.Columns["reason"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["reason"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["CertsCount"].HeaderText = "عدد الشهادات";
                dgv_Vote.Columns["CertsCount"].Width = 80;
                dgv_Vote.Columns["CertsCount"].DisplayIndex = 7;
                dgv_Vote.Columns["CertsCount"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["CertsCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["TotalSharesQty"].HeaderText = "عدد الاسهم";
                dgv_Vote.Columns["TotalSharesQty"].Width = 80;
                dgv_Vote.Columns["TotalSharesQty"].DisplayIndex = 8;
                dgv_Vote.Columns["TotalSharesQty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["TotalSharesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["holder_name"].HeaderText = "الاســـــــم";
                dgv_Vote.Columns["holder_name"].Width = 200;
                dgv_Vote.Columns["holder_name"].DisplayIndex = 9;
                dgv_Vote.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["Entry_date"].HeaderText = "تاريخ الحضور";
                dgv_Vote.Columns["Entry_date"].Width = 130;
                dgv_Vote.Columns["Entry_date"].DisplayIndex = 10;
                dgv_Vote.Columns["Entry_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["Entry_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["DetailsClassName"].HeaderText = "الـفـئــة";
                dgv_Vote.Columns["DetailsClassName"].Width = 100;
                dgv_Vote.Columns["DetailsClassName"].DisplayIndex = 11;
                dgv_Vote.Columns["DetailsClassName"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["DetailsClassName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Vote.Columns["receptionusername"].HeaderText = "مستخدم الحضور";
                dgv_Vote.Columns["receptionusername"].Width = 100;
                dgv_Vote.Columns["receptionusername"].DisplayIndex = 12;
                dgv_Vote.Columns["receptionusername"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["receptionusername"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Vote.Columns["reception_type_name"].HeaderText = "نوع التمثيل";
                dgv_Vote.Columns["reception_type_name"].Width = 130;
                dgv_Vote.Columns["reception_type_name"].DisplayIndex = 12;
                dgv_Vote.Columns["reception_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Vote.Columns["reception_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
                dgv_Vote.Columns["document_type"].Visible = false;
                dgv_Vote.Columns["PrintRowId"].Visible = false;
                dgv_Vote.Columns["DetailsClass"].Visible = false;
                txtTotalRows.Text = dgv_Vote.RowCount.ToString();
            }
            catch
            {
                txtTotalRows.Text = "0";
            }
        }
        private void chOnlyMine_CheckedChanged(object sender, System.EventArgs e)
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

        private void dgv_Vote_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgv_Vote.Columns[e.ColumnIndex].Name == "CertsCount" || dgv_Vote.Columns[e.ColumnIndex].Name == "TotalSharesQty")
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

        private void btn_reprint_Click(object sender, EventArgs e)
        {
            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 5, 1, "ReprintVotePaper"))
            {
                frm_PrintVote frm = new frm_PrintVote("reprint", dgv_Vote["document_no", dgv_Vote.CurrentRow.Index].Value.ToString(), "vote");
                frm.ShowDialog();
            }
            else
            { 
                MessageBox.Show("ليس لديك الصلاحية الكافية");
                return;
            }

            
            //try {
            //    string Msg = "هل تريد بالتأكيد إعادة طباعة ورقة الاقتراع؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد الحفظ.";
            //    if (new Dialogs.Dg_ComfirmMessage("طباعة ورقة اقتراع", Msg).MessageResult() == DialogResult.Yes)
            //    {
            //        int EntryDocNo = (int)dgv_Vote["document_no", dgv_Vote.CurrentRow.Index].Value;
            //        if (Db.HasRight(SharedParam.CurrentUser.RoleId, 5, 1, "ReprintVotePaperFromQueryScreen"))
            //        {
            //            if (Db.PrintedTimes(EntryDocNo, "all") < Config.MaxVotePaperPrintTimes)
            //            {
            //                string result = Db.CreatePrint(EntryDocNo
            //                            , "vote", "reprint", SharedParam.CurrentUser.UserID, "other"
            //                            , "إعادة الطباعة من شاشة الاستعلام عن اوراق الاقتراع");
            //                if (result == "success")
            //                {
            //                    PrintToPrinter(EntryDocNo.ToString()
            //                        , dgv_Vote["holder_class", dgv_Vote.CurrentRow.Index].Value.ToString()
            //                        , dgv_Vote["TotalSharesQty", dgv_Vote.CurrentRow.Index].Value.ToString()
            //                        , dgv_Vote["holder_class_name", dgv_Vote.CurrentRow.Index].Value.ToString());
            //                    Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تمت عملية إعادة الطباعة بنجاح ");
            //                    frm.ShowDialog();
            //                }
            //                else
            //                {
            //                    MessageBox.Show("فشلت عملية إعادة الطباعة");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("عدد مرات طباعة ورقة الاقتراع تجاوز الحد الاقصى المسموح به");
            //            }
            //        }
            //        else
            //        {
            //            Dialogs.Dg_Error frm = new Dialogs.Dg_Error("ليس لديك الصلاحية الكافية");
            //            frm.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        void PrintToPrinter(string EntryDocNo, string candclass, string shares, string classname)
        {
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetVotePaper", "VoteDT", "@class", candclass, "@status", "candidate");
            appcode.Printable p = new Printable();
            //p.PrinterName = "PDFCreator";
            ReportParameter[] ReportParams = new ReportParameter[]
                                {
                                    new ReportParameter("title","لإنتخاب أعضاء مجلس الادارة فئة "+classname),
                                    new ReportParameter("SharesQty",shares),
                                    new ReportParameter("docno",EntryDocNo)
                                };
            p.OnlyOnePage = true;
            p.Run(@Config.ReportsPath + "VotePaper.rdlc", "DataSet1", dt, ReportParams);
        }

        private void dgv_Vote_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Vote["document_type",e.RowIndex].Value.ToString()!="vote")
            {
                btn_reprint.Enabled = false;
                btn_reprint.Visible = false;
            }
            else
            {
                btn_reprint.Enabled = true;
                btn_reprint.Visible = true;
            }
        }
    }
}

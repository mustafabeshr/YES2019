using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using YES.appcode;
namespace YES.Forms
{
    public partial class frm_reception : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private string CurrentHolderClass = string.Empty;
        private string CurrentHolderClassName = string.Empty;
        private string CurrentStepName = "Query";
        private int CurrentHolderNo = 0;
        private List<PresentHolderCertsWithDelegate> HolderCertsList;
        int CertsCount = 0;
        int TotalShares = 0;
        public frm_reception(string Holder_Class)
        {
            InitializeComponent();
            CurrentHolderClass = Holder_Class;
            CurrentHolderClassName = appcode.Config.GetHoldeClassName(Holder_Class);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_reception_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode==Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode==Keys.F10)
            {
                btn_Commit_Click(sender, e);
            }
        }

        private void frm_reception_Load(object sender, EventArgs e)
        {
            co_H_IdType.Visible = false;
            PopulateIdTypesLists();
            lbl_ClassName.Text = CurrentHolderClassName;
            ChangeClassBackgroundColor();
            txt_Q_CertNo.Focus();
            ArrangePanels("pnl_Query");
            txtUserInfo.Text = Config.LoggedInUserInfo;
            btn_AddCerts.Enabled = Config.AddAdditionalCertsToReception;
            //this.reportViewer1.RefreshReport();
        }
        void PopulateIdTypesLists()
        {
            string strsql ="select 'nochange' id_type,N'بدون تغيير' id_type_name ,-1 id_order union " +Environment.NewLine
                + "select id_type,id_type_name,id_order from IDs where attend_allow=1 order by id_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt!=null)
            {
                co_H_IdType.DataSource = dt;
                co_H_IdType.DisplayMember = "id_type_name";
                co_H_IdType.ValueMember = "id_type";
            }
        }
        void ArrangePanels(string OnlyThis)
        {
            if (string.IsNullOrEmpty(OnlyThis))
            {
                foreach (Panel p in pnl_Container.Controls)
                {
                    p.Visible = false;
                }
            }
            else
            {
                foreach (Panel p in pnl_Container.Controls)
                {
                    if (p.Name == OnlyThis)
                    {
                        p.Visible = true;
                        p.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        p.Visible = false;
                    }
                }
            }
        }
        void ChangeClassBackgroundColor()
        {
            switch (CurrentHolderClass)
            {
                case SharedParam.SINGLE_HOLDER_CLASS:
                    pnl_holderclass.BackColor = Color.FromArgb(241, 48, 48);
                    break;
                case SharedParam.EMPLOYEE_HOLDER_CLASS:
                    pnl_holderclass.BackColor = Color.FromArgb(28, 156, 211);
                    break;
                case SharedParam.COMPANY_HOLDER_CLASS:
                    pnl_holderclass.BackColor = Color.FromArgb(11, 245, 27);
                    break;
                case SharedParam.FOUNDER_HOLDER_CLASS:
                    pnl_holderclass.BackColor = Color.FromArgb(125, 16, 247);
                    break;
            }
        }

        private void txt_Q_CertNo_TextChanged(object sender, EventArgs e)
        {
            if (appcode.Utility.ValidRegEx(txt_Q_CertNo.Text,"^[0-9]{3}-[0-9]{6}")
                ||
                appcode.Utility.ValidRegEx(txt_Q_CertNo.Text, "^[0-9]{6}-[0-9]{3}"))
            {
                txt_Q_CertNo.ForeColor = Color.Green;
                txt_Q_HolderName.Text = string.Empty;
                txt_Q_ShareQty.Text = string.Empty;
                pnl_sharesDetails.Visible = false;
                CurrentHolderNo = 0;
                DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "Holders", "CertNo", txt_Q_CertNo.Text, "HolderClass", CurrentHolderClass,"status","0");
                if (dt!=null)
                {
                    DataRow HolderDataRow = dt.Rows[0];
                    if (HolderDataRow["status"].ToString() != "5" || int.Parse(HolderDataRow["share_qty"].ToString())>0)
                    {
                        txt_Q_HolderName.Text = HolderDataRow["holder_name"].ToString();
                        txt_Q_ShareQty.Text= HolderDataRow["share_qty"].ToString();
                        txt_H_IdType.Text= HolderDataRow["id_type_name"].ToString();
                        txt_H_IdNo.Text= HolderDataRow["id_no"].ToString();
                        txt_H_IdDate.Text= (HolderDataRow["id_date"]!=DBNull.Value)? DateTime.Parse(HolderDataRow["id_date"].ToString()).ToString("dd/MM/yyyy"):null;
                        txt_H_IdPlace.Text= HolderDataRow["id_place"].ToString();
                        txt_H_IdTypeId.Text = HolderDataRow["id_type"].ToString();
                        CurrentHolderNo = (int)HolderDataRow["holder_no"];

                        btn_Q_Next.Enabled = true;
                        if (CurrentHolderNo > 0)
                        {
                            string strsql = "SELECT count(*) cnt,sum(share_qty) shares FROM shareholders WHERE holder_no=@holderno having count(*)>1";

                            DataTable dt2 = Db.GetDataAsDataTable(strsql, "AggregateTable", "holderno", HolderDataRow["holder_no"].ToString());
                            if (dt != null)
                            {
                                DataRow AggregateDataRow = dt2.Rows[0];
                                txt_Q_HolderCertCount.Text = AggregateDataRow["cnt"].ToString();
                                txt_Q_HolderSharesQty.Text = AggregateDataRow["shares"].ToString();
                                pnl_sharesDetails.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        txt_Q_HolderName.Text = string.Empty;
                        txt_Q_ShareQty.Text = string.Empty;
                        btn_Q_Next.Enabled = false;
                        pnl_sharesDetails.Visible = false;
                        CurrentHolderNo = 0;
                    }
                }
                else
                {
                    txt_Q_HolderName.Text = string.Empty;
                    txt_Q_ShareQty.Text = string.Empty;
                    btn_Q_Next.Enabled = false;
                    pnl_sharesDetails.Visible = false;
                    CurrentHolderNo = 0;
                }
            }
            else
            {
                txt_Q_CertNo.ForeColor = Color.Red;
                txt_Q_HolderName.Text = string.Empty;
                txt_Q_ShareQty.Text = string.Empty;
                btn_Q_Next.Enabled = false;
                pnl_sharesDetails.Visible = false;
                CurrentHolderNo = 0;
            }
        }

        private void btn_Q_Next_Click(object sender, EventArgs e)
        {
            ArrangePanels("pnl_Holder");
            CurrentStepName = "Holder";
            btn_H_Prev.Enabled = true;
            txt_H_CertNo.Text = txt_Q_CertNo.Text;
            txt_H_HolderName.Text = txt_Q_HolderName.Text;
            txt_H_ShareQty.Text = txt_Q_ShareQty.Text;
            DataTable dt;
            if (CurrentHolderNo > 0)
            {
                 dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByHolderNo", "HolderCerts", "HolderNo", CurrentHolderNo.ToString()
                    , "HolderClass", CurrentHolderClass, "Status", "0");
            }else
            {
                dt=Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "Holders", "CertNo", txt_Q_CertNo.Text, "HolderClass", CurrentHolderClass, "status", "0");
            }
                if (dt!=null)
                {
                HolderCertsList = new List<PresentHolderCertsWithDelegate>();
                    foreach (DataRow HolderCertDataRow in dt.Rows)
                    {
                          PresentHolderCertsWithDelegate PHCert =
                            new PresentHolderCertsWithDelegate((int)HolderCertDataRow["share_qty"], HolderCertDataRow["cert_no"].ToString()
                            , HolderCertDataRow["holder_name"].ToString(), HolderCertDataRow["class_name"].ToString()
                            , HolderCertDataRow["holder_class"].ToString(), HolderCertDataRow["rowid"].ToString(),0
                            ,false, "000", string.Empty, DateTime.MinValue, "000", DateTime.MinValue, string.Empty
                            , string.Empty,"Delegated","توكيل", "Holder",SharedParam.CurrentUser.UserID);
                        CertsCount += 1;
                        TotalShares += (int)HolderCertDataRow["share_qty"];
                        HolderCertsList.Add(PHCert);
                    }
                
                dgvCerts.DataSource = HolderCertsList;
                    txtTotalCerts.Text = CertsCount.ToString("N0");
                    txtTotalShares.Text = TotalShares.ToString("N0");
                dgv_ApplyStyle();
            }
            
        }

     

        private void btn_H_Prev_Click(object sender, EventArgs e)
        {
            GoFirstPhase();
        }

        private void GoFirstPhase()
        {
            ArrangePanels("pnl_Query");
            CurrentStepName = "Query";
            btn_H_Prev.Enabled = false;
            btn_Q_Next.Enabled = false;
            HolderCertsList.Clear();
            dgvCerts.DataSource = null;
            dgvCerts.DataSource = HolderCertsList;
            txt_H_CertNo.Text = txt_Q_CertNo.Text =
            txt_H_HolderName.Text = txt_Q_HolderName.Text =
            txt_H_ShareQty.Text = txt_Q_ShareQty.Text = string.Empty;
            txt_Q_CertNo.Focus();
        }

        private void txt_H_IdType_Enter(object sender, EventArgs e)
        {
            co_H_IdType.Visible = true;
            co_H_IdType.Location = txt_H_IdType.Location;
            co_H_IdType.Size = txt_H_IdType.Size;
            co_H_IdType.Focus();
        }

        private void co_H_IdType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (co_H_IdType.SelectedValue.ToString() == "nochange")
            {
                co_H_IdType.Visible = false;
                txt_H_IdNo.Focus();
            }
            else
            {
                txt_H_IdType.Text = co_H_IdType.Text;
                txt_H_IdTypeId.Text = co_H_IdType.SelectedValue.ToString();
                co_H_IdType.Visible = false;
                txt_H_IdNo.Focus();
            }
        }

        private void txt_H_IdDate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidDate(txt_H_IdDate.Text))
            {
                txt_H_IdDate.ForeColor = Color.Black;
            }
            else
            {
                txt_H_IdDate.ForeColor = Color.Red;
            }
        }

        private void dgv_ApplyStyle()
        {
            dgvCerts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["ShareQty"].HeaderText = "عدد الأسهم";
            dgvCerts.Columns["ShareQty"].DisplayIndex = 0;
            dgvCerts.Columns["ShareQty"].Width = 140;
            dgvCerts.Columns["ShareQty"].DefaultCellStyle.ForeColor = Color.Brown;
            dgvCerts.Columns["ShareQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["CertNo"].HeaderText = "رقم الشهادة";
            dgvCerts.Columns["CertNo"].DisplayIndex = 1;
            dgvCerts.Columns["CertNo"].Width = 120;
            dgvCerts.Columns["CertNo"].DefaultCellStyle.ForeColor = Color.Blue;
            dgvCerts.Columns["CertNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["HolderName"].HeaderText = "اسم المساهم";
            dgvCerts.Columns["HolderName"].DisplayIndex = 2;
            dgvCerts.Columns["HolderName"].Width = 300;
            dgvCerts.Columns["HolderName"].DefaultCellStyle.ForeColor = Color.Purple;
            dgvCerts.Columns["HolderName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCerts.Columns["ClassName"].HeaderText = "الفئة";
            dgvCerts.Columns["ClassName"].DisplayIndex = 3;
            dgvCerts.Columns["ClassName"].Width = 130;
            dgvCerts.Columns["ClassName"].DefaultCellStyle.ForeColor = Color.DarkGreen;
            dgvCerts.Columns["ClassName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["ClassId"].Visible = false;
            dgvCerts.Columns["RowId"].Visible = false;
            dgvCerts.Columns["EntryDocNo"].Visible = false;
            dgvCerts.Columns["DlgNo"].Visible = false;
            dgvCerts.Columns["DlgName"].Visible = false;
            dgvCerts.Columns["DlgDate"].Visible = false;
            dgvCerts.Columns["ApprovedNo"].Visible = false;
            dgvCerts.Columns["ApprovedDate"].Visible = false;
            dgvCerts.Columns["ApprovedOrg"].Visible = false;
            dgvCerts.Columns["Note"].Visible = false;
            dgvCerts.Columns["Delegate_Type"].Visible = false;
            dgvCerts.Columns["Delegate_Type_Name"].Visible = false;
            dgvCerts.Columns["Reception_Type"].Visible = false;
            dgvCerts.Columns["IsDelagated"].Visible = false;
        }

        private void dgvCerts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvCerts.Columns[e.ColumnIndex].Name== "ShareQty")
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

        private void dgvCerts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow r in dgvCerts.SelectedRows)
                {
                    var item = HolderCertsList.Single(itm => itm.RowId == r.Cells["RowId"].Value.ToString());
                    HolderCertsList.Remove(item);
                    
                }
                dgvCerts.DataSource = null;
                dgvCerts.DataSource = HolderCertsList;
                dgv_ApplyStyle();
            }
        }

        private void btn_AddCerts_Click(object sender, EventArgs e)
        {
            PresentHolderCertsWithDelegate DelData = new PresentHolderCertsWithDelegate(0, string.Empty, string.Empty
                , string.Empty, string.Empty, string.Empty, 0,false, string.Empty, string.Empty, DateTime.MinValue
                , string.Empty, DateTime.MinValue, string.Empty, string.Empty,"Delegated","توكيل", "Holder",SharedParam.CurrentUser.UserID);
            frm_HolderSearch frm = new frm_HolderSearch(CurrentHolderClass,false,DelData, ref HolderCertsList);
            frm.ShowDialog();
            dgvCerts.DataSource = null;
            dgvCerts.DataSource = HolderCertsList;
            dgv_ApplyStyle();
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

        private void dgvCerts_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCerts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateHolderStat();
        }

        private void UpdateHolderStat()
        {
            CertsCount = HolderCertsList.Count(t => !string.IsNullOrEmpty(t.CertNo));
            txtTotalCerts.Text = CertsCount.ToString();
            TotalShares = HolderCertsList.Sum(t => t.ShareQty);
            txtTotalShares.Text = TotalShares.ToString();
        }

        bool CheckRequiredFields()
        {
            toolTipMessage.AutoPopDelay = 5000;
            toolTipMessage.InitialDelay = 1000;
            toolTipMessage.ReshowDelay = 500;
            toolTipMessage.BackColor = Color.Red;
            toolTipMessage.ForeColor = Color.Red;
            toolTipMessage.ShowAlways = true;
            toolTipMessage.IsBalloon = true;
            toolTipMessage.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            toolTipMessage.ToolTipTitle = string.Empty;
            if (string.IsNullOrEmpty(txt_H_IdNo.Text))
            {
                //toolTipMessage.SetToolTip(txt_H_IdNo, "يجب ادخال رقم الهوية!");
                toolTipMessage.Show("يجب ادخال رقم الهوية",txt_H_IdNo,2000);
                txt_H_IdNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_IdType.Text))
            {
                toolTipMessage.Show("يجب تحديد نوع الهوية", txt_H_IdType, 2000);
                txt_H_IdType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_IdDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ اصدار الهوية", txt_H_IdDate, 2000);
                txt_H_IdDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_IdPlace.Text))
            {
                toolTipMessage.Show("يجب ادخال مكان اصدار الهوية", txt_H_IdPlace, 2000);
                txt_H_IdPlace.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txt_H_IdDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ اصدار الهوية بالشكل الصحيح", txt_H_IdDate, 2000);
                txt_H_IdDate.Focus();
                return false;
            }
                if (Config.AdmissionCardRequired)
            {
                if (string.IsNullOrEmpty(txt_H_CardNo.Text))
                {
                    toolTipMessage.Show("يجب ادخال رقم الكرت", txt_H_CardNo, 2000);
                    txt_H_CardNo.Focus();
                    return false;
                }
            }
            if (TotalShares<=0)
            {
                toolTipMessage.Show("ليس لدى المساهم اسهم", btn_Commit, 2000);
                btn_Commit.Focus();
                return false;
            }
            return true;
        }
        private void NewTransaction()
        {
            if (!object.ReferenceEquals(HolderCertsList, null))
            {
                HolderCertsList.Clear();
                dgvCerts.DataSource = null;
                dgvCerts.DataSource = HolderCertsList;
                dgv_ApplyStyle();
            }
            else
            {
                dgvCerts.Rows.Clear();
                dgv_ApplyStyle();
            }
            txt_H_CertNo.Text = txt_Q_CertNo.Text =
            txt_H_HolderName.Text = txt_Q_HolderName.Text =
            txt_H_ShareQty.Text = txt_Q_ShareQty.Text = string.Empty;
            GoFirstPhase();
        }
        private void btn_Commit_Click(object sender, EventArgs e)
        {
            if (CheckRequiredFields())
            {
                if (Config.PrintAdmissionDocument &&  Db.GetPrinterName(Utility.GetMACAddress()) == "N/A")
                {
                    MessageBox.Show("لم يتم تحديد الطابعة التي سيتم عبرها طباعة بطاقة الدخول", "خطأ"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 
                        MessageBoxOptions.RightAlign);
                }
                else
                {
                    string Msg = "هل تريد بالتأكيد الحفظ؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد الحفظ.";
                    if (new Dialogs.Dg_ComfirmMessage("الحفظ", Msg).MessageResult() == DialogResult.Yes)
                    {
                        string EntryDocNo = Db.CreateReception(txt_H_CertNo.Text, int.Parse(txt_H_ShareQty.Text), CurrentHolderClass
                            , txt_H_HolderName.Text, txt_H_IdTypeId.Text, txt_H_IdNo.Text, DateTime.Parse(txt_H_IdDate.Text)
                            , txt_H_IdPlace.Text, int.Parse(string.IsNullOrEmpty(txt_H_CardNo.Text) ? "0" : txt_H_CardNo.Text)
                            , string.Empty, SharedParam.CurrentUser.UserID, "Holder", "post", SharedParam.CurrentUser.UserID);
                        if (int.Parse(EntryDocNo) > 0)
                        {
                            int lineno = 0;
                            foreach (PresentHolderCerts tmp in HolderCertsList)
                            {
                                int result = Db.CreateReceptionDetails(int.Parse(EntryDocNo), ++lineno, tmp.CertNo, tmp.ShareQty, tmp.ClassId
                                    , false, string.Empty, DateTime.MinValue, string.Empty, string.Empty, DateTime.MinValue, string.Empty
                                    , int.Parse(tmp.RowId), string.Empty, "Delegated", "Holder", SharedParam.CurrentUser.UserID);

                            }
                            if (!Db.HasData("reception_details", " Where entry_doc_no=" + EntryDocNo))
                            {
                                Db.ExecuteSQLCommand("delete from reception where entry_doc_no=" + EntryDocNo);
                            }
                            else
                            {
                                DataTable dt = Db.GetDataAsDataTable("select isnull(count(*),0) cnt,sum(share_qty) shares from reception_details where entry_doc_no=@entrydocno"
                                    , "actual", "entrydocno", EntryDocNo);
                                if (dt != null)
                                {
                                    Dialogs.Dg_InfoMessage frm = new Dialogs.Dg_InfoMessage("تم الحفظ بنجاح"
                                        , EntryDocNo
                                        , (dt.Rows[0]["cnt"] == DBNull.Value ? 0 : (int)dt.Rows[0]["cnt"])
                                        , (dt.Rows[0]["shares"] == DBNull.Value ? 0 : (int)dt.Rows[0]["shares"]));
                                    frm.ShowDialog();
                                    NewTransaction();

                                    if (Config.PrintAdmissionDocument)
                                    {
                                        string result = Db.CreatePrint(int.Parse(EntryDocNo)
                                          , "entry", "first_print", SharedParam.CurrentUser.UserID, "other"
                                          , string.Empty);
                                        if (result == "success")
                                        {
                                            //if (Config.GetPrinterName() != "N/A")
                                            //{
                                            DataTable dt2 = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
                                            appcode.Printable p = new Printable();
                                            //p.PrinterName = "PDFCreator";
                                            ReportParameter[] ReportParams = new ReportParameter[]
                                            {
                                    new ReportParameter("EventDate",Config.EventDate),
                                    new ReportParameter("EventYear",Config.EventYear)
                                            };
                                            p.OnlyOnePage = true;
                                            p.Run(@Config.ReportsPath + "SelfAdmission.rdlc", "AdmissionDataset", dt2, ReportParams);
                                            //PrintToPrinter(EntryDocNo, ReportParams);
                                            //PrintToPrinter(EntryDocNo);
                                            //}
                                            //else
                                            //{

                                            //}
                                        }
                                        else
                                        {
                                            MessageBox.Show("فشلت عملية الطباعة");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        //MessageBox.Show("NO");
                    }
                }
            }
        }

        private void txt_H_CardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utility.OnlyNumber(e.KeyChar, false, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        void PreviewReport(string EntryDocNo, ReportParameter[] parameters)
        {
            //reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "SelfAdmission.rdlc";
            //reportViewer1.LocalReport.DataSources.Clear();
            //DataTable dt = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            //ReportDataSource rds = new ReportDataSource("AdmissionDataset", dt);
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.SetParameters(parameters);
            //reportViewer1.SetDisplayMode(DisplayMode.Normal);
        }

        void PrintToPrinter(string EntryDocNo)
        {
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            appcode.Printable p = new Printable();
            p.PrinterName = "PDFCreator";
            p.Run(Config.ReportsPath + "SelfAdmission.rdlc", "AdmissionDataset", dt);
        }

        void PrintToPrinter(string EntryDocNo, ReportParameter[] parameters)
        {
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            appcode.Printable p = new Printable();
            //p.PrinterName = "PDFCreator";
            p.Run(Config.ReportsPath + "SelfAdmission.rdlc", "AdmissionDataset", dt,parameters);
        }

    }
    }

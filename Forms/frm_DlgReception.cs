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
    public partial class frm_DlgReception : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private string CurrentHolderClass = string.Empty;
        private string CurrentDelegateClass = string.Empty;
        private string CurrentHolderClassName = string.Empty;
        private string CurrentStepName = "new";
        private string CurrentEntryNo = "0";
        private int CurrentHolderNo = 0;
        private List<PresentHolderCertsWithDelegate> HolderCertsList;
        int CertsCount = 0;
        int TotalShares = 0;
        public frm_DlgReception(string Holder_Class,string StepName,string EntryDocNo)
        {
            InitializeComponent();
            CurrentHolderClass = Holder_Class;
            CurrentStepName = StepName;
            CurrentEntryNo = EntryDocNo;
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

        private void frm_DlgReception_KeyDown(object sender, KeyEventArgs e)
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
        }

        private void frm_DlgReception_Load(object sender, EventArgs e)
        {
            co_H_IdType.Visible = false;
            PopulateIdTypesLists();
            PopulateDelegateTypeList();
            lbl_ClassName.Text = CurrentHolderClassName;
            ChangeClassBackgroundColor();
            txtUserInfo.Text = Config.LoggedInUserInfo;
            btn_AddCerts.Enabled = Config.AddAdditionalCertsToReception;

            if (CurrentStepName == "new")
            {
                ArrangePanels("pnl_Query");
                txt_Q_CertNo.Focus();
            }
            else if (CurrentStepName == "edit")
            {
                ArrangePanels("pnl_Holder");
                btn_H_Prev.Visible = false;
                txt_H_AttDocNo.Text = CurrentEntryNo;
                LoadReceptionData(CurrentEntryNo);
            }
        }

        void LoadReceptionData(string EntryNo)
        {
            string strsql = "SELECT TOP 1 * FROM [dbo].[v_DlgReception] WHERE [Entry_doc_no]=@Entry ";
            DataTable dt_Reception = Db.GetDataAsDataTable(strsql,"reception", "Entry", EntryNo);
            if (dt_Reception != null)
            {
                DataRow RecDR = dt_Reception.Rows[0];
                txt_Q_HolderName.Text = RecDR["holder_name"].ToString();
                txt_Q_ShareQty.Text = RecDR["share_qty"].ToString();
                txt_H_HolderName.Text= RecDR["holder_name"].ToString();
                txt_H_CertNo.Text= RecDR["Cert_No"].ToString();
                txt_H_ShareQty.Text= RecDR["share_qty"].ToString();
                txt_H_IdType.Text = RecDR["id_type_name"].ToString();
                txt_H_IdNo.Text = RecDR["id_no"].ToString();
                txt_H_IdDate.Text = (Utility.IsValidDate(RecDR["id_date"].ToString()) ? DateTime.Parse(RecDR["id_date"].ToString()).ToString("dd/MM/yyyy") : RecDR["id_date"].ToString()); 
                txt_H_IdPlace.Text = RecDR["id_place"].ToString();
                txt_H_IdTypeId.Text = RecDR["id_type"].ToString();
                txt_H_CardNo.Text = RecDR["entry_card_no"].ToString();
                // Get Reception Details 
                strsql = "SELECT * FROM [dbo].[v_DlgReception_Details] WHERE [Entry_doc_no]=@Entry AND holder_class=@holderclass order by reception_type desc";
                DataTable dt_ReceptionDetails = Db.GetDataAsDataTable(strsql,"DlgReceptionDetails", "Entry", EntryNo, "holderclass", CurrentHolderClass);
                if (dt_ReceptionDetails != null)
                {
                    DataRow RecDetDR = dt_ReceptionDetails.Rows[0];
                    CurrentDelegateClass = RecDetDR["holder_class"].ToString();
                    txt_H_DlgName.Text = RecDetDR["Dlg_Name"].ToString();
                    txt_H_DlgNo.Text = RecDetDR["Dlg_no"].ToString();
                    txt_H_DlgDate.Text = (Utility.IsValidDate(RecDetDR["Dlg_date"].ToString())?DateTime.Parse(RecDetDR["Dlg_date"].ToString()).ToString("dd/MM/yyyy"): RecDetDR["Dlg_date"].ToString());
                    txt_H_ApprovedNo.Text = RecDetDR["Approved_no"].ToString();
                    txt_H_ApprovedDate.Text = (Utility.IsValidDate(RecDetDR["Dlg_date"].ToString()) ? DateTime.Parse(RecDetDR["Approved_date"].ToString()).ToString("dd/MM/yyyy") : RecDetDR["Approved_date"].ToString()); 
                    txt_H_ApprovedOrg.Text = RecDetDR["Approved_org"].ToString();
                    // build Cert List ...
                    HolderCertsList = new List<PresentHolderCertsWithDelegate>();
                    //HolderCertsList.Clear();
                    foreach (DataRow dr in dt_ReceptionDetails.Rows)
                    {
                        PresentHolderCertsWithDelegate tmp = new PresentHolderCertsWithDelegate(
                             (int)dr["share_qty"], dr["cert_no"].ToString(), dr["holder_name"].ToString(), dr["holder_class_name"].ToString()
                             , dr["holder_class"].ToString(), dr["CertRowId"].ToString(),(int) dr["Entry_doc_no"], (bool)dr["Delagate"]
                             , dr["Dlg_no"].ToString(), dr["Dlg_Name"].ToString(), (DateTime)dr["Dlg_date"], dr["Approved_no"].ToString()
                             , (DateTime)dr["Approved_date"], dr["Approved_org"].ToString(), dr["note"].ToString(), dr["Delegate_Type"].ToString()
                             , dr["Delegate_Type_Name"].ToString(), dr["reception_type"].ToString(), dr["userid"].ToString());
                        HolderCertsList.Add(tmp);
                    }
                    dgvCerts.DataSource = null;
                    dgvCerts.DataSource = HolderCertsList;
                    dgv_ApplyStyle();
                }
            }

        }

        void PopulateIdTypesLists()
        {
            string strsql = "select 'nochange' id_type,N'بدون تغيير' id_type_name ,-1 id_order union " + Environment.NewLine
                + "select id_type,id_type_name,id_order from IDs where attend_allow=1 order by id_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                co_H_IdType.DataSource = dt;
                co_H_IdType.DisplayMember = "id_type_name";
                co_H_IdType.ValueMember = "id_type";
            }
        }

        void PopulateDelegateTypeList()
        {
            string strsql = "SELECT [Delegate_Type],[Delegate_Type_Name] FROM [dbo].[Delegate_Type] ORDER BY [Delegate_Type_Order]";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coDelegateType.DataSource = dt;
                coDelegateType.DisplayMember = "Delegate_Type_Name";
                coDelegateType.ValueMember = "Delegate_Type";
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
            if (appcode.Utility.ValidRegEx(txt_Q_CertNo.Text, "^[0-9]{3}-[0-9]{6}")
                ||
                appcode.Utility.ValidRegEx(txt_Q_CertNo.Text, "^[0-9]{6}-[0-9]{3}"))
            {
                txt_Q_CertNo.ForeColor = Color.Green;
                txt_Q_HolderName.Text = string.Empty;
                txt_Q_ShareQty.Text = string.Empty;
                pnl_sharesDetails.Visible = false;
                CurrentHolderNo = 0;
                DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "Holders", "CertNo", txt_Q_CertNo.Text, "HolderClass", "all", "status", (Config.CheckAgentCertStatus?"0":"-1"));
                if (dt != null)
                {
                    DataRow HolderDataRow = dt.Rows[0];
                    if (HolderDataRow["holder_class"].ToString() == SharedParam.SINGLE_HOLDER_CLASS || HolderDataRow["holder_class"].ToString() == SharedParam.EMPLOYEE_HOLDER_CLASS)
                    {
                        txt_Q_HolderName.Text = HolderDataRow["holder_name"].ToString();
                        txt_Q_ShareQty.Text = HolderDataRow["share_qty"].ToString();
                        txt_H_IdType.Text = HolderDataRow["id_type_name"].ToString();
                        txt_H_IdNo.Text = HolderDataRow["id_no"].ToString();
                        txt_H_IdDate.Text = (HolderDataRow["id_date"] != DBNull.Value) ? DateTime.Parse(HolderDataRow["id_date"].ToString()).ToString("dd/MM/yyyy") : null;
                        txt_H_IdPlace.Text = HolderDataRow["id_place"].ToString();
                        txt_H_IdTypeId.Text = HolderDataRow["id_type"].ToString();
                        txt_H_DlgName.Text= HolderDataRow["holder_name"].ToString();
                        CurrentDelegateClass= HolderDataRow["holder_class"].ToString();
                        CurrentHolderNo = (int)HolderDataRow["holder_no"];

                        btn_Q_Next.Enabled = true;
                        //if (CurrentHolderNo > 0)
                        //{
                        //    string strsql = "SELECT count(*) cnt,sum(share_qty) shares FROM shareholders "
                        //        +" WHERE holder_no in ('"+SharedParam.SINGLE_HOLDER_CLASS+"','"+SharedParam.EMPLOYEE_HOLDER_CLASS+"') having count(*)>1";

                        //    DataTable dt2 = Db.GetDataAsDataTable(strsql, "AggregateTable", "holderno", HolderDataRow["holder_no"].ToString());
                        //    if (dt != null)
                        //    {
                        //        DataRow AggregateDataRow = dt2.Rows[0];
                        //        txt_Q_HolderCertCount.Text = AggregateDataRow["cnt"].ToString();
                        //        txt_Q_HolderSharesQty.Text = AggregateDataRow["shares"].ToString();
                        //        pnl_sharesDetails.Visible = true;
                        //    }
                        //}
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
            btn_H_Prev.Enabled = true;
            txt_H_CertNo.Text = txt_Q_CertNo.Text;
            txt_H_HolderName.Text = txt_Q_HolderName.Text;
            txt_H_ShareQty.Text = txt_Q_ShareQty.Text;
            dgvCerts.DataSource = null;
            //DataTable dt;
            //if (CurrentHolderNo > 0)
            //{
            //    dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByHolderNo", "HolderCerts", "HolderNo", CurrentHolderNo.ToString()
            //       , "HolderClass", CurrentHolderClass, "Status", "0");
            //}
            //else
            //{
            //    dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "Holders", "CertNo", txt_Q_CertNo.Text, "HolderClass", CurrentHolderClass, "status", "0");
            //}
            //if (dt != null)
            //{
            //    HolderCertsList = new List<PresentHolderCerts>();
            //    foreach (DataRow HolderCertDataRow in dt.Rows)
            //    {
            //        PresentHolderCerts PHCert =
            //            new PresentHolderCerts((int)HolderCertDataRow["share_qty"], HolderCertDataRow["cert_no"].ToString()
            //            , HolderCertDataRow["holder_name"].ToString(), HolderCertDataRow["class_name"].ToString()
            //            , HolderCertDataRow["holder_class"].ToString(), HolderCertDataRow["rowid"].ToString(), 0);
            //        CertsCount += 1;
            //        TotalShares += (int)HolderCertDataRow["share_qty"];
            //        HolderCertsList.Add(PHCert);
            //    }
            //    dgvCerts.DataSource = HolderCertsList;
            //    txtTotalCerts.Text = CertsCount.ToString("N0");
            //    txtTotalShares.Text = TotalShares.ToString("N0");
            //    dgv_ApplyStyle();
            //}
        }
        private void btn_H_Prev_Click(object sender, EventArgs e)
        {
            GoFirstPhase();
        }

        private void GoFirstPhase()
        {
            ArrangePanels("pnl_Query");
            btn_H_Prev.Enabled = false;
            btn_Q_Next.Enabled = false;
            txt_Q_CertNo.Focus();
            //NewTransaction();
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
            txt_H_ShareQty.Text = txt_Q_ShareQty.Text =
            txt_H_DlgNo.Text = txt_H_DlgDate.Text = txt_H_DlgName.Text
            = txt_H_ApprovedNo.Text = txt_H_ApprovedDate.Text = txt_H_ApprovedOrg.Text
            = txt_H_Note.Text = string.Empty;
            GoFirstPhase();
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
            dgvCerts.Columns["ShareQty"].Width = 100;
            dgvCerts.Columns["ShareQty"].DisplayIndex = 0;
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
            dgvCerts.Columns["DlgNo"].HeaderText = "رقم التوكيل";
            dgvCerts.Columns["DlgNo"].DisplayIndex = 5;
            dgvCerts.Columns["DlgNo"].Width = 60;
            dgvCerts.Columns["DlgNo"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["DlgNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["DlgDate"].HeaderText = "تاريخ التوكيل";
            dgvCerts.Columns["DlgDate"].DisplayIndex = 6;
            dgvCerts.Columns["DlgDate"].Width = 80;
            dgvCerts.Columns["DlgDate"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["DlgDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["DlgName"].HeaderText = "اسم الوكيل";
            dgvCerts.Columns["DlgName"].DisplayIndex = 7;
            dgvCerts.Columns["DlgName"].Width = 100;
            dgvCerts.Columns["DlgName"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["DlgName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCerts.Columns["ApprovedNo"].HeaderText = "رقم الاعتماد";
            dgvCerts.Columns["ApprovedNo"].DisplayIndex = 8;
            dgvCerts.Columns["ApprovedNo"].Width = 60;
            dgvCerts.Columns["ApprovedNo"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["ApprovedNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["ApprovedDate"].HeaderText = "تاريخ الاعتماد";
            dgvCerts.Columns["ApprovedDate"].DisplayIndex = 9;
            dgvCerts.Columns["ApprovedDate"].Width = 80;
            dgvCerts.Columns["ApprovedDate"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["ApprovedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["ApprovedOrg"].HeaderText = "جهة الاعتماد";
            dgvCerts.Columns["ApprovedOrg"].DisplayIndex = 10;
            dgvCerts.Columns["ApprovedOrg"].Width = 100;
            dgvCerts.Columns["ApprovedOrg"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["ApprovedOrg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCerts.Columns["Note"].HeaderText = "ملاحظات";
            dgvCerts.Columns["Note"].DisplayIndex = 12;
            dgvCerts.Columns["Note"].Width = 100;
            dgvCerts.Columns["Note"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["Note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCerts.Columns["Delegate_Type_Name"].HeaderText = "نوع التوكيل";
            dgvCerts.Columns["Delegate_Type_Name"].DisplayIndex = 11;
            dgvCerts.Columns["Delegate_Type_Name"].Width = 100;
            dgvCerts.Columns["Delegate_Type_Name"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["Delegate_Type_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCerts.Columns["IsDelagated"].HeaderText = "وكالة";
            dgvCerts.Columns["IsDelagated"].DisplayIndex = 4;
            dgvCerts.Columns["IsDelagated"].Width = 40;
            dgvCerts.Columns["IsDelagated"].DefaultCellStyle.ForeColor = Color.Black;
            dgvCerts.Columns["IsDelagated"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCerts.Columns["Reception_Type"].Visible = false;
            dgvCerts.Columns["Delegate_Type"].Visible = false;
            dgvCerts.Columns["Userid"].Visible = false;
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
            if (CheckDelegationRequiredData())
            {
                PresentHolderCertsWithDelegate DelData = new PresentHolderCertsWithDelegate(0, string.Empty, string.Empty
                      , string.Empty, string.Empty, string.Empty, 0,true, txt_H_DlgNo.Text, txt_H_DlgName.Text, DateTime.Parse(txt_H_DlgDate.Text)
                      , txt_H_ApprovedNo.Text, DateTime.Parse(txt_H_ApprovedDate.Text), txt_H_ApprovedOrg.Text, txt_H_Note.Text
                      ,coDelegateType.SelectedValue.ToString(), coDelegateType.Text, "HolderDelagate",SharedParam.CurrentUser.UserID);
                if (object.ReferenceEquals(HolderCertsList,null))
                {
                    HolderCertsList = new List<PresentHolderCertsWithDelegate>();
                }
                frm_HolderSearch frm = new frm_HolderSearch(CurrentHolderClass, true, DelData, ref HolderCertsList);
                frm.ShowDialog();
                dgvCerts.DataSource = null;
                dgvCerts.DataSource = HolderCertsList;
                dgv_ApplyStyle();
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
        bool CheckDelegationRequiredData()
        {
            if (string.IsNullOrEmpty(coDelegateType.SelectedValue.ToString()))
            {
                toolTipMessage.Show("يجب تحديد نوع التوكيل او التفويض", coDelegateType, 2000);
                coDelegateType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_DlgNo.Text))
            {
                toolTipMessage.Show("يجب ادخال رقم التوكيل او التفويض", txt_H_DlgNo, 2000);
                txt_H_DlgNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_DlgDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ التوكيل او التفويض", txt_H_DlgDate, 2000);
                txt_H_DlgDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_DlgName.Text))
            {
                toolTipMessage.Show("يجب ادخال اسم الوكيل او المفوض", txt_H_DlgName, 2000);
                txt_H_DlgName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_ApprovedNo.Text))
            {
                toolTipMessage.Show("يجب ادخال رقم إعتماد التوكيل", txt_H_ApprovedNo, 2000);
                txt_H_ApprovedNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_ApprovedDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ إعتماد التوكيل", txt_H_ApprovedDate, 2000);
                txt_H_ApprovedDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_ApprovedOrg.Text))
            {
                toolTipMessage.Show("يجب ادخال الجهة التي قامت بإعتماد التوكيل", txt_H_ApprovedOrg, 2000);
                txt_H_ApprovedOrg.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txt_H_DlgDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ التوكيل بالشكل الصحيح", txt_H_DlgDate, 2000);
                txt_H_DlgDate.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txt_H_ApprovedDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ إعتماد التوكيل بالشكل الصحيح", txt_H_ApprovedDate, 2000);
                txt_H_ApprovedDate.Focus();
                return false;
            }
            return true;
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
                toolTipMessage.Show("يجب ادخال رقم الهوية", txt_H_IdNo, 2000);
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
            
            if (string.IsNullOrEmpty(txt_H_DlgNo.Text))
            {
                toolTipMessage.Show("يجب ادخال رقم التوكيل او التفويض", txt_H_DlgNo, 2000);
                txt_H_DlgNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_DlgDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ التوكيل او التفويض", txt_H_DlgDate, 2000);
                txt_H_DlgDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_DlgName.Text))
            {
                toolTipMessage.Show("يجب ادخال اسم الوكيل او المفوض", txt_H_DlgName, 2000);
                txt_H_DlgName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_ApprovedNo.Text))
            {
                toolTipMessage.Show("يجب ادخال رقم إعتماد التوكيل", txt_H_ApprovedNo, 2000);
                txt_H_ApprovedNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_ApprovedDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ إعتماد التوكيل", txt_H_ApprovedDate, 2000);
                txt_H_ApprovedDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_H_ApprovedOrg.Text))
            {
                toolTipMessage.Show("يجب ادخال الجهة التي قامت بإعتماد التوكيل", txt_H_ApprovedOrg, 2000);
                txt_H_ApprovedOrg.Focus();
                return false;
            }
            
            if (!Utility.IsValidDate(txt_H_IdDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ اصدار الهوية بالشكل الصحيح", txt_H_IdDate, 2000);
                txt_H_IdDate.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txt_H_DlgDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ التوكيل بالشكل الصحيح", txt_H_DlgDate, 2000);
                txt_H_DlgDate.Focus();
                return false;
            }
            if (!Utility.IsValidDate(txt_H_ApprovedDate.Text))
            {
                toolTipMessage.Show("يجب ادخال تاريخ إعتماد التوكيل بالشكل الصحيح", txt_H_ApprovedDate, 2000);
                txt_H_ApprovedDate.Focus();
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
            if (TotalShares <= 0)
            {
                toolTipMessage.Show("ليس لدى المساهم اسهم", btn_Commit, 2000);
                btn_Commit.Focus();
                return false;
            }

            if (!ContainDelegation())
            {
                MessageBox.Show("لا توجد اي اسهم تم التوكيل بها ، اي لا يحتوي التوكيل على اي اسهم", "لا توجد اسهم", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }

            return true;
        }
        bool ContainDelegation()
        {
            foreach (DataGridViewRow VR in dgvCerts.Rows)
            {
                if (Boolean.Parse(VR.Cells["IsDelagated"].Value.ToString()) == true)
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_Commit_Click(object sender, EventArgs e)
        {
            if (CheckRequiredFields())
            {
                if (Config.PrintAdmissionDocument && Db.GetPrinterName(Utility.GetMACAddress()) == "N/A")
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
                        if (CurrentStepName == "new")
                        {
                            #region Create New Reception ...
                            string EntryDocNo = Db.CreateDlgReception(txt_H_CertNo.Text, int.Parse(txt_H_ShareQty.Text), CurrentDelegateClass
                                , txt_H_HolderName.Text, txt_H_IdTypeId.Text, txt_H_IdNo.Text, DateTime.Parse(txt_H_IdDate.Text)
                                , txt_H_IdPlace.Text, int.Parse(string.IsNullOrEmpty(txt_H_CardNo.Text) ? "0" : txt_H_CardNo.Text)
                                , string.Empty, SharedParam.CurrentUser.UserID, "HolderDelagate", "pending", string.Empty);
                            if (int.Parse(EntryDocNo) > 0)
                            {
                                int lineno = 0;
                                foreach (PresentHolderCertsWithDelegate tmp in HolderCertsList)
                                {
                                    int result = Db.CreateDlgReceptionDetails(int.Parse(EntryDocNo), ++lineno, tmp.CertNo, tmp.ShareQty, tmp.ClassId
                                       , tmp.IsDelagated, tmp.DlgNo, tmp.DlgDate, tmp.DlgName, tmp.ApprovedNo, tmp.ApprovedDate, tmp.ApprovedOrg
                                       , int.Parse(tmp.RowId), tmp.Note, tmp.Delegate_Type, tmp.Reception_Type, tmp.Userid);

                                }
                                if (!Db.HasData("DlgReception_Details", " Where entry_doc_no=" + EntryDocNo))
                                {
                                    Db.ExecuteSQLCommand("delete from DlgReception where entry_doc_no=" + EntryDocNo);
                                }
                                else
                                {
                                    DataTable dt = Db.GetDataAsDataTable("select isnull(count(*),0) cnt,sum(share_qty) shares from DlgReception_Details where entry_doc_no=@entrydocno"
                                        , "actual", "entrydocno", EntryDocNo);
                                    if (dt != null)
                                    {
                                        Dialogs.Dg_InfoMessage frm = new Dialogs.Dg_InfoMessage("تم الحفظ بنجاح"
                                            , EntryDocNo
                                            , (dt.Rows[0]["cnt"] == DBNull.Value ? 0 : (int)dt.Rows[0]["cnt"])
                                            , (dt.Rows[0]["shares"] == DBNull.Value ? 0 : (int)dt.Rows[0]["shares"]));
                                        frm.ShowDialog();
                                        #region Print Admission Paper ...
                                        //if (Config.PrintAdmissionDocument)
                                        //{
                                        //    string result = Db.CreatePrint(int.Parse(EntryDocNo)
                                        //     , "entry", "first_print", SharedParam.CurrentUser.UserID, "other"
                                        //     , string.Empty);
                                        //    if (result == "success")
                                        //    {

                                        //        DataTable dt2 = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
                                        //        appcode.Printable p = new Printable();
                                        //        //p.PrinterName = "PDFCreator";
                                        //        ReportParameter[] ReportParams = new ReportParameter[]
                                        //        {
                                        //new ReportParameter("EventDate",Config.EventDate),
                                        //new ReportParameter("EventYear",Config.EventYear)
                                        //        };
                                        //        //frm_Report frm2 = new frm_Report();
                                        //        //frm2.PreviewAdmissionByAgentReport(EntryDocNo, ReportParams);
                                        //        p.OnlyOnePage = true;
                                        //        p.Run(@Config.ReportsPath + "AgentAdmission.rdlc", "AddmissionDataset", dt2, ReportParams);
                                        //    }
                                        //    else
                                        //    {
                                        //        MessageBox.Show("فشلت عملية الطباعة");
                                        //    }
                                        //}
                                        #endregion
                                        NewTransaction();
                                    }
                                }
                            }
                            else
                            {

                            }
                            #endregion
                        }
                        else if (CurrentStepName == "edit")
                        {
                            #region Edit Reception ...
                            int result = Db.EditDlgReception(CurrentEntryNo, txt_H_IdTypeId.Text, txt_H_IdNo.Text, DateTime.Parse(txt_H_IdDate.Text)
                                , txt_H_IdPlace.Text, int.Parse(string.IsNullOrEmpty(txt_H_CardNo.Text) ? "0" : txt_H_CardNo.Text), string.Empty);
                            if (result == 1)
                            {
                                Db.ExecuteSQLCommand("delete from DlgReception_Details where entry_doc_no=" + CurrentEntryNo);
                                int lineno = 0;
                                foreach (PresentHolderCertsWithDelegate tmp in HolderCertsList)
                                {
                                    result = Db.CreateDlgReceptionDetails(int.Parse(CurrentEntryNo), ++lineno, tmp.CertNo, tmp.ShareQty, tmp.ClassId
                                      , tmp.IsDelagated, tmp.DlgNo, tmp.DlgDate, tmp.DlgName, tmp.ApprovedNo, tmp.ApprovedDate, tmp.ApprovedOrg
                                      , int.Parse(tmp.RowId), tmp.Note, tmp.Delegate_Type, tmp.Reception_Type, tmp.Userid);

                                }

                                DataTable dt = Db.GetDataAsDataTable("select isnull(count(*),0) cnt,sum(share_qty) shares from DlgReception_Details where entry_doc_no=@entrydocno"
                                              , "actual", "entrydocno", CurrentEntryNo);
                                if (dt != null)
                                {
                                    Dialogs.Dg_InfoMessage frm = new Dialogs.Dg_InfoMessage("تم التعديل بنجاح"
                                        , CurrentEntryNo
                                        , (dt.Rows[0]["cnt"] == DBNull.Value ? 0 : (int)dt.Rows[0]["cnt"])
                                        , (dt.Rows[0]["shares"] == DBNull.Value ? 0 : (int)dt.Rows[0]["shares"]));
                                    frm.ShowDialog();
                                    #region Print Admission Paper ...
                                    //if (Config.PrintAdmissionDocument)
                                    //{
                                    //    string result2 = Db.CreatePrint(int.Parse(CurrentEntryNo)
                                    //     , "entry", "first_print", SharedParam.CurrentUser.UserID, "other"
                                    //     , string.Empty);
                                    //    if (result2 == "success")
                                    //    {

                                    //        DataTable dt2 = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
                                    //        appcode.Printable p = new Printable();
                                    //        //p.PrinterName = "PDFCreator";
                                    //        ReportParameter[] ReportParams = new ReportParameter[]
                                    //        {
                                    //    new ReportParameter("EventDate",Config.EventDate),
                                    //    new ReportParameter("EventYear",Config.EventYear)
                                    //        };
                                    //        //frm_Report frm2 = new frm_Report();
                                    //        //frm2.PreviewAdmissionByAgentReport(EntryDocNo, ReportParams);
                                    //        p.OnlyOnePage = true;
                                    //        p.Run(@Config.ReportsPath + "AgentAdmission.rdlc", "AddmissionDataset", dt2, ReportParams);
                                    //    }
                                    //    else
                                    //    {
                                    //        MessageBox.Show("فشلت عملية الطباعة");
                                    //    }
                                    //}
                                    #endregion
                                    this.Close();
                                }
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        //MessageBox.Show("NO");
                    }

                }// Check Printer ...
            }
        }

        private void txt_H_IdNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utility.OnlyNumber(e.KeyChar, false, sender);
        }

        private void txt_H_DlgDate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidDate(txt_H_DlgDate.Text))
            {
                txt_H_DlgDate.ForeColor = Color.Black;
            }
            else
            {
                txt_H_DlgDate.ForeColor = Color.Red;
            }
        }

        private void txt_H_ApprovedDate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsValidDate(txt_H_ApprovedDate.Text))
            {
                txt_H_ApprovedDate.ForeColor = Color.Black;
            }
            else
            {
                txt_H_ApprovedDate.ForeColor = Color.Red;
            }
        }

        private void btnAddAgentCerts_Click(object sender, EventArgs e)
        {
            //if (CheckDelegationRequiredData())
            //{
                PresentHolderCertsWithDelegate DelData = new PresentHolderCertsWithDelegate(0, string.Empty, string.Empty
                      , string.Empty, string.Empty, string.Empty, 0, false, string.Empty, string.Empty, DateTime.MinValue
                      , string.Empty, DateTime.MinValue, string.Empty, string.Empty, coDelegateType.SelectedValue.ToString()
                      , string.Empty, "Holder",SharedParam.CurrentUser.UserID);
                if (object.ReferenceEquals(HolderCertsList, null))
                {
                    HolderCertsList = new List<PresentHolderCertsWithDelegate>();
                }
                frm_HolderSearch frm = new frm_HolderSearch(CurrentHolderClass, true, DelData, ref HolderCertsList);
                frm.ShowDialog();
                dgvCerts.DataSource = null;
                dgvCerts.DataSource = HolderCertsList;
                dgv_ApplyStyle();
            //}
        }
    }
}

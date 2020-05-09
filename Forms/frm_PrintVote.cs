using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_PrintVote : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        DataTable EntryDocInfo;
        bool DataLoaded = false;
        private string _OpType;
        private string _EntryDocNo;
        private string _DocType;
        public frm_PrintVote(string OpType,string EntryDocNo,string DocType)
        {
            InitializeComponent();
            _OpType = OpType;
            _EntryDocNo = EntryDocNo;
            _DocType = DocType;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_PrintVote_KeyDown(object sender, KeyEventArgs e)
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
                btn_Print_Click(sender, e);
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

        private void txt_H_IdNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Utility.OnlyNumber(e.KeyChar, false, sender);
        }

        private void frm_PrintVote_Activated(object sender, EventArgs e)
        {
            txtEntryDocNo.Focus();
        }

        void ClearData()
        {
            txtClassName.Text = txtHolderName.Text = txtCertCount.Text = txtShares.Text = string.Empty;
            DataLoaded = false;
            btn_Print.Enabled = DataLoaded;
        }
        void LoadData(string EntryDocNo)
        {
            ClearData();
            EntryDocInfo = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            if (EntryDocInfo != null)
            {if (EntryDocInfo.Rows[0]["status"].ToString()=="post")
                {
                    if (int.Parse(EntryDocInfo.Rows[0]["TotalShareQty"].ToString()) > 0)
                    {
                        DataRow dr = EntryDocInfo.Rows[0];
                        string hc = dr["DetailsClass"].ToString();
                        int pt = Db.PrintedTimes(int.Parse(EntryDocNo), "all");
                        if (dr["DetailsClass"].ToString() == SharedParam.SINGLE_HOLDER_CLASS
                            && SharedParam.CurrentUser.HasSingleHolderClass
                            && (_OpType == "first_print" ? Db.PrintedTimes(int.Parse(EntryDocNo), _DocType) == 0 : true))
                        {
                            txtEntryDocNo.Text = dr["Entry_doc_no"].ToString();
                            txtClassName.Text = dr["DetailsClassName"].ToString();
                            txtHolderName.Text = dr["holder_name"].ToString();
                            txtCertCount.Text = dr["CertCount"].ToString();
                            txtShares.Text = dr["TotalShareQty"].ToString();
                            DataLoaded = true;
                            btn_Print.Enabled = DataLoaded;
                        }
                        else if (dr["DetailsClass"].ToString() == SharedParam.EMPLOYEE_HOLDER_CLASS
                          && SharedParam.CurrentUser.HasEmployeeHolderClass
                          && (_OpType == "first_print" ? Db.PrintedTimes(int.Parse(EntryDocNo), _DocType) == 0 : true))
                        {
                            txtEntryDocNo.Text = dr["Entry_doc_no"].ToString();
                            txtClassName.Text = dr["DetailsClassName"].ToString();
                            txtHolderName.Text = dr["holder_name"].ToString();
                            txtCertCount.Text = dr["CertCount"].ToString();
                            txtShares.Text = dr["TotalShareQty"].ToString();
                            DataLoaded = true;
                            btn_Print.Enabled = DataLoaded;
                        }
                        else if (dr["DetailsClass"].ToString() == SharedParam.COMPANY_HOLDER_CLASS
                            && SharedParam.CurrentUser.HasCompanyHolderClass
                            && (_OpType == "first_print" ? Db.PrintedTimes(int.Parse(EntryDocNo), _DocType) == 0 : true))
                        {
                            txtEntryDocNo.Text = dr["Entry_doc_no"].ToString();
                            txtClassName.Text = dr["DetailsClassName"].ToString();
                            txtHolderName.Text = dr["holder_name"].ToString();
                            txtCertCount.Text = dr["CertCount"].ToString();
                            txtShares.Text = dr["TotalShareQty"].ToString();
                            DataLoaded = true;
                            btn_Print.Enabled = DataLoaded;
                        }
                        else if (dr["DetailsClass"].ToString() == SharedParam.FOUNDER_HOLDER_CLASS
                            && SharedParam.CurrentUser.HasFounderHolderClass
                            && (_OpType == "first_print" ? Db.PrintedTimes(int.Parse(EntryDocNo), _DocType) == 0 : true))
                        {
                            txtEntryDocNo.Text = dr["Entry_doc_no"].ToString();
                            txtClassName.Text = dr["DetailsClassName"].ToString();
                            txtHolderName.Text = dr["holder_name"].ToString();
                            txtCertCount.Text = dr["CertCount"].ToString();
                            txtShares.Text = dr["TotalShareQty"].ToString();
                            DataLoaded = true;
                            btn_Print.Enabled = DataLoaded;
                        }
                        else
                        {
                            string msg = "لا توجد بيانات  قد يكون احدى الاسباب التالية : " + Environment.NewLine
                                + "- ليس لديك الصلاحية الكافية لطباعة ورقة اقتراع لفئة" + dr["DetailsClassName"].ToString() + Environment.NewLine
                                + "- قد تمت الطباعة مسبقا و للتاكد من ذلك عبر شاشة الاستعلام عن اوراق الاقتراع المطبوعة";
                            Dialogs.Dg_Info frm = new Dialogs.Dg_Info(msg);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        string msg = "بطاقة الحضور لا تزال قيد المراجعة " + Environment.NewLine
                                + "يرجى اعتماد البطاقة قبل طباعتها";
                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info(msg);
                        frm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("لا توجد بيانات", "طباعة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void txtEntryDocNo_TextChanged(object sender, EventArgs e)
        {
            ClearData();
        }
        private void txtEntryDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (_OpType == "first_print")
                {
                    LoadData(txtEntryDocNo.Text);
                }
                else if (_OpType == "reprint")
                {
                    if (Db.HasRight(SharedParam.CurrentUser.RoleId,5,1, "ReprintVotePaper"))
                    {
                        LoadData(txtEntryDocNo.Text);
                    }
                    else
                    {
                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("ليس لديك الصلاحية الكافية");
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (Db.GetPrinterName(Utility.GetMACAddress()) == "N/A")
            {
                MessageBox.Show("لم يتم تحديد الطابعة التي سيتم عبرها طباعة بطاقة الدخول", "خطأ"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
            }
            else
            {
                //var CandidateCount = Db.isHolderClassHasCandidates(EntryDocInfo.Rows[0]["DetailsClass"].ToString());
                //if (!CandidateCount)
                //{
                //    MessageBox.Show("لا يمكن طباعة ورقة الاقتراع لهذه لفئة  " + txtClassName.Text + Environment.NewLine  + " نظرا لعدم وجود مرشحين"
                //                             , "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                //    return;
                //}
                string Msg = string.Empty;
                if (_OpType == "first_print")
                {
                    Msg = "هل تريد بالتأكيد طباعة ورقة الاقتراع؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد الحفظ.";
                }
                else if (_OpType == "reprint")
                {
                    if (_DocType == "vote")
                    {
                        Msg = "هل تريد بالتأكيد إعادة طباعة ورقة الاقتراع؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد الحفظ.";
                    }
                    else if (_DocType == "entry")
                    {
                        Msg = "هل تريد بالتأكيد إعادة طباعة بطاقة الحضور؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد الحفظ.";
                    }
                }
                if (new Dialogs.Dg_ComfirmMessage("طباعة ورقة اقتراع", Msg).MessageResult() == DialogResult.Yes)
                {
                    #region Confirm to print ...
                    if ((_DocType == "vote") &&
                        (Db.PrintedTimes(int.Parse(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString()), "entry") == 0))
                    {
                        MessageBox.Show("لم يتم طباعة بطاقة الدخول بعد"+Environment.NewLine+ Environment.NewLine+" يجب اولا طباعة بطاقة الدخول (الحضور) ثم طباعة ورقة الاقتراع"
                                             , "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
                    }
                    else
                    {
                        if (_OpType == "first_print")
                        {

                            if (Db.PrintedTimes(int.Parse(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString()), _DocType) < Config.MaxVotePaperPrintTimes)
                            {
                                if (DataLoaded)
                                {
                                    string result = Db.CreatePrint(int.Parse(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString())
                                    , _DocType, "first_print", SharedParam.CurrentUser.UserID, "other", string.Empty);
                                    if (result == "success")
                                    {
                                        PrintToPrinter(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString()
                                            , EntryDocInfo.Rows[0]["DetailsClass"].ToString()
                                            , EntryDocInfo.Rows[0]["TotalShareQty"].ToString()
                                            , EntryDocInfo.Rows[0]["DetailsClassName"].ToString());
                                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تمت عملية الطباعة بنجاح ");
                                        frm.ShowDialog();
                                        ClearData();

                                    }
                                    else
                                    {
                                        MessageBox.Show("فشلت عملية الطباعة");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("لا توجد بيانات");
                                }
                            }
                            else
                            {
                                MessageBox.Show("عدد مرات طباعة ورقة الاقتراع تجاوز الحد الاقصى المسموح به");
                            }
                        }
                        else if (_OpType == "reprint")
                        {
                            if (_DocType == "vote")
                            {
                                if (!Db.HasRight(SharedParam.CurrentUser.RoleId, 5, 1, "ReprintVotePaper"))
                                {
                                    MessageBox.Show("ليس لديك الصلاحية الكافية");
                                    return;
                                }
                            }
                            else if (_DocType == "entry")
                            {
                                if (!Db.HasRight(SharedParam.CurrentUser.RoleId, 1, 3, "ReprintEntryDoc"))
                                {
                                    MessageBox.Show("ليس لديك الصلاحية الكافية");
                                    return;
                                }
                            }

                            bool PrintTimesExceeded = false;
                            int PrintedTimes = Db.PrintedTimes(int.Parse(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString()), _DocType);
                            PrintTimesExceeded = PrintedTimes >= (_DocType == "vote" ? Config.MaxVotePaperPrintTimes : Config.MaxEntryDocPrintTimes);
                            if (!PrintTimesExceeded)
                            {
                                if (coreason.SelectedValue.ToString() == "other")
                                {
                                    if (string.IsNullOrEmpty(txtReason.Text))
                                    {
                                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال السبب");
                                        frm.ShowDialog();
                                        return;
                                    }
                                }
                                if (DataLoaded)
                                {
                                    string result = string.Empty;
                                    if (PrintedTimes == 0)
                                    {
                                        result = Db.CreatePrint(int.Parse(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString())
                                                                , _DocType, "first_print", SharedParam.CurrentUser.UserID
                                                                , "other"
                                                                , txtReason.Text);
                                    }
                                    else
                                    {
                                        result = Db.CreatePrint(int.Parse(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString())
                                                    , _DocType, "reprint", SharedParam.CurrentUser.UserID, coreason.SelectedValue.ToString()
                                                    , txtReason.Text);
                                    }
                                    if (result == "success")
                                    {
                                        PrintToPrinter(EntryDocInfo.Rows[0]["Entry_doc_no"].ToString()
                                            , EntryDocInfo.Rows[0]["DetailsClass"].ToString()
                                            , EntryDocInfo.Rows[0]["TotalShareQty"].ToString()
                                            , EntryDocInfo.Rows[0]["DetailsClassName"].ToString());
                                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تمت عملية إعادة الطباعة بنجاح ");
                                        frm.ShowDialog();
                                        ClearData();
                                        if (!string.IsNullOrEmpty(_EntryDocNo))
                                        {
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("فشلت عملية إعادة الطباعة");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("لا توجد بيانات");
                                }
                            }
                            else
                            {
                                MessageBox.Show("عدد مرات الطباعة تجاوز الحد الاقصى المسموح به");
                            }
                        }
                    }
                    #endregion
                }
            } // Check Printer ...
        }
        void PrintToPrinter(string EntryDocNo,string candclass,string shares,string classname)
        {
            if (_DocType == "vote")
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
                p.Run(@Config.ReportsPath  + "VotePaper.rdlc", "DataSet1", dt, ReportParams);
            }
            else if (_DocType=="entry")
            {
                DataTable dt2 = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
                appcode.Printable p = new Printable();
                //p.PrinterName = "PDFCreator";
                ReportParameter[] ReportParams = new ReportParameter[]
                {
                                    new ReportParameter("EventDate",Config.EventDate),
                                    new ReportParameter("EventYear",Config.EventYear),
                                    new ReportParameter("EventName",Config.EventName)
                };
                p.OnlyOnePage = true;
                //if (int.Parse(dt2.Rows[0]["TotalHolderDelagateSharesQty"].ToString()) > 0)
                //{
                    p.Run(@Config.ReportsPath + "AgentAdmission2.rdlc", "AddmissionDataset", dt2, ReportParams);
                //}
                //else
                //{
                //    p.Run(@Config.ReportsPath + "SelfAdmission.rdlc", "AdmissionDataset", dt2, ReportParams);
                //}
            }
        }

        private void frm_PrintVote_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            if (_OpType == "first_print")
            {
                this.Size= new System.Drawing.Size(693, 354);
                lblreason.Visible = false;
                lblreasonid.Visible = false;
                coreason.Visible = false;
                txtReason.Visible = false;
                btn_Print.Text = "طباعة (F10)";
            }
            else if (_OpType == "reprint")
            {
                this.Size = new System.Drawing.Size(693, 460);
                lblreason.Visible = true;
                lblreasonid.Visible = true;
                coreason.Visible = true;
                txtReason.Visible = true;
                btn_Print.Text = "إعادة الطباعة (F10)";
                PopulateReasonList();
            }
            
            if (_DocType== "vote" && !string.IsNullOrEmpty(_EntryDocNo))
            {
                lblTitle.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  طباعة ورقة الاقتراع";
                LoadData(_EntryDocNo);
            }
            else if (_DocType == "entry" && !string.IsNullOrEmpty(_EntryDocNo))
            {
                lblTitle.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  طباعة بطاقة دخول";
                LoadData(_EntryDocNo);
            }
        }
        void PopulateReasonList()
        {
            string strsql = "SELECT [print_reason_id],[print_reason] FROM [dbo].[Print_Reason] ORDER BY [print_reason_order]";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coreason.DataSource = dt;
                coreason.DisplayMember = "print_reason";
                coreason.ValueMember = "print_reason_id";
            }
        }

        private void coreason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coreason.SelectedValue.ToString()== "other")
            {
                txtReason.Enabled = true;
            }
            else
            {
                txtReason.Text = string.Empty;
                txtReason.Enabled = false;
            }
        }
    }
}

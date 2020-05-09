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
    public partial class frm_CandCertChecking : Form
    {
        public string Answer { get; set; }
        public string AnswerCertNo { get; set; }
        public string AnswerHolderClassId { get; set; }

        public int AnswerHolderNo { get; set; }

        public frm_CandCertChecking()
        {
            InitializeComponent();
        }

        void ClearTextBoxes()
        {
            txtHolderName.Text = txtClassName.Text = txtShares.Text = txtCertsCount.Text = txtTotalShares.Text = string.Empty;
            txtMessage.Text= Answer=AnswerCertNo=AnswerHolderClassId = string.Empty;
            btnNext.Enabled = false;
            AnswerHolderNo = 0;
        }
        private void txtCertNo_TextChanged(object sender, EventArgs e)
        {
            ClearTextBoxes();
            if (appcode.Utility.ValidRegEx(txtCertNo.Text, "^[0-9]{3}-[0-9]{6}")
               ||
               appcode.Utility.ValidRegEx(txtCertNo.Text, "^[0-9]{6}-[0-9]{3}"))
            {
                txtCertNo.ForeColor = Color.Green;
                DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetHoldersByCert", "Holders", "CertNo", txtCertNo.Text, "HolderClass", "all", "status", "-1");
                if (dt != null)
                {
                    DataRow HolderDataRow = dt.Rows[0];
                    if (int.Parse(HolderDataRow["share_qty"].ToString())>0)
                    {
                      if (Db.HasData("candidate_certs", " WHERE cert_no='"+ txtCertNo.Text + "'")== false)
                        {
                            txtHolderName.Text = HolderDataRow["holder_name"].ToString();
                            txtShares.Text = HolderDataRow["share_qty"].ToString();
                            txtClassName.Text = HolderDataRow["class_name"].ToString();
                            if (int.Parse(HolderDataRow["holder_no"].ToString()) > 0)
                            {
                                string strsql = "SELECT ISNULL(COUNT(*),0) CertCnt,ISNULL(SUM(share_qty),0) Shares "
                                    + "FROM shareholders WHERE status<>5 and holder_no=" + HolderDataRow["holder_no"].ToString();
                                DataTable dt2 = Db.GetDataAsDataTable(strsql);
                                if (dt2!=null)
                                {
                                    txtCertsCount.Text = dt2.Rows[0]["CertCnt"].ToString();
                                    txtTotalShares.Text = dt2.Rows[0]["Shares"].ToString();
                                }
                            }
                            else
                            {
                                txtCertsCount.Text = "1";
                                txtTotalShares.Text = HolderDataRow["share_qty"].ToString();
                            }
                            Answer = "data";
                            AnswerCertNo = HolderDataRow["cert_no"].ToString();
                            AnswerHolderClassId = HolderDataRow["holder_class"].ToString();
                            AnswerHolderNo= int.Parse( HolderDataRow["holder_no"].ToString());
                            btnNext.Enabled = true;
                        }
                        else
                        {
                            txtMessage.Text = "شهادة سبق ادخالها لمرشح اخر";
                        }
                    }
                    else
                    {
                        txtMessage.Text = "شهادة منتهية";
                    }
                }
                else
                {
                    txtMessage.Text = "شهادة غير موجودة";
                }
            }
            else
            {
                txtCertNo.ForeColor = Color.Red;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Answer = "close";
            this.Close();
        }

        private void frm_CandCertChecking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                btn_close_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frm_CandCertChecking_Activated(object sender, EventArgs e)
        {
            txtCertNo.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

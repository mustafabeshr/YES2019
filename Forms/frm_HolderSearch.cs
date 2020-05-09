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
    public partial class frm_HolderSearch : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private string _Holder_Class;
        private bool _isDelegate = false;
        PresentHolderCertsWithDelegate _Delagate_Data;
        
        private List<PresentHolderCertsWithDelegate> _CertList;
        public frm_HolderSearch(string HolderClass,bool isDelegate,PresentHolderCertsWithDelegate DelegateData,ref List<PresentHolderCertsWithDelegate> CertList)
        {
            InitializeComponent();
            _Holder_Class = HolderClass;
            _isDelegate = isDelegate;
            _CertList = CertList;
            _Delagate_Data =  DelegateData;
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_HolderSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            if (e.KeyCode==Keys.F9)
            {
                btn_Query_Click(sender, e);
            }
        }

        private void ch_IncludebyHolderNo_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_IncludebyHolderNo.Checked)
            {
                ch_IncludebyHolderNo.ForeColor = Color.Blue;
            }
            else
            {
                ch_IncludebyHolderNo.ForeColor = Color.Black;
            }
        }

        private void ch_ExcludePresents_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ExcludePresents.Checked)
            {
                ch_ExcludePresents.ForeColor = Color.Blue;
            }
            else
            {
                ch_ExcludePresents.ForeColor = Color.Black;
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
            LoadHoldersData();
        }

        private void LoadHoldersData()
        {
            StringBuilder strsql;
            List<string> parameters;
            BuildSQLCommand(out strsql, out parameters, 0);
            DataTable dt = Db.GetDataAsDataTable(strsql.ToString(), "holder", parameters.ToArray());
            if (ch_IncludebyHolderNo.Checked && dt != null)
            {
                DataRow dr = dt.Rows[0];
                if ((int)dr["holder_no"] > 0)
                {
                    strsql.Clear();
                    parameters.Clear();
                    BuildSQLCommand(out strsql, out parameters, (int)dr["holder_no"]);
                    dt = Db.GetDataAsDataTable(strsql.ToString(), "holder", parameters.ToArray());
                }
            }
            dgvCerts.DataSource = dt;
            dgv_ApplyStyle();
            txt_CertCount.Text = dgvCerts.RowCount.ToString("N0");
        }

        private void BuildSQLCommand(out StringBuilder strsql, out List<string> parameters,int holderno)
        {
            bool ActiveCertNoParameter = false;
            bool ActiveHolderNameParameter = false;
            bool ActiveIdNoParameter = false;
            bool ActiveHolderNoParameter = false;
            strsql = new StringBuilder();
            strsql.Append("SELECT TOP 300 cert_no,holder_name,share_qty,id_type_name,id_no,id_date,id_place"
                        + ", status_name, status_date, gender_name,"
                        + "entry_card_no, entry_doc_no,class_name, note, holder_no,status, rowid, id_type, holder_class"
                        + "  FROM [dbo].[v_Holders] where holder_class=@holderclass ");
            StringBuilder WhereClause = new StringBuilder();
            if (!string.IsNullOrEmpty(txt_CertNo.Text))
            {
                if (holderno > 0)
                {
                    WhereClause.Append(" and ((cert_no like '%' + @certno + '%') OR (holder_no=@holderno))");
                    ActiveHolderNoParameter = true;
                }
                else
                {
                    WhereClause.Append(" and cert_no like '%' + @certno + '%'");
                }
                ActiveCertNoParameter = true;
            }
            if (!string.IsNullOrEmpty(txt_HolderName.Text))
            {
                WhereClause.Append(" and holder_name like '%'+ @holdername +'%'");
                ActiveHolderNameParameter = true;
            }
            if (!string.IsNullOrEmpty(txt_IdNo.Text))
            {
                WhereClause.Append(" and id_no like '%'+ @idno +'%'");
                ActiveIdNoParameter = true;
            }
            if (holderno > 0)
            {
                WhereClause.Append(" and (holder_no=@holderno) ");
                ActiveHolderNoParameter = true;
            }
            if (ch_ExcludePresents.Checked)
            {
                WhereClause.Append(" and status=0 ");
                string presecntcert = string.Empty;
                foreach (PresentHolderCerts item in _CertList)
                {
                    if (string.IsNullOrEmpty(presecntcert))
                    {
                        presecntcert = "'" + item.CertNo + "'";
                    }
                    else
                    {
                        presecntcert += ",'" + item.CertNo + "'";
                    }
                }
                if (!string.IsNullOrEmpty(presecntcert))
                {
                    WhereClause.Append(" and cert_no not in (" + presecntcert + ")");
                }
            }
            parameters = new List<string>();
            parameters.Add("holderclass");
            parameters.Add(_Holder_Class);
            if (ActiveCertNoParameter)
            {
                parameters.Add("certno");
                parameters.Add(txt_CertNo.Text);
            }
            if (ActiveHolderNameParameter)
            {
                parameters.Add("holdername");
                parameters.Add(txt_HolderName.Text);
            }
            if (ActiveIdNoParameter)
            {
                parameters.Add("idno");
                parameters.Add(txt_IdNo.Text);
            }
            if (ActiveHolderNoParameter && holderno>0)
            {
                parameters.Add("holderno");
                parameters.Add(holderno.ToString());
            }
            strsql.Append(WhereClause.ToString());
        }

        private void btn_Query_MouseHover(object sender, EventArgs e)
        {
            btn_Query.FlatAppearance.BorderColor = Color.Red;
        }

        private void btn_Query_MouseLeave(object sender, EventArgs e)
        {
            btn_Query.FlatAppearance.BorderColor = Color.DarkGoldenrod;
        }

        private void dgv_ApplyStyle()
        {
            if (dgvCerts.RowCount <= 0) return;
            try
            {
                int ColDisplayOrder = 0;
                dgvCerts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["select"].HeaderText = "تحديد";
                dgvCerts.Columns["select"].DisplayIndex = ColDisplayOrder;
                dgvCerts.Columns["select"].Width = 50;
                dgvCerts.Columns["select"].ReadOnly = false;
                dgvCerts.Columns["select"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["cert_no"].HeaderText = "رقم الشهادة";
                dgvCerts.Columns["cert_no"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["cert_no"].Width = 90;
                dgvCerts.Columns["cert_no"].ReadOnly = true;
                dgvCerts.Columns["cert_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["cert_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["holder_name"].HeaderText = "اسم المساهم";
                dgvCerts.Columns["holder_name"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["holder_name"].Width = 200;
                dgvCerts.Columns["holder_name"].ReadOnly = true;
                dgvCerts.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvCerts.Columns["share_qty"].HeaderText = "عدد الاسهم";
                dgvCerts.Columns["share_qty"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["share_qty"].Width = 70;
                dgvCerts.Columns["share_qty"].ReadOnly = true;
                dgvCerts.Columns["share_qty"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["share_qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["id_type_name"].HeaderText = "نوع الهوية";
                dgvCerts.Columns["id_type_name"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["id_type_name"].Width = 90;
                dgvCerts.Columns["id_type_name"].ReadOnly = true;
                dgvCerts.Columns["id_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["id_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["id_no"].HeaderText = "رقمها";
                dgvCerts.Columns["id_no"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["id_no"].Width = 100;
                dgvCerts.Columns["id_no"].ReadOnly = true;
                dgvCerts.Columns["id_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["id_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["id_date"].HeaderText = "تاريخها";
                dgvCerts.Columns["id_date"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["id_date"].Width = 80;
                dgvCerts.Columns["id_date"].ReadOnly = true;
                dgvCerts.Columns["id_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["id_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["id_place"].HeaderText = "مكان الاصدار";
                dgvCerts.Columns["id_place"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["id_place"].Width = 100;
                dgvCerts.Columns["id_place"].ReadOnly = true;
                dgvCerts.Columns["id_place"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["id_place"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["status_name"].HeaderText = "الحالة";
                dgvCerts.Columns["status_name"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["status_name"].Width = 70;
                dgvCerts.Columns["status_name"].ReadOnly = true;
                dgvCerts.Columns["status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["status_date"].HeaderText = "تاريخ الحالة";
                dgvCerts.Columns["status_date"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["status_date"].Width = 120;
                dgvCerts.Columns["status_date"].ReadOnly = true;
                dgvCerts.Columns["status_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["status_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["gender_name"].HeaderText = "الجنس";
                dgvCerts.Columns["gender_name"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["gender_name"].Width = 60;
                dgvCerts.Columns["gender_name"].ReadOnly = true;
                dgvCerts.Columns["gender_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["gender_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["entry_card_no"].HeaderText = "رقم الكرت";
                dgvCerts.Columns["entry_card_no"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["entry_card_no"].Width = 50;
                dgvCerts.Columns["entry_card_no"].ReadOnly = true;
                dgvCerts.Columns["entry_card_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["entry_card_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["entry_doc_no"].HeaderText = "رقم الحضور";
                dgvCerts.Columns["entry_doc_no"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["entry_doc_no"].Width = 60;
                dgvCerts.Columns["entry_doc_no"].ReadOnly = true;
                dgvCerts.Columns["entry_doc_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["entry_doc_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["class_name"].HeaderText = "الفئة";
                dgvCerts.Columns["class_name"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["class_name"].Width = 60;
                dgvCerts.Columns["class_name"].ReadOnly = true;
                dgvCerts.Columns["class_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["class_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["note"].HeaderText = "ملاحظات";
                dgvCerts.Columns["note"].DisplayIndex = ++ColDisplayOrder;
                dgvCerts.Columns["note"].Width = 300;
                dgvCerts.Columns["note"].ReadOnly = true;
                dgvCerts.Columns["note"].DefaultCellStyle.ForeColor = Color.Black;
                dgvCerts.Columns["note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCerts.Columns["holder_no"].Visible = false;
                dgvCerts.Columns["status"].Visible = false;
                dgvCerts.Columns["rowid"].Visible = false;
                dgvCerts.Columns["id_type"].Visible = false;
                dgvCerts.Columns["holder_class"].Visible = false;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("ArgumentOutOfRangeException Error !");
            }
        }

        private void dgvCerts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex==0 && e.RowIndex>=0)
            //{
            //    if (Boolean.Parse(dgvCerts[0, e.RowIndex].Value.ToString())==true)
            //    {
            //        dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //    }
            //}
        }

        private void dgvCerts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //    {
            //        if (Boolean.Parse(dgvCerts[0, e.RowIndex].Value.ToString()) == true)
            //        {
            //            dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            //        }
            //        else
            //        {
            //            dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //        }
            //    }
            //}
            //catch { }
        }

        private void dgvCerts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvCerts.Columns[e.ColumnIndex].Name == "select" && e.RowIndex >= 0)
                {
                    if (Boolean.Parse(dgvCerts["select", e.RowIndex].Value.ToString()) == true)
                    {
                        dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGreen;
                        dgvCerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dgvCerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            catch { }
        }

        private void btn_selectall_Click(object sender, EventArgs e)
        {
            for (int i=0;i<dgvCerts.Rows.Count;++i)
            {
                dgvCerts["select", i].Value = true;
            }
        }

        private void btn_deselectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCerts.Rows.Count; ++i)
            {
                dgvCerts["select", i].Value = false; 
            }
        }

        private void btn_inverseSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCerts.Rows.Count; ++i)
            {
               if (DBNull.Equals(dgvCerts["select", i].Value, null) ||
                    Boolean.Parse(dgvCerts["select", i].Value.ToString())== true)
                {
                    dgvCerts["select", i].Value = false;
                }
               else
                {
                    dgvCerts["select", i].Value = true;
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            AddCertsToList();
            this.Close();
       }

        private void btn_addtolist_Click(object sender, EventArgs e)
        {
            AddCertsToList();
        }

        private void AddCertsToList()
        {
            int shares = 0;
            string CertNo = string.Empty;
            string HolderName = string.Empty;
            string ClassName = string.Empty;
            string ClassId = string.Empty;
            string RowId = string.Empty;
            

            for (int i = 0; i < dgvCerts.Rows.Count; ++i)
            {
                if (!DBNull.Equals(dgvCerts["select", i].Value, null) &&
                    Boolean.Parse(dgvCerts["select", i].Value.ToString()) == true)
                {
                    shares = (int)dgvCerts["share_qty", i].Value;
                    CertNo = dgvCerts["cert_no", i].Value.ToString();
                    HolderName = dgvCerts["holder_name", i].Value.ToString();
                    ClassName = dgvCerts["class_name", i].Value.ToString();
                    ClassId = dgvCerts["holder_class", i].Value.ToString();
                    RowId = dgvCerts["rowid", i].Value.ToString();
                    if (shares > 0 && dgvCerts["status",i].Value.ToString()=="0")
                    {
                        PresentHolderCertsWithDelegate tmp = new PresentHolderCertsWithDelegate(shares, CertNo, HolderName, ClassName, ClassId, RowId, 0
                            , _Delagate_Data.IsDelagated,_Delagate_Data.DlgNo,_Delagate_Data.DlgName,_Delagate_Data.DlgDate,_Delagate_Data.ApprovedNo
                            ,_Delagate_Data.ApprovedDate,_Delagate_Data.ApprovedOrg,_Delagate_Data.Note, _Delagate_Data.Delegate_Type
                            , _Delagate_Data.Delegate_Type_Name, _Delagate_Data.Reception_Type, SharedParam.CurrentUser.UserID);
                        if (!object.ReferenceEquals(_CertList,null))
                        {
                            PresentHolderCertsWithDelegate tmp2 = _CertList.Find(t => t.CertNo == CertNo);
                            if (tmp2 == null)
                            {
                                _CertList.Add(tmp);
                            }
                        }
                        else
                        {
                            _CertList = new List<PresentHolderCertsWithDelegate>();
                            _CertList.Add(tmp);
                        }
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm_shareholders frm = new frm_shareholders();
            frm.ShowDialog();
        }

        private void frm_HolderSearch_Load(object sender, EventArgs e)
        {
            ch_ExcludePresents.Checked = true;
        }

        private void mnuHolderCerts_Click(object sender, EventArgs e)
        {
            txt_CertNo.Text = dgvCerts["cert_no", dgvCerts.CurrentRow.Index].Value.ToString();
            txt_HolderName.Text = txt_IdNo.Text = string.Empty;
            ch_IncludebyHolderNo.Checked = true;
            ch_ExcludePresents.Checked = true;
            LoadHoldersData();
        }

        private void mnuSameName_Click(object sender, EventArgs e)
        {
            txt_CertNo.Text = string.Empty;
            txt_IdNo.Text = string.Empty;
            txt_HolderName.Text = dgvCerts["holder_name", dgvCerts.CurrentRow.Index].Value.ToString();
            ch_IncludebyHolderNo.Checked = false;
            ch_ExcludePresents.Checked = true;
            LoadHoldersData();
        }
    }
}

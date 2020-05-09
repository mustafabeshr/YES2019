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
    public partial class frm_shareholders : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_shareholders()
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

        private void frm_shareholders_KeyDown(object sender, KeyEventArgs e)
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

        private void frm_shareholders_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateLists();
        }
        void PopulateLists()
        {
            //string strsql = "SELECT * from "+  Environment.NewLine
            //    +"(" + Environment.NewLine
            //    + "select 'all' class_id,N'الـكــل' class_name ,-1 class_order" + Environment.NewLine
            //    + " UNION ALL" + Environment.NewLine
            //    + "select class_id,class_name,class_order from holder_class where has_Candidate=1 " + Environment.NewLine
            //    + ") v  " + Environment.NewLine
            //    + " ORDER BY v.class_order" ;
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetUserClass","users", "@userid",SharedParam.CurrentUser.UserID);
            if (dt != null)
            {
                coClass.DataSource = dt;
                coClass.DisplayMember = "class_name";
                coClass.ValueMember = "class_id";
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

        private void BuildSQLCommand(out StringBuilder strsql, out List<string> parameters, int holderno)
        {
            dgv_Holders.DataSource = null;
            txtTotalShares.Text = "0";
            txtCertCount.Text = "0";
            bool ActiveCertNoParameter = false;
            bool ActiveHolderNameParameter = false;
            bool ActiveIdNoParameter = false;
            bool ActiveHolderNoParameter = false;
            bool ActiveHolderClassParameter = false;
            strsql = new StringBuilder();
            strsql.Append("SELECT TOP 1000 cert_no,holder_name,share_qty,id_type_name,id_no,id_date,id_place"
                        + ",class_name,gender_name,entry_doc_no, status_name, status_date, "
                        + "entry_card_no,note, holder_no,status, rowid, id_type, holder_class"
                        + "  FROM [dbo].[v_Holders] ");
            StringBuilder WhereClause = new StringBuilder();
            if (!string.IsNullOrEmpty(txtCertNo.Text))
            {
                if (holderno > 0)
                {
                    WhereClause.Append(" WHERE ((cert_no like '%' + @certno + '%') OR (holder_no=@holderno))");
                    ActiveHolderNoParameter = true;
                }
                else
                {
                    WhereClause.Append(" WHERE cert_no like '%' + @certno + '%'");
                }
                ActiveCertNoParameter = true;
            }
            if (!string.IsNullOrEmpty(txtHolderName.Text))
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause.Append(" and holder_name like '%'+ @holdername +'%'");
                }
                else
                {
                    WhereClause.Append(" WHERE holder_name like '%'+ @holdername +'%'");
                }
                ActiveHolderNameParameter = true;
            }
            if (coClass.SelectedValue.ToString()!="all")
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause.Append(" and [holder_class] = @holderclass");
                }
                else
                {
                    WhereClause.Append(" WHERE  [holder_class] = @holderclass");
                }
                ActiveHolderClassParameter = true;
            }
            else
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause.Append(" AND [holder_class] IN ("+SharedParam.CurrentUser.HolderClassIdsList+")");
                }
                else
                {
                    WhereClause.Append(" WHERE  [holder_class] IN (" + SharedParam.CurrentUser.HolderClassIdsList + ")");
                }
            }

            if (!string.IsNullOrEmpty(txtIdNo.Text))
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause.Append(" and id_no like '%'+ @idno +'%'");
                }
                else
                {
                    WhereClause.Append(" WHERE id_no like '%'+ @idno +'%'");
                }
                ActiveIdNoParameter = true;
            }
            if (holderno > 0)
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause.Append(" and (holder_no=@holderno) ");
                }
                else
                {
                    WhereClause.Append(" WHERE (holder_no=@holderno) ");
                }
                ActiveHolderNoParameter = true;
            }
            //if (ch_ExcludePresents.Checked)
            //{
            //    WhereClause.Append(" and status=0 ");
            //    string presecntcert = string.Empty;
            //    foreach (PresentHolderCerts item in _CertList)
            //    {
            //        if (string.IsNullOrEmpty(presecntcert))
            //        {
            //            presecntcert = "'" + item.CertNo + "'";
            //        }
            //        else
            //        {
            //            presecntcert += ",'" + item.CertNo + "'";
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(presecntcert))
            //    {
            //        WhereClause.Append(" and cert_no not in (" + presecntcert + ")");
            //    }
            //}
            parameters = new List<string>();
            if (ActiveCertNoParameter)
            {
                parameters.Add("certno");
                parameters.Add(txtCertNo.Text);
            }
            if (ActiveHolderClassParameter)
            {
                parameters.Add("holderclass");
                parameters.Add(coClass.SelectedValue.ToString());
            }
            if (ActiveHolderNameParameter)
            {
                parameters.Add("holdername");
                parameters.Add(txtHolderName.Text);
            }
            if (ActiveIdNoParameter)
            {
                parameters.Add("idno");
                parameters.Add(txtIdNo.Text);
            }
            if (ActiveHolderNoParameter && holderno > 0)
            {
                parameters.Add("holderno");
                parameters.Add(holderno.ToString());
            }
            strsql.Append(WhereClause.ToString());
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
            dgv_Holders.DataSource = dt;
            dgv_ApplyStyle();
            txtCertCount.Text = dgv_Holders.RowCount.ToString("N0");
        }

        private void dgv_ApplyStyle()
        {
            if (dgv_Holders.RowCount <= 0) return;
            try
            {
                int ColDisplayOrder = 0;
                dgv_Holders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["cert_no"].HeaderText = "رقم الشهادة";
                dgv_Holders.Columns["cert_no"].DisplayIndex = ColDisplayOrder;
                dgv_Holders.Columns["cert_no"].Width = 90;
                dgv_Holders.Columns["cert_no"].ReadOnly = true;
                dgv_Holders.Columns["cert_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["cert_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["holder_name"].HeaderText = "اسم المساهم";
                dgv_Holders.Columns["holder_name"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["holder_name"].Width = 200;
                dgv_Holders.Columns["holder_name"].ReadOnly = true;
                dgv_Holders.Columns["holder_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["holder_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Holders.Columns["share_qty"].HeaderText = "عدد الاسهم";
                dgv_Holders.Columns["share_qty"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["share_qty"].Width = 70;
                dgv_Holders.Columns["share_qty"].ReadOnly = true;
                dgv_Holders.Columns["share_qty"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["share_qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["id_type_name"].HeaderText = "نوع الهوية";
                dgv_Holders.Columns["id_type_name"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["id_type_name"].Width = 90;
                dgv_Holders.Columns["id_type_name"].ReadOnly = true;
                dgv_Holders.Columns["id_type_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["id_type_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["id_no"].HeaderText = "رقمها";
                dgv_Holders.Columns["id_no"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["id_no"].Width = 100;
                dgv_Holders.Columns["id_no"].ReadOnly = true;
                dgv_Holders.Columns["id_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["id_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["id_date"].HeaderText = "تاريخها";
                dgv_Holders.Columns["id_date"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["id_date"].Width = 80;
                dgv_Holders.Columns["id_date"].ReadOnly = true;
                dgv_Holders.Columns["id_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["id_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["id_place"].HeaderText = "مكان الاصدار";
                dgv_Holders.Columns["id_place"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["id_place"].Width = 100;
                dgv_Holders.Columns["id_place"].ReadOnly = true;
                dgv_Holders.Columns["id_place"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["id_place"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["class_name"].HeaderText = "الفئة";
                dgv_Holders.Columns["class_name"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["class_name"].Width = 60;
                dgv_Holders.Columns["class_name"].ReadOnly = true;
                dgv_Holders.Columns["class_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["class_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["gender_name"].HeaderText = "الجنس";
                dgv_Holders.Columns["gender_name"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["gender_name"].Width = 60;
                dgv_Holders.Columns["gender_name"].ReadOnly = true;
                dgv_Holders.Columns["gender_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["gender_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["entry_doc_no"].HeaderText = "رقم الحضور";
                dgv_Holders.Columns["entry_doc_no"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["entry_doc_no"].Width = 60;
                dgv_Holders.Columns["entry_doc_no"].ReadOnly = true;
                dgv_Holders.Columns["entry_doc_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["entry_doc_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Holders.Columns["status_name"].HeaderText = "الحالة";
                dgv_Holders.Columns["status_name"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["status_name"].Width = 70;
                dgv_Holders.Columns["status_name"].ReadOnly = true;
                dgv_Holders.Columns["status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["status_date"].HeaderText = "تاريخ الحالة";
                dgv_Holders.Columns["status_date"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["status_date"].Width = 130;
                dgv_Holders.Columns["status_date"].ReadOnly = true;
                dgv_Holders.Columns["status_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["status_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               
                dgv_Holders.Columns["entry_card_no"].HeaderText = "رقم الكرت";
                dgv_Holders.Columns["entry_card_no"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["entry_card_no"].Width = 50;
                dgv_Holders.Columns["entry_card_no"].ReadOnly = true;
                dgv_Holders.Columns["entry_card_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["entry_card_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                dgv_Holders.Columns["note"].HeaderText = "ملاحظات";
                dgv_Holders.Columns["note"].DisplayIndex = ++ColDisplayOrder;
                dgv_Holders.Columns["note"].Width = 300;
                dgv_Holders.Columns["note"].ReadOnly = true;
                dgv_Holders.Columns["note"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Holders.Columns["note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Holders.Columns["holder_no"].Visible = false;
                dgv_Holders.Columns["status"].Visible = false;
                dgv_Holders.Columns["rowid"].Visible = false;
                dgv_Holders.Columns["id_type"].Visible = false;
                dgv_Holders.Columns["holder_class"].Visible = false;
                int totalshares = 0;

                for (int i = 0; i < dgv_Holders.Rows.Count; ++i)
                {
                    totalshares += (int)dgv_Holders["share_qty", i].Value;
                }
                txtTotalShares.Text = totalshares.ToString("N0");
                txtCertCount.Text = dgv_Holders.RowCount.ToString(); 
            }
            catch (ArgumentOutOfRangeException)
            {
                txtTotalShares.Text = "0";
                txtCertCount.Text = "0";
                //MessageBox.Show("ArgumentOutOfRangeException Error !");
            }
        }

        private void dgv_Holders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgv_Holders.Columns[e.ColumnIndex].Name == "share_qty")
                {
                    double tmp = double.Parse(e.Value.ToString());
                    e.Value = tmp.ToString("N0");
                }
                if (int.Parse(dgv_Holders["status", e.RowIndex].Value.ToString()) == 5)
                {
                    dgv_Holders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                    dgv_Holders.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                if (int.Parse(dgv_Holders["status", e.RowIndex].Value.ToString()) == 1)
                {
                    dgv_Holders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    dgv_Holders.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (int.Parse(dgv_Holders["status", e.RowIndex].Value.ToString()) == 0)
                {
                    dgv_Holders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgv_Holders.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch { }
        }

        private void mnuAllHolderCerts_Click(object sender, EventArgs e)
        {
            txtCertNo.Text = dgv_Holders["cert_no", dgv_Holders.CurrentRow.Index].Value.ToString();
            txtHolderName.Text = txtIdNo.Text = string.Empty;
            ch_IncludebyHolderNo.Checked = true;
            LoadHoldersData();
        }

        private void mnuSameName_Click(object sender, EventArgs e)
        {
            txtCertNo.Text = txtIdNo.Text = string.Empty;
            txtHolderName.Text = dgv_Holders["holder_name", dgv_Holders.CurrentRow.Index].Value.ToString();
            coClass.SelectedValue = "all";
            ch_IncludebyHolderNo.Checked = false;
            LoadHoldersData();
        }
    }
}

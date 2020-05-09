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
    public partial class frm_CandidateQuery : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private bool _Allow_Edit = false;
        public frm_CandidateQuery(bool Allow_Edit)
        {
            InitializeComponent();
            _Allow_Edit = Allow_Edit;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_CandidateQuery_KeyDown(object sender, KeyEventArgs e)
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void frm_CandidateQuery_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
            if (_Allow_Edit)
            {
                this.dgv_Cand.ContextMenuStrip = this.contextMenuStrip1;
            }
            else
            {
                this.dgv_Cand.ContextMenuStrip = null;
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            string strsql = "SELECT [cand_pic],[cand_no],[cand_name],[status_name],[status_date],[create_time]"
                + "  FROM [dbo].[v_Candidate] where cand_class='"+coClass.SelectedValue.ToString()+"' order by cand_no";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            dgv_Cand.DataSource = dt;
            PrepareGrids();

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
        }
        private void PrepareGrids()
        {
            try {
                dgv_Cand.RowTemplate.Height = 70;
                dgv_Cand.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Cand.Columns["cand_no"].HeaderText = "رقم المرشح";
                dgv_Cand.Columns["cand_no"].Width = 80;
                dgv_Cand.Columns["cand_no"].DisplayIndex = 1;
                dgv_Cand.Columns["cand_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["cand_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Cand.Columns["cand_name"].HeaderText = "إسم المرشح";
                dgv_Cand.Columns["cand_name"].Width = 250;
                dgv_Cand.Columns["cand_name"].DisplayIndex = 2;
                dgv_Cand.Columns["cand_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["cand_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_Cand.Columns["status_name"].HeaderText = "الحالة";
                dgv_Cand.Columns["status_name"].Width = 120;
                dgv_Cand.Columns["status_name"].DisplayIndex = 3;
                dgv_Cand.Columns["status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Cand.Columns["status_date"].HeaderText = "تاريخ الحالة";
                dgv_Cand.Columns["status_date"].Width = 170;
                dgv_Cand.Columns["status_date"].DisplayIndex = 4;
                dgv_Cand.Columns["status_date"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["status_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Cand.Columns["create_time"].HeaderText = "وقت الانشاء";
                dgv_Cand.Columns["create_time"].Width = 170;
                dgv_Cand.Columns["create_time"].DisplayIndex = 5;
                dgv_Cand.Columns["create_time"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["create_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgv_Cand.Columns["cand_pic"];
                imageColumn.ImageLayout= DataGridViewImageCellLayout.Stretch;
                //dgv_Cand.Columns["cand_pic"] = imageColumn;
                dgv_Cand.Columns["cand_pic"].DisplayIndex = 0;
                dgv_Cand.Columns["cand_pic"].HeaderText = "الصورة";
                txtTotalRows.Text = dgv_Cand.RowCount.ToString();
            }
            catch
            {
                txtTotalRows.Text = "0";
            }
        }

        private void dgv_Cand_DoubleClick(object sender, EventArgs e)
        {
            try {
                if (!object.ReferenceEquals(dgv_Cand["cand_no", dgv_Cand.CurrentRow.Index], null))
                {
                    frm_NewCandidate frm = new frm_NewCandidate("query"
                        , "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  عرض بيانات المرشح"
                        , dgv_Cand["cand_no", dgv_Cand.CurrentRow.Index].Value.ToString()
                        ,coClass.SelectedValue.ToString());
                    frm.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void dgv_Cand_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 4, 2, "Allow_Candidate_Edit"))
            {
               frm_NewCandidate frm=new frm_NewCandidate("edit"
                   , "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  تعديل بيانات المرشحين"
                   , dgv_Cand["cand_no",dgv_Cand.CurrentRow.Index].Value.ToString(),coClass.SelectedValue.ToString());
                frm.ShowDialog();
            }
            else
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("ليس لديك الصلاحية الكافية");
                frm.ShowDialog();
            }
        }
    }
}

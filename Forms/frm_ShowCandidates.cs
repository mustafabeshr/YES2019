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
    public partial class frm_ShowCandidates : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private string ClassId = string.Empty;
        private string ClassName = string.Empty;
        public frm_ShowCandidates(string class_id)
        {
            InitializeComponent();
            ClassId = class_id;
        }

        private void frm_ShowCandidates_Load(object sender, EventArgs e)
        {
            ClassName = Config.GetHoldeClassName(ClassId);
            lblTitle.Text = "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل";
            lblClassName.Text = ClassName;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkbtnRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadCandidatesData();
        }

        private void LoadCandidatesData()
        {
            string strsql = "SELECT [cand_pic],[cand_no],[cand_name] FROM [dbo].[v_Candidate] where status='candidate' and cand_class='" + ClassId + "' order by cand_no";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            dgv_Cand.DataSource = dt;
            PrepareGrids();
        }

        private void PrepareGrids()
        {
            try
            {
                dgv_Cand.RowTemplate.Height = 100;
                dgv_Cand.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Cand.Columns["cand_no"].HeaderText = "رقم المرشح";
                dgv_Cand.Columns["cand_no"].Width = 100;
                dgv_Cand.Columns["cand_no"].DisplayIndex = 1;
                dgv_Cand.Columns["cand_no"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["cand_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_Cand.Columns["cand_name"].HeaderText = "إسم المرشح";
                dgv_Cand.Columns["cand_name"].Width = 530;
                dgv_Cand.Columns["cand_name"].DisplayIndex = 2;
                dgv_Cand.Columns["cand_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Cand.Columns["cand_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgv_Cand.Columns["cand_pic"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgv_Cand.Columns["cand_pic"].DisplayIndex = 0;
                dgv_Cand.Columns["cand_pic"].Width = 100;
                dgv_Cand.Columns["cand_pic"].HeaderText = "صورة المرشح";
                txtTotalRows.Text = dgv_Cand.RowCount.ToString();
            }
            catch
            {
                txtTotalRows.Text = "0";
            }
        }
        private void frm_ShowCandidates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                btn_close_Click( sender,  e);
            }
            if (e.KeyCode==Keys.F5)
            {
                LoadCandidatesData();
            }
        }

        private void frm_ShowCandidates_Activated(object sender, EventArgs e)
        {
            LoadCandidatesData();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
            
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
    }
}

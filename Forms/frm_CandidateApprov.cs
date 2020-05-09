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
    public partial class frm_CandidateApprov : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private bool AllowChangeStatus = true;
        public frm_CandidateApprov()
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

        private void frm_CandidateApprov_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlDetails.Visible == true)
                { pnlDetails.Visible = false; }
                else
                {
                    this.Close();
                }
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

        private void frm_CandidateApprov_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateLists();
            txtLastDay.Text = Config.ChangeCandStatusLastDay.ToString("yyyy/MM/dd");
        }
        void PopulateLists()
        {
            string strsql = "select class_id,class_name from holder_class where has_Candidate=1 order by class_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coClass.DataSource = dt;
                coClass.DisplayMember = "class_name";
                coClass.ValueMember = "class_id";
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        }
        private void PrepareGrids()
        {
            try
            {
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

                dgv_Cand.Columns["status"].Visible = false;

                //DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgv_Cand.Columns["cand_pic"];
                //imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dgv_Cand.Columns["cand_pic"].DisplayIndex = 0;
                //dgv_Cand.Columns["cand_pic"].HeaderText = "الصورة";


                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgv_Cand.Columns["cand_pic"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dgv_Cand.Columns["cand_pic"] = imageColumn;
                dgv_Cand.Columns["cand_pic"].DisplayIndex = 0;
                dgv_Cand.Columns["cand_pic"].HeaderText = "الصورة";

                DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
                    dgvButton.FlatStyle = FlatStyle.Standard;
                    dgvButton.HeaderText = string.Empty;
                    dgvButton.Name = "StatusDetails";
                    dgvButton.UseColumnTextForButtonValue = true;
                    dgvButton.Text = "تفاصيل";
                //if (dgv_Cand.Columns.Count<5)
                //{
                    dgv_Cand.Columns.Add(dgvButton);
                    dgv_Cand.Columns["StatusDetails"].DisplayIndex = 4;
                //}
                txtTotalRows.Text = dgv_Cand.RowCount.ToString();
            }
            catch
            {
                txtTotalRows.Text = "0";
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            LoadCandidateData();
        }

        private void LoadCandidateData()
        {
            //dgv_Cand.DataSource = null;
            string strsql = "SELECT [cand_pic],[cand_no],[cand_name],[status_name],[status]"
                           + "  FROM [dbo].[v_Candidate] where cand_class='" + coClass.SelectedValue.ToString() + "' order by cand_no";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            dgv_Cand.DataSource = dt;
            if (dgv_Cand.Columns.Contains(dgv_Cand.Columns["StatusDetails"]))
            {
                dgv_Cand.Columns.Remove(dgv_Cand.Columns["StatusDetails"]);
            }
            PrepareGrids();
        }

        void ClearTextBoxes()
        {
            txtCandName.Text = txtCandNo.Text = txtOldStatus.Text = txtOldStatusId.Text =txtNote.Text= string.Empty;
            gbNewStatus.Enabled = false;
        }

        private void dgv_Cand_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ClearTextBoxes();
            txtCandNo.Text = dgv_Cand["cand_no", e.RowIndex].Value.ToString();
            txtCandName.Text = dgv_Cand["cand_name", e.RowIndex].Value.ToString();
            txtOldStatusId.Text = dgv_Cand["status", e.RowIndex].Value.ToString();
            txtOldStatus.Text = dgv_Cand["status_name", e.RowIndex].Value.ToString();

            string strsql = "SELECT [target_status],[target_status_name] FROM [dbo].[v_Candidate_Status_Settings] "
                + " WHERE [status]='"+ txtOldStatusId.Text + "' ORDER BY [order]";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coNewStatus.DataSource = dt;
                coNewStatus.DisplayMember = "target_status_name";
                coNewStatus.ValueMember = "target_status";
                TimeSpan ts = Config.ChangeCandStatusLastDay.Subtract(DateTime.Now);
                if (ts.TotalDays > 0)
                { gbNewStatus.Enabled = true; }
            }
            else
            {
                coNewStatus.DataSource = null;
                gbNewStatus.Enabled = false;
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                MessageBox.Show("يجب ادخال الملاحظات");
                txtNote.Focus();
            }
            else
            {
                string strsql = "UPDATE candidate SET status='" + coNewStatus.SelectedValue.ToString() + "' WHERE cand_no=" + txtCandNo.Text +" AND cand_class='"+ coClass.SelectedValue.ToString() + "'";
                if (Db.ExecuteSQLCommand(strsql))
                {
                    string result = Db.CreateCandidateChangeStatusLog(txtCandNo.Text, txtOldStatusId.Text, coNewStatus.SelectedValue.ToString()
                        , SharedParam.CurrentUser.UserID, txtNote.Text, coClass.SelectedValue.ToString());
                    if (result == "success")
                    {
                        MessageBox.Show("تم تغيير الحالة بنجاح");
                        LoadCandidateData();
                    }
                    else
                    {
                        MessageBox.Show("فشل في تغيير الحالة");
                    }
                }
                else
                {
                    MessageBox.Show("فشل في تغيير الحالة");
                }
            }
        }

        private void btnCloseDetails_Click(object sender, EventArgs e)
        {
            pnlDetails.Visible = false;
        }

        private void dgv_Cand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Cand.Columns[e.ColumnIndex].Name== "StatusDetails")
            {
                string strsql = "SELECT [log_time],[old_status_name],[new_status_name],[username],[note] "
                          + "  FROM [dbo].[v_Candidate_Status_Log] where [cand_no]=" + dgv_Cand["cand_no", e.RowIndex].Value.ToString() 
                          + " order by rowid ";
                DataTable dt = Db.GetDataAsDataTable(strsql);
                if (dt != null)
                {
                    txtDetailsCandNo.Text = dgv_Cand["cand_no", e.RowIndex].Value.ToString();
                    txtDetailsCandName.Text= dgv_Cand["cand_name", e.RowIndex].Value.ToString();
                    dgvDetails.DataSource = dt;
                    pnlDetails.Visible = true;
                    PrepareDetailsGrids();
                }
                else
                {
                    MessageBox.Show("لا توجد اي بيانات حول تغيير الحالة");
                }
            }
        }
          private void PrepareDetailsGrids()
        {
            try
            {
                dgvDetails.RowTemplate.Height = 25;
                dgvDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDetails.Columns["log_time"].HeaderText = "التاريخ";
                dgvDetails.Columns["log_time"].Width = 145;
                dgvDetails.Columns["log_time"].DisplayIndex = 0;
                dgvDetails.Columns["log_time"].DefaultCellStyle.ForeColor = Color.Black;
                dgvDetails.Columns["log_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvDetails.Columns["old_status_name"].HeaderText = "الحالة القديمة";
                dgvDetails.Columns["old_status_name"].Width = 140;
                dgvDetails.Columns["old_status_name"].DisplayIndex = 1;
                dgvDetails.Columns["old_status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvDetails.Columns["old_status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvDetails.Columns["new_status_name"].HeaderText = "الحالة الجديدة";
                dgvDetails.Columns["new_status_name"].Width = 140;
                dgvDetails.Columns["new_status_name"].DisplayIndex = 2;
                dgvDetails.Columns["new_status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgvDetails.Columns["new_status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvDetails.Columns["username"].HeaderText = "المستخدم";
                dgvDetails.Columns["username"].Width = 140;
                dgvDetails.Columns["username"].DisplayIndex = 3;
                dgvDetails.Columns["username"].DefaultCellStyle.ForeColor = Color.Black;
                dgvDetails.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvDetails.Columns["note"].HeaderText = "ملاحظات";
                dgvDetails.Columns["note"].Width = 250;
                dgvDetails.Columns["note"].DisplayIndex = 4;
                dgvDetails.Columns["note"].DefaultCellStyle.ForeColor = Color.Black;
                dgvDetails.Columns["note"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
            }
            catch
            {
                
            }
        }

        private void dgv_Cand_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void coClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCandidateData();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_UserQuery : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_UserQuery()
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

        private void frm_UserQuery_KeyDown(object sender, KeyEventArgs e)
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

        private void frm_UserQuery_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
        }
        void PopulateIdTypesLists()
        {
            string strsql = "select * from "
                + "(select 'all' roleid,N'الـكــل' rolename,-1 role_order" +
                " UNION ALL " +
                "select roleid,rolename,role_order from roles ) v order by role_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coRole.DataSource = dt;
                coRole.DisplayMember = "rolename";
                coRole.ValueMember = "roleid";
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            dgv_User.DataSource = null;
            txtTotalRows.Text = "0";
            string WhereClause = string.Empty;
            List<string> parameters = new List<string>();
            #region Build Where Clause ...
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                WhereClause = " WHERE username like '% '+ @username + '%' ";
                parameters.Add("username");
                parameters.Add(txtUserName.Text);
            }
            if (coRole.SelectedValue.ToString()!="all")
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE role_id=@roleid";
                    parameters.Add("roleid");
                    parameters.Add(coRole.SelectedValue.ToString());
                }
                else
                {
                    WhereClause += " AND role_id=@roleid";
                    parameters.Add("roleid");
                    parameters.Add(coRole.SelectedValue.ToString());
                }
            }
            if (!string.IsNullOrEmpty(txtUserId.Text))
            {
                if (string.IsNullOrEmpty(WhereClause))
                {
                    WhereClause = " WHERE userid=@userid";
                    parameters.Add("userid");
                    parameters.Add(txtUserId.Text);
                }
                else
                {
                    WhereClause += " AND userid=@userid";
                    parameters.Add("userid");
                    parameters.Add(txtUserId.Text);
                }
            }
            #endregion
            string strsql = "SELECT [userid],[username],[rolename],[user_status_name],[status],[statustime]"
                + "  ,[single_class],[employee_class],[company_class],[founder_class]"
                + "  FROM [dbo].[v_Users] "
                + WhereClause;
            if (object.ReferenceEquals(parameters, null))
            {
                DataTable dt = Db.GetDataAsDataTable(strsql);
                dgv_User.DataSource = dt;
                PrepareUserGrid();
            }
            else
            {
                DataTable dt = Db.GetDataAsDataTable(strsql, parameters.ToArray());
                dgv_User.DataSource = dt;
                PrepareUserGrid();
            }
        }

        private void PrepareUserGrid()
        {
            try
            {
                dgv_User.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_User.Columns["userid"].HeaderText = "رمز المستخدم";
                dgv_User.Columns["userid"].Width = 80;
                dgv_User.Columns["userid"].DisplayIndex = 0;
                dgv_User.Columns["userid"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["userid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_User.Columns["username"].HeaderText = "اسم المستخدم";
                dgv_User.Columns["username"].Width = 220;
                dgv_User.Columns["username"].DisplayIndex = 1;
                dgv_User.Columns["username"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_User.Columns["rolename"].HeaderText = "المجموعة";
                dgv_User.Columns["rolename"].Width = 220;
                dgv_User.Columns["rolename"].DisplayIndex = 2;
                dgv_User.Columns["rolename"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["rolename"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv_User.Columns["user_status_name"].HeaderText = "الحالة";
                dgv_User.Columns["user_status_name"].Width = 100;
                dgv_User.Columns["user_status_name"].DisplayIndex = 3;
                dgv_User.Columns["user_status_name"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["user_status_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_User.Columns["statustime"].HeaderText = "تاريخ الحالة";
                dgv_User.Columns["statustime"].Width = 150;
                dgv_User.Columns["statustime"].DisplayIndex = 4;
                dgv_User.Columns["statustime"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["statustime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_User.Columns["single_class"].HeaderText = "فئة الافراد";
                dgv_User.Columns["single_class"].Width = 80;
                dgv_User.Columns["single_class"].DisplayIndex = 5;
                dgv_User.Columns["single_class"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["single_class"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_User.Columns["employee_class"].HeaderText = "فئة الموظفين";
                dgv_User.Columns["employee_class"].Width = 80;
                dgv_User.Columns["employee_class"].DisplayIndex = 6;
                dgv_User.Columns["employee_class"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["employee_class"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_User.Columns["company_class"].HeaderText = "فئة الشركات";
                dgv_User.Columns["company_class"].Width = 80;
                dgv_User.Columns["company_class"].DisplayIndex = 7;
                dgv_User.Columns["company_class"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["company_class"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv_User.Columns["founder_class"].HeaderText = "فئة المؤسسين";
                dgv_User.Columns["founder_class"].Width = 80;
                dgv_User.Columns["founder_class"].DisplayIndex = 8;
                dgv_User.Columns["founder_class"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_User.Columns["founder_class"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_User.Columns["status"].Visible = false;
                txtTotalRows.Text = dgv_User.RowCount.ToString();
            }
            catch
            {
                txtTotalRows.Text = "0";
            }
        }

        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                frm_users frm = new frm_users("edit", dgv_User["userid", dgv_User.CurrentRow.Index].Value.ToString());
                frm.ShowDialog();
            }
            catch
            {

            }
        }

        private void mnuResetPassword_Click(object sender, EventArgs e)
        {
            string Msg = "هل تريد بالتأكيد إعادة تعيين كلمة المرور الخاصة بـ"+ dgv_User["username", dgv_User.CurrentRow.Index].Value.ToString() 
                + "؟" + Environment.NewLine + Environment.NewLine + "تنبيه : لايمكن  التراجع بعد التعديل.";
            if (new Dialogs.Dg_ComfirmMessage("إعادة تعيين كلمة المرور", Msg).MessageResult() == DialogResult.Yes)
            {
               string result= Db.ChangeUserPassword(dgv_User["userid", dgv_User.CurrentRow.Index].Value.ToString()
                    , Security.Cryptography.Encrypt(Config.ResetPasswordWord, true, SharedParam.USER_PASSWORD_KEY));
                if (result == "success")
                {
                    Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم الحفظ بنجاح ");
                    frm.ShowDialog();
                }
            }
        }
    }
}

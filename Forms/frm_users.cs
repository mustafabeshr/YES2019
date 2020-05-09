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
    public partial class frm_users : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        string Operation_Type = string.Empty;
        string CurrentUser = string.Empty;
        public frm_users(string OperationType,string currentuser)
        {
            InitializeComponent();
            Operation_Type = OperationType;
            CurrentUser = currentuser;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frm_users_KeyDown(object sender, KeyEventArgs e)
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

        private void frm_users_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
            if (Operation_Type=="edit")
            {
                txtUserId.Enabled = false;
                txtPassword.Enabled = false;
                LoadData();
            }
            else if (Operation_Type == "new")
            {
                txtUserId.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
        void PopulateIdTypesLists()
        {
            string strsql ="select * from " 
                +"(select 'none' roleid,N'تحديد المجموعة' rolename,-1 role_order" +
                " UNION ALL "+
                "select roleid,rolename,role_order from roles ) v order by role_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coRole.DataSource = dt;
                coRole.DisplayMember = "rolename";
                coRole.ValueMember = "roleid";
            }
            strsql = "SELECT [user_status_id],[user_status_name] FROM [dbo].[Users_Status] order by [status_order]";
            DataTable dt2 = Db.GetDataAsDataTable(strsql);
            if (dt2 != null)
            {
                coStatus.DataSource = dt2;
                coStatus.DisplayMember = "user_status_name";
                coStatus.ValueMember = "user_status_id";
            }
        }

        void LoadData()
        {
            if (Operation_Type=="edit" && CurrentUser!="0")
            {
                string strsql = "SELECT TOP 1 * from v_Users where userid=@userid";
                DataTable dt = Db.GetDataAsDataTable(strsql,"Users", "@userid", CurrentUser);
                if (dt!=null)
                {
                    DataRow dr = dt.Rows[0];
                    txtUserId.Text = dr["userid"].ToString();
                    txtUserName.Text= dr["username"].ToString();
                    
                    coRole.SelectedValue= dr["role_id"].ToString();
                    if (Db.HasRight(SharedParam.CurrentUser.RoleId, 9, 2, "ChangeRole"))
                    {
                        coRole.Enabled = true;
                    }
                    else
                    {
                        coRole.Enabled = false;
                    }
                    coStatus.SelectedValue = dr["status"].ToString();
                    chSingle.Checked = Boolean.Parse(dr["single_class"].ToString());
                    chEmployee.Checked = Boolean.Parse(dr["employee_class"].ToString());
                    chCompany.Checked = Boolean.Parse(dr["company_class"].ToString());
                    chFounder.Checked = Boolean.Parse(dr["founder_class"].ToString());
                }
            }
        }

        private void chSingle_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBoxColor(chSingle);
        }
        void ChangeCheckBoxColor(CheckBox ch)
        {
            if (ch.Checked)
            {
                ch.ForeColor = Color.Blue;
            }
            else
            {
                ch.ForeColor = Color.Black;
            }
        }

        private void chEmployee_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBoxColor(chEmployee);
        }

        private void chCompany_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBoxColor(chCompany);
        }

        private void chFounder_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckBoxColor(chFounder);
        }
        bool checkRequiredData()
        {
            if (string.IsNullOrEmpty(txtUserId.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال رمز المستخدم");
                frm.ShowDialog();
                txtUserId.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال اسم المستخدم");
                frm.ShowDialog();
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) && Operation_Type == "new")
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال كلمة المرور ");
                frm.ShowDialog();
                txtPassword.Focus();
                return false;
            }
            if (coRole.SelectedValue.ToString()=="none")
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب تحديد المجموعة ");
                frm.ShowDialog();
                coRole.Focus();
                return false;
            }

            return true;
        }
        private void btn_Commit_Click(object sender, EventArgs e)
        {
            if (Operation_Type == "new")
            {
                if (checkRequiredData())
                {
                    string result = Db.CreateUser(txtUserId.Text, Security.Cryptography.Encrypt(txtPassword.Text,true,SharedParam.USER_PASSWORD_KEY), txtUserName.Text, coRole.SelectedValue.ToString()
                        , chSingle.Checked, chEmployee.Checked, chCompany.Checked, chFounder.Checked,SharedParam.CurrentUser.UserID);
                    if (result == "success")
                    {
                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم انشاء المستخدم بنجاح ");
                        frm.ShowDialog();
                        ClearData();
                    }
                    else if (result == "exists")
                    {
                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("المستخدم تم انشائه مسبقاً");
                        frm.ShowDialog();
                    }
                    else if (result == "fail")
                    {
                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("حدث خطأ عند محاولة انشاء المستخدم");
                        frm.ShowDialog();
                    }
                }
            }
            if (Operation_Type == "edit")
            {
                if (checkRequiredData())
                {
                    string result = Db.UpdateUser(CurrentUser,coStatus.SelectedValue.ToString(), coRole.SelectedValue.ToString()
                        ,chSingle.Checked, chEmployee.Checked, chCompany.Checked, chFounder.Checked);
                    if (result == "success")
                    {
                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم تعديل بيانات المستخدم بنجاح ");
                        frm.ShowDialog();
                        this.Close();
                    }
                    else if (result == "not_exists")
                    {
                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("المستخدم غير موجود");
                        frm.ShowDialog();
                        this.Close();
                    }
                    else if (result == "fail"  || result.Substring(0,5) == "Error")
                    {
                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("حدث خطأ عند محاولة تعديل بيانات المستخدم المستخدم" + Environment.NewLine+result);
                        frm.ShowDialog();
                        this.Close();
                    }
                }
            }
        }
        void ClearData()
        {
            txtPassword.Text = txtUserId.Text = txtUserName.Text = string.Empty;
            coRole.SelectedValue = "all";
            chSingle.Checked = chEmployee.Checked = chCompany.Checked = chFounder.Checked = false;
            txtUserId.Focus();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = "123456";
            }
        }
    }
}

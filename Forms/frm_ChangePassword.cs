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
    public partial class frm_ChangePassword : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_ChangePassword()
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

        private void frm_ChangePassword_KeyDown(object sender, KeyEventArgs e)
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

        bool checkRequiredData()
        {
            if (string.IsNullOrEmpty(txtOldPass.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال كلمة المرور القديمة");
                frm.ShowDialog();
                txtOldPass.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال كلمة المرور الجديدة");
                frm.ShowDialog();
                txtNewPass.Focus();
                return false;
            }
            if (!txtNewPass.Text.Equals(txtNewPass2.Text) )
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب تطابق كلمة المرور الجديدة مع التاكيد");
                frm.ShowDialog();
                txtNewPass2.Focus();
                return false;
            }
           

            return true;
        }
        private void frm_ChangePassword_MouseMove(object sender, MouseEventArgs e)
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

        private void frm_ChangePassword_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }

        private void frm_ChangePassword_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void frm_ChangePassword_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
        }

        private void btn_Commit_Click(object sender, EventArgs e)
        {
            if (checkRequiredData())
            {
                if (Db.HasData("users"," WHERE userid='"+SharedParam.CurrentUser.UserID
                    + "' and userpassword='"+Security.Cryptography.Encrypt(txtOldPass.Text,true, SharedParam.USER_PASSWORD_KEY)
                    +"'"))
                {
                    string result = Db.ChangeUserPassword(SharedParam.CurrentUser.UserID,
                        Security.Cryptography.Encrypt(txtNewPass.Text, true, SharedParam.USER_PASSWORD_KEY));
                    if (result == "success")
                    {
                        Dialogs.Dg_Info frm = new Dialogs.Dg_Info("تم تغيير كلمة المرور بنجاح ");
                        frm.ShowDialog();
                    }
                    else if (result == "fail")
                    {
                        Dialogs.Dg_Error frm = new Dialogs.Dg_Error("حدث خطأ عند محاولة تغيير كلمة المرور");
                        frm.ShowDialog();
                    }
                }
                else
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("كلمة المرور القديمة غير صحيحة");
                    frm.ShowDialog();
                }

            }
        }
    
    }
}

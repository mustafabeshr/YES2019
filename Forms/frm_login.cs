using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_login : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        SharedParam.UserInfo ui;
        public frm_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Forms.AboutBox1 frm = new Forms.AboutBox1();
            //frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_Click( sender,  e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            txtOpId.Focus();
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

        private void txtOpId_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        bool checkRequiredData()
        {
            if (string.IsNullOrEmpty(txtOpId.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال رمز المستخدم");
                frm.ShowDialog();
                txtOpId.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("يجب ادخال كلمة المرور");
                frm.ShowDialog();
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkRequiredData())
            {
                DataTable dt = Db.GetDataAsDataTable("select TOP 1 * from v_Users where userid=@user and userpassword=@pass and status='active'"
                    , "user", "@user", txtOpId.Text, "@pass", Security.Cryptography.Encrypt(txtPassword.Text, true, SharedParam.USER_PASSWORD_KEY));
                if (dt != null)
                {
                    DataRow UserDataRow = dt.Rows[0];

                    ui = new SharedParam.UserInfo(UserDataRow["userid"].ToString()
                        , UserDataRow["username"].ToString()
                        , UserDataRow["role_id"].ToString()
                        , UserDataRow["rolename"].ToString()
                        ,Boolean.Parse(UserDataRow["single_class"].ToString())
                        ,Boolean.Parse( UserDataRow["employee_class"].ToString())
                        ,Boolean.Parse( UserDataRow["company_class"].ToString())
                        ,Boolean.Parse(UserDataRow["founder_class"].ToString()));
                    SharedParam.CurrentUser = ui;
                    Config.Load();

                    frm_Dashboard frm = new frm_Dashboard();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    Dialogs.Dg_Error frm = new Dialogs.Dg_Error("رمز المستخدم او كلمة المرور غير صحيح");
                    frm.ShowDialog();
                    txtOpId.Focus();
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frm_test frm = new frm_test();
            frm.Show();
        }
    }
}

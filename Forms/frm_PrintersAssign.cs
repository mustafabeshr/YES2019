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
    public partial class frm_PrintersAssign : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_PrintersAssign()
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

        private void frm_PrintersAssign_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender, e);
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

        private void frm_PrintersAssign_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            LoadPCInfo();
            LoadPrinters();
        }

        private void LoadPCInfo()
        {
            txtName.Text = Utility.GetMachineName();
            txtIP.Text = Utility.GetLocalIPAddress();
            txtMAC.Text = Utility.GetMACAddress();
        }
        private void LoadPrinters()
        {
            lbPrinters.Items.Clear();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                lbPrinters.Items.Add(printer);
            }
            string pname = Db.GetPrinterName(txtMAC.Text);
            if (pname != "N/A")
            {
                lbPrinters.SelectedItem = pname;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lbPrinters.SelectedItems.Count > 0)
            {
                string result = Db.CreateOrUpdatePrinter(txtIP.Text, txtName.Text, txtMAC.Text, lbPrinters.SelectedItem.ToString());
                if (result=="success")
                {
                    MessageBox.Show("تم عملية الحفظ بنجاح", "تعيين الطابعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                else
                {
                    MessageBox.Show("فشلت عملية الحفظ", "تعيين الطابعة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
            }
            else
            {
                MessageBox.Show("يجب تحديد الطابعة", "تعيين الطابعة", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPCInfo();
            LoadPrinters();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 9, 6, "DeletePrinter"))
            {
                string strsql = "DELETE FROM [dbo].[PrinterSettings] WHERE [MachineMacAddress]='" + txtMAC.Text + "'";
                Db.ExecuteSQLCommand(strsql);
                LoadPrinters();
            }
            else
            {
                MessageBox.Show("ليس لديك الصلاحية الكافية", "حذف الطابعة", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }
    }
}

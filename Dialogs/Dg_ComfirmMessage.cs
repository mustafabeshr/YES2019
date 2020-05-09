using System;
using System.Windows.Forms;

namespace YES.Dialogs
{
    public partial class Dg_ComfirmMessage : Form
    {
        private string Title = string.Empty;
        private string Message = string.Empty;
        private DialogResult dg_Result = DialogResult.No;

        public DialogResult MessageResult()
        {
            this.ShowDialog();
            return dg_Result;
            //get
            //{
            //    return dg_Result;
            //}
        }

        public Dg_ComfirmMessage(string title,string message)
        {
            InitializeComponent();
            Title = title;
            Message = message;
        }

        private void Dg_ComfirmMessage_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Title;
            txtMessage.Text = Message;
        }

        private void btn_YES_Click(object sender, EventArgs e)
        {
            dg_Result = DialogResult.Yes;
            this.Close();
        }

        private void btn_NO_Click(object sender, EventArgs e)
        {
            dg_Result = DialogResult.No;
            this.Close();
        }

        private void Dg_ComfirmMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btn_YES_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_NO_Click(sender, e);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

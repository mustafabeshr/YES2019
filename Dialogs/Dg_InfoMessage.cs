using System;
using System.Drawing;
using System.Windows.Forms;

namespace YES.Dialogs
{
    public partial class Dg_InfoMessage : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        string _message = string.Empty;
        string _EntryDocNo = string.Empty;
        int _Certs = 0;
        int _Shares = 0;

        public Dg_InfoMessage(string Msg,string EntryNo,int Certs,int Shares)
        {
            InitializeComponent();
            _message = Msg;
            _EntryDocNo = EntryNo;
            _Certs = Certs;
            _Shares = Shares;
        }

        private void Dg_InfoMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void Dg_InfoMessage_Load(object sender, EventArgs e)
        {
            lblMessage.Text = _message;
            txtEntryDocNo.Text = _EntryDocNo;
            txtCertCount.Text = _Certs.ToString("N0");
            txtShares.Text = _Shares.ToString("N0");
        }

        private void Dg_InfoMessage_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dg_InfoMessage_MouseMove(object sender, MouseEventArgs e)
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

        private void Dg_InfoMessage_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }

        private void Dg_InfoMessage_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YES.Dialogs
{
    public partial class Dg_Info : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        private string InfoMsg = string.Empty;
        public Dg_Info(string message)
        {
            InitializeComponent();
            InfoMsg = message;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dg_Info_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape || e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void Dg_Info_Load(object sender, EventArgs e)
        {
            
            lblMessage.Text = InfoMsg;
            this.panel2.Size = new System.Drawing.Size(lblMessage.Width + 50, lblMessage.Height + 30);
            this.Size = new System.Drawing.Size(panel2.Width + 150, panel2.Height + 100);
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
    }
}

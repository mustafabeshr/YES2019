using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YES.Forms
{
    public partial class frmEnc : Form
    {
        public frmEnc()
        {
            InitializeComponent();
        }

        private void btnEnc_Click(object sender, EventArgs e)
        {
            try
            {
                YES.appcode.Security sec = new YES.appcode.Security();
                txtAnother.Text = YES.appcode.Security.Cryptography.Encrypt(txt.Text, true, txtKey.Text);
            }
            catch { }
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            try
            {
                YES.appcode.Security sec = new YES.appcode.Security();
                txtAnother.Text = YES.appcode.Security.Cryptography.Decrypt(txt.Text, true, txtKey.Text);
            }
            catch { }
        }
    }
}

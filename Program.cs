using System;
using System.Windows.Forms;
using YES.Forms;

namespace YES
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_login());
            //Application.Run(new frm_test());

        }
    }
}

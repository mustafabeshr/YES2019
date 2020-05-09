using Microsoft.Reporting.WinForms;
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
    public partial class frm_AgentSummaryReport : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_AgentSummaryReport()
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

        private void frm_AgentSummaryReport_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_Query_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "AgentSummary.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            string strsql = "SELECT * FROM v_reception WHERE DetailsClass='" + coClass.SelectedValue.ToString() + "' AND reception_type in ('HolderDelagate','OrgDelegate') ORDER BY Entry_doc_no";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] ReportParams = new ReportParameter[]
                               {
                                new ReportParameter("ReportTitle","جدول احصائي"+Environment.NewLine+"يوضح اجمالي عدد المساهمين من فئة "
                                +coClass.Text+" الذين وكلوا مساهمين اخرين للمشاركة في فعاليات الاجتماع التاسع للجمعية العامة للشركة المنعقدة لعام 2015")
                               };
            reportViewer1.LocalReport.SetParameters(ReportParams);
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            reportViewer1.RefreshReport();
            //this.WindowState = FormWindowState.Maximized;
            //this.ShowDialog();
        }

        private void frm_AgentSummaryReport_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
        }
        void PopulateIdTypesLists()
        {
            string strsql = "select class_id,class_name from holder_class where has_Candidate=1 order by class_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coClass.DataSource = dt;
                coClass.DisplayMember = "class_name";
                coClass.ValueMember = "class_id";
            }
        }
    }
}

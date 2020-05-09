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
    public partial class frm_AttendanceInfo : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_AttendanceInfo()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_AttendanceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            
        }
        void LoadData()
        {
            string strsql = "SELECT ISNULL(COUNT(DISTINCT Reception_Details.Entry_doc_no),0) Attendees" + Environment.NewLine
                + "  ,ISNULL(COUNT(Reception_Details.Cert_No),0) CertCount  " + Environment.NewLine
                + "   ,ISNULL(SUM(Reception_Details.share_qty),0) Shares " + Environment.NewLine
                + "  FROM Reception,Reception_Details   " + Environment.NewLine
                + " WHERE Reception.Entry_doc_no = Reception_Details.Entry_doc_no " + Environment.NewLine
                + " AND Reception.status = 'post' ";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            txtAttendees.Text = double.Parse(dt.Rows[0]["Attendees"].ToString()).ToString("N0");
            txtCertsCnt.Text = double.Parse(dt.Rows[0]["CertCount"].ToString()).ToString("N0");
            txtShares.Text = double.Parse(dt.Rows[0]["Shares"].ToString()).ToString("N0");
            double ratio =double.Parse(dt.Rows[0]["Shares"].ToString()) / Config.TotalYemenMobileShares*100;
            txtRatio.Text = ratio.ToString("N2");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrintReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReportParameter[] ReportParams = new ReportParameter[]
                                   {
                                    new ReportParameter("EventDate",Config.EventDate),
                                    new ReportParameter("title",Config.EventName),
                                   };
            frm_Report frm = new frm_Report();
            frm.PreviewReport(ReportParams);

        }
    }
}

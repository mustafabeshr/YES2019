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
    public partial class frm_Report : Form
    {
        public frm_Report()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void frm_Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
        public void PreviewAdmissionByAgentReport(string EntryDocNo,ReportParameter[] parameters)
        {
            reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "AgentAdmission.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_AdmissionReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            ReportDataSource rds = new ReportDataSource("AddmissionDataset", dt);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
        }

        public void PreviewEntireReceptionInfoReport(string EntryDocNo, ReportParameter[] parameters)
        {
            reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "EntireReceptionInfo.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetReception", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            DataTable dt2 = Db.GetDataAsDataTableFromSP("sp_GetReceptionDetails", "AdmissionDT2", "@EntryDocNo", EntryDocNo);    
            ReportDataSource rds = new ReportDataSource("ReceptionDataSet", dt);
            ReportDataSource rds2 = new ReportDataSource("ReceptionDetailsDataSet", dt2);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds2);
            //reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
        }
        public void PreviewEntireDlgReceptionInfoReport(string EntryDocNo, ReportParameter[] parameters)
        {
            reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "EntireReceptionInfo.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetDlgReception", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            DataTable dt2 = Db.GetDataAsDataTableFromSP("sp_GetDlgReceptionDetails", "AdmissionDT2", "@EntryDocNo", EntryDocNo);
            ReportDataSource rds = new ReportDataSource("ReceptionDataSet", dt);
            ReportDataSource rds2 = new ReportDataSource("ReceptionDetailsDataSet", dt2);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds2);
            //reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
        }

        public void PreviewReport(ReportParameter[] parameters)
        {
            reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "AttendanceReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_AttendanceInfo", "AdmissionDT");
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.WindowState= FormWindowState.Maximized;
            this.ShowDialog();
        }

        public void PreviewAgentAdmit(string EntryDocNo, ReportParameter[] parameters)
        {
            reportViewer1.LocalReport.ReportPath = Config.ReportsPath + "AgentAdmit.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            DataTable dt = Db.GetDataAsDataTableFromSP("sp_GetAgentAdmitReport", "AdmissionDT", "@EntryDocNo", EntryDocNo);
            ReportDataSource rds = new ReportDataSource("AgentAdmitDataSet", dt);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
        }
    }
}

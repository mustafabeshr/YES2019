using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_Dashboard : Form
    {
        private bool mouseIsDown = false;
        private Point firstPoint;
        
        class RoleSubitem
        {
            public string RoleId { get; set; }
            public int ItemId { get; set; }
            public int SubitemId { get; set; }
            public string SubitemName { get; set; }

        }
        public frm_Dashboard()
        {
            InitializeComponent();
            BuildControls(SharedParam.CurrentUser.RoleId);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void BuildControls(string roleid)
        {
            string strSQL = "SELECT  TOP (100) PERCENT dbo.Role_Items.roleid, dbo.Dashboad_item.itemid"
                           + ", dbo.Dashboad_item.itemname1, dbo.Dashboad_item.itemname2, "
                           + " dbo.Dashboad_item.itemorder, dbo.Dashboad_item.imagename,dbo.Dashboad_item.panel_name "
                           + " FROM   dbo.Dashboad_item INNER JOIN "
                           + " dbo.Role_Items ON dbo.Dashboad_item.itemid = dbo.Role_Items.itemid "
                           + " WHERE dbo.Role_Items.roleid=@RoleId"
                           + " ORDER BY dbo.Dashboad_item.itemorder desc";

            using (SqlConnection con = appcode.Db.GetSQLConnection())
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("RoleId", roleid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "RolesItems");
                foreach (DataRow Dr in ds.Tables["RolesItems"].Rows)
                {
                    Button btn = new Button();
                    btn.Name = Dr["itemname1"].ToString();
                    btn.Text = Dr["itemname2"].ToString();
                    btn.BackColor = System.Drawing.Color.Transparent;
                    btn.Cursor = Cursors.Hand;
                    btn.Dock = DockStyle.Top;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumBlue;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new System.Drawing.Font("Tahoma", 12F);
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.ImageKey = Dr["imagename"].ToString();
                    btn.ImageList = this.imageList1;
                    btn.Tag= Dr["panel_name"].ToString();
                    btn.Location = new System.Drawing.Point(0, 10);
                    btn.Size = new System.Drawing.Size(231, 40);
                    btn.TabIndex = 0;
                    btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    btn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    btn.UseVisualStyleBackColor = false;
                    btn.Click += Btn_Click;
                    pnl_Item.Controls.Add(btn);
                }
            }

           
        }
        void HideAllButtons(Control parent)
        {
            foreach(Control c in parent.Controls)
            {
                if (c.GetType().Name=="Button")
                {
                    c.Visible = false;
                }
                else if (c.GetType().Name == "Panel")
                {
                    HideAllButtons(c);
                }
            }
        }

        void ShowButtons(Control parent,string btnName)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().Name == "Button" && c.Name==btnName)
                {
                    c.Visible = true;
                }
                else if (c.GetType().Name == "Panel")
                {
                    ShowButtons(c, btnName);
                }
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            string panelname = ((Button)sender).Tag.ToString();
            showHidePanels(panelname);
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

        private void frm_Dashboard_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void frm_Dashboard_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            showHidePanels(string.Empty);
            HideAllButtons(pnl_Container);
            #region Load sub-items ..
            List<RoleSubitem> role_subitem_list = new List<RoleSubitem>();
            string strSQL = "SELECT  [roleid],[itemid],[subitemid],[subitemname1],[subitemname2],[subitemorder]"
                + "  FROM [dbo].[v_Role_Subitem]  WHERE roleid=@role order by [itemid],[subitemid] ";
            DataTable dt = Db.GetDataAsDataTable(strSQL, "items", "role", SharedParam.CurrentUser.RoleId);
            if (dt != null)
            {
                foreach (DataRow itemDataRow in dt.Rows)
                {
                    ShowButtons(pnl_Container, itemDataRow["subitemname1"].ToString());
                }

            }
            #endregion
        }

        void showHidePanels(string OnlyThis)
        {
            if (string.IsNullOrEmpty(OnlyThis))
            {
                foreach (Panel p in pnl_Container.Controls)
                {
                    p.Visible = false;
                }
            }
            else
            {
                foreach (Panel p in pnl_Container.Controls)
                {
                    if (p.Name == OnlyThis)
                    {
                        p.Visible = true;
                        p.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        p.Visible = false;
                    }
                }
            }
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            if (SharedParam.CurrentUser.HasSingleHolderClass)
            {
                frm_reception frm = new frm_reception(SharedParam.SINGLE_HOLDER_CLASS);
                frm.ShowDialog();
            }
        }

        private void btnReceptionEmployee_Click(object sender, EventArgs e)
        {
            if (SharedParam.CurrentUser.HasEmployeeHolderClass)
            {
                frm_reception frm = new frm_reception(SharedParam.EMPLOYEE_HOLDER_CLASS);
                frm.ShowDialog();
            }
        }

        private void btn_Del_ReceptionSingle_Click(object sender, EventArgs e)
        {
            if (SharedParam.CurrentUser.HasSingleHolderClass)
            {
               frm_DlgReception frm = new frm_DlgReception(SharedParam.SINGLE_HOLDER_CLASS,"new","0");
                frm.ShowDialog();
            }
        }

        private void btn_Del_ReceptionEmployee_Click(object sender, EventArgs e)
        {
            if (SharedParam.CurrentUser.HasEmployeeHolderClass)
            {
                frm_DlgReception frm = new frm_DlgReception(SharedParam.EMPLOYEE_HOLDER_CLASS, "new", "0");
                frm.ShowDialog();
            }
        }

        private void btn_Del_ReceptionCompany_Click(object sender, EventArgs e)
        {
            if (SharedParam.CurrentUser.HasCompanyHolderClass)
            {
              frm_DlgCompanyFounder frm = new frm_DlgCompanyFounder(SharedParam.COMPANY_HOLDER_CLASS);
                frm.ShowDialog();
            }
        }

        private void btn_Del_ReceptionFounder_Click(object sender, EventArgs e)
        {
            if (SharedParam.CurrentUser.HasFounderHolderClass)
            {
                frm_DlgCompanyFounder frm = new frm_DlgCompanyFounder(SharedParam.FOUNDER_HOLDER_CLASS);
                frm.ShowDialog();
            }
        }

        private void btn_can_new_Click(object sender, EventArgs e)
        {
            frm_NewCandidate frm = new frm_NewCandidate("new", "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  استقبال الترشيحات","0",string.Empty);
            frm.ShowDialog();
        }

        private void btn_can_edit_Click(object sender, EventArgs e)
        {
            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 4, 2, "Allow_Candidate_Edit"))
            {
                frm_CandidateQuery frm = new frm_CandidateQuery(true);
                frm.ShowDialog();
            }
            else
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("ليس لديك الصلاحية الكافية");
                frm.ShowDialog();
            }
            //frm_NewCandidate frm = new frm_NewCandidate("edit", "نظام ادارة اجتماع الجمعية العمومية ليمن موبايل -  تعديل بيانات المرشحين", "0");
            //frm.ShowDialog();
        }

        private void btn_can_query_Click(object sender, EventArgs e)
        {
            frm_CandidateQuery frm = new frm_CandidateQuery(false);
            frm.ShowDialog();
        }

        private void btn_Del_Query_Click(object sender, EventArgs e)
        {
            frm_DlgReceptionQuery frm = new frm_DlgReceptionQuery();
            frm.ShowDialog();
        }

        private void btn_rec_query_Click(object sender, EventArgs e)
        {
            frm_DlgReceptionQuery frm = new frm_DlgReceptionQuery();
            frm.ShowDialog();
        }

        private void btn_rec_search_Click(object sender, EventArgs e)
        {
            frm_shareholders frm = new frm_shareholders();
            frm.ShowDialog();
        }

        private void btn_st_users_Click(object sender, EventArgs e)
        {
            frm_users frm = new frm_users("new","0");
            frm.ShowDialog();
        }

        private void btn_st_UserQuery_Click(object sender, EventArgs e)
        {
            frm_UserQuery frm = new frm_UserQuery();
            frm.ShowDialog();
        }

        private void btn_st_ChangePassword_Click(object sender, EventArgs e)
        {
            frm_ChangePassword frm = new frm_ChangePassword();
            frm.ShowDialog();
        }

        private void btnRoleItem_Click(object sender, EventArgs e)
        {
            frm_RoleItem frm = new frm_RoleItem();
            frm.ShowDialog();
        }

        private void btn_vote_print_Click(object sender, EventArgs e)
        {
            frm_PrintVote frm = new frm_PrintVote("first_print",string.Empty,"vote");
            frm.ShowDialog();
        }

        private void btn_vote_reprint_Click(object sender, EventArgs e)
        {
            if (Db.HasRight(SharedParam.CurrentUser.RoleId, 5, 1, "ReprintVotePaper"))
            {
                frm_PrintVote frm = new frm_PrintVote("reprint", string.Empty, "vote");
                frm.ShowDialog();
            }
            else
            {
                Dialogs.Dg_Error frm = new Dialogs.Dg_Error("ليس لديك الصلاحية الكافية");
                frm.ShowDialog();
            }
        }

        private void btn_vote_query_Click(object sender, EventArgs e)
        {
            frm_VotePaperQuery frm = new frm_VotePaperQuery();
            frm.ShowDialog();
        }

        private void btn_can_approved_Click(object sender, EventArgs e)
        {
            frm_CandidateApprov frm = new frm_CandidateApprov();
            frm.ShowDialog();
        }

        private void btn_info_attendance_Click(object sender, EventArgs e)
        {
            frm_AttendanceInfo frm = new frm_AttendanceInfo();
            frm.ShowDialog();
        }

        private void btn_info_canSingle_Click(object sender, EventArgs e)
        {
            frm_ShowCandidates frm = new frm_ShowCandidates(SharedParam.SINGLE_HOLDER_CLASS);
            frm.ShowDialog();
        }

        private void btn_info_canEmployee_Click(object sender, EventArgs e)
        {
            frm_ShowCandidates frm = new frm_ShowCandidates(SharedParam.EMPLOYEE_HOLDER_CLASS);
            frm.ShowDialog();
        }

        private void btn_info_canCompany_Click(object sender, EventArgs e)
        {
            frm_ShowCandidates frm = new frm_ShowCandidates(SharedParam.COMPANY_HOLDER_CLASS);
            frm.ShowDialog();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            string Msg = "هل تريد بالتأكيد تسجيل الخروج؟" ;
            if (new Dialogs.Dg_ComfirmMessage("تسجيل خروج", Msg).MessageResult() == DialogResult.Yes)
            {
                SharedParam.CurrentUser = null;
                GC.Collect();
                this.Close();
                frm_login frm = new frm_login();
                frm.Show();
                

            }
                
        }

        private void btnDelApproved_Click(object sender, EventArgs e)
        {
            frm_PostDlgReception frm = new frm_PostDlgReception();
            frm.ShowDialog();
        }

        private void btnAgentReport1_Click(object sender, EventArgs e)
        {
            //frm_AgentSummaryReport frm = new frm_AgentSummaryReport();
            //frm.ShowDialog();
        }

        private void btnAssignPrinter_Click(object sender, EventArgs e)
        {
            //frm_PrintersAssign frm = new frm_PrintersAssign();
            //frm.ShowDialog();
        }
    }
}

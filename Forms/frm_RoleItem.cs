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
    public partial class frm_RoleItem : Form
    {
        class RoleItem
        {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
        }
        class RoleSubitem
        {
            public bool Selected { get; set; }
            public int Item { get; set; }
            public int Subitem { get; set; }
            public string SubitemName { get; set; }
        }

        class Permission
        {
            public bool Selected { get; set; }
            public int Item { get; set; }
            public int Subitem { get; set; }
            public string PermissionId { get; set; }
            public string PermissionName { get; set; }
        }
        List<RoleSubitem> RoleSubitemList = new List<RoleSubitem>();
        List<RoleItem> RoleItemList = new List<RoleItem>();
        List<Permission> PermissionList = new List<Permission>();
        private bool mouseIsDown = false;
        private Point firstPoint;
        public frm_RoleItem()
        {
            InitializeComponent();
        }

        private void frm_RoleItem_Load(object sender, EventArgs e)
        {
            txtUserInfo.Text = Config.LoggedInUserInfo;
            PopulateIdTypesLists();
            LoadLists();
        }
        void PopulateIdTypesLists()
        {
            string strsql = "select roleid,rolename,role_order from roles  order by role_order";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt != null)
            {
                coRole.DataSource = dt;
                coRole.DisplayMember = "rolename";
                coRole.ValueMember = "roleid";
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_RoleItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode==Keys.F9)
            {
                btn_Query_Click(sender,  e);
            }
            if (e.KeyCode == Keys.F9)
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

        void LoadLists()
        {
            dgv_Item.DataSource = null;
            string strsql = "SELECT [itemid],ltrim(rtrim([itemname2])) itemname2 FROM [dbo].[Dashboad_item] ORDER BY [itemorder]";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            if (dt!=null)
            {
                foreach (DataRow ItemDataRow in dt.Rows)
                {
                    RoleItem tmp = new RoleItem();
                    tmp.ItemId = Int16.Parse(ItemDataRow["itemid"].ToString());
                    tmp.ItemName = ItemDataRow["itemname2"].ToString();
                    RoleItemList.Add(tmp);
                }
                //dgv_Item.DataSource = RoleItemList;
                PrepareItemGrid();
            }


            dgv_Subitem.DataSource = null;
            strsql = "SELECT [itemid],[subitemid],[subitemname2]  FROM [dbo].[Dashboard_subitem] "
                + "  ORDER BY [subitemorder]";
            DataTable dt2 = Db.GetDataAsDataTable(strsql);
            if (dt2 != null)
            {
                foreach (DataRow SubitemDataRow in dt2.Rows)
                {
                    RoleSubitem tmp = new RoleSubitem();
                    tmp.Selected = false;
                    tmp.Subitem = Int16.Parse(SubitemDataRow["subitemid"].ToString());
                    tmp.SubitemName = SubitemDataRow["subitemname2"].ToString();
                    tmp.Item = Int16.Parse(SubitemDataRow["itemid"].ToString());
                    RoleSubitemList.Add(tmp);
                }
                //dgv_Subitem.DataSource = RoleSubitemList;
                //PrepareSubitemGrid();
            }

            dgv_Permission.DataSource = null;
            strsql = "SELECT [itemid],[subitemid],[permission_id],[permission_name] FROM [dbo].[permissions] ORDER BY [permission_order] ";
            DataTable dt3 = Db.GetDataAsDataTable(strsql);
            if (dt3 != null)
            {
                foreach (DataRow PemissionDataRow in dt3.Rows)
                {
                    Permission tmp = new Permission();
                    tmp.Selected = false;
                    tmp.Item = Int16.Parse(PemissionDataRow["itemid"].ToString());
                    tmp.Subitem = Int16.Parse(PemissionDataRow["subitemid"].ToString());
                    tmp.PermissionId = PemissionDataRow["permission_id"].ToString();
                    tmp.PermissionName = PemissionDataRow["permission_name"].ToString();
                    PermissionList.Add(tmp);
                }
                //dgv_Subitem.DataSource = RoleSubitemList;
                //PrepareSubitemGrid();
            }
        }
        //Db.HasData("[dbo].[Role_Subitem]", " WHERE roleid='"+coRole.SelectedValue.ToString()+"'"
        //                + " AND itemid="+ SubitemDataRow["itemid"].ToString()
        //                + " AND subitemid="+ SubitemDataRow["subitemid"].ToString());
        private void btn_Query_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("11111");
            foreach (RoleSubitem r in RoleSubitemList)
            {
                r.Selected = Db.HasData("[dbo].[Role_Subitem]", " WHERE roleid='" + coRole.SelectedValue.ToString() + "'"
                        + " AND itemid=" + r.Item
                        + " AND subitemid=" + r.Subitem);
            }
            //MessageBox.Show("222");
            foreach (Permission r in PermissionList)
            {
                r.Selected = Db.HasData("[dbo].[Role_Permission]", " WHERE roleid='" + coRole.SelectedValue.ToString() + "'"
                        + " AND itemid=" + r.Item
                        + " AND subitemid=" + r.Subitem
                        + " AND permission_id='" + r.PermissionId + "'");
            }
            //MessageBox.Show("3333");
            //MessageBox.Show("RoleItemList.Count=" + RoleItemList.Count.ToString());
            dgv_Item.DataSource = RoleItemList;
            PrepareItemGrid();
            //MessageBox.Show("4444");
            dgv_Item.Rows[0].Selected = true;
            LoadSubitemData(0);
            //MessageBox.Show("555");
            dgv_Subitem.Rows[0].Selected = true;
            LoadPermissionData(0);
            //dgv_Subitem.DataSource = RoleSubitemList;

        }
        private void PrepareItemGrid()
        {
            try
            {
                dgv_Item.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Item.Columns["ItemId"].HeaderText = "رمز البند";
                dgv_Item.Columns["ItemId"].Width = 80;
                dgv_Item.Columns["ItemId"].DisplayIndex = 0;
                dgv_Item.Columns["ItemId"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Item.Columns["ItemId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Item.Columns["ItemName"].HeaderText = "اسم البند";
                dgv_Item.Columns["ItemName"].Width = 1000;
                dgv_Item.Columns["ItemName"].DisplayIndex = 1;
                dgv_Item.Columns["ItemName"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Item.Columns["ItemName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //txtTotalRows.Text = dgv_User.RowCount.ToString();
            }
            catch
            {
                //txtTotalRows.Text = "0";
            }
        }

        private void dgv_Item_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadSubitemData(e.RowIndex);
        }

        private void LoadSubitemData(int rowindex)
        {
            //if (RoleSubitemList.Count > 0)
            //{
            //    List<RoleSubitem> RoleSubitemList2 = new List<RoleSubitem>();
            //    RoleSubitemList2 = RoleSubitemList.FindAll(t => t.Item == Int16.Parse(dgv_Item["ItemId", e.RowIndex].Value.ToString()));
            dgv_Subitem.DataSource = RoleSubitemList.FindAll(t => t.Item == Int16.Parse(dgv_Item["ItemId", rowindex].Value.ToString()));
            PrepareSubitemGrid();
            //}
        }

        private void LoadPermissionData(int rowindex)
        {
            //if (RoleSubitemList.Count > 0)
            //{
            //    List<RoleSubitem> RoleSubitemList2 = new List<RoleSubitem>();
            //    RoleSubitemList2 = RoleSubitemList.FindAll(t => t.Item == Int16.Parse(dgv_Item["ItemId", e.RowIndex].Value.ToString()));
            dgv_Permission.DataSource = PermissionList.FindAll(t => t.Item == Int16.Parse(dgv_Subitem["Item", rowindex].Value.ToString())
            && t.Subitem == Int16.Parse(dgv_Subitem["Subitem", rowindex].Value.ToString()));
            PreparePermissionGrid();
            //}
        }

        private void PreparePermissionGrid()
        {
            try
            {
                dgv_Permission.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Permission.Columns["Selected"].HeaderText = "تحديد";
                dgv_Permission.Columns["Selected"].Width = 50;
                dgv_Permission.Columns["Selected"].DisplayIndex = 0;
                dgv_Permission.Columns["Selected"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Permission.Columns["Selected"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Permission.Columns["PermissionName"].HeaderText = "الصلاحية";
                dgv_Permission.Columns["PermissionName"].Width = 400;
                dgv_Permission.Columns["PermissionName"].ReadOnly = true;
                dgv_Permission.Columns["PermissionName"].DisplayIndex = 1;
                dgv_Permission.Columns["PermissionName"].DefaultCellStyle.ForeColor = Color.Black;

                dgv_Permission.Columns["Item"].Visible = false;
                dgv_Permission.Columns["Subitem"].Visible = false;
                dgv_Permission.Columns["PermissionId"].Visible = false;
                //txtTotalRows.Text = dgv_User.RowCount.ToString();
            }
            catch
            {
                //txtTotalRows.Text = "0";
            }
        }
        private void PrepareSubitemGrid()
        {
            try
            {
                dgv_Subitem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Subitem.Columns["Selected"].HeaderText = "تحديد";
                dgv_Subitem.Columns["Selected"].Width = 50;
                dgv_Subitem.Columns["Selected"].DisplayIndex = 0;
                dgv_Subitem.Columns["Selected"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Subitem.Columns["Selected"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Subitem.Columns["Subitem"].HeaderText = "رقم البند";
                dgv_Subitem.Columns["Subitem"].Width = 50;
                dgv_Subitem.Columns["Subitem"].ReadOnly = true;
                dgv_Subitem.Columns["Subitem"].DisplayIndex = 1;
                dgv_Subitem.Columns["Subitem"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Subitem.Columns["Subitem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Subitem.Columns["SubitemName"].HeaderText = "اسم البند";
                dgv_Subitem.Columns["SubitemName"].ReadOnly = true;
                dgv_Subitem.Columns["SubitemName"].Width = 400;
                dgv_Subitem.Columns["SubitemName"].DisplayIndex = 2;
                dgv_Subitem.Columns["SubitemName"].DefaultCellStyle.ForeColor = Color.Black;
                dgv_Subitem.Columns["SubitemName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Subitem.Columns["Item"].Visible = false;
                //txtTotalRows.Text = dgv_User.RowCount.ToString();
            }
            catch
            {
                //txtTotalRows.Text = "0";
            }
        }

        private void btn_selectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Subitem.Rows.Count; ++i)
            {
               dgv_Subitem["Selected", i].Value = true;
            }
        }

        private void btn_deselectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Subitem.Rows.Count; ++i)
            {
                dgv_Subitem["Selected", i].Value = false;
            }
        }

        private void btn_inverseSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Subitem.Rows.Count; ++i)
            {
                if (DBNull.Equals(dgv_Subitem["Selected", i].Value, null) ||
                     Boolean.Parse(dgv_Subitem["Selected", i].Value.ToString()) == true)
                {
                    dgv_Subitem["Selected", i].Value = false;
                }
                else
                {
                    dgv_Subitem["Selected", i].Value = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                if (dgv_Item.Rows.Count > 0)
                {
                    btnSave.Enabled = false;
                    Cursor.Current = Cursors.WaitCursor;
                    string strsql = string.Empty;
                    foreach (RoleSubitem tmp in RoleSubitemList)
                    {
                        if (tmp.Selected)
                        {
                            if (Db.HasData("[dbo].[Role_Items]", " WHERE roleid='" + coRole.SelectedValue.ToString() + "'"
                                + " AND itemid=" + tmp.Item.ToString()))
                            {
                                string result = Db.AddRoleSubitem(coRole.SelectedValue.ToString(), tmp.Item, tmp.Subitem);
                            }
                            else
                            {
                                string result = Db.AddRoleItem(coRole.SelectedValue.ToString(), tmp.Item);
                                result = Db.AddRoleSubitem(coRole.SelectedValue.ToString(), tmp.Item, tmp.Subitem);
                            }
                        }
                        else
                        {
                            string result = Db.DeleteRoleSubitem(coRole.SelectedValue.ToString(), tmp.Item, tmp.Subitem);
                        }
                    }
                    // Add Remove Permissions ...
                    foreach (Permission tmp in PermissionList)
                    {
                        if (tmp.Selected)
                        {
                            if (!Db.HasData("[dbo].[Role_Permission]", " WHERE roleid='" + coRole.SelectedValue.ToString() + "'"
                                + " AND itemid=" + tmp.Item
                                + " AND subitemid=" + tmp.Subitem
                                + " AND permission_id='" + tmp.PermissionId + "'"))
                            {
                                string result = Db.AddPermission(coRole.SelectedValue.ToString(), tmp.Item, tmp.Subitem, tmp.PermissionId);
                            }
                        }
                        else
                        {
                            string result = Db.DeletePermission(coRole.SelectedValue.ToString(), tmp.Item, tmp.Subitem, tmp.PermissionId);
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    btnSave.Enabled = true;
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void coRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_Item.DataSource = null;
            dgv_Subitem.DataSource = null;
        }

        private void dgv_Subitem_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadPermissionData(e.RowIndex);
        }

        private void btn_PerSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Permission.Rows.Count; ++i)
            {
                dgv_Permission["Selected", i].Value = true;
            }
        }

        private void btn_PerDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Permission.Rows.Count; ++i)
            {
                dgv_Permission["Selected", i].Value = false;
            }
        }

        private void btn_PerInverseSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_Permission.Rows.Count; ++i)
            {
                if (DBNull.Equals(dgv_Permission["Selected", i].Value, null) ||
                     Boolean.Parse(dgv_Permission["Selected", i].Value.ToString()) == true)
                {
                    dgv_Permission["Selected", i].Value = false;
                }
                else
                {
                    dgv_Permission["Selected", i].Value = true;
                }
            }
        }
    }
}

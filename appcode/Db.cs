using System;
using System.Data;
using System.Data.SqlClient;

namespace YES.appcode
{
    /// <summary>
    /// Contains all database functions.
    /// </summary>
    class Db
    {
        public static SqlConnection GetSQLConnection()
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            scb.PersistSecurityInfo = true;
            if (Utility.GetKeyValueFromConfigFile("Local") == "no")
            {
                scb.UserID = Security.Cryptography.Decrypt(Utility.GetKeyValueFromConfigFile("User"), true, "Ym!YEs");
                scb.Password = Security.Cryptography.Decrypt(Utility.GetKeyValueFromConfigFile("Password"), true, "Ym!YEs");
                //scb.DataSource = Security.Cryptography.Decrypt(Utility.GetKeyValueFromConfigFile("DB_Server"), true, "Ym!YEs");
                scb.DataSource = Utility.GetKeyValueFromConfigFile("DB_Server");
                scb.InitialCatalog = Security.Cryptography.Decrypt(Utility.GetKeyValueFromConfigFile("DB_Name"), true, "Ym!YEs");
                scb.ConnectTimeout = 30;
                //scb.IntegratedSecurity = true;
            }
            else
            {
                scb.UserID = "sa";
                scb.Password = "Mus1234";
                scb.DataSource = ".";
                scb.InitialCatalog = "YES2016";
                scb.ConnectTimeout = 30;
            }
            SqlConnection con = new SqlConnection(scb.ConnectionString);
            return con;
        }
        public static DataTable GetDataAsDataTableFromSP(string SPName,string DataTableName="Table1",params string[] Params)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand(SPName, sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i=0;i<Params.Length;i+=2)
                {
                    cmd.Parameters.AddWithValue(Params[i], Params[i + 1]);
                }
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DA.Fill(DS, DataTableName);
                if (DS.Tables[DataTableName].Rows.Count > 0)
                {
                    return DS.Tables[DataTableName];
                }
                else
                {
                    return null;
                }
            }
        }
        public static DataTable GetDataAsDataTable(string strsql, string DataTableName = "Table1", params string[] Params)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < Params.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(Params[i], Params[i + 1]);
                }
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DA.Fill(DS, DataTableName);
                if (DS.Tables[DataTableName].Rows.Count > 0)
                {
                    return DS.Tables[DataTableName];
                }
                else
                {
                    return null;
                }
            }
        }
        public static DataTable GetDataAsDataTable(string strsql, params string[] Params)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < Params.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(Params[i], Params[i + 1]);
                }
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    return DS.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }


        public static string GetPrinterName(string MACAddress)
        {
            return "printer";
            //using (SqlConnection sqlconnection = GetSQLConnection())
            //{
            //    string strsql = "SELECT [PrinterName] FROM [dbo].[PrinterSettings] WHERE [MachineMacAddress]='" + MACAddress + "'";
            //    DataSet DS = new DataSet();
            //    SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
            //    cmd.CommandType = CommandType.Text;
            //    SqlDataAdapter DA = new SqlDataAdapter();
            //    DA.SelectCommand = cmd;
            //    DA.Fill(DS);
            //    if (DS.Tables[0].Rows.Count > 0)
            //    {
            //        return DS.Tables[0].Rows[0]["PrinterName"].ToString();
            //    }
            //    else
            //    {
            //        return "N/A";
            //    }
            //}
        }

        public static string GetFieldData(string FieldName,string strsql, params string[] Params)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
                cmd.CommandType = CommandType.Text;
                for (int i = 0; i < Params.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(Params[i], Params[i + 1]);
                }
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    return DS.Tables[0].Rows[0][FieldName].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public static DataTable GetDataAsDataTable(string strsql)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    return DS.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public static bool HasData(string TableName,string WhereClause)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                string strsql = "SELECT isnull(count(*),0) as cnt from  " + TableName + WhereClause;
                SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
                sqlconnection.Open();
                int result = int.Parse(cmd.ExecuteScalar().ToString());
                if (result>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool isHolderClassHasCandidates(string holderClass)
        {
            string strsql = "SELECT isnull(count(*),0) CandCount   FROM [dbo].[candidate]  WHERE cand_class = '"+ holderClass + "' AND status ='candidate' ";
            var dt = GetDataAsDataTable(strsql);
            if (dt == null) return false;
            if (int.Parse(dt.Rows[0]["CandCount"].ToString()) > 0)
                return true;
            else return false;
        }

        public static bool ExecuteSQLCommand(string strsql)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                SqlCommand cmd = new SqlCommand(strsql, sqlconnection);
                sqlconnection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static string CreateReception(string CertNo,int ShareQty,string HolderClass,string HolderName
            ,string IdType,string IdNo,DateTime IdDate,string IdPlace,int EntryCardNo,string Note,string userid
            , string ReceptionType,string status,string statususer)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertReception", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cert_no", CertNo);
                cmd.Parameters.AddWithValue("share_qty", ShareQty);
                cmd.Parameters.AddWithValue("holder_class", HolderClass);
                cmd.Parameters.AddWithValue("holder_name", HolderName);
                cmd.Parameters.AddWithValue("id_type", IdType);
                cmd.Parameters.AddWithValue("id_no", IdNo);
                cmd.Parameters.AddWithValue("id_place", IdPlace);
                cmd.Parameters.AddWithValue("id_date",IdDate);
                cmd.Parameters.AddWithValue("entry_card_no", EntryCardNo);
                cmd.Parameters.AddWithValue("note", Note);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("reception_type", ReceptionType);
                cmd.Parameters.AddWithValue("status", status);
                cmd.Parameters.AddWithValue("statususer", statususer);
                sqlconnection.Open();
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
        }


        public static string CreateDlgReception(string CertNo, int ShareQty, string HolderClass, string HolderName
         , string IdType, string IdNo, DateTime IdDate, string IdPlace, int EntryCardNo, string Note, string userid
         , string ReceptionType, string status, string statususer)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertDlgReception", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cert_no", CertNo);
                cmd.Parameters.AddWithValue("share_qty", ShareQty);
                cmd.Parameters.AddWithValue("holder_class", HolderClass);
                cmd.Parameters.AddWithValue("holder_name", HolderName);
                cmd.Parameters.AddWithValue("id_type", IdType);
                cmd.Parameters.AddWithValue("id_no", IdNo);
                cmd.Parameters.AddWithValue("id_place", IdPlace);
                cmd.Parameters.AddWithValue("id_date", IdDate);
                cmd.Parameters.AddWithValue("entry_card_no", EntryCardNo);
                cmd.Parameters.AddWithValue("note", Note);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("reception_type", ReceptionType);
                cmd.Parameters.AddWithValue("status", status);
                cmd.Parameters.AddWithValue("statususer", statususer);
                sqlconnection.Open();
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
        }

        public static int EditReception(string EntryDocNo, string IdType, string IdNo, DateTime IdDate
            , string IdPlace, int EntryCardNo, string Note)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_EditReception", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_doc_no", EntryDocNo);
                cmd.Parameters.AddWithValue("id_type", IdType);
                cmd.Parameters.AddWithValue("id_no", IdNo);
                cmd.Parameters.AddWithValue("id_place", IdPlace);
                cmd.Parameters.AddWithValue("id_date", IdDate);
                cmd.Parameters.AddWithValue("entry_card_no", EntryCardNo);
                cmd.Parameters.AddWithValue("note", Note);
               
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }


        public static int EditDlgReception(string EntryDocNo, string IdType, string IdNo, DateTime IdDate
           , string IdPlace, int EntryCardNo, string Note)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_EditDlgReception", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_doc_no", EntryDocNo);
                cmd.Parameters.AddWithValue("id_type", IdType);
                cmd.Parameters.AddWithValue("id_no", IdNo);
                cmd.Parameters.AddWithValue("id_place", IdPlace);
                cmd.Parameters.AddWithValue("id_date", IdDate);
                cmd.Parameters.AddWithValue("entry_card_no", EntryCardNo);
                cmd.Parameters.AddWithValue("note", Note);

                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int PostReception(string EntryDocNo,string postuser)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_PostReception", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_doc_no", EntryDocNo);
                cmd.Parameters.AddWithValue("@postuser", postuser);

                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int PostDlgReception(string EntryDocNo, string postuser)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_PostDlgReception", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entry_doc_no", EntryDocNo);
                cmd.Parameters.AddWithValue("@postuser", postuser);

                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int CreateReceptionDetails(int EntryDocNo, int LineNo, string CertNo, int ShareQty
           , string HolderClass, bool isDelagate, string DlgNO,DateTime DlgDate,string DlgName
           ,string ApprovedNo,DateTime ApprovedDate,string ApprovedOrg,int CertRowId,string Note,string DelegateType
            ,string Reception_Type,string userid)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertReceptionDetails", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("entry_doc_no", EntryDocNo);
                cmd.Parameters.AddWithValue("line_no", LineNo);
                cmd.Parameters.AddWithValue("cert_no", CertNo);
                cmd.Parameters.AddWithValue("share_qty", ShareQty);
                cmd.Parameters.AddWithValue("holder_class", HolderClass);
                cmd.Parameters.AddWithValue("delegate", isDelagate);
                cmd.Parameters.AddWithValue("dlg_no", DlgNO);
                cmd.Parameters.AddWithValue("dlg_date", DlgDate.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("dlg_name", DlgName);
                cmd.Parameters.AddWithValue("approved_no", ApprovedNo);
                cmd.Parameters.AddWithValue("approved_date", ApprovedDate.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("approved_org", ApprovedOrg);
                cmd.Parameters.AddWithValue("certrowid", CertRowId);
                cmd.Parameters.AddWithValue("note", Note);
                cmd.Parameters.AddWithValue("@Delegate_Type", DelegateType);
                cmd.Parameters.AddWithValue("@reception_type", Reception_Type);
                cmd.Parameters.AddWithValue("@userid", userid);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int CreateDlgReceptionDetails(int EntryDocNo, int LineNo, string CertNo, int ShareQty
          , string HolderClass, bool isDelagate, string DlgNO, DateTime DlgDate, string DlgName
          , string ApprovedNo, DateTime ApprovedDate, string ApprovedOrg, int CertRowId, string Note, string DelegateType
           , string Reception_Type, string userid)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertDlgReceptionDetails", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("entry_doc_no", EntryDocNo);
                cmd.Parameters.AddWithValue("line_no", LineNo);
                cmd.Parameters.AddWithValue("cert_no", CertNo);
                cmd.Parameters.AddWithValue("share_qty", ShareQty);
                cmd.Parameters.AddWithValue("holder_class", HolderClass);
                cmd.Parameters.AddWithValue("delegate", isDelagate);
                cmd.Parameters.AddWithValue("dlg_no", DlgNO);
                cmd.Parameters.AddWithValue("dlg_date", DlgDate.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("dlg_name", DlgName);
                cmd.Parameters.AddWithValue("approved_no", ApprovedNo);
                cmd.Parameters.AddWithValue("approved_date", ApprovedDate.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("approved_org", ApprovedOrg);
                cmd.Parameters.AddWithValue("certrowid", CertRowId);
                cmd.Parameters.AddWithValue("note", Note);
                cmd.Parameters.AddWithValue("@Delegate_Type", DelegateType);
                cmd.Parameters.AddWithValue("@reception_type", Reception_Type);
                cmd.Parameters.AddWithValue("@userid", userid);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int CreateCandidate(string cand_class, string cand_name, string nickname,DateTime DOB,string  birth_place
        ,string  address, string id_type, string id_no,DateTime id_date
        , string id_place, string work_org, string job, string mobile_no, string home_tel, string work_tel, string fax
        , string email, string website, string userid
        , string legal_name, string main_activity, string legal_form, string company_address, string licence_no
        ,DateTime licence_date, string licence_place, string note, byte[] cand_pic,string cand_pic_name)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertCandidate", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cand_class", cand_class);
                cmd.Parameters.AddWithValue("cand_name", cand_name);
                cmd.Parameters.AddWithValue("DOB", DOB.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("birth_place", birth_place);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("id_type", id_type);
                cmd.Parameters.AddWithValue("id_no", id_no);
                cmd.Parameters.AddWithValue("id_date", id_date.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("id_place", id_place);
                cmd.Parameters.AddWithValue("work_org", work_org);
                cmd.Parameters.AddWithValue("job", job);
                cmd.Parameters.AddWithValue("mobile_no", mobile_no);
                cmd.Parameters.AddWithValue("home_tel", home_tel);
                cmd.Parameters.AddWithValue("work_tel", work_tel);
                cmd.Parameters.AddWithValue("fax", fax);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("website", website);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("status", "request");
                cmd.Parameters.AddWithValue("status_date",DateTime.Now);
                cmd.Parameters.AddWithValue("create_time", DateTime.Now);
                cmd.Parameters.AddWithValue("legal_name", legal_name);
                cmd.Parameters.AddWithValue("main_activity", main_activity);
                cmd.Parameters.AddWithValue("legal_form", legal_form);
                cmd.Parameters.AddWithValue("company_address", company_address);
                cmd.Parameters.AddWithValue("licence_no", licence_no);
                cmd.Parameters.AddWithValue("licence_date", licence_date.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("licence_place", licence_place);
                cmd.Parameters.AddWithValue("note", note);
                cmd.Parameters.AddWithValue("cand_pic", cand_pic);
                cmd.Parameters.AddWithValue("cand_pic_name", cand_pic_name);

                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }


        public static int UpdateCandidate(string cand_no,string cand_class, string cand_name, string nickname, DateTime DOB, string birth_place
      , string address, string id_type, string id_no, DateTime id_date
      , string id_place, string work_org, string job, string mobile_no, string home_tel, string work_tel, string fax
      , string email, string website, string userid
      , string legal_name, string main_activity, string legal_form, string company_address, string licence_no
      , DateTime licence_date, string licence_place, string note,byte[] cand_pic,string cand_pic_name)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_UpdateCandidate", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cand_no", cand_no);
                cmd.Parameters.AddWithValue("cand_class", cand_class);
                cmd.Parameters.AddWithValue("cand_name", cand_name);
                cmd.Parameters.AddWithValue("DOB", DOB.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("birth_place", birth_place);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("id_type", id_type);
                cmd.Parameters.AddWithValue("id_no", id_no);
                cmd.Parameters.AddWithValue("id_date", id_date.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("id_place", id_place);
                cmd.Parameters.AddWithValue("work_org", work_org);
                cmd.Parameters.AddWithValue("job", job);
                cmd.Parameters.AddWithValue("mobile_no", mobile_no);
                cmd.Parameters.AddWithValue("home_tel", home_tel);
                cmd.Parameters.AddWithValue("work_tel", work_tel);
                cmd.Parameters.AddWithValue("fax", fax);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("website", website);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("legal_name", legal_name);
                cmd.Parameters.AddWithValue("main_activity", main_activity);
                cmd.Parameters.AddWithValue("legal_form", legal_form);
                cmd.Parameters.AddWithValue("company_address", company_address);
                cmd.Parameters.AddWithValue("licence_no", licence_no);
                cmd.Parameters.AddWithValue("licence_date", licence_date.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("licence_place", licence_place);
                cmd.Parameters.AddWithValue("note", note);
                cmd.Parameters.AddWithValue("cand_pic", cand_pic);
                cmd.Parameters.AddWithValue("cand_pic_name", cand_pic_name);

                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
        public static int InsertCandidateCerts(int cand_no, string cert_no, int share_qty
            , string holder_name,string class_id, string note,string cand_class)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertCandidateCerts", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cand_no", cand_no);
                cmd.Parameters.AddWithValue("cert_no", cert_no);
                cmd.Parameters.AddWithValue("share_qty", share_qty);
                cmd.Parameters.AddWithValue("holder_name", holder_name);
                cmd.Parameters.AddWithValue("class_id", class_id);
                cmd.Parameters.AddWithValue("note", note);
                cmd.Parameters.AddWithValue("@cand_class", cand_class);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string GetHolderDetailsClass(string EntryDocNo)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_GetHolderDetailsClass", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EntryDocNo", EntryDocNo);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string GetDlgHolderDetailsClass(string EntryDocNo)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_GetDlgHolderDetailsClass", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EntryDocNo", EntryDocNo);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int InsertCandidateExperience(int cand_no, int line_no, string experience, string cand_class)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertCandidateExperience", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cand_no", cand_no);
                cmd.Parameters.AddWithValue("line_no", line_no);
                cmd.Parameters.AddWithValue("experience", experience);
                cmd.Parameters.AddWithValue("@cand_class", cand_class);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int InsertCandidateLastJob(int cand_no,int line_no,string job,DateTime start_date,DateTime end_date,string org_name, string cand_class)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertCandidateLastJob", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cand_no", cand_no);
                cmd.Parameters.AddWithValue("job", job);
                cmd.Parameters.AddWithValue("line_no", line_no);
                cmd.Parameters.AddWithValue("start_date", start_date.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("end_date", end_date.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("org_name", org_name);
                cmd.Parameters.AddWithValue("@cand_class", cand_class);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static int InsertCandidateQualification(int cand_no, int line_no, string qualification, string cand_class)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertCandidateQualification", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cand_no", cand_no);
                cmd.Parameters.AddWithValue("line_no", line_no);
                cmd.Parameters.AddWithValue("qualification", qualification);
                cmd.Parameters.AddWithValue("@cand_class", cand_class);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string CreateUser(string userid, string userpassword, string username, string role_id, bool single_class, bool employee_class, bool company_class, bool founder_class,string createuserid)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_CreateUser", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@userpassword", userpassword);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@role_id", role_id);
                cmd.Parameters.AddWithValue("@single_class", single_class);
                cmd.Parameters.AddWithValue("@employee_class", employee_class);
                cmd.Parameters.AddWithValue("@company_class", company_class);
                cmd.Parameters.AddWithValue("@founder_class", founder_class);
                cmd.Parameters.AddWithValue("@createuserid", createuserid);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string UpdateUser(string userid,string status,string role_id, bool single_class, bool employee_class, bool company_class, bool founder_class)
        {
            try
            {
                using (SqlConnection sqlconnection = GetSQLConnection())
                {
                    DataSet DS = new DataSet();
                    SqlCommand cmd = new SqlCommand("sp_UpdateUser", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@role_id", role_id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@single_class", single_class);
                    cmd.Parameters.AddWithValue("@employee_class", employee_class);
                    cmd.Parameters.AddWithValue("@company_class", company_class);
                    cmd.Parameters.AddWithValue("@founder_class", founder_class);
                    sqlconnection.Open();
                    string result = (string)cmd.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "Error:"+ex.Message;
            }
        }

        public static string ChangeUserPassword(string userid, string password)
        {
            try
            {
                using (SqlConnection sqlconnection = GetSQLConnection())
                {
                    DataSet DS = new DataSet();
                    SqlCommand cmd = new SqlCommand("sp_ChangePassword", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@NewPass", password);
                    sqlconnection.Open();
                    string result = (string)cmd.ExecuteScalar();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
        }

        public static string AddRoleSubitem(string roleid, int itemid,int subitemid)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertRoleSubitem", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", roleid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                cmd.Parameters.AddWithValue("@subitemid", subitemid);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string DeleteRoleSubitem(string roleid, int itemid, int subitemid)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_DeleteRoleSubitem", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", roleid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                cmd.Parameters.AddWithValue("@subitemid", subitemid);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }
        public static string AddRoleItem(string roleid, int itemid)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertRoleItem", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", roleid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }
        public static string AddPermission(string roleid, int itemid, int subitemid,string permission_id)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertPermission", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", roleid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                cmd.Parameters.AddWithValue("@subitemid", subitemid);
                cmd.Parameters.AddWithValue("@permission_id", permission_id);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }
        public static string DeletePermission(string roleid, int itemid, int subitemid, string permission_id)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_DeletePermission", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", roleid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                cmd.Parameters.AddWithValue("@subitemid", subitemid);
                cmd.Parameters.AddWithValue("@permission_id", permission_id);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }
        public static bool HasRight(string roleid, int itemid, int subitemid, string permission_id)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_HasPermission", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", roleid);
                cmd.Parameters.AddWithValue("@itemid", itemid);
                cmd.Parameters.AddWithValue("@subitemid", subitemid);
                cmd.Parameters.AddWithValue("@permission_id", permission_id);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                if (result == "yes")
                    return true;
                else
                    return false;
            }
        }
        public static int PrintedTimes(int document_no, string document_type)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_PrintedTimes", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@document_no", document_no);
                cmd.Parameters.AddWithValue("@document_type", document_type);
                sqlconnection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
        public static string CreatePrint(int document_no, string document_type,string print_type,string print_user,string print_reason_id,string reason)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertPrint", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@document_no", document_no);
                cmd.Parameters.AddWithValue("@document_type", document_type);
                cmd.Parameters.AddWithValue("@print_type", print_type);
                cmd.Parameters.AddWithValue("@print_user", print_user);
                cmd.Parameters.AddWithValue("@print_reason_id", print_reason_id);
                cmd.Parameters.AddWithValue("@reason", reason);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string CreateCandidateChangeStatusLog(string cand_no, string old_status, string new_status
            , string status_user,string note,string cand_class)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertCandidateStatusLog", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cand_no", cand_no);
                cmd.Parameters.AddWithValue("@old_status", old_status);
                cmd.Parameters.AddWithValue("@new_status", new_status);
                cmd.Parameters.AddWithValue("@status_user", status_user);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@cand_class", cand_class);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }

        public static string CreateOrUpdatePrinter(string MachineIP,string MachineName,string MachineMacAddress,string PrinterName)
        {
            using (SqlConnection sqlconnection = GetSQLConnection())
            {
                DataSet DS = new DataSet();
                SqlCommand cmd = new SqlCommand("sp_InsertPrinterSettings", sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MachineIP", MachineIP);
                cmd.Parameters.AddWithValue("@MachineName", MachineName);
                cmd.Parameters.AddWithValue("@MachineMacAddress", MachineMacAddress);
                cmd.Parameters.AddWithValue("@PrinterName", PrinterName);
                sqlconnection.Open();
                string result = (string)cmd.ExecuteScalar();
                return result;
            }
        }


    }
}

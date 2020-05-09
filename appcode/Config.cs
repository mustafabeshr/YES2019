using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace YES.appcode
{
    /// <summary>
    /// Load all configurations to it to use throughout app.
    /// </summary>
    class Config
    {
        class ParamPairs
        {
           
            public string ParamId { get; set; }
            public string ParamValue { get; set; }
        }

        class Holder_Class
        {

            public string ClassId { get; set; }
            public string ClassName { get; set; }
        }

        private static bool _PrintAdmissionDocument = false;
        private static bool _AdmissionCardRequired = false;
        private static bool _AddAdditionalCertsToReception = false;
        private static int _CertNoLength = 0;
        private static string _ResetPasswordWord;
        private static int _MaxVotePaperPrintTimes = 0;
        private static int _MaxEntryDocPrintTimes = 0;
        private static DateTime _ChangeCandStatusLastDay;
        private static double _TotalYemenMobileShares;
        private static string _LoggedInUserInfo;
        private static string _EventName;
        private static string _ChoosePrinterIndecator;
        private static bool _CheckAgentCertStatus = true;
        private static List<Holder_Class> _HolderClassList = new List<Holder_Class>();
        public static bool PrintAdmissionDocument
        {
            get
            {
                return _PrintAdmissionDocument;
            }

            set
            {
                _PrintAdmissionDocument = value;
            }
        }
        public static bool AdmissionCardRequired
        {
            get
            {
                return _AdmissionCardRequired;
            }

            set
            {
                _AdmissionCardRequired = value;
            }
        }

        public static bool AddAdditionalCertsToReception
        {
            get
            {
                return _AddAdditionalCertsToReception;
            }

            set
            {
                _AddAdditionalCertsToReception = value;
            }
        }

        public static int CertNoLength
        {
            get
            {
                return _CertNoLength;
            }

            set
            {
                _CertNoLength = value;
            }
        }

        public static string ResetPasswordWord
        {
            get
            {
                return _ResetPasswordWord;
            }

            set
            {
                _ResetPasswordWord = value;
            }
        }

        public static string ReportsPath
        {
            get
            {
                return _ReportsPath;
            }

            set
            {
                _ReportsPath = value;
            }
        }

        public static string EventDate
        {
            get
            {
                return _EventDate;
            }

            set
            {
                _EventDate = value;
            }
        }

        public static string EventDayName
        {
            get
            {
                return _EventDayName;
            }

            set
            {
                _EventDayName = value;
            }
        }

        public static string EventYear
        {
            get
            {
                return _EventYear;
            }

            set
            {
                _EventYear = value;
            }
        }

        public static int MaxVotePaperPrintTimes
        {
            get
            {
                return _MaxVotePaperPrintTimes;
            }

            set
            {
                _MaxVotePaperPrintTimes = value;
            }
        }

        public static int MaxEntryDocPrintTimes
        {
            get
            {
                return _MaxEntryDocPrintTimes;
            }

            set
            {
                _MaxEntryDocPrintTimes = value;
            }
        }

        public static DateTime ChangeCandStatusLastDay
        {
            get
            {
                return _ChangeCandStatusLastDay;
            }

            set
            {
                _ChangeCandStatusLastDay = value;
            }
        }

        public static double TotalYemenMobileShares
        {
            get
            {
                return _TotalYemenMobileShares;
            }

            set
            {
                _TotalYemenMobileShares = value;
            }
        }

        public static string LoggedInUserInfo
        {
            get
            {
                return _LoggedInUserInfo;
            }

            set
            {
                _LoggedInUserInfo = value;
            }
        }

        public static string EventName
        {
            get
            {
                return _EventName;
            }

            set
            {
                _EventName = value;
            }
        }

        public string ChoosePrinterIndecator
        {
            get
            {
                return _ChoosePrinterIndecator;
            }

            set
            {
                _ChoosePrinterIndecator = value;
            }
        }

        public static bool CheckAgentCertStatus
        {
            get
            {
                return _CheckAgentCertStatus;
            }

            set
            {
                _CheckAgentCertStatus = value;
            }
        }

        private List<Holder_Class> HolderClassList
        {
            get
            {
                return _HolderClassList;
            }

            //set
            //{
            //    _HolderClassList = value;
            //}
        }

        private static string _ReportsPath;
        private static string _EventDate;
        private static string _EventDayName;
        private static string _EventYear;
        public static string GetHoldeClassName(string ClassId)
        {
            return _HolderClassList.Find(h => h.ClassId == ClassId).ClassName;
            //string ClassName = string.Empty;
            //switch (ClassId)
            //{
            //    case "single":
            //        ClassName = "أفراد - مواطنين";
            //        break;
            //    case "employee":
            //        ClassName = "موظفين";
            //        break;
            //    case "company":
            //        ClassName = "شركات";
            //        break;
            //    case "founder":
            //        ClassName = "مؤسسين";
            //        break;
            //    default:
            //        ClassName = "غير معروف";
            //        break;
            //}
            //return ClassName;

        }

        public static void Load()
        {
            List<ParamPairs> param_list = new List<ParamPairs>();
            string strsql = "select * from param";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            foreach(DataRow pdr in dt.Rows)
            {
                ParamPairs tmp = new ParamPairs();
                tmp.ParamId = pdr["param_id"].ToString();
                tmp.ParamValue= pdr["param_name"].ToString();
                param_list.Add(tmp);
            }

            
            strsql = "select [class_id],[class_name] from [dbo].[holder_class] order by [class_order]";
            DataTable dt2 = Db.GetDataAsDataTable(strsql);
            foreach (DataRow cr in dt2.Rows)
            {
                Holder_Class tmp = new Holder_Class();
                tmp.ClassId = cr["class_id"].ToString();
                tmp.ClassName = cr["class_name"].ToString();
                _HolderClassList.Add(tmp);
            }
            _TotalYemenMobileShares = 86524000;
            _PrintAdmissionDocument = Utility.IsBoolean(param_list.Find(t=>t.ParamId== "PrintAdmissionDocument").ParamValue);
            _AdmissionCardRequired = Utility.IsBoolean(param_list.Find(t => t.ParamId == "AdmissionCardRequired").ParamValue);
            _CheckAgentCertStatus = Utility.IsBoolean(param_list.Find(t => t.ParamId == "CheckAgentCertStatus").ParamValue); 
            _AddAdditionalCertsToReception = Utility.IsBoolean(param_list.Find(t => t.ParamId == "AddAdditionalCertsToReception").ParamValue); 
            _CertNoLength = int.Parse(param_list.Find(t => t.ParamId == "CertNoLength").ParamValue);
            _ResetPasswordWord = param_list.Find(t => t.ParamId == "ResetPasswordWord").ParamValue;
            //_ReportsPath = param_list.Find(t => t.ParamId == "ReportsPath").ParamValue;
            _ReportsPath = Application.StartupPath+@"\Reports\";
            _EventDate = @param_list.Find(t => t.ParamId == "EventDate").ParamValue;
            _EventDayName = @param_list.Find(t => t.ParamId == "EventDayName").ParamValue;
            _EventYear = @param_list.Find(t => t.ParamId == "EventYear").ParamValue;
            _EventName = @param_list.Find(t => t.ParamId == "EventName").ParamValue;
            _ChoosePrinterIndecator = @param_list.Find(t => t.ParamId == "ChoosePrinterIndecator").ParamValue;
            _MaxVotePaperPrintTimes = int.Parse(param_list.Find(t => t.ParamId == "MaxVotePaperPrintTimes").ParamValue);
            _MaxEntryDocPrintTimes = int.Parse(param_list.Find(t => t.ParamId == "MaxEntryDocPrintTimes").ParamValue);
            DateTime.TryParse(param_list.Find(t => t.ParamId == "ChangeCandStatusLastDay").ParamValue, out _ChangeCandStatusLastDay);
            _LoggedInUserInfo= SharedParam.CurrentUser.UserName + " / " + SharedParam.CurrentUser.RoleName +" / " + SharedParam.CurrentUser.HCNamesList;


        }

        public static string GetPrinterName()
        {
            string PrinterName = "N/A";
            if (_ChoosePrinterIndecator== "MachineIP")
            {
                DataTable dt = Db.GetDataAsDataTable("SELECT * FROM PrinterSettings WHERE MachineIP='" + Utility.GetLocalIPAddress() + "'");
                if (dt!=null)
                {
                    PrinterName=dt.Rows[0]["PrinterName"].ToString();
                }
                else
                {
                    PrinterName = "N/A";
                }
            }else if (_ChoosePrinterIndecator == "MachineName")
            {
                DataTable dt = Db.GetDataAsDataTable("SELECT * FROM PrinterSettings WHERE MachineName='" + Utility.GetMachineName() + "'");
                if (dt != null)
                {
                    PrinterName = dt.Rows[0]["PrinterName"].ToString();
                }
                else
                {
                    PrinterName = "N/A";
                }
            }  else if (_ChoosePrinterIndecator == "MachineMacAddress")
            {
                DataTable dt = Db.GetDataAsDataTable("SELECT * FROM PrinterSettings WHERE MachineMacAddress='" + Utility.GetMACAddress() + "'");
                if (dt != null)
                {
                    PrinterName = dt.Rows[0]["PrinterName"].ToString();
                }
                else
                {
                    PrinterName = "N/A";
                }
            }
            return PrinterName;
        }
    }
    partial class SharedParam
    {
        public enum HolderReceptionSteps{Query=1,Holder=2,Certs=3 }
        public const string USER_PASSWORD_KEY = "YeS#2015*";
        private static UserInfo currentUser;
        
        public const string SINGLE_HOLDER_CLASS = "single";
        public const string EMPLOYEE_HOLDER_CLASS = "employee";
        public const string COMPANY_HOLDER_CLASS = "company";
        public const string FOUNDER_HOLDER_CLASS = "founder";

       
        public static UserInfo CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
    }

    public class PresentHolderCerts
    {
        private int _ShareQty;
        private string _CertNo;
        private string _HolderName;
        private string _ClassName;
        private string _ClassId;
        private string _RowId;
        private int _EntryDocNo;
       

        public int ShareQty
        {
            get
            {
                return _ShareQty;
            }

            set
            {
                _ShareQty = value;
            }
        }

        public string CertNo
        {
            get
            {
                return _CertNo;
            }

            set
            {
                _CertNo = value;
            }
        }

        public string HolderName
        {
            get
            {
                return _HolderName;
            }

            set
            {
                _HolderName = value;
            }
        }

        public string ClassName
        {
            get
            {
                return _ClassName;
            }

            set
            {
                _ClassName = value;
            }
        }

        public string ClassId
        {
            get
            {
                return _ClassId;
            }

            set
            {
                _ClassId = value;
            }
        }

        public string RowId
        {
            get
            {
                return _RowId;
            }

            set
            {
                _RowId = value;
            }
        }

        public int EntryDocNo
        {
            get
            {
                return _EntryDocNo;
            }

            set
            {
                _EntryDocNo = value;
            }
        }

        public PresentHolderCerts() { }

        public PresentHolderCerts(int Share_Qty,string Cert_No,string Holder_Name
            ,string Class_Name,string Class_Id,string Row_Id,int Entry_doc_no)
        {
            _ShareQty = Share_Qty;
            _CertNo = Cert_No;
            _HolderName = Holder_Name;
            _ClassName = Class_Name;
            _ClassId = Class_Id;
            _RowId = Row_Id;
            _EntryDocNo = Entry_doc_no;
        }
    }
    public class PresentHolderCertsWithDelegate:PresentHolderCerts
    {
        private bool _isDelagated;
        private string _DlgNo;
        private string _DlgName;
        private DateTime _DlgDate;
        private string _ApprovedNo;
        private DateTime _ApprovedDate;
        private string _ApprovedOrg;
        private string _Note;
        private string _Delegate_Type;
        private string _Delegate_Type_Name;
        private string _Reception_Type;
        private string _userid;
      

        public string DlgNo
        {
            get
            {
                return _DlgNo;
            }

            set
            {
                _DlgNo = value;
            }
        }

        public string DlgName
        {
            get
            {
                return _DlgName;
            }

            set
            {
                _DlgName = value;
            }
        }

        public DateTime DlgDate
        {
            get
            {
                return _DlgDate;
            }

            set
            {
                _DlgDate = value;
            }
        }

        public string ApprovedNo
        {
            get
            {
                return _ApprovedNo;
            }

            set
            {
                _ApprovedNo = value;
            }
        }

        public DateTime ApprovedDate
        {
            get
            {
                return _ApprovedDate;
            }

            set
            {
                _ApprovedDate = value;
            }
        }

        public string ApprovedOrg
        {
            get
            {
                return _ApprovedOrg;
            }

            set
            {
                _ApprovedOrg = value;
            }
        }

        public string Note
        {
            get
            {
                return _Note;
            }

            set
            {
                _Note = value;
            }
        }

        public string Delegate_Type
        {
            get
            {
                return _Delegate_Type;
            }

            set
            {
                _Delegate_Type = value;
            }
        }

        public string Delegate_Type_Name
        {
            get
            {
                return _Delegate_Type_Name;
            }

            set
            {
                _Delegate_Type_Name = value;
            }
        }

        public bool IsDelagated
        {
            get
            {
                return _isDelagated;
            }

            set
            {
                _isDelagated = value;
            }
        }

        public string Reception_Type
        {
            get
            {
                return _Reception_Type;
            }

            set
            {
                _Reception_Type = value;
            }
        }

        public string Userid
        {
            get
            {
                return _userid;
            }

            set
            {
                _userid = value;
            }
        }

        public PresentHolderCertsWithDelegate() { }
        public PresentHolderCertsWithDelegate(int Share_Qty, string Cert_No, string Holder_Name
           , string Class_Name, string Class_Id, string Row_Id, int Entry_doc_no,bool isDelagated
           , string Delegate_No, string Delegate_Name, DateTime Delegate_Date
           , string Approved_No, DateTime Approved_Date, string Approved_Org,string Note
            ,string DelegateType,string DelegateTypeName,string ReceptionType,string userid)
            :base(Share_Qty, Cert_No, Holder_Name, Class_Name, Class_Id, Row_Id, Entry_doc_no)
        {
            _isDelagated = isDelagated;
            _DlgNo = Delegate_No;
            _DlgDate = Delegate_Date;
            _DlgName = Delegate_Name;
            _ApprovedNo = Approved_No;
            _ApprovedDate = Approved_Date;
            _ApprovedOrg = Approved_Org;
            _Note = Note;
            _Delegate_Type = DelegateType;
            _Delegate_Type_Name = DelegateTypeName;
            _Reception_Type = ReceptionType;
            _userid = userid;
        }
    }

    }

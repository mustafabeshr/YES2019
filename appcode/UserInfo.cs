using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YES.appcode
{
    partial class SharedParam
    {
        public class UserInfo
        {
            private string userID;
            public string UserID
            {
                get { return userID; }
            }
            private string userName;
            public string UserName
            {
                get { return userName; }
            }

            private string roleid;
            public string RoleId
            {
                get { return roleid; }
            }

            private string rolename;
            public string RoleName
            {
                get { return rolename; }
            }
            private bool _HasHCSinlge;
            public bool HasSingleHolderClass
            {
                get { return _HasHCSinlge; }
            }
            private bool _HasHCEmployee;
            public bool HasEmployeeHolderClass
            {
                get { return _HasHCEmployee; }
            }
            private bool _HasHCCompany;
            public bool HasCompanyHolderClass
            {
                get { return _HasHCCompany; }
            }
            private bool _HasHCFounder;
            public bool HasFounderHolderClass
            {
                get { return _HasHCFounder; }
            }
            public string HCNamesList
            {
                get
                {
                    string tmplist = string.Empty;
                    if (_HasHCSinlge)
                    {
                        tmplist = Config.GetHoldeClassName(SharedParam.SINGLE_HOLDER_CLASS);

                    }
                    if (_HasHCEmployee)
                    {
                        if (!string.IsNullOrEmpty(tmplist))
                        {
                            tmplist +=" | " +Config.GetHoldeClassName(SharedParam.EMPLOYEE_HOLDER_CLASS);
                        }
                        else
                        {
                            tmplist = Config.GetHoldeClassName(SharedParam.EMPLOYEE_HOLDER_CLASS);
                        }
                    }
                    if (_HasHCCompany)
                    {
                        if (!string.IsNullOrEmpty(tmplist))
                        {
                            tmplist += " | " + Config.GetHoldeClassName(SharedParam.COMPANY_HOLDER_CLASS);
                        }
                        else
                        {
                            tmplist = Config.GetHoldeClassName(SharedParam.COMPANY_HOLDER_CLASS);
                        }
                    }
                    if (_HasHCFounder)
                    {
                        if (!string.IsNullOrEmpty(tmplist))
                        {
                            tmplist += " | " + Config.GetHoldeClassName(SharedParam.FOUNDER_HOLDER_CLASS);
                        }
                        else
                        {
                            tmplist = Config.GetHoldeClassName(SharedParam.FOUNDER_HOLDER_CLASS);
                        }
                    }
                    return tmplist;
                }
            }

            public string HolderClassIdsList
            {
                get
                {
                    string tmplist = string.Empty;
                    if (_HasHCSinlge)
                    {
                        tmplist = "'"+SharedParam.SINGLE_HOLDER_CLASS+"'";

                    }
                    if (_HasHCEmployee)
                    {
                        if (!string.IsNullOrEmpty(tmplist))
                        {
                            tmplist += ",'" + SharedParam.EMPLOYEE_HOLDER_CLASS+"'";
                        }
                        else
                        {
                            tmplist = "'"+SharedParam.EMPLOYEE_HOLDER_CLASS+"'";
                        }
                    }
                    if (_HasHCCompany)
                    {
                        if (!string.IsNullOrEmpty(tmplist))
                        {
                            tmplist +=",'"+SharedParam.COMPANY_HOLDER_CLASS+"'";
                        }
                        else
                        {
                            tmplist = "'"+SharedParam.COMPANY_HOLDER_CLASS+"'";
                        }
                    }
                    if (_HasHCFounder)
                    {
                        if (!string.IsNullOrEmpty(tmplist))
                        {
                            tmplist += ",'"+SharedParam.FOUNDER_HOLDER_CLASS+"'";
                        }
                        else
                        {
                            tmplist = "'"+SharedParam.FOUNDER_HOLDER_CLASS+"'";
                        }
                    }
                    return tmplist;
                }
            }

            public UserInfo(
                string userID, string userName,
                string Role_Id, string Role_Name,
                bool HasSingle, bool HasEmployee,
                bool HasCompany, bool HasFounder)
            {
                this.userID = userID;
                this.userName = userName;
                this.roleid = Role_Id;
                this.rolename = Role_Name;
                _HasHCSinlge = HasSingle;
                _HasHCEmployee = HasEmployee;
                _HasHCCompany = HasCompany;
                _HasHCFounder = HasFounder;
            }
        }
    }
}

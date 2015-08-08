using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models.Business
{
    public interface IBusinessAuthentication
    {
        string IsValidUserBusiness(string email, string pwd);
        bool ChangePasswordBusiness(string email, string oldpwd, string newpwd);
        bool RegisterBusiness(string uname, string email, string pwd);
        DataTable GetUserBussiness(string username);
    }
}
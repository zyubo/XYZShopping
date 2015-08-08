using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models.Repositories
{
    public interface IDataAuthentication
    {
        string IsValidUser(string username, string pwd);
        bool ChangePassword(string username, string oldpwd, string newpwd);
        bool Register(string uname, string email, string pwd);
        DataTable GetUser(string username);
    }
}
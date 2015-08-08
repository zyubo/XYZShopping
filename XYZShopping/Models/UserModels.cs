using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models
{
    public class UserModels
    {
        private string username = "";
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string email = "";
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password = "";
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string newPassword = "";
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; }
        }

        private string newPasswordRetype = "";
        public string NewPasswordRetype
        {
            get { return newPasswordRetype; }
            set { newPasswordRetype = value; }
        }

        private bool rememberMe = false;
        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }

        private DataTable userTable = new DataTable();
        public DataTable UserTable
        {
            get { return userTable; }
            set { userTable = value; }
        }

        private List<UserModels> userList = new List<UserModels>();
        public List<UserModels> UserList
        {
            get { return userList; }
            set { userList = value; }
        }
    }
}
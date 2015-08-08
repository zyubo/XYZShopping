using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using XYZShopping.Models.Data;
using XYZShopping.Models.Patterns;
using System.Configuration;
using System.Data.SqlClient;

namespace XYZShopping.Models.Repositories
{
    public class AccountModelsRepository : MembershipProvider
    {
        IDataAccess _idataAccess = null;
        public AccountModelsRepository(IDataAccess ida)
        {
            _idataAccess = ida;
        }

        public AccountModelsRepository()
            : this(GenericFactory<DataAccess, IDataAccess>.CreateInstance())
        {
        }

        string CONNSTR = ConfigurationManager.ConnectionStrings["XYZShopping"].ConnectionString;

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            bool res = false;
            try
            {
                string sql = "select username from users where " +
                    "username='" + username + "' and password='" +
                    password + "'";
                object obj = _idataAccess.GetScalar(sql);
                if (obj != null)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "changePassword"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@username", System.Data.SqlDbType.NChar, 10);
                SqlParameter p2 = new SqlParameter("@oldpwd", System.Data.SqlDbType.NChar, 10);
                SqlParameter p3 = new SqlParameter("@newpwd", System.Data.SqlDbType.NChar, 10);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = username;
                p2.Value = oldPassword;
                p3.Value = newPassword;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.UserRejected;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "register"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@username", System.Data.SqlDbType.NChar, 10);
                SqlParameter p2 = new SqlParameter("@email", System.Data.SqlDbType.NChar, 10);
                SqlParameter p3 = new SqlParameter("@password", System.Data.SqlDbType.NChar, 10);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = username;
                p2.Value = email;
                p3.Value = password;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    status = MembershipCreateStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}
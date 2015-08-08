using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using XYZShopping.Models.Data;
using System.Data;
using XYZShopping.Models.Patterns;

namespace XYZShopping.Models.Repositories
{
    public class Repository : IDataAuthentication, IDataAccount
    {
        IDataAccess _idataAccess = null;
        public Repository(IDataAccess ida)
        {
            _idataAccess = ida;
        }

        public Repository()
            : this(GenericFactory<DataAccess, IDataAccess>.CreateInstance())
        {
        }

        string CONNSTR = ConfigurationManager.ConnectionStrings["XYZShopping"].ConnectionString;

        public string IsValidUser(string username, string pwd)
        {
            string res = "";
            try
            {
                string sql = "select username from users where " +
                    "username='" + username + "' and password='" +
                    pwd + "'";
                object obj = _idataAccess.GetScalar(sql);
                if (obj != null)
                    res = obj.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public bool ChangePassword(string username, string oldpwd, string newpwd)
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
                p2.Value = oldpwd;
                p3.Value = newpwd;

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

        public bool Register(string uname, string email, string pwd)
        {
            bool res = false;
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

                p1.Value = uname;
                p2.Value = email;
                p3.Value = pwd;

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

        public bool AddCart(string email, int id, int pcount)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "addCart"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@email", System.Data.SqlDbType.NChar, 10);
                SqlParameter p2 = new SqlParameter("@id", System.Data.SqlDbType.Int);
                SqlParameter p3 = new SqlParameter("@pcount", System.Data.SqlDbType.Int);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = email;
                p2.Value = id;
                p3.Value = pcount;

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

        public DataTable ViewCart(string email, ref float result)
        {
            SqlConnection conn = new SqlConnection(CONNSTR);
            DataTable cartTable = new DataTable();
            try
            {
                conn.Open();
                string sql = "viewCart"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.NChar, 10));
                cmd.Parameters["@email"].Value = email;

                cartTable.Load(cmd.ExecuteReader());
                if (cartTable.Rows.Count != 0)
                    result = float.Parse(cartTable.Rows[0][6].ToString());
                else
                    result = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cartTable;
        }

        public bool EditCart(string email, int id, int pcount)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "editCart"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@email", System.Data.SqlDbType.NChar, 10);
                SqlParameter p2 = new SqlParameter("@id", System.Data.SqlDbType.Int);
                SqlParameter p3 = new SqlParameter("@pcount", System.Data.SqlDbType.Int);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = email;
                p2.Value = id;
                p3.Value = pcount;

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

        public bool DeleteCart(string email, int id)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "deleteCart"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@email", System.Data.SqlDbType.NChar, 10);
                SqlParameter p2 = new SqlParameter("@id", System.Data.SqlDbType.Int);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = email;
                p2.Value = id;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);

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

        public bool AddOrder(string email, int orderid, string address, long cardnum, ref float result)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "addOrder"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@email", System.Data.SqlDbType.NChar, 10);
                SqlParameter p2 = new SqlParameter("@orderid", System.Data.SqlDbType.Int);
                SqlParameter p3 = new SqlParameter("@address", System.Data.SqlDbType.NVarChar, 4000);
                SqlParameter p4 = new SqlParameter("@cardnum", System.Data.SqlDbType.Real);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = email;
                p2.Value = orderid;
                p3.Value = address;
                p4.Value = cardnum;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);

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

        public DataTable ViewOrder(string email)
        {
            SqlConnection conn = new SqlConnection(CONNSTR);
            DataTable orderTable = new DataTable();
            try
            {
                conn.Open();
                string sql = "viewOrder"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@email", System.Data.SqlDbType.NChar, 10);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                p1.Value = email;
                cmd.Parameters.Add(p1);

                orderTable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orderTable;
        }

        public bool AddProduct(int id, string title, int available, float price, string image, string summary, string details)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "addProduct"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@id", System.Data.SqlDbType.Int);
                SqlParameter p2 = new SqlParameter("@title", System.Data.SqlDbType.NChar, 10);
                SqlParameter p3 = new SqlParameter("@available", System.Data.SqlDbType.Int);
                SqlParameter p4 = new SqlParameter("@price", System.Data.SqlDbType.Float);
                SqlParameter p5 = new SqlParameter("@image", System.Data.SqlDbType.NVarChar, 4000);
                SqlParameter p6 = new SqlParameter("@summary", System.Data.SqlDbType.NVarChar, 4000);
                SqlParameter p7 = new SqlParameter("@details", System.Data.SqlDbType.NVarChar, 4000);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = id;
                p2.Value = title;
                p3.Value = available;
                p4.Value = price;
                p5.Value = image;
                p6.Value = summary;
                p7.Value = details;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);

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

        public DataTable ViewProduct(int id)
        {
            SqlConnection conn = new SqlConnection(CONNSTR);
            DataTable productTable = new DataTable();
            try
            {
                conn.Open();
                string sql = "viewProduct"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@id", System.Data.SqlDbType.Int);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                p1.Value = id;
                cmd.Parameters.Add(p1);

                productTable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productTable;
        }

        public DataTable ViewAllProduct()
        {
            SqlConnection conn = new SqlConnection(CONNSTR);
            DataTable productTableAll = new DataTable();
            try
            {
                conn.Open();
                string sql = "viewAllProduct"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                productTableAll.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productTableAll;
        }

        public bool DeleteProduct(int id)
        {
            bool res = false;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                string sql = "deleteProduct"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@id", System.Data.SqlDbType.Int);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                p1.Value = id;

                cmd.Parameters.Add(p1);

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

        public DataTable GetUser(string username)
        {
            SqlConnection conn = new SqlConnection(CONNSTR);
            DataTable userTable = new DataTable();
            try
            {
                conn.Open();
                string sql = "getUser"; // name of SP

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter p1 = new SqlParameter("@username", System.Data.SqlDbType.NChar, 10);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                p1.Value = username;
                cmd.Parameters.Add(p1);

                userTable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userTable;
        }

        //public List<UserModels> ViewAllUsers()
        //{
        //    var results = from u in se.users
        //                  select new
        //                  {
        //                      username = u.username,
        //                      email = u.email,
        //                      password = u.password
        //                  };
        //    return results.ToList<UserModels>();
        //}
    }
}
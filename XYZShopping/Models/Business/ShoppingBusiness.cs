using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XYZShopping.Models.Repositories;
using XYZShopping.Models.Patterns;

namespace XYZShopping.Models.Business
{
    public class ShoppingBusiness : IBusinessAuthentication, IBusinessAccount
    {
        IDataAuthentication idau = null;
        IDataAccount idac = null;
        public ShoppingBusiness(IDataAuthentication idauth, IDataAccount idacc)
        {
            idau = idauth;
            idac = idacc;
        }

        public ShoppingBusiness() :
            this(GenericFactory<Repository, IDataAuthentication>.CreateInstance(),
         GenericFactory<Repository, IDataAccount>.CreateInstance())
        {
        }

        public string IsValidUserBusiness(string email, string pwd)
        {
            return idau.IsValidUser(email, pwd);
        }

        public bool ChangePasswordBusiness(string username, string oldpwd, string newpwd)
        {
            return idau.ChangePassword(username, oldpwd, newpwd);
        }

        public bool RegisterBusiness(string uname, string email, string pwd)
        {
            return idau.Register(uname, email, pwd);
        }

        public System.Data.DataTable GetUserBussiness(string username)
        {
            return idau.GetUser(username);
        }

        public bool AddCartBussiness(string email, int id, int pcount)
        {
            return idac.AddCart(email, id, pcount);
        }

        public System.Data.DataTable ViewCartBussiness(string email, ref float result)
        {
            return idac.ViewCart(email, ref result);
        }

        public bool EditCartBussiness(string email, int id, int pcount)
        {
            return idac.EditCart(email, id, pcount);
        }

        public bool DeleteCartBussiness(string email, int id)
        {
            return idac.DeleteCart(email, id);
        }

        public bool AddOrderBussiness(string email, int orderid, string address, long cardnum, ref float res)
        {
            return idac.AddOrder(email, orderid, address, cardnum, ref res);
        }

        public System.Data.DataTable ViewOrderBussiness(string email)
        {
            return idac.ViewOrder(email);
        }

        public bool AddProductBussiness(int id, string title, int available, float price, string image, string summary, string details)
        {
            return idac.AddProduct(id, title, available, price, image, summary, details);
        }

        public System.Data.DataTable ViewProductBussiness(int id)
        {
            return idac.ViewProduct(id);
        }

        public System.Data.DataTable ViewAllProductBussiness()
        {
            return idac.ViewAllProduct();
        }

        public bool DeleteProductBussiness(int id)
        {
            return idac.DeleteProduct(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models.Business
{
    public interface IBusinessAccount
    {
        bool AddCartBussiness(string email, int id, int pcount);
        DataTable ViewCartBussiness(string email, ref float result);
        bool EditCartBussiness(string email, int id, int pcount);
        bool DeleteCartBussiness(string email, int id);
        bool AddOrderBussiness(string email, int orderid, string address, long cardnum, ref float res);
        DataTable ViewOrderBussiness(string email);
        bool AddProductBussiness(int id, string title, int available, float price, string image, string summary, string details);
        DataTable ViewProductBussiness(int id);
        DataTable ViewAllProductBussiness();
        bool DeleteProductBussiness(int id);
    }
}
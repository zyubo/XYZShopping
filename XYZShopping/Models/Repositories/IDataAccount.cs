using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models.Repositories
{
    public interface IDataAccount
    {
        bool AddCart(string email, int id, int pcount);
        DataTable ViewCart(string email, ref float result);
        bool EditCart(string email, int id, int pcount);
        bool DeleteCart(string email, int id);
        bool AddOrder(string email, int orderid, string address, long cardnum, ref float res);
        DataTable ViewOrder(string email);
        bool AddProduct(int id, string title, int available, float price, string image, string summary, string details);
        DataTable ViewProduct(int id);
        DataTable ViewAllProduct();
        bool DeleteProduct(int id);
    }
}
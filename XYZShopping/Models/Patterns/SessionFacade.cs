using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZShopping.Models.Patterns
{
    public class SessionFacade
    {
        public static void setNullToAll()
        {
            USERNAME = "";
            EMAIL = "";
            PASSWORD = "";
            ORDER = null;
            PRODUCTID = -1;
        }

        static readonly string _USERNAME = "USERNAME";
        public static string USERNAME
        {
            get
            {
                string res = null;
                if (HttpContext.Current.Session[_USERNAME] != null)
                    res = (string)HttpContext.Current.Session[_USERNAME];
                return res == null ? res : res.Replace(" ", "");
            }
            set
            {
                HttpContext.Current.Session[_USERNAME] = value;
            }
        }

        static readonly string _EMAIL = "EMAIL";
        public static string EMAIL
        {
            get
            {
                string res = null;
                if (HttpContext.Current.Session[_EMAIL] != null)
                    res = (string)HttpContext.Current.Session[_EMAIL];
                return res == null ? res : res.Replace(" ", "");
            }
            set
            {
                HttpContext.Current.Session[_EMAIL] = value;
            }
        }

        static readonly string _PASSWORD = "PASSWORD";
        public static string PASSWORD
        {
            get
            {
                string res = null;
                if (HttpContext.Current.Session[_PASSWORD] != null)
                    res = (string)HttpContext.Current.Session[_PASSWORD];
                return res == null ? res : res.Replace(" ", "");
            }
            set
            {
                HttpContext.Current.Session[_PASSWORD] = value;
            }
        }

        static readonly string _ORDER = "ORDER";
        public static OrderModel ORDER
        {
            get
            {
                OrderModel res = null;
                if (HttpContext.Current.Session[_ORDER] != null)
                    res = (OrderModel)HttpContext.Current.Session[_ORDER];
                return res;
            }
            set
            {
                HttpContext.Current.Session[_ORDER] = value;
            }
        }

        static readonly string _PRODUCTID = "PRODUCTID";
        public static int PRODUCTID
        {
            get
            {
                int res = -1;
                if (HttpContext.Current.Session[_PRODUCTID] != null)
                    res = (int)HttpContext.Current.Session[_PRODUCTID];
                return res;
            }
            set
            {
                HttpContext.Current.Session[_PRODUCTID] = value;
            }
        }

        static readonly string _TOTAL = "TOTAL";
        public static float TOTAL
        {
            get
            {
                float res = 0;
                if (HttpContext.Current.Session[_TOTAL] != null)
                    res = (float)HttpContext.Current.Session[_TOTAL];
                return res;
            }
            set
            {
                HttpContext.Current.Session[_TOTAL] = value;
            }
        }
    }
}
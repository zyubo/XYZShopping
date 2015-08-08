using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace XYZShopping.Models
{
    public class OrderModel
    {
        private string email = "a@m.c";
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int id = 123546;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int pcount = 2;
        public int Pcount
        {
            get { return pcount; }
            set { pcount = value; }
        }

        private int orderid = 594123;
        public int Orderid
        {
            get { return orderid; }
            set { orderid = value; }
        }

        private string address = "Main Street #17";
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private bool delivered = false;
        public bool Delivered
        {
            get { return delivered; }
            set { delivered = value; }
        }

        private long cardnum = 4111111111111111;
        public long Cardnum
        {
            get { return cardnum; }
            set { cardnum = value; }
        }

        private string arrive = "two days";
        public string Arrive
        {
            get { return arrive; }
            set { arrive = value; }
        }

        private float total = 0;
        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        private DataTable orderTable;
        public DataTable OrderTable
        {
            get { return orderTable; }
            set { orderTable = value; }
        }
    }
}
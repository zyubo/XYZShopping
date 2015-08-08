using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZShopping.Models
{
    public class CartModel
    {
        private string title = "book1";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        //private string summary = "Learn cocos2d Game Development with iOS 5";
        private string summary = DateTime.Now.Second.ToString();
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        private string image = "http://ecx.images-amazon.com/images/I/51F1NVZ29jL._BO2,204,203,200_PIsitb-sticker-arrow-click,TopRight,35,-76_AA300_SH20_OU01_.jpg";
        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private double price = 12.5;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private int pcount = 1;
        public int Pcount
        {
            get { return pcount; }
            set { pcount = value; }
        }
    }
}
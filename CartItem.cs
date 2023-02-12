using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedWebDevelopment
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }

        public double Total
        {
            get { return Price * Quantity; }
        }
        public CartItem(int ID,string name, string image, double price, int quantity)
        {
            this.ProductId = ID;
            this.ProductName = name;
            this.Image = image;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
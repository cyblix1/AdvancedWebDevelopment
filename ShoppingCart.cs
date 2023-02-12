using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedWebDevelopment
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        private int ItemIndexOf(int ID)
        {
            foreach (CartItem item in Items)
            {
                if (item.ProductId == ID)
                {
                    return Items.IndexOf(item);
                }
            }
            return -1;
        }
        public void Insert(CartItem item)
        {
            int index = ItemIndexOf(item.ProductId);
            if (index == -1)
            {
                Items.Add(item);
            }
            else
            {
                Items[index].Quantity++;
            }
        }

        public void Delete(int productId)
        {
            int index = ItemIndexOf(productId);
            if (index >= 0)
            {
                Items.RemoveAt(index);
            }
        }

        public void Update(int productId, int Quantity)
        {
            int index = ItemIndexOf(productId);
            if (index >= 0)
            {
                if (Quantity > 0)
                {
                    Items[index].Quantity = Quantity;
                }
                else
                {
                    Delete(productId);
                }
            }
        }

        public double GrandTotal
        {
            get
            {
                if (Items == null)
                {
                    return 0;
                }
                else
                {
                    double grandTotal = 0;
                    foreach (CartItem item in Items)
                    {
                        grandTotal += item.Quantity * item.Price;
                    }
                    return grandTotal;
                }
            }
        }
    }


}
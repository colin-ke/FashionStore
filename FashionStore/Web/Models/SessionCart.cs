using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Models
{
    public class SessionCart
    {
        private List<CartItem> itemCollection = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return itemCollection; }
        }

        public int ItemCount
        {
            get { return itemCollection.Select<CartItem, int>(item => item.Quantity).Sum(); }
        }

        public void AddItem(Products pdt,int sizeId,int colorId, int quantity)
        {
            CartItem item = itemCollection.FirstOrDefault(p => p.Products.ID == pdt.ID && p.Size.ID == sizeId && p.Color.ID == colorId);
            if (item == null)
            {
                Colors clr = pdt.Colors.Where<Colors>(color => color.ID == colorId).FirstOrDefault<Colors>();
                Sizes sz = pdt.Sizes.Where<Sizes>(size => size.ID == sizeId).FirstOrDefault<Sizes>();
                itemCollection.Add(new CartItem { Products = pdt, Quantity = quantity, Color = clr, Size = sz });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Products pdt)
        {
            itemCollection.RemoveAll(it => it.Products.ID == pdt.ID);
        }

        public decimal ComputeTotalValue()
        {
            return itemCollection.Sum(e => e.Products.Price * e.Quantity);
        }

        public void Clear()
        {
            itemCollection.Clear();
        }
    }

    public class CartItem
    {
        public Products Products { get; set; }
        public Colors Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public string Title
        {
            get
            {
                return string.Format("{0} {1} {2}", Products.Title, Color.Name, Size.Name);
            }
            private set { }
        }
    }
}
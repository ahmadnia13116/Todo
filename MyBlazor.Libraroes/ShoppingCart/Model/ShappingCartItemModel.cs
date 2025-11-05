using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlazor.Libraroes.Ptoduct.Models;

namespace MyBlazor.Libraroes.ShoppingCart.Model
{
    public class ShappingCartItemModel
    {
        public ProductModel Product { get; }
        public int price { get; protected set; }
        public int Quantity { get; protected set; }
        public int TotalPrice
        {
            get
            {
                return price * Quantity;
            }
        }

        public ShappingCartItemModel(ProductModel product, int quantity)
        {
            this.Product = product;
            this.price = product.Price;
            Quantity = quantity;
        }

        public void UpdateQuantity(ProductModel product, int quantity)
        {
            price = product.Price;
            Quantity = quantity;
        }
    }
}

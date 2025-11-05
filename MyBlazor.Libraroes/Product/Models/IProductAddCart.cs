using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlazor.Libraroes.Ptoduct.Models;

namespace MyBlazor.Libraroes.Product.Models
{
    public interface IProductAddCart
    {
        public ProductModel? Product { get; set; }
        public int? Quantity { get; set; }
        void AddToCart();
    }
}

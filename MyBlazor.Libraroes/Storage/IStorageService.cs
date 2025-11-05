using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlazor.Libraroes.Ptoduct.Models;
using MyBlazor.Libraroes.ShoppingCart.Model;

namespace MyBlazor.Libraroes.Storage
{
    public interface IStorageService
    {
        IList<ProductModel> ptoducts { get; }

        ShoppingCartModel shoppingCart { get; }
        ShappingCartItemModel? GetCartItemBySku(string sku);
    }
}

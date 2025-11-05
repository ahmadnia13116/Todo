using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazor.Libraroes.ShoppingCart.Model
{
    public class ShoppingCartModel
    {
        public IList<ShappingCartItemModel> Items { get; }
        public ShoppingCartModel()
        {
            Items = new List<ShappingCartItemModel>();
        }
    }
}

using MyBlazor.Libraroes.Ptoduct.Models;
using MyBlazor.Libraroes.ShoppingCart.Model;

namespace MyBlazor.Libraroes.ShoppingCart
{
    public interface IShappingCartService
    {

        ShoppingCartModel GetShoppingCart();

        void AddProduct(ProductModel product, int quantity);

        void DeleteProduct(ShappingCartItemModel Item);

        int Count();

        bool HasProduct(string sku);
    }
}

using MyBlazor.Libraroes.Ptoduct.Models;
using MyBlazor.Libraroes.ShoppingCart.Model;
using MyBlazor.Libraroes.Storage;

namespace MyBlazor.Libraroes.ShoppingCart
{
    public class ShappingCartService : IShappingCartService
    {
        private readonly IStorageService _storageService;
        public ShappingCartService(IStorageService storageService)
        {
            this._storageService = storageService;
        }

        public void AddProduct(ProductModel product, int quantity)
        {
            var items = GetShoppingCart().Items;
            if (HasProduct(product.sku))
            {
                var item = items.First(i => i.Product.sku == product.sku);
                item.UpdateQuantity(product, quantity);
            }
            else
            {
                items.Add(new ShappingCartItemModel(product, quantity));
            }
        }

        public int Count()
        {
            return GetShoppingCart().Items.Count();
        }

        public void DeleteProduct(ShappingCartItemModel Item)
        {
            var items = GetShoppingCart().Items;
            if (HasProduct(Item.Product.sku))
            {
                items.Remove(items.First(i => i.Product.sku == Item.Product.sku));

            }
        }

        public ShoppingCartModel GetShoppingCart()
        {
            return _storageService.shoppingCart;
        }

        public bool HasProduct(string sku)
        {
            var shoppingCart = GetShoppingCart();
            return shoppingCart.Items.Any(i=> i.Product.sku == sku);
        }
    }
}

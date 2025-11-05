using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlazor.Libraroes.Ptoduct.Models;
using MyBlazor.Libraroes.ShoppingCart.Model;

namespace MyBlazor.Libraroes.Storage
{
    public class StorageService : IStorageService
    {
        public IList<ProductModel> ptoducts { get; private set; }

        public ShoppingCartModel shoppingCart { get; private set; }



        public StorageService()
        {
            ptoducts = new List<ProductModel>();
            shoppingCart = new ShoppingCartModel();

            AddProducts(new ProductModel("SKU001", "Product 1", 100, "tiiii.png"));
            AddProducts(new ProductModel("SKU002", "Product 2", 200, "tiiii.png"));
            AddProducts(new ProductModel("SKU003", "Product 3", 300, "tiiii.png"));
            AddProducts(new ProductModel("SKU004", "Product 4", 400, "tiiii.png"));
            AddProducts(new ProductModel("SKU005", "Product 5", 500, "tiiii.png"));
            AddProducts(new ProductModel("SKU006", "Product 6", 600, "tiiii.png"));
            AddProducts(new ProductModel("SKU007", "Product 7", 700, "tiiii.png"));
            AddProducts(new ProductModel("SKU008", "Product 8", 800, "tiiii.png"));
        }

        private void AddProducts(ProductModel ptoduct)
        {
            if (!ptoducts.Any(p => p.sku == ptoduct.sku))
            {
                ptoducts.Add(ptoduct);
            }
        }

        public ShappingCartItemModel? GetCartItemBySku(string sku)
        {
            throw new NotImplementedException();
        }
    }
}

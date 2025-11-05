using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlazor.Libraroes.Ptoduct;
using MyBlazor.Libraroes.Ptoduct.Models;
using MyBlazor.Libraroes.Storage;

namespace MyBlazor.Libraroes.Product
{
    public class ProductService : IProductService
    {
        private readonly IStorageService _storageService;
        public ProductService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public IList<ProductModel> GetAll()
        {
            return _storageService.ptoducts.ToList();
        }

        public ProductModel? GetProduct(string sku)
        {
            return _storageService.ptoducts.FirstOrDefault(p => p.sku == sku);
        }

        public ProductModel? GetProductBySlug(string slug)
        {
            return _storageService.ptoducts.FirstOrDefault(p => p.Slug == slug);    
        }
    }
}

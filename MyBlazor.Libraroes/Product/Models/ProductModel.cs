namespace MyBlazor.Libraroes.Ptoduct.Models
{
    public class ProductModel
    {

        public string sku { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        public string Slug
        {
            get
            {
                return sku.ToLower();
            }
        }

        public string FullUrl
        {
            get
            {
                return string.Format("/Product/{0}", Slug);
            }
        }

        public ProductModel(string sku ,string name , int price, string image)
        {
            this.sku = sku;
            this.Name = name;
            this.Price = price;
            this.Image = image;
        }
    }
}

using BlazorApp4.Models;

namespace BlazorApp4.Services
{
    public class ProductService : IProductService
    {
        //ประกาศ
        public List<Product> ProductList { get; set; } 
        Random rnd;

        public ProductService() 
        {
            //สร้าง oop
            ProductList = new List<Product>();
            rnd = new Random();
            GenData();
        }

        public void GenData(int number=10)
        {
            for (int i = 1; i <= number; i++) {
                ProductList.Add(new Product
                {
                    Id = i,
                    Name = "Product" + i,
                    Price = rnd.Next(10, 101) + rnd.NextDouble(),
                    Amount = rnd.Next(1,11),
                });
            }
        }

        public void Add(Product product)
        {
            if (ProductList.Count > 0)
            {
                product.Id = ProductList.Max(x => x.Id) + 1;
            }
            else { 
                product.Id = 1;
            }

            ProductList.Add (product);
        }

        public void Delete(int id)
        {
            var product = ProductList.FirstOrDefault(x => x.Id == id);
            
            if (product != null) ProductList.Remove(product);
        }

        public void Edit(Product product)
        {
            //var tempProduct = ProductList.FirstOrDefault(px=>px.Id.Equals(product.Id));

            //if (tempProduct != null) tempProduct = product;

            var oldProduct = ProductList.FirstOrDefault(px=>px.Id.Equals(product.Id));
            if (oldProduct != null) 
            {
                ProductList.Remove(oldProduct);
                ProductList.Add(product);
 
            }

            //if (oldProduct != null) 
            //{
            //   var index = ProductList.IndexOf(oldProduct);

            //    if (index >= 0)
            //    {
            //        ProductList.RemoveAt(index);
            //        ProductList.Insert(index, product);
            //    }

            //}
          
        }

        public Product FindbyId(int id)
        {
            var product = ProductList.FirstOrDefault(px=>px.Id.Equals(id));
            return product;
        }
    }
}

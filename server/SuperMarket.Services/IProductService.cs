using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.Core.Models;

namespace SuperMarket.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProduct(int productId);
        public Product AdddProduct(Product product);
        public Product EditProduct(int productId, Product product);
        public void DeleteProduct(int productId);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.Core;
using SuperMarket.Core.Models;
namespace SuperMarket.Services
{
    public class ProductService:IProductService
    {
        private readonly DataContext _context;
        public ProductService (DataContext context){
            _context = context;
        }
        public Product AdddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id == productId);
            if (product == null){
                return;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product EditProduct(int productId, Product product)
        {
            var editProduct = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (editProduct == null) {
                return null;
            }
            editProduct.Name = product.Name;
            editProduct.CategoryId = product.CategoryId;
            editProduct.Description = product.Description;
            editProduct.ImageUrl = product.ImageUrl;
            editProduct.Price = product.Price;
            _context.SaveChanges();
            return editProduct;
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.FirstOrDefault (x => x.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
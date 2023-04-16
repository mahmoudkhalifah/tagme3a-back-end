using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly MainDbContext _context;

        public ProductRepo(MainDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
           Product? prd = _context.Products.Find(id);
            if (prd != null)
            {
                _context.Products.Remove(prd);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Set<Product>();
        }

        public Product GetProductById(int id)
        {
            Product? prd = _context.Products.Find(id);
                return prd;            
        }

        public int saveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateProduct(Product product, int id)
        {
            Product prd = _context.Products.Find(id);
            if (prd != null)
            {
                prd.Name = product.Name;
                prd.Description = product.Description;
                prd.Price = product.Price;
                prd.Discount = product.Discount;
                prd.UnitInStocks= product.UnitInStocks;
                prd.CategoryID = product.CategoryID;
                prd.BrandID = product.BrandID;
                foreach (var image in product.ProductImages)
                {
                    prd.ProductImages.Add(image);
                }

                _context.SaveChanges();
            }
        }
    }
}

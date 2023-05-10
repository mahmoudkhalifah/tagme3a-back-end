using Microsoft.EntityFrameworkCore;
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
            //int id = product.Id;
           // int counter = product.ProductImages.Count;
           // for (int i = 0; i < counter; i++)
            //{
                //ProductImage productImage = new ProductImage() { Photo = product.ProductImages.ElementAt(i).Photo, ProductId = id };
              //  product.ProductImages.ElementAt(i).ProductId = id;
            //}
            //_context.ProductImages.AddRange(product.ProductImages);
            //_context.SaveChanges();
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
            return _context.Set<Product>().Include(p=>p.ProductImages);
        }
        public Product GetProductById(int id)
        {
            Product? product = _context.Products.Include(p=>p.ProductPCs)
                .Include(p=>p.ProductOrders)
                .FirstOrDefault(x=>x.Id == id);
            return product;
        }
        public Product GetProductWithPcOrderById(int id)
        {
            Product? prd = _context.Products.Include(p=>p.ProductPCs).Include(p=>p.ProductOrders).FirstOrDefault(p=>p.Id == id);
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
                var counter = 0;
                foreach (var image in product.ProductImages)
                {
                    prd.ProductImages.ElementAt(counter).Photo = image.Photo;
                    counter++;
                }
                _context.SaveChanges();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MainDbContext _context;

        public CategoryRepo(MainDbContext context)
        {
            _context = context;
        }
        public void DeleteCategory(int id)
        {
            Category category = _context.Categories.Find(id)!;
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Set<Category>().Include(s=>s.Products);
        }

        public Category GetDetails(int id)
        {
            return _context.Categories.Find(id)!;
        }

        public Category GetWithProductsById(int id)
        {
            return _context.Set<Category>()
                     .Include(d => d.Products)
                     .ThenInclude(i=>i.ProductImages)
                     .FirstOrDefault(d => d.CategoryId == id)!;
        }

        public void Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateCategory(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

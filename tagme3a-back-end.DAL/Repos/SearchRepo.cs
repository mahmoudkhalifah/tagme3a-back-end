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
    public class SearchRepo : ISearchRepo
    {
        private readonly MainDbContext _context;

        public SearchRepo(MainDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> SearchByName(string productName)
        {
            return _context.Products.Where(p => p.Name.Contains(productName)).Include(p=>p.ProductImages);
        }
    }
}

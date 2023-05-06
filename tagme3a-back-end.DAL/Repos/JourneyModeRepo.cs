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
    public class JourneyModeRepo : IJourneyModeRepo
    {
        private readonly MainDbContext context;

        public JourneyModeRepo(MainDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.Where(c=>c.InJourneyMode == true)
                .OrderBy(c=>c.OrderForJourneyMode);
        }

        public IEnumerable<Product> GetCategoriesWithProductsByPrice(int categoryId, decimal maxPrice)
        {
            return context.Products
                .Where(p => p.CategoryID == categoryId && p.Price-p.Discount < maxPrice && p.UnitInStocks > 0)
                .Include(p=>p.ProductImages)
                .OrderBy(c=>c.Price);
        }
    }
}

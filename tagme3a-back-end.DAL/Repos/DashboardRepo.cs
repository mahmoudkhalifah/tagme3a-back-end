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
    public class DashboardRepo : IDashboardRepo
    {
        private readonly MainDbContext _context;

        public DashboardRepo(MainDbContext context)
        {
            _context = context;
        }
        public int numberOfCategories()
        {
           return _context.Categories.Count();
        }

        public IEnumerable<Order> ordersStates()
        {
            return _context.Orders.ToList();

        }

        public int numberOfProducts()
        {
            return _context.Products.Count();

        }

        public decimal TotalEarnings()
        {
            

            var totalOrders = _context.Orders.Sum(t => t.Bill);

            return totalOrders;
        }
    }
}

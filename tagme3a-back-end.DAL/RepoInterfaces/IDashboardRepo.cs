using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IDashboardRepo
    {
        IEnumerable<Order> ordersStates();
        public int numberOfProducts();

        public int numberOfCategories();

        public decimal TotalEarnings();

        



    }
}

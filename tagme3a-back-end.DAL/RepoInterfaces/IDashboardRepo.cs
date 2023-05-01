using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IDashboardRepo
    {
        public int numberOfOrders();
        public int numberOfProducts();

        public int numberOfCategories();

        public decimal TotalEarnings();





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers.DashboardManager
{
    public class DashboardManager : IDashboardManager
    {
        private readonly IDashboardRepo _dashboardRepo;

        public DashboardManager(IDashboardRepo dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }
        public decimal getAllEarnings()
        {
            return _dashboardRepo.TotalEarnings();
        }

        public int getAllNumCategories()
        {
           return _dashboardRepo.numberOfCategories();
        }

        public int getAllNumOrders()
        {
            return _dashboardRepo.numberOfOrders();

        }

        public int getAllNumProducts()
        {
            return _dashboardRepo.numberOfProducts();

        }
    }
}

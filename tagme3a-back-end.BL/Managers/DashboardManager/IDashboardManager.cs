using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.OrderDTO;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Managers.DashboardManager
{
    public interface IDashboardManager
    {

        public OrderStatisticsDTO GetOrders();

        public int getAllNumCategories();

        public int getAllNumProducts();

        public decimal getAllEarnings();



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.Managers.DashboardManager
{
    public interface IDashboardManager
    {
        public int getAllNumOrders();

        public int getAllNumCategories();

        public int getAllNumProducts();

        public decimal getAllEarnings();



    }
}

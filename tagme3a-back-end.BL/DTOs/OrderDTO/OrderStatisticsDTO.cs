using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public class OrderStatisticsDTO
    {
        public int TotalOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int DeliveredOrders { get; set; }


    }
}

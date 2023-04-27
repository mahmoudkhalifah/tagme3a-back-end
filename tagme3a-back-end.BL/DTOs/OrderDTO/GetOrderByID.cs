using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public class GetOrderByID
    {
        // AddressID , Bill, OrderDate,ShippingDate,ArrivalDate,OrderState,PayMethod,UserId
        public int ID { get; set; }
        public int AddressID { get; set; }
        public decimal Bill { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string OrderState { get; set; } = string.Empty;
        public string PayMethod { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}

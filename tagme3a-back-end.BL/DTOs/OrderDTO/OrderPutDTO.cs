using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public class OrderPutDTO
    {
        public int ID { get; set; }
        public int AddressID { get; set; }
        public decimal Bill { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public OrderState OrderState { get; set; }
        public PayMethod PayMethod { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}

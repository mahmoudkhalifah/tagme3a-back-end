using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.Address
{
    public class OrderReadInAddressDTO
    {
        public decimal Bill { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public OrderState OrderState { get; set; } = OrderState.Processing;

    }
}

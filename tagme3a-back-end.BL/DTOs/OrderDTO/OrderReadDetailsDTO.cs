using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public class OrderReadDetailsDTO
    {
        public int Id { get; set; }

        public AddressReadinOrderDTO? Address { get; set; }
        public decimal Bill { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string OrderState { get; set; }
        public string PayMethod { get; set; }
        public UserReadInOrderDTO? User { get; set; }


        public IEnumerable<ProductOrdersReadInOrderDTO> ProductOrdersReadInOrder { get; init; }
        = new List<ProductOrdersReadInOrderDTO>();

    }
}

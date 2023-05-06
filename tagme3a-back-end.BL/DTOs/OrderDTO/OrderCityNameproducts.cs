using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public  class OrderCityNameproducts
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string UserId { get; set; }=string.Empty;    
        public string  CityName { get; set; }=string.Empty; 
        public decimal Bill { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? OrderState { get; set; }
        public string PayMethod { get; set; }
        public string Fname { get; set; }   =string.Empty;
        public string Lname { get; set; } = string.Empty;

        public IEnumerable<ProductOrdersReadInOrderDTO> ProductOrdersReadInOrder { get; set; }
        = new List<ProductOrdersReadInOrderDTO>();


    }
}

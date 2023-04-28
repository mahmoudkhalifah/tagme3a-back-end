using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public class OrderReadDTO
    {
        public int Id { get; set; }

        public AddressReadinOrderDTO? Address { get; set; }
        public decimal Bill { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string OrderState { get; set; }
        public string PayMethod { get; set; } 
        public string UserName { get; set; } = string.Empty;

    }
}

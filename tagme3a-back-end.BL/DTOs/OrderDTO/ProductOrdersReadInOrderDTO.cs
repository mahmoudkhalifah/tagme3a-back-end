using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{
    public class ProductOrdersReadInOrderDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantiy { get; set; } = 0;
        public int ProductId { get; set; }
        public decimal Price { get; set; }


    }
}

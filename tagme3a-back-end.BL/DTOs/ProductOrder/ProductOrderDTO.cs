using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.ProductOrder
{
    public class ProductOrderDTO
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantiy { get; set; } = 0;
    }
}

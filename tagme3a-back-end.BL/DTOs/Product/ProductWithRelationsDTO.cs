using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.Product
{
    public class ProductWithRelationsDTO
    {
        public int Id { get; set; }
        public int NumOrders { get; set; }
        public int NumPCs { get; set; }
    }
}

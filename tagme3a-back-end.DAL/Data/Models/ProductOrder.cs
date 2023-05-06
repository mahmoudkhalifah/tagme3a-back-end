using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class ProductOrder
    {

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public int Quantiy { get; set; } = 0;
    }
}


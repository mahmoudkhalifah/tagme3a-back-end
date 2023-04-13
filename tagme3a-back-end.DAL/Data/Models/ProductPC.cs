using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class ProductPC
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int PCId { get; set; }
        public virtual PC? PC { get; set; }
        public int Quantity { get; set; }
    }
}

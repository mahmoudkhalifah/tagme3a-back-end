using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class ProductCompatibility
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public int CompatibleProductId { get; set; }
        public virtual Product? CompatibleProduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[]? Photo { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
}

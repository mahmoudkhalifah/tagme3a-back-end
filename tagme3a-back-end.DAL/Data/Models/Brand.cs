        using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        public byte[]? Logo { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}

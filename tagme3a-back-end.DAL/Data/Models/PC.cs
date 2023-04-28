using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class PC
    {
        [Key]
        public int PCId { get; set; }
        [Required, MaxLength(100)]
        public string BundleName { get; set; } = string.Empty;
        public virtual ICollection<ProductPC> ProductsPC { get; set; } = new HashSet<ProductPC>();

        public byte[]? Image { set; get; }

        public decimal TotalPrice { get; set; }

    }
}

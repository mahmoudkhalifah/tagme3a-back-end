using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        public byte[]? Image { set; get; }
        public virtual ICollection<Product> Products { set; get; } = new List<Product>();
    }
}

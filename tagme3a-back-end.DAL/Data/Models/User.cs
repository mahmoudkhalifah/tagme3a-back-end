using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string Fname { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Lname { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Product> WishlistProducts { get; set; } = new HashSet<Product>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<UserProductInCart> ProductsInCart{ get; set; } = new HashSet<UserProductInCart>();
    }
}

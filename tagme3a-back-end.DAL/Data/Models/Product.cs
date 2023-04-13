using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public int? UnitInStocks { get; set; }

        #region Relations 

        //Images
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();

        //Category

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }


        //Brand
        [ForeignKey("Brand")]
        public int BrandID { get; set; }
        public virtual Brand? Brand { get; set; }

        //PC
        public virtual ICollection<ProductPC> ProductPCs { get; set; } = new HashSet<ProductPC>();

        //Order

        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();

        //cart     
        public virtual ICollection<UserProductInCart> ProductsInCart { get; set; } = new HashSet<UserProductInCart>();


        //WishLists
        public virtual ICollection<User> UsersWishlist { get; set; } = new HashSet<User>();
        //Reviews
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        public virtual ICollection<ProductCompatibility> CompatibleProducts { get; set; } = new HashSet<ProductCompatibility>();


        #endregion
    }
}

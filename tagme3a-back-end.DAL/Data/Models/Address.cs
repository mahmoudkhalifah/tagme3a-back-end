using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required, MaxLength(50)]
        public string ApartementNumber { get; set; } = string.Empty;
        public int Floornumber { get; set; }
        [Required, MaxLength(50)]
        public string StreetName { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Area { get; set; } = string.Empty;
        public int CityId { get; set; }
        public virtual City? City { get; set; }
        [Required, MaxLength(50)]
        public string ZipCode { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string? NearestLandmark { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;
        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

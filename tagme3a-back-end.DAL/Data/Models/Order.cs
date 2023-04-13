using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public  class Order
    {
        public int Id { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address? Address { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Bill { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public OrderState OrderState { get; set; } = OrderState.Processing;
        public PayMethod PayMethod { get; set; } = PayMethod.Cash;

        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;
        public virtual User? User { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();

    }
}

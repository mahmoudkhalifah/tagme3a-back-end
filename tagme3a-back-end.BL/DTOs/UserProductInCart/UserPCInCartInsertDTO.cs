using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.UserProductInCart
{
    public class UserPCInCartInsertDTO
    {
        public int ProductId { get; set; }
        //public string UserId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}

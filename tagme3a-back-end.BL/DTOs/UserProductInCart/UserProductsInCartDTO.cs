using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;

namespace tagme3a_back_end.BL.DTOs.UserProductInCart
{
    public class UserProductsInCartDTO
    {
        public string UserId { get; set; } = string.Empty;
        public IEnumerable<ProductReadDto>productReadDtos { get; set; }=new List<ProductReadDto>();

      

    }
}

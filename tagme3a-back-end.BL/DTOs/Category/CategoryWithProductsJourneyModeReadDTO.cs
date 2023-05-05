using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;

namespace tagme3a_back_end.BL.DTOs.Category
{
    public class CategoryWithProductsJourneyModeReadDTO
    {
        public int CategoryId { get; set; }
        public IEnumerable<ProductJourneyModeReadDTO> Products { get; set; }
    }
}

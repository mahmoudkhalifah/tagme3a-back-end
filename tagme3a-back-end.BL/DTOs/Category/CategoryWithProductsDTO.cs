using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;

namespace tagme3a_back_end.BL.DTOs.Category
{
    public class CategoryWithProductsDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public bool InJourneyMode { get; set; }
        public int? OrderForJourneyMode { get; set; }
        public IEnumerable<ProductBrandCategoryDTO> products { get; set; }= new List<ProductBrandCategoryDTO>();
    }
}

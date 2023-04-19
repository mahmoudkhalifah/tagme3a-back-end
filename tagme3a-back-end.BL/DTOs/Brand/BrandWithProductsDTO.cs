using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;

namespace tagme3a_back_end.BL.DTOs.Brand
{
    public class BrandWithProductsDTO
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Logo { get; set; }
        public IEnumerable<ProductBrandCategoryDTO> products { get; set; } = new List<ProductBrandCategoryDTO>();

    }
}

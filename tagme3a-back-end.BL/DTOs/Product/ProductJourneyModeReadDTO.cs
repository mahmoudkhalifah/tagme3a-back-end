using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.Product
{
    public class ProductJourneyModeReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public int? UnitInStocks { get; set; }
        public List<string> ProductImages { get; set; } = new List<string>();
    }
}

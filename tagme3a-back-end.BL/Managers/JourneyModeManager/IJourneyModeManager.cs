using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Managers.JourneyModeManager
{
    public interface IJourneyModeManager
    {
        public IEnumerable<CategoryJourneyModeDTO> GetCategories();
        public IEnumerable<ProductJourneyModeReadDTO> GetCategoriesWithProductsByPrice(int categoryId, decimal maxPrice);
    }
}

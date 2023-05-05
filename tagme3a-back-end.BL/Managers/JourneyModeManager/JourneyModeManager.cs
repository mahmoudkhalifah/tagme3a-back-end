using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;

namespace tagme3a_back_end.BL.Managers.JourneyModeManager
{
    public class JourneyModeManager : IJourneyModeManager
    {
        private readonly IJourneyModeRepo repo;

        public JourneyModeManager(IJourneyModeRepo repo)
        {
            this.repo = repo;
        }
        public IEnumerable<CategoryJourneyModeDTO> GetCategories()
        {
            return repo.GetCategories().Select(c=>new CategoryJourneyModeDTO()
            {
                CategoryId = c.CategoryId,
                Description = c.Description,
                Name = c.Name
            });
        }

        public IEnumerable<ProductJourneyModeReadDTO> GetCategoriesWithProductsByPrice(int categoryId, decimal maxPrice)
        {
            return repo.GetCategoriesWithProductsByPrice(categoryId,maxPrice)
                .Select(p => new ProductJourneyModeReadDTO()
                {
                    Id = p.Id,
                    Price = p.Price,
                    UnitInStocks = p.UnitInStocks,
                    Description = p.Description,
                    Discount = p.Discount,
                    BrandName = p.Brand?.Name ?? "",
                    Name = p.Name,
                    ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo)).ToList(),
                });
        }
    }
}

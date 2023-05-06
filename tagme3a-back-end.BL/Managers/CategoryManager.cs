using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IProductRepo productRepo;
        public CategoryManager (ICategoryRepo category, IProductRepo productRepo)
        {
            this.categoryRepo = category;
            this.productRepo = productRepo;
        }
        public void DeleteCategory(int id)
        {
            categoryRepo.DeleteCategory(id);
        }
        public IEnumerable<CategoryDTO> GetAll()
        {
           var Categories = categoryRepo.GetAll();
            return Categories.Select(c => new CategoryDTO
            (
              Id:c.CategoryId,
              Name:c.Name,
              Description:c.Description,
              Image:c.Image!,
              InJourneyMode:c.InJourneyMode,
              OrderForJourneyMode:c.OrderForJourneyMode
            ));
        }

        public CategoryDTO GetDetails(int id)
        {
            var category = categoryRepo.GetDetails(id);
            if (category == null)
                return null!;
            return new CategoryDTO
                (
                 category.CategoryId,category.Name,category.Description,category.Image!,
                 category.InJourneyMode,category.OrderForJourneyMode
                );           
        }

        public CategoryWithProductsDTO GetProductsWithCategory(int id)
        {
            Category catFromDb = categoryRepo.GetWithProductsById(id);
            if (catFromDb == null) { return null!; }
            return new CategoryWithProductsDTO
            {
                CategoryId = catFromDb.CategoryId,
                Name = catFromDb.Name,
                Description = catFromDb.Description,
                Image = catFromDb.Image,
                InJourneyMode = catFromDb.InJourneyMode,
                OrderForJourneyMode = catFromDb.OrderForJourneyMode,
                products = catFromDb.Products.Select(
                    p => new ProductBrandCategoryDTO
                    {   Id = p.Id, Description = p.Description, 
                        Discount = p.Discount,
                        Name = p.Name,
                        Price = p.Price,
                        UnitInStocks = p.UnitInStocks,
                        ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo!)).ToList()
                    })
            };
        }

        public void Insert(CategoryInsertDTO categoryDTO)
        {
            byte[] imageBytes = Convert.FromBase64String(categoryDTO.Image);
            Category category = new Category()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                Image = imageBytes,
                InJourneyMode = categoryDTO.InJourneyMode,
                OrderForJourneyMode = categoryDTO.OrderForJourneyMode,              
            };
            categoryRepo.Insert(category);
        }

        public void UpdateCategory(int id, CategoryInsertDTO dto)
        {
            var category = categoryRepo.GetDetails(id);
            byte[] imageBytes = Convert.FromBase64String(dto.Image);
            if (category != null)
            {
                category.Name = dto.Name;
                category.Description = dto.Description;
                category.Image = imageBytes;
                category.InJourneyMode = dto.InJourneyMode;
                category.OrderForJourneyMode= dto.OrderForJourneyMode;  
            }
            categoryRepo.UpdateCategory(id, category!);
        }
    }
}

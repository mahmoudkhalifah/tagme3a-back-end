using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryManager (ICategoryRepo category)
        {
            this.categoryRepo = category;
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
              Image:c.Image!
            ));
        }

        public CategoryDTO GetDetails(int id)
        {
            var category = categoryRepo.GetDetails(id);
            if (category == null)
                return null!;
            return new CategoryDTO
                (
                 category.CategoryId,category.Name,category.Description,category.Image!
                );           
        }
        public void Insert(CategoryInsertDTO categoryDTO)
        {
            byte[] imageBytes = Convert.FromBase64String(categoryDTO.Image);
            Category category = new Category()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                Image = imageBytes,
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
            }
            categoryRepo.UpdateCategory(id, category!);
        }
    }
}

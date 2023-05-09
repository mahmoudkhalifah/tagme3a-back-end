using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.Managers;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager categoryManager;
        public CategoriesController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }
        [Authorize(Constants.Authorize.Admin)]
        [HttpPost]
        public ActionResult addCategory(CategoryInsertDTO categoryDTO)
        {//
            //
            categoryManager.Insert(categoryDTO);
            return NoContent();
        }
        [HttpGet]
        public ActionResult<List<CategoryDTO>> GetCategories() 
        {
            return categoryManager.GetAll().ToList();
        }
        [HttpGet]
        [Route("CategoriesWithPrds/{id}")]
        public ActionResult<CategoryWithProductsDTO> GetCategoriesWithProducts(int id)
        {
            if(categoryManager.GetProductsWithCategory(id) == null) { return NotFound(); }
            return categoryManager.GetProductsWithCategory(id);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<CategoryDTO>> GetCategoryById(int id)
        {
            var category = categoryManager.GetDetails(id);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }
        [Authorize(Constants.Authorize.Admin)]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            var categortToDelete = categoryManager.GetProductsWithCategory(id);
            if (categortToDelete is null)
                return NotFound();
            if(categortToDelete.products.Count() == 0)
                return BadRequest();
            categoryManager.DeleteCategory(id);
            return NoContent();
        }
        [Authorize(Constants.Authorize.Admin)]
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryInsertDTO dto)
        {
            var categoryToUpdate = categoryManager.GetDetails(id);
            if (categoryToUpdate is null)
            {
                return NotFound();
            }
            categoryManager.UpdateCategory(id, dto);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Brand;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.Managers;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandManager brandManager;
        public BrandsController(IBrandManager brandManager)
        {
            this.brandManager = brandManager;
        }
        [Authorize(Constants.Authorize.Admin)]
        [HttpPost]
        public ActionResult addBrand(BrandInsertDTO brandDTO)
        {//
            /*
             *
             */
            //
            brandManager.Insert(brandDTO);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<BrandDTO>> GetCategories()
        {
            return brandManager.GetAll().ToList();
        }

        [HttpGet]
        [Route("BrandsWithPrds/{id}")]
        public ActionResult<BrandWithProductsDTO> GetBrandsWithProducts(int id)
        {
            if(brandManager.GetBrandWithProducts(id) == null) { return NotFound(); }
            return brandManager.GetBrandWithProducts(id);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<BrandDTO>> GetCategoryById(int id)
        {
            var brand = brandManager.GetDetails(id);
            if (brand == null) { return NotFound(); }
            return Ok(brand);
        }
        [Authorize(Constants.Authorize.Admin)]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            var brandToDelete = brandManager.GetBrandWithProducts(id);
            if (brandToDelete is null)
            {
                return NotFound();
            }
            if (brandToDelete.products.Count() != 0)
                return BadRequest();
            brandManager.DeleteBrand(id);
             
            return NoContent();
        }
        [Authorize(Constants.Authorize.Admin)]
        [HttpPut("{id}")]
        public IActionResult PutBrand(int id, BrandInsertDTO dto)
        {
            var brandToUpdate = brandManager.GetDetails(id);
            if (brandToUpdate is null)
            {
                return NotFound();
            }
            brandManager.UpdateBrand(id, dto);
            return NoContent();

        }
    }
}

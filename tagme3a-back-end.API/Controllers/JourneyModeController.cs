using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.BL.Managers.JourneyModeManager;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyModeController : ControllerBase
    {
        private readonly IJourneyModeManager manager;

        public JourneyModeController(IJourneyModeManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        [Route("getCategories")]
        [Authorize(Constants.Authorize.User)]
        public ActionResult<List<CategoryJourneyModeDTO>> GetCategories()
        {
            return manager.GetCategories().ToList();
        }
        [HttpGet]
        [Route("getCategoriesWithProductsByPrice/{id:int}")]
        [Authorize(Constants.Authorize.User)]
        public ActionResult<List<ProductJourneyModeReadDTO>> GetCategoriesWithProductsByPrice(int id,decimal maxPrice)
        {
            return manager.GetCategoriesWithProductsByPrice(id, maxPrice).ToList();
        }

    }
}

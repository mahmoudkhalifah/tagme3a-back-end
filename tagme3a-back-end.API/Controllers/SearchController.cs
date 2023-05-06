using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.BL.Managers.ProductManager;
using tagme3a_back_end.BL.Managers.SearchManager;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchManager _searchManager;
        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }
        
        [HttpGet("{productName}")]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProduct(string productName)
        {
            var products = _searchManager.GetAllProduct(productName);
            return Ok(products);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.BL.Managers.ProductManager;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        [Route("catbrandprds")]
        public ActionResult<List<ProductReadDto>> getAllProducts(int brandId,int categoryId)
        {
            return _productManager.GetAllProduct(brandId, categoryId).ToList();
        }

        [HttpGet]
        [Route("admin/products")]
        public ActionResult<List<ProductReadDto>> getAllProductsAdmin()
        {
            return _productManager.GetAllProductAdmin().ToList();
        }
        [HttpGet]
        public ActionResult<List<ProductReadDto>> getAllProductsUser()
        {
            return _productManager.GetAllProduct().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<ProductReadDto>> getProductById(int id)
        {
            var prd = _productManager.getProductbyId(id);
            if (prd != null)
            {
                return Ok(prd);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult addProduct (ProductPostDto product)
        {
            _productManager.AddProduct(product);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]

        public ActionResult updateProduct(ProductPutDto product , int id)
        {
            var getPrd = _productManager.getProductbyId (id);   
            if (getPrd is not null)
            {
                _productManager.UpdateProduct(product, id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult deleteProduct(int id)
        {
            var getPrd = _productManager.getProductbyId(id);
            if (getPrd is not null)
            {
                _productManager.DeleteProduct(id);
                return NoContent();

            }
            else
            {
                return NotFound();
            }
        }


    }
}

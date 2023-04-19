using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Brand;
using tagme3a_back_end.BL.DTOs.UserProductInCart;
using tagme3a_back_end.BL.Managers;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProducstInCartController : ControllerBase
    {
        private readonly IUserProductInCartManager userProductInCartManager;
        public UserProducstInCartController(IUserProductInCartManager userProductInCartManager)
        {
            this.userProductInCartManager = userProductInCartManager;
        }
        [HttpGet]
        public ActionResult GetDetailsOfCartForSpecificUser(string UserId)
        {
            var t = userProductInCartManager.GetUserProductsInCart(UserId);
            if(t == null) { return NotFound(); }
            return Ok(t);
        }
        [HttpPost]
        public ActionResult AddProductInCart(UserProductInCartInsertDTO DTO)
        {
            userProductInCartManager.AddProductInCart(DTO);
            return NoContent();
        }
        [HttpDelete]
        [Route("{UserId}/{ProductId}")]
        public ActionResult DeleteById(string UserId, int ProductId)
        {
            var productToDelete = userProductInCartManager.GetDetails(UserId, ProductId);
            if (productToDelete is null)
            {
                return NotFound();
            }
            userProductInCartManager.DeleteProductInCart(UserId,ProductId);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [Authorize(Constants.Authorize.User)]
        [HttpGet]
        public ActionResult GetDetailsOfCartForSpecificUser(string UserId)
        {
            var t = userProductInCartManager.GetUserProductsInCart(UserId);
            if (t == null) { return NotFound(); }
            return Ok(t);
        }
        [Authorize(Constants.Authorize.User)]
        [HttpPost]
        public ActionResult AddProductInCart(UserProductInCartInsertDTO DTO)
        {
            try
            {
                userProductInCartManager.AddProductInCart(DTO);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Constants.Authorize.User)]
        [HttpPost]
        [Route("{userId}")]
        public ActionResult AddProductsInCart(List<UserPCInCartInsertDTO> userPCInCarts, string userId)
        {
            userProductInCartManager.AddLstProductInCart(userPCInCarts, userId);
            return NoContent();
        }
        [Authorize(Constants.Authorize.User)]
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
        [Authorize(Constants.Authorize.User)]
        [HttpGet]
        [Route("GetUserCartPrdName")]
        public ActionResult <List<UserCartPrdName>> GetUserCartPrdName(string UserId )
        {
            var Carts = userProductInCartManager.GetUserCartPrdName(UserId).ToList();
            if (Carts == null) { return NoContent(); }
            return Ok(Carts);
        }
        [Authorize(Constants.Authorize.User)]
        [HttpPut]
        [Route("UpdateCard")]
        public ActionResult UpdateCard (int PID, String UID, UserProductInCartInsertDTO UserProductInCartInsertDTO)
        {
            userProductInCartManager.UpdateCard(PID, UID, UserProductInCartInsertDTO);
            return Ok();
        }
        [Authorize(Constants.Authorize.User)]
        [HttpDelete]
        [Route("DeleteCarts")]
        public ActionResult DeleteCards(String UID)
        {
            userProductInCartManager.DeleteCarts(UID);
            return NoContent();
        }


    }
}

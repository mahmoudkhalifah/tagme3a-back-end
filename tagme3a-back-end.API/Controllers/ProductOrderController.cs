using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.Managers;
using tagme3a_back_end.BL.Managers.PrpductOrderManager;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {
        private readonly IPOManager _pOManager;
        private readonly IOrderManager _OrderManager;
        private readonly IUserProductInCartManager _userProductInCart;
        public ProductOrderController(IPOManager pOManager)
        {
            this._pOManager = pOManager;

        }
        [HttpPost]
        [Route("AddProductOrder")]
        [Authorize(Constants.Authorize.User)]
        public IActionResult AddProductOrder(string UID)
        {
            _pOManager.AddProductOrder(UID);
            return NoContent();

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.BL.Managers.DashboardManager;
using tagme3a_back_end.BL.Managers.ProductManager;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardManager _dashboardManager;
        public DashboardController(IDashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }

        [Authorize(Constants.Authorize.Admin)]

        [HttpGet("numOfProducts")]
        public ActionResult<int> NumOfProducts()
        {
            return _dashboardManager.getAllNumProducts();
        }

        [Authorize(Constants.Authorize.Admin)]

        [HttpGet("numOfCategories")]
        public ActionResult<int> NumOfCategories()
        {
            return _dashboardManager.getAllNumCategories();
        }

        [Authorize(Constants.Authorize.Admin)]

        [HttpGet("numOfOrders")]
        public ActionResult<int> NumOfOrders()
        {
            return _dashboardManager.getAllNumOrders();
        }

        [Authorize(Constants.Authorize.Admin)]

        [HttpGet("totalEarnings")]
        public ActionResult<decimal> TotalEarnings()
        {
            return _dashboardManager.getAllEarnings();
        }


    }
}

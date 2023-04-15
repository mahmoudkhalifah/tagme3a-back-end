using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.OrderDTO;
using tagme3a_back_end.BL.Managers;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public ActionResult<List<OrderReadDTO>> GetAll()
        {
            return _orderManager.GetAll().ToList();
        }

        [HttpGet]
        [Route("CityName")]
        public ActionResult<CitynameOrderReadDTO>  GetCityName(int id)
        {
            return _orderManager.GetWithAddressWithCityId(id);
        }


        [HttpGet]
        [Route("GetWithProduct")]
        public ActionResult<List<ProductOrdersReadInOrderDTO>> GetProductOrders(int id)
        {
            return _orderManager.GetProductOrdersReadInOrder(id).ToList();
        }


        [HttpGet]
        [Route("GetWithUSER,PRODUCT,CITY")]

        public ActionResult<OrderReadDetailsDTO> GetOrderReadDetails(int id)
        {
            return Ok(_orderManager.GetOrderReadDetails(id));
        }

        [HttpPost]
        public void Post (OrderPostDTO orderPostDTO)
        {
            // int AddressID , decimal Bill ,DateTime OrderDate,DateTime ShippingDate, DateTime ArrivalDate,OrderState OrderState ,PayMethod PayMethod,int UserId
           
            _orderManager.postOrder(orderPostDTO.AddressID, orderPostDTO.Bill,orderPostDTO.OrderDate,orderPostDTO.ShippingDate,orderPostDTO.ArrivalDate,orderPostDTO.OrderState,orderPostDTO.PayMethod,orderPostDTO.UserId);
        }

        [HttpPut]
        public IActionResult Put(int id, OrderPutDTO orderPutDTO)
        {
            return Ok(_orderManager.UpdateOrder(id, orderPutDTO));
        }

    }
}

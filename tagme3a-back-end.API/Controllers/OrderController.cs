using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Constants.Authorize.Admin)]
        public ActionResult<List<OrderReadDTO>> GetAll()
        {
            var Orders= _orderManager.GetAll().ToList();
            if(Orders == null) { return NoContent(); }
            return Ok(Orders);
        }

        [HttpGet]
        [Route("CityName")]
        public ActionResult<CitynameOrderReadDTO>  GetCityName(int id)
        {
            var Orders= _orderManager.GetWithAddressWithCityId(id);
            if (Orders != null)
            {
                return Ok(Orders);
            }
            else
                return NotFound();
        }


        [HttpGet]
        [Route("GetWithProduct")]
        public ActionResult<List<ProductOrdersReadInOrderDTO>> GetProductOrders(int id)
        {
            var Orders= _orderManager.GetProductOrdersReadInOrder(id).ToList();
            if(Orders!=null)
            {
                return Ok(Orders);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpGet]
        [Route("GetWithUSER,PRODUCT,CITY")]
        public ActionResult<OrderReadDetailsDTO> GetOrderReadDetails(int id)
        {
            var Orders=_orderManager.GetOrderReadDetails(id);
            if(Orders!=null)
            { return Ok(Orders); }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("OrderCityNameproducts")]
        [Authorize(Constants.Authorize.Admin)]
        public ActionResult<OrderCityNameproducts> GetCityNameproducts(int id)
        {
            var Orders = _orderManager.CityNameproducts(id);
            if (Orders != null)
            { return Ok(Orders); }
            else { return NotFound(); }

        }

        //Details
        [HttpGet]
        [Route("GetOrderByID")]
        public ActionResult<GetOrderByID> GetGetOrderByID(int id)
        {
            var Order=_orderManager.GetOrderById(id);   
            if(Order==null) return NotFound();
            return Ok(Order);
        }

        //For user 

        [HttpGet]
        [Route("OrderByUserID")]
        [Authorize(Constants.Authorize.User)]
        //public ActionResult<OrderCityNameproducts> GetAllForUser(string ID)
        public ActionResult<List<OrderCityNameproducts>> GetAllForUser(string ID)
        {
            var Orders = _orderManager.OrderByUserID(ID);//ToList();
            if (Orders == null) { return NoContent(); }
            return Ok(Orders);
        }



        [HttpPost]
        [Authorize(Constants.Authorize.User)]
        public ActionResult Post (OrderPostDTO orderPost)
        {           
            _orderManager.postOrder(orderPost);
            return NoContent();
        }


        [HttpPut]
        [Authorize(Constants.Authorize.Admin)]
        public IActionResult Put(int id, OrderPutDTO orderPutDTO)
        {
            return Ok(_orderManager.UpdateOrder(id, orderPutDTO));
        }



    }
}

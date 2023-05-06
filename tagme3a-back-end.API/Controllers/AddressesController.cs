using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.Address;
using tagme3a_back_end.BL.Managers.address;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressManager _addressManager;

        public AddressesController(IAddressManager addressManager)
        {
            this._addressManager = addressManager;
        }

        [HttpGet]
        public ActionResult<List<AddressReadDTO>> GetAll()
        {
            return _addressManager.GetAll().ToList();
        }
        [HttpPost]
        public ActionResult AddAddress(AddressAddDTO address)
        {
            if (!_addressManager.AddAddress(address))
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateAddress(int id , AddressAddDTO addressAddDTO)
        {
            if(!_addressManager.UpdateAddress(id, addressAddDTO))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteAddress(int id)
        {
            if(!_addressManager.RemoveAddress(id))
                return NotFound();
            return Ok();
        }

        [HttpGet]
        [Route("getAddressID")]
        public IActionResult getAID(string UID)
        {
           return Ok(_addressManager.GetAddressIDbyUID(UID));
        }

        [HttpGet]
        [Route("GetAddressesByUID")]

        public IActionResult GetAddressesByUID(string ID)
        {
            var Addresses=_addressManager.GetAddress(ID);
            if(Addresses==null) return NotFound();
            return Ok(Addresses);
        }
    }
}

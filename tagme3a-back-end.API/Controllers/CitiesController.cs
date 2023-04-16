using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.DTOs.City;
using tagme3a_back_end.BL.Managers;
using tagme3a_back_end.BL.Managers.City;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityManager _cityManager;

        public CitiesController(ICityManager cityManager)
        {
            this._cityManager = cityManager;
        }

        [HttpGet]
        public ActionResult<List<CityReadDTO>> GetAll() 
        {
            return _cityManager.GetAll().ToList();
        }
    }
}

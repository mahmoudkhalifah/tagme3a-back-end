using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Constants.Authorize.User)]
        [Route("User")]
        public ActionResult<string> GetDataForUser()
        {
            return "User Data";
        }

        [HttpGet]
        [Authorize(Constants.Authorize.Admin)]
        [Route("Admin")]
        public ActionResult<string> GetDataForAdmin()
        {
            return "Admin Data";
        }

    }
}

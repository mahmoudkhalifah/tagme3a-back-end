using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagme3a_back_end.BL.Managers.ProfileManager;
using tagme3a_back_end.BL.Managers.UserProfileManager;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileManager _userProfileManager;
        public UserProfileController(IUserProfileManager userProfileManager)
        {
            _userProfileManager = userProfileManager;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _userProfileManager.getUserbyId(userId);
            if (user == null)
                return NotFound();

            return Ok(user);


        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, User user)
        {
            if (userId != user.Id)
                return BadRequest();

            await _userProfileManager.UpdateUser(user, userId);

            return NoContent();
        }
    }
}

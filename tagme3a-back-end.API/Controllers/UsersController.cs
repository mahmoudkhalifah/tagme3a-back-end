using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tagme3a_back_end.BL.DTOs.User;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public UsersController(IConfiguration configuration,UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserTokenReturnDto>> Login(UserLoginDto credentials)
        {
            User? user = await userManager.FindByEmailAsync(email: credentials.Email);
            if (user == null)
                return NotFound();
            bool isAuthenitcated = await userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenitcated)
                return Unauthorized();

            var claimsList = await userManager.GetClaimsAsync(user);

            var secretKeyString = configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(14);

            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return new UserTokenReturnDto(tokenString, expiry);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserRegisterDto registerDto)
        {
            User user = new User()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Fname = registerDto.Fname,
                Lname = registerDto.Lname,
                Gender = registerDto.Gender,
            };

            var result = await userManager.CreateAsync(user,registerDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, Constants.Roles.User)
            };

            await userManager.AddClaimsAsync(user, claims);
            return NoContent();
        }
    }
}

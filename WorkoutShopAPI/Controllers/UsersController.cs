using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutShop.Domain.Entities;
using WorkoutShop.API.ViewModels;

using System.IdentityModel.Tokens.Jwt;


namespace WorkoutShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userName = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found in token.");
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.Address
            });
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileViewModel model)
        {
            var userName = User?.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized("User not found in token.");
            }

            var user = await _userManager.FindByNameAsync(userName);


            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Profile updated successfully.");
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StreamSpoatsPR.Server.Model;
using StreamSpoatsPR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private static UserModel LoggedOutUser = new UserModel { IsAuthenticated = false };

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });

            }

            return Ok(new RegisterResult { Successful = true });
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult<AccountUserUpdate>> GetUser(string UserId)
        {
            var User = await _userManager.FindByNameAsync(UserId);
           
            if (User == null)
            {
                return NotFound();
            }
            AccountUserUpdate u = new AccountUserUpdate();
            u.Email = User.Email;
            u.Name = User.Name;
            u.Bio = User.Bio;
            u.ProfileImage = User.ProfileImage;
            u.Phone = User.PhoneNumber;
            return u;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] AccountUserUpdate model)
        {
            var user =await _userManager.FindByEmailAsync(model.Email);
            user.Name = model.Name;
            user.PhoneNumber = model.Phone;
            user.Bio = model.Bio;
            var result = await _userManager.UpdateAsync(user);

            //var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email };

            //var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });

            }

            return Ok(new RegisterResult { Successful = true });
        }

    }
}

﻿
using JWTDemo.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });

            }

            await _userManager.AddToRoleAsync(newUser, "User");
            if (newUser.Email!.ToLower().StartsWith("admin"))
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
                return Ok(new RegisterResult { Successful = true });
            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}

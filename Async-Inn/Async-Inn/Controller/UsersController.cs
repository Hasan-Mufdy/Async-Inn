using Async_Inn.Models.DTO;
using Async_Inn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Async_Inn.Controller
{
    [Authorize(Roles = "District Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser userService;
        public UsersController(IUser service)
        {
            userService = service;
        }

        [Authorize(Roles = "Property Manager, Agent")]
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await userService.Authenticate(loginDto.UserName, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        [Authorize(Roles = "District Manager")]
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
            return await userService.GetUser(this.User);
        }


    }
}
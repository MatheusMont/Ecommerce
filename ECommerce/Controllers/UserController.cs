using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Models;
using ECommerce.Api.DTO.User.Request;
using ECommerce.Api.DTO.User.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public UserResponse GetUser(Guid userId)
        {
            Console.WriteLine(userId);
            _userService.RegisterUser(new User());
            return new UserResponse();
        }

        // POST api/<UserController>
        [HttpPost("Register")]
        public void Post([FromBody] UserRequest userRequest)
        {

        }

        // PUT api/<UserController>/5
        [HttpPost("Login")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using AutoMapper;
using Ecommerce.API.Configurations;
using Ecommerce.DOMAIN.DTOs.Request;
using Ecommerce.DOMAIN.DTOs.Response;
using Ecommerce.DOMAIN.Interfaces.INotifier;
using Ecommerce.DOMAIN.Interfaces.IServices;
using Ecommerce.DOMAIN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : BaseController
    {
        private readonly IUserServices _userServices;
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices,
                                INotifier notifier,
                                IMapper mapper) : base(notifier, mapper)
        {
            _userServices = userServices;
            _notifier = notifier;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromHeader] int id)
        {
            //var user = await _userServices.GetUserById(id);

            return HasError()
                ? ReturnBadRequest()
                : Ok(new UserResponse());
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>A message indicating success or error</returns>
        /// <response code = "201">Returns a success creation message</response>
        /// <response code = "400">Returns a user error message</response>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(UserCreationRequest userDto)
        {
            var user = _mapper.Map<User>(userDto);

            await _userServices.CreateUser(user);

            return HasError()
                ? ReturnBadRequest()
                : Ok(201);
        }
    }
}

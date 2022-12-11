using AutoMapper;
using Ecommerce.API.Configurations;
using Ecommerce.DOMAIN.DTOs.Request;
using Ecommerce.DOMAIN.DTOs.Response;
using Ecommerce.DOMAIN.Interfaces.INotifier;
using Ecommerce.DOMAIN.Interfaces.IRepository;
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

        /// <summary>
        /// Gets the User by their Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An error or the User's public information</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userServices.GetUserById(id);

            return HasError()
                ? ReturnBadRequest()
                : Ok(_mapper.Map<UserResponse>(user));
        }

        /// <summary>
        /// Gets the User by their Id.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>An error or the User's public information</returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userServices.GetUserByEmail(email);

            return HasError()
                ? ReturnBadRequest()
                : Ok(_mapper.Map<UserResponse>(user));
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
                : StatusCode(201, "Created");
        }

        /// <summary>
        /// Gets the User by their Id.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>An error or the User's public information</returns>
        [HttpPut("Update/{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest userDto, Guid id)
        {
            var user = _mapper.Map<User>(userDto);

            await _userServices.UpdateUser(user, id);

            return HasError()
                ? ReturnBadRequest()
                : Ok("Usuário atualizado com sucesso");
        }

        [HttpPut("Update/ChangePassword/{id:Guid}")]
        public async Task<IActionResult> ChangePassword([FromBody] string password, Guid id)
        {

            var userDto = new UserCreationRequest("UsernamePlaceHolder", password, "email@placeholder.com");
            var user = _mapper.Map<User>(userDto);
            await _userServices.ChangePassword(user, id);

            return HasError()
                ? ReturnBadRequest()
                : Ok("Usuário atualizado com sucesso");
        }

        /// <summary>
        /// Gets the User by their Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>An error or the confirmation of the User's deletion</returns>
        [HttpDelete("Delete/{id:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userServices.DeleteUser(id);

            return HasError()
                ? ReturnBadRequest()
                : Ok("Usuário deletado com sucesso");
        }

    }
}

using AutoMapper;
using Ecommerce.Core.Controller;
using Ecommerce.Core.Notifications;
using Ecommerce.DOMAIN.Interfaces.IServices;
using Ecommerce.DOMAIN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
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

        [HttpGet("User/{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromHeader] Guid id)
        {
            var user = _userServices.GetUser(id);

            return HasError()
                ? ReturnBadRequest()
                : Ok();
        }
    }
}

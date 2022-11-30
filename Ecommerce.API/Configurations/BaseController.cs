using AutoMapper;
using Ecommerce.DOMAIN.Interfaces.INotifier;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Configurations
{
    [ApiController]
    //[Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public BaseController(INotifier notifier,
                                IMapper mapper)
        {
            _notifier = notifier;
            _mapper = mapper;
        }

        protected bool HasError()
        {
            if (!_notifier.HasNotifications()) return false;

            foreach (var notification in _notifier.GetNotifications())
            {
                ModelState.AddModelError(notification.Field, notification.Message);
            }

            return true;
        }

        protected IActionResult ReturnBadRequest()
        {
            return ValidationFilter.ControllerBadRequestResponse(ModelState);
        }
    }
}

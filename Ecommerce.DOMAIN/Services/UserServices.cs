using Ecommerce.DOMAIN.Interfaces.IServices;
using Ecommerce.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DOMAIN.Interfaces.IRepository;
using Ecommerce.DOMAIN.Interfaces.INotifier;
using Ecommerce.DOMAIN.Validations;
using FluentValidation;

namespace Ecommerce.DOMAIN.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly INotifier _notifier;
        
        public UserServices(INotifier notifier, 
                            IUserRepository repository)
        {
            _repository = repository;
            _notifier = notifier;
        }

        public async Task CreateUser(User user)
        {
            var validator = new UserValidator();
            var validation = validator.Validate(user);

            if (!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                {
                    var notification = new Notification(error.AttemptedValue.ToString(), error.ErrorMessage);
                    _notifier.AddNotification(notification);
                }
            }
            
            await _repository.CreateUser(user);
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

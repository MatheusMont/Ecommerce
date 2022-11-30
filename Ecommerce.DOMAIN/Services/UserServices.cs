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
using Ecommerce.DOMAIN.DTOs.Request;

namespace Ecommerce.DOMAIN.Services
{
    public class UserServices : BaseService, IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly INotifier _notifier;
        
        public UserServices(INotifier notifier, 
                            IUserRepository repository) : base(notifier)
        {
            _repository = repository;
            _notifier = notifier;
        }

        public async Task CreateUser(User user)
        {

            try
            {
                var validation = ExecuteValidation(new UserValidator(), user);
                /*
                if (!validation.IsValid)
                {
                    foreach (var error in validation.Errors)
                    {
                        var notification = new Notification(error.AttemptedValue.ToString(), error.ErrorMessage);
                        _notifier.AddNotification(notification);
                    }
                }
                */

                if (!validation)
                    return;
                
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                if (await _repository.EmailExists(user.Email))
                    NotifyErrorMessage("Email", "Este email já está cadastrado");

                var nots = _notifier.HasNotifications();
                if(!_notifier.HasNotifications())
                    await _repository.CreateUser(user);
            }
            catch(Exception e)
            {
                NotifyErrorMessage($"{e}", "Ocorreu um erro inesperado, tente novamente mais tarde.");
            }
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var user = await _repository.GetUserById(id);

                if (user == null)
                    NotifyErrorMessage("Email", "Este email não está cadastrado");

                return user;
            }
            catch (Exception e)
            {
                NotifyErrorMessage($"{e}", "Ocorreu um erro inesperado, tente novamente mais tarde.");
                return new User();
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = await _repository.GetUserByEmail(email);

                if (user == null)
                    NotifyErrorMessage("Email", "Este email não está cadastrado");

                return user;
            }
            catch (Exception e)
            {
                NotifyErrorMessage($"{e}", "Ocorreu um erro inesperado, tente novamente mais tarde.");
                return new User();
            }
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Services
{
    public class UserService : IUserService
    {
        public Task ChangePassword(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUser(User user)
        {
            Console.WriteLine("Olha o usuário registrado");
            throw new NotImplementedException();
        }
    }
}

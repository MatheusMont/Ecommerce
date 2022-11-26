using Ecommerce.DOMAIN.Interfaces.IServices;
using Ecommerce.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Services
{
    public class UserServices : IUserServices
    {
        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

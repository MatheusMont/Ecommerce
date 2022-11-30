using Ecommerce.DOMAIN.DTOs.Request;
using Ecommerce.DOMAIN.DTOs.Response;
using Ecommerce.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Interfaces.IServices
{
    public interface IUserServices
    {
        Task CreateUser(User user);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}

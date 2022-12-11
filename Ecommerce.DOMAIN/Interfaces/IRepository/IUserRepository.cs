using Ecommerce.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Interfaces.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> EmailExists(string email);
        Task<User> GetUserByEmail(string email);
    }
}

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
        Task GetUser(Guid id);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}

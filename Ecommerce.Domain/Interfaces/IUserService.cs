using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(User user);
        Task LoginUser(string username, string password);
        Task ChangePassword(string oldPassword, string newPassword);
        Task DeleteUser();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Models
{
    public class User : Base
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(Guid id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}

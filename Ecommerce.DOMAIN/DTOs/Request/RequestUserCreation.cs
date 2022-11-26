using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.DTOs.Request
{
    public class RequestUserCreation
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
    }
}

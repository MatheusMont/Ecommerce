﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.DTOs.Request
{
    public class UserCreationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserCreationRequest(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public UserCreationRequest() { }
    }
}

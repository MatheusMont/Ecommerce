using Ecommerce.DATA.Context;
using Ecommerce.DOMAIN.Interfaces.IRepository;
using Ecommerce.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DATA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceContext _context;

        public UserRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
            _context.SaveChanges();
            
        }

        public async Task<bool> EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return _context.Users.First(u => u.Email == email);
        }
    }
}

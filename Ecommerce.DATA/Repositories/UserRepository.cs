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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ECommerceContext _context;

        public UserRepository(ECommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email && u.Active == true);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return _context.Users.First(u => u.Email == email && u.Active == true);
        }
    }
}

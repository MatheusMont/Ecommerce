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

            var addUser = new User(new Guid(), "usuario", "email@mail.com", "senha");
            await _context.AddAsync(addUser);
            _context.SaveChanges();
            
        }
    }
}

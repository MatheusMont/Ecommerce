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
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected ECommerceContext _context;

        public BaseRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var result = _context.Set<T>().First(u => u.Id == id && u.Active == true);

            result.Active = false;
            result.DeletionDate = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public async Task<T> GetById(Guid id)
        {
            return _context.Set<T>().First(u => u.Id == id && u.Active == true);
        }

        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().Where(u => u.Active == true).ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

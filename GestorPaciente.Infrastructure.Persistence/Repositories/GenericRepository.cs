using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, int id)
        {
            var entitie = await this.GetByIdAsync(id);
            _context.Entry(entitie).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllIncludeAsync(List<string> properties)
        {
            var query = _context.Set<T>().AsQueryable();
            if (properties != null)
            {
                foreach (var item in properties)
                {
                    query = query.Include(item);
                }

            }
            return await query.ToListAsync();

        }


    }
}

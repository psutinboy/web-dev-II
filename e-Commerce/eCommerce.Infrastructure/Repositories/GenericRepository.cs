using Microsoft.EntityFrameworkCore;
using System.Data;

namespace eCommerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        //The DbContext class that handles database operations like querying, 
        // adding, updating, and deleting data
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync(); // Ensure changes are saved
            return entity;
        }

        public async Task Update(T entity)
        {

            try
            {
                if (entity == null) throw new ArgumentNullException(nameof(entity));

                _dbSet.Update(entity);
                await _context.SaveChangesAsync(); // Ensure changes are saved

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(); // Ensure changes are saved
        }
    }
}

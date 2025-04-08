using eCommerce.Domain.Entities;
using eCommerce.Infrastructure;
using eCommerce.Infrastructure.Repositories;

namespace eCommerce.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 
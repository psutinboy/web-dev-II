using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;
public interface IUserRepository : IGenericRepository<ApplicationUser>
{
    Task<bool> IsExists(int id);

    Task<ApplicationUser> GetByEmail(string email);

}

public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {

        _context = context;
    }

    public async Task<bool> IsExists(int id)
    {
        return await _context.Users.FindAsync(id) != null;
    }

    public async Task<ApplicationUser> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(p => p.Email == email); //_dbSet.FindAsync(id);
    }
}

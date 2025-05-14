using eCommerce.Domain.Entities;

namespace eCommerce.Infrastructure.Repositories
{
    public interface IInventoryRepository : IGenericRepository<Inventory>
    {}
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(AppDbContext context) : base(context) { }
    }
}
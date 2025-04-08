using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(string name, string email, string password, string role);
        Task<(bool success, string token, string role)> LoginAsync(string email, string password);
        Task<bool> IsEmailUniqueAsync(string email);
    }
} 
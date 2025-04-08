using AutoMapper;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Repositories;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);

    Task<UserDto> GetByEmail(string email);
    Task<UserDto> AddAsync(UserDto userDto);
    Task<UserDto> UpdateAsync(UserDto userDto);
    Task<bool> DeleteAsync(int id);
    Task<bool> IsExists(int id);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> AddAsync(UserDto userDto)
    {
        var user = _mapper.Map<ApplicationUser>(userDto);
        var createdUser = await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(createdUser);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var product = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(product);
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return false;
        }
        await _userRepository.Delete(user);
        return true;
    }

    public async Task<bool> IsExists(int id)
    {
        return await _userRepository.IsExists(id);
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        if (userDto.Id == null)
        {
            throw new ArgumentException("User ID cannot be null");
        }
        
        var user = await _userRepository.GetByIdAsync(userDto.Id.Value);
        if (user == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        _mapper.Map(userDto, user);
        await _userRepository.Update(user);
        return _mapper.Map<UserDto>(user);
    }
}
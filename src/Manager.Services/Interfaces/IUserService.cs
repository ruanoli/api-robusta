
using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> Get(long id);
        Task<UserDto> Create(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task Delete(long id);
        Task<UserDto> GetByEmail(string email);
        Task<List<UserDto>> SearchByEmail (string email);
        Task<List<UserDto>> SearchByName(string name);

    }
}
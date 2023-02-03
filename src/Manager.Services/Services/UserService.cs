using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infra.Inteface;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Core.Exceptions;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _map;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper map, IUserRepository userRepository)
        {
            _map = map;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var allUsers = await _userRepository.GetAll();

            return _map.Map<List<UserDto>>(allUsers);
        }
        
        public async Task<UserDto> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _map.Map<UserDto>(user);
        }
        
        public async Task<UserDto> GetByEmail(string email)
        {
            var userEmail = await _userRepository.GetByEmail(email);
            
            if(userEmail == null)
                throw new DomainException("Não existe nenhum usuário com este e-mail cadastrado");

            return _map.Map<UserDto>(userEmail);
        }

        public async Task<List<UserDto>> SearchByEmail(string email)
        {
            var userEmail = await _userRepository.SearchByEmail(email);

            return _map.Map<List<UserDto>>(userEmail);
        }

        public async Task<List<UserDto>> SearchByName(string name)
        {
            var userName = await _userRepository.SearchByName(name);

            return _map.Map<List<UserDto>>(userName);
        }
        
        public async Task<UserDto> Create(UserDto userDto)
        {
            var userExists = await _userRepository.GetByEmail(userDto.Email);

            if(userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o e-mail informado.");

            var user = _map.Map<User>(userDto);
            user.Validate();

            var userCreate = await _userRepository.Create(user);

            return _map.Map<UserDto>(userCreate);
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            var userExists = await _userRepository.Get(userDto.Id);

            if(userExists == null)
                throw new DomainException("Não existe nenhum usuário com o Id informado.");

            var user = _map.Map<User>(userDto);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _map.Map<UserDto>(userUpdated);
        }

        public async Task Delete(long id)
        {
            await _userRepository.Delete(id);
        }
    }
}
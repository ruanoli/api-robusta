
namespace Manager.Services.DTO
{
    public class UserDto
    {
        public long Id {get; set;}
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }  

        public UserDto()
        {
            
        }

        public UserDto(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
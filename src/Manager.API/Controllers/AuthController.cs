using Manager.API.Token;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login (LoginViewModel loginViewModel)
        {
            try
            {
                var login = _configuration["Jwt:Login"];
                var password = _configuration["Jwt:Password"];

                if(loginViewModel.Login == login && loginViewModel.Password == password)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado",
                        Sucess = true,
                        Data = new 
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }          
        }
    }
}
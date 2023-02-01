using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _map;
        private readonly IUserService _userService;

        public UserController(IMapper map, IUserService userService)
        {
            _map = map;
            _userService = userService;
        }

        [HttpPost]
        [Route("api/v1/create")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserViewModel createUserViewModel)
        {
            try
            {
                var userDTO = _map.Map<UserDto>(createUserViewModel);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message= "User criado.",
                    Sucess = true,
                    Data = userCreated
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}

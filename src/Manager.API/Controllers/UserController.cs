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
    [Route("[controller]/api/v1")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _map;
        private readonly IUserService _userService;

        public UserController(IMapper map, IUserService userService)
        {
            _map = map;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var user = await _userService.GetAll();

                if(user == null) 
                {
                    return Ok(new ResultViewModel()
                    {
                        Message = "Não há users cadastrados.",
                        Sucess = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel()
                {
                    Message = "Todos users",
                    Sucess = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var user = await _userService.Get(id);
                
                if(user == null)
                {
                    return Ok(new ResultViewModel()
                    {
                        Message = "User não encontrado!",
                        Sucess = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel()
                {
                    Message = "User encontrado",
                    Sucess = true,
                    Data = user
                });        
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var userEmail = await _userService.GetByEmail(email);

                if (userEmail == null)
                {
                    return Ok(new ResultViewModel()
                    {
                        Message = "Email não encontrado!",
                        Sucess = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel()
                {
                    Message = "Email encontrado",
                    Sucess = true,
                    Data = userEmail
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet("search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var userAll = await _userService.SearchByName(name);

                if(userAll.Count == 0)
                {
                    return Ok(new ResultViewModel()
                    {
                        Message = "Nome não encontrado",
                        Sucess = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel()
                {
                    Message = "Nome encontrado",
                    Sucess = true,
                    Data = userAll
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet("search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var userAll = await _userService.SearchByName(email);

                if (userAll.Count == 0)
                {
                    return Ok(new ResultViewModel()
                    {
                        Message = "Email não encontrado",
                        Sucess = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel()
                {
                    Message = "Email encontrado",
                    Sucess = true,
                    Data = userAll
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost("create")]
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

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var userDTO = _map.Map<UserDto>(updateUserViewModel);
                var userUpdate = await _userService.Update(userDTO);

                return Ok(new ResultViewModel()
                {
                    Message = "User atualizado",
                    Sucess = true,
                    Data = userUpdate
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                await _userService.Delete(id);

                return Ok(new ResultViewModel()
                {
                    Message = "User excluído.",
                    Sucess = true,
                    Data = null
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}

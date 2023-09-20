using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using update.Input;

namespace update.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;

        public UserController(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }


        // GET: api/User
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginInput userInput)
        {
            try
            {
                var user = _mapper.Map<UserLoginInput, User>(userInput);

                var jwt = await _userDomain.Login(user);

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }


        // POST: api/User
        ///[Filter.Authorize("admin")]
        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup([FromBody] UserInput userInput)
        {
            
            var user = _mapper.Map<UserInput, User>(userInput);
            var id = await _userDomain.Signup(user);
            
            if (id > 0)
                return Ok(id.ToString());
            else
                return BadRequest();
        }
        
    }
}

using CC.DbModels;
using CC.Helpers;
using CC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]User e)
        {
            try
            {
                if (_userRepository.CheckUniqueEmail(e.email))
                {
                    _userRepository.Add(e);
                    return Ok();
                }
                else
                {
                    return BadRequest("email already in use");
                }

            }
            catch
            {
                return StatusCode(418);
            }
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginInfo loginInfo)
        {
            var user = _userRepository.Login(loginInfo.email, loginInfo.password);

            if (user == null)
                return Unauthorized("bad credentials");
            else
            {
                return Ok(user);
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] User u)
        {
            try { 
                _userRepository.Update(u);
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }

            
        }


    }
}

using CC.DbModels;
using CC.Queries;
using CC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly UserDataService _userDataService;

        public UserDataController(UserDataService userDataService)
        {
            this._userDataService = userDataService;
        }


        [HttpGet("goalsVariables")]
        public IActionResult GetVariables()
        {
            return Ok(this._userDataService.GetVariables());
        }


        [HttpPost]
        public IActionResult SaveGoals(UserData userData)
        {
            this._userDataService.SetUserData(userData);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUserData([FromQuery]UserDataQuery userDataQuery)
        {
            return Ok(this._userDataService.GetUserData(userDataQuery));
        }

        [HttpGet('statistics')]
        public IActionResult GetStatistics([FromQuery] UserDataQuery userDataQuery)
        {
            return Ok(this._userDataService.GetStatistics(userDataQuery)); //TO DO STATISTICS
        }

    }
}

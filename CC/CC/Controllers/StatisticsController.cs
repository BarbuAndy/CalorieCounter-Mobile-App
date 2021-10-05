using CC.DbModels;
using CC.Helpers;
using CC.Queries;
using CC.Repository;
using CC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsController(StatisticsService statisticsService)
        {
            this._statisticsService = statisticsService;
        }


        [HttpGet]
        public IActionResult Get([FromQuery]StatisticsQuery query)
        {
            try {
                return Ok(this._statisticsService.GetStatistics(query));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

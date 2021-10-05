using CC.DbModels;
using CC.Helpers;
using CC.Queries;
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
    public class FoodItemConsumedController : ControllerBase
    {
        private readonly FoodItemConsumedRepository _foodItemConsumedRepository;

        public FoodItemConsumedController(FoodItemConsumedRepository foodItemConsumedRepository)
        {
            this._foodItemConsumedRepository = foodItemConsumedRepository;
        }

        [HttpPost]
        [Authorize(Role="user,admin")]
        public IActionResult UserEatsItem([FromBody] FoodItemConsumed foodItemConsumed)
        {
            try { 
                this._foodItemConsumedRepository.Add(foodItemConsumed);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Authorize(Role = "user,admin")]
        public IActionResult GetItemsEaten([FromQuery] FoodItemConsumedQuery foodItemConsumedQuery) {
            try {
                return Ok(this._foodItemConsumedRepository.Get(foodItemConsumedQuery));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Role = "user,admin")]
        public IActionResult UpdateItemEaten([FromBody] FoodItemConsumed foodItemConsumed)
        {
            try
            {
                this._foodItemConsumedRepository.Update(foodItemConsumed);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize(Role = "user,admin")]
        public IActionResult DeleteItemEaten([FromQuery] int foodItemConsumedId)
        {
            try
            {
                this._foodItemConsumedRepository.Delete(new FoodItemConsumed { foodItemConsumedId = foodItemConsumedId });
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}

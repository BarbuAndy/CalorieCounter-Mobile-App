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
    public class FoodItemController : ControllerBase
    {
        private readonly FoodItemService _foodItemService;

        public FoodItemController(FoodItemService foodItemService)
        {
            this._foodItemService = foodItemService;
        }


        [HttpGet]
        [Authorize(Role = "user,admin")]
        public IActionResult Get([FromQuery]FoodItemQuery query)
        {
            try {
                return Ok(this._foodItemService.Get(query));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("/api/FoodItem/suggest")]
        [Authorize(Role = "user,admin")]
        public IActionResult AddFoodItemSuggestion([FromBody] FoodItem foodItem)
        {
            try
            {
                this._foodItemService.AddFoodItemSuggestion(foodItem);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Authorize(Role = "admin")]
        public IActionResult AddFoodItem([FromBody] FoodItem foodItem)
        {
            try
            {
                this._foodItemService.AddFoodItem(foodItem);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Authorize(Role = "admin")]
        public IActionResult Update([FromBody] FoodItem foodItem)
        {
            try
            {
                this._foodItemService.Update(foodItem);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize(Role = "admin")]
        public IActionResult Delete([FromQuery] int foodItemId)
        {
            try
            {
                this._foodItemService.Delete(new FoodItem { foodItemId = foodItemId});
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

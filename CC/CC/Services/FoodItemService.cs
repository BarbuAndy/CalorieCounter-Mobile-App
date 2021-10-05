using CC.DbModels;
using CC.Queries;
using CC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Services
{
    public class FoodItemService
    {
        private readonly FoodItemRepository _foodItemRepository;

        public FoodItemService(FoodItemRepository foodItemRepository)
        {
            this._foodItemRepository = foodItemRepository;
        }

        public IEnumerable<FoodItem> Get(FoodItemQuery query)
        {
            return this._foodItemRepository.Get(query);
        }

        public void AddFoodItemSuggestion(FoodItem foodItem)
        {
            foodItem.published = false;
            foodItem.timesFlaggedWrong = 0;
            this._foodItemRepository.Add(foodItem);
        }

        public void Update(FoodItem foodItem)
        {
            foodItem.timesFlaggedWrong = 0;
            this._foodItemRepository.Update(foodItem);
        }

        public void Delete(FoodItem foodItem)
        {
            this._foodItemRepository.Delete(foodItem);
        }

        internal void AddFoodItem(FoodItem foodItem)
        {
            foodItem.published = true;
            foodItem.timesFlaggedWrong = 0;
            this._foodItemRepository.Add(foodItem);
        }
    }
}

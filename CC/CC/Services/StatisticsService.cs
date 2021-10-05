using CC.Models;
using CC.Queries;
using CC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Services
{
    public class StatisticsService
    {

        private readonly FoodItemConsumedRepository _foodItemConsumedRepository;

        public StatisticsService(FoodItemConsumedRepository _foodItemConsumedRepository)
        {
            this._foodItemConsumedRepository = _foodItemConsumedRepository;
        }

        public List<Statistics> GetStatistics(StatisticsQuery query)
        {
            var itemsEaten =  this._foodItemConsumedRepository.Get(new FoodItemConsumedQuery
            {
                includeFood = true,
                userId = query.userId,
                dateTimeMin = query.dateMin.Date,
                dateTimeMax = query.dateMax.AddDays(1).Date
            });
            List<Statistics> statisticsPeriod = new List<Statistics>();
            for (int day = 0; day <= (int)Math.Round((query.dateMax.Date - query.dateMin.Date).TotalDays); day++)
            {
                Statistics statistics = new Statistics();
                statistics.date = query.dateMin.AddDays(day).Date;
                statistics.userId = query.userId;

                itemsEaten.ToList().ForEach(i =>
                {
                    if (i.dateTime.Date == query.dateMin.AddDays(day).Date)
                    {
                        if (statistics.ContainsMeal(i.meal))
                        {
                            var meal = statistics.meals.Where(m => m.name == i.meal).FirstOrDefault();
                            meal.AddFoodItem(i);
                        }
                        else
                        {
                            var meal = new Meal();
                            meal.name = i.meal;
                            meal.AddFoodItem(i);
                            statistics.meals.Add(meal);
                        }
                    }
                });

                statistics.ComputeTotals();
                statisticsPeriod.Add(statistics);
            }
            return statisticsPeriod;

        }
    }
}

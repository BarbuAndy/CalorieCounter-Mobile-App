using CC.DbModels;
using CC.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CC.Repository
{
    public class FoodItemConsumedRepository : IBaseRepository<FoodItemConsumed, FoodItemConsumedQuery>
    {
        private readonly CCDbContext _dbContext;
        public FoodItemConsumedRepository(CCDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(FoodItemConsumed e)
        {
            _dbContext.Add(e);
            _dbContext.SaveChanges();
        }

        public void Delete(FoodItemConsumed e)
        {
            _dbContext.Remove(e);
            _dbContext.SaveChanges();
        }

        public IEnumerable<FoodItemConsumed> Get(FoodItemConsumedQuery req)
        {
            IQueryable<FoodItemConsumed> query = this._dbContext.FoodItemConsumed.AsQueryable();

            if (req.includeFood)
            {
                query = query.Include(e => e.foodItem);
            }
            if (req.includeUser)
            {
                query = query.Include(e => e.user);
            }
            if (req.foodItemConsumedId != 0)
            {
                query = query.Where(e => e.foodItemConsumedId == req.foodItemConsumedId);
            }
            if(req.foodId != 0)
            {
                query = query.Where(e => e.foodItemId == req.foodId);
            }
            if(req.userId != 0)
            {
                query = query.Where(e => e.userId == req.userId);
            }
            if (!string.IsNullOrEmpty(req.meal))
            {
                query = query.Where(e => e.meal.Contains(req.meal));
            }
            if (req.dateTimeMin != DateTime.MinValue)
            {
                query = query.Where(e => e.dateTime >= req.dateTimeMin);
            }
            if (req.dateTimeMax != DateTime.MinValue)
            {
                query = query.Where(e => e.dateTime <= req.dateTimeMax);
            }
            return query.AsEnumerable();
        }

        public void Update(FoodItemConsumed e)
        {
            _dbContext.Update(e);
            _dbContext.SaveChanges();
        }
    }
}

using CC.DbModels;
using CC.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Repository
{
    public class FoodItemRepository : IBaseRepository<FoodItem, FoodItemQuery>
    {
        private readonly CCDbContext _dbContext;
        public FoodItemRepository(CCDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(FoodItem e)
        {
            this._dbContext.Add(e);
            this._dbContext.SaveChanges();
        }

        public void Delete(FoodItem e)
        {
            this._dbContext.Remove(e);
            this._dbContext.SaveChanges();
        }

        public IEnumerable<FoodItem> Get(FoodItemQuery req)
        {
            IQueryable<FoodItem> query = this._dbContext.FoodItem.AsQueryable();

            switch (req.published)
            {
                case true:
                    query = query.Where(e => e.published == true);
                    break;
                case false:
                    query = query.Where(e => e.published == false);
                    break;
                default:
                    break;
            }

            if(req.foodItemId != 0)
            {
                query = query.Where(e => e.foodItemId == req.foodItemId);
            }
            if (!string.IsNullOrEmpty(req.name))
            {
                if (req.name == "*") { //get random elements, used for testing, to be deleted
                    query = query.OrderBy(e => Guid.NewGuid());
                }
                else
                {
                    query = query.Where(e => e.name.Contains(req.name));
                }
            }
            if(req.proteinMin != 0)
            {
                query = query.Where(e => e.protein >= req.proteinMin);
            }
            if (req.proteinMax != 0)
            {
                query = query.Where(e => e.protein <= req.proteinMax);
            }
            if (req.carbohydratesMin != 0)
            {
                query = query.Where(e => e.carbohydrates >= req.carbohydratesMin);
            }
            if (req.carbohydratesMax != 0)
            {
                query = query.Where(e => e.carbohydrates <= req.carbohydratesMax);
            }
            if (req.fatsMin != 0)
            {
                query = query.Where(e => e.fats >= req.fatsMin);
            }
            if (req.fatsMax != 0)
            {
                query = query.Where(e => e.fats <= req.fatsMax);
            }
            if (req.timesFlaggedWrongMin != 0)
            {
                query = query.Where(e => e.timesFlaggedWrong >= req.timesFlaggedWrongMin);
            }
            if (req.timesFlaggedWrongMax != 0)
            {
                query = query.Where(e => e.timesFlaggedWrong <= req.timesFlaggedWrongMax);
            }
            if(req.numberOfResults != 0)
            {
                query = query.Take(req.numberOfResults);
            }

            return query.AsEnumerable();
        }

        public void Update(FoodItem e)
        {
            this._dbContext.Update(e);
            this._dbContext.SaveChanges();
        }
    }
}

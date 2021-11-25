using CC.DbModels;
using CC.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Repository
{
    public class UserDataRepository : IBaseRepository<UserData, UserDataQuery>
    {
        private readonly CCDbContext _dbContext;

        public UserDataRepository(CCDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(UserData e)
        {
            this._dbContext.UserData.Add(e);
            this._dbContext.SaveChanges();
        }

        public void Delete(UserData e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserData> Get(UserDataQuery req)
        {
            IQueryable<UserData> query = this._dbContext.UserData.AsQueryable();
            if (req.userId != 0)
            {
                query = query.Where(x => x.userId == req.userId);
            }
            if(req.dateTime != new DateTime())
            {
                //not implemented 
            }

            query = query.OrderByDescending(x => x.dateSet);
            query = query
                .Include(x => x.activityLevel)
                .Include(x => x.goal)
                .Include(x => x.prefferedDiet);

            return query.ToList();

        }

        public void Update(UserData e)
        {
            throw new NotImplementedException();
        }

        public List<ActivityLevel> GetActivityLevels()
        {
            return this._dbContext.ActivityLevel.ToList();
        }

        public List<PrefferedDiet> GetPrefferedDiets()
        {
            return this._dbContext.PrefferedDiet.ToList();
        }

        public List<Goal> GetGoals()
        {
            return this._dbContext.Goal.ToList();
        }
    }
}

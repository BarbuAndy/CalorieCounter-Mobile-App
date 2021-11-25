using CC.DbModels;
using CC.Models;
using CC.Queries;
using CC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Services
{
    public class UserDataService
    {
        private readonly UserDataRepository _userDataRepository;

        public UserDataService(UserDataRepository userDataRepository)
        {
            this._userDataRepository = userDataRepository;
        }

        public GoalVariables GetVariables()
        {
            GoalVariables goalVariables = new GoalVariables
            {
                activityLevels = this._userDataRepository.GetActivityLevels(),
                goals = this._userDataRepository.GetGoals(),
                prefferedDiets = this._userDataRepository.GetPrefferedDiets()
            };
            return goalVariables;
        }

        public void SetUserData(UserData userData)
        {
            userData.dateSet = DateTime.Now;
            userData.activityLevelId = userData.activityLevel.activityLevelId;
            userData.goalId = userData.goal.goalId;
            userData.prefferedDietId = userData.prefferedDiet.prefferedDietId;
            userData.goal = null;
            userData.prefferedDiet = null;
            userData.activityLevel = null;
            this._userDataRepository.Add(userData);
        }

        public UserData GetUserData(UserDataQuery userDataQuery)
        {
            return this._userDataRepository.Get(userDataQuery).FirstOrDefault();
        }
    }
}

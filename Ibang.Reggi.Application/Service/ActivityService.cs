using Ibang.Reggi.Application.Contract.Dto;
using Ibang.Reggi.Application.Contract.IService;
using Ibang.Reggi.Application.Mappers;
using Ibang.Reggi.Domain.IRepositories;
using Ibang.Reggi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ibang.Reggi.Application.Service
{
    public class ActivityService : IActivityService
    {
        #region Internals
        private readonly IActivityRepository _activityRepository;
        #endregion

        #region Constructor
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        #endregion

        #region Methods
        public async Task<ActivityDtoResponse> CreateActivity(ActivityDto activity)
        {
            Activity newActivity = await _activityRepository.CreateActivityAsync(new Activity() { Description = activity.Description, UserId = activity.UserId });
            return newActivity.MapToDtoResponse();
        }

        public async Task<ActivityHourDtoResponse> CreateActivityHour(ActivityHourDto activityHour)
        {
            ActivityHours newActivityHour = await _activityRepository.CreateActivityHoursAsync(new ActivityHours() 
            { 
                DateHour = activityHour.DateHour,
                Hour = activityHour.Hour,
                IdActivity = activityHour.IdActivity
            });

            return newActivityHour.MapToDtoResponse();
        }

        public async Task<List<ActivityDtoResponse>> GetActivitiesByUser(string userId) 
        {
            List<Activity> activities = await _activityRepository.ReadActivityAsync(userId);

            return activities.MapToList();
        } 
        #endregion
    }
}

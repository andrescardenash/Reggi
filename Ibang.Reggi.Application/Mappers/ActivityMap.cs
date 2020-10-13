using Ibang.Reggi.Application.Contract.Dto;
using Ibang.Reggi.Domain.Models;
using System.Collections.Generic;

namespace Ibang.Reggi.Application.Mappers
{
    public static class ActivityMap
    {
        #region Extensions
        public static List<ActivityDtoResponse> MapToList(this List<Activity> activityCollection)
        {
            List<ActivityDtoResponse> activities = new List<ActivityDtoResponse>();

            foreach (var activity in activityCollection)
            {
                activities.Add(new ActivityDtoResponse()
                {
                    ActivityHours = SetActivityHours(activity),
                    Description = activity.Description,
                    IdActivity = activity.IdActivity
                });
            }

            return activities;
        }

        public static ActivityDtoResponse MapToDtoResponse(this Activity activity)
        {
            ActivityDtoResponse response = new ActivityDtoResponse();

            if (activity != null)
            {
                response.Description = activity.Description;
                response.IdActivity = activity.IdActivity;
                response.ActivityHours = SetActivityHours(activity);
            }

            return response;
        }

        public static ActivityHourDtoResponse MapToDtoResponse(this ActivityHours activityHour)
        {
            ActivityHourDtoResponse response = new ActivityHourDtoResponse();

            if (activityHour != null)
            {
                response.DateHour = activityHour.DateHour;
                response.Hour = activityHour.Hour;
                response.IdActivityHour = activityHour.IdActivityHour;
            }

            return response;
        }
        #endregion

        #region Private Methods
        private static List<ActivityHourDtoResponse> SetActivityHours(Activity activity)
        {
            List<ActivityHourDtoResponse> activityHoursCollection = new List<ActivityHourDtoResponse>();

            if (activity.ActivityHours != null)
            {
                foreach (var activityHours in activity.ActivityHours)
                {
                    activityHoursCollection.Add(new ActivityHourDtoResponse()
                    {
                        DateHour = activityHours.DateHour,
                        Hour = activityHours.Hour,
                        IdActivityHour = activityHours.IdActivityHour
                    });
                } 
            }

            return activityHoursCollection;
        }
        #endregion
    }
}

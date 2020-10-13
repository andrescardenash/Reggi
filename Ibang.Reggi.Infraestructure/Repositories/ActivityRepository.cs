using Ibang.Reggi.Domain.IRepositories;
using Ibang.Reggi.Domain.Models;
using Ibang.Reggi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibang.Reggi.Infraestructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        #region Internals
        private ReggiContext _reggiContext;
        #endregion

        #region Constructor
        public ActivityRepository(ReggiContext reggiContext)
        {
            _reggiContext = reggiContext;
        }
        #endregion

        #region Methods
        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            await _reggiContext.Activity.AddAsync(activity);
            await _reggiContext.SaveChangesAsync();

            return activity;
        }

        public async Task<List<Activity>> ReadActivityAsync(string userId)
        {
            List<Activity> activities = await _reggiContext.Activity.Where(w => w.UserId == userId).Include("ActivityHours").AsNoTracking().ToListAsync();
            return activities;
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            _reggiContext.Entry(activity).State = EntityState.Modified;
            _reggiContext.Update(activity);
            await _reggiContext.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(Activity activity)
        {
            _reggiContext.Activity.Remove(activity);
            await _reggiContext.SaveChangesAsync();
        }

        public async Task<ActivityHours> CreateActivityHoursAsync(ActivityHours activityHours)
        {
            await _reggiContext.ActivityHours.AddAsync(activityHours);
            await _reggiContext.SaveChangesAsync();

            return activityHours;
        }

        #endregion
    }
}

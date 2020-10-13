using Ibang.Reggi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ibang.Reggi.Domain.IRepositories
{
    public interface IActivityRepository
    {
        Task<Activity> CreateActivityAsync(Activity activity);

        Task<List<Activity>> ReadActivityAsync(string userId);

        Task UpdateActivityAsync(Activity activity);

        Task DeleteActivityAsync(Activity activity);

        Task<ActivityHours> CreateActivityHoursAsync(ActivityHours activityHours);
    }
}

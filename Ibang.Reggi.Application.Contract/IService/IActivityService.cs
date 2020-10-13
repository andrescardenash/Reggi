using Ibang.Reggi.Application.Contract.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ibang.Reggi.Application.Contract.IService
{
    /// <summary>
    /// Servicio de actividades con Reggi.
    /// </summary>
    public interface IActivityService
    {
        /// <summary>
        /// Crea una nueva actividad en el sistema Reggi.
        /// </summary>
        /// <param name="activity">Parametros para la generación de una nueva activida-</param>
        /// <returns></returns>
        Task<ActivityDtoResponse> CreateActivity(ActivityDto activity);

        /// <summary>
        /// Crea una cantidad de horas asignadas a una actividad por fecha.
        /// </summary>
        /// <param name="activityHour">Parametros para la generación de fechas y horas por actividad.</param>
        /// <returns></returns>
        Task<ActivityHourDtoResponse> CreateActivityHour(ActivityHourDto activityHour);

        /// <summary>
        /// Obtiene todas las actividades creacdas en el sistema Reggi para un usuario especifico.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns></returns>
        Task<List<ActivityDtoResponse>> GetActivitiesByUser(string userId);
    }
}

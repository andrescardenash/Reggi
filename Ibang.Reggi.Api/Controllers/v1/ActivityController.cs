using Ibang.Reggi.Application.Contract.Dto;
using Ibang.Reggi.Application.Contract.IService;
using Ibang.Reggi.Common.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ibang.Reggi.Api.Controllers.v1
{
    /// <summary>
    /// Actividades Reggi
    /// </summary>
    [Route("v1/[controller]/[action]")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Guest)]
    public class ActivityController : ControllerBase
    {
        #region Internals
        /// <summary>
        /// Servicio de administración y gestión de actividades.
        /// </summary>
        private readonly IActivityService _activityService;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ActivityController"/>
        /// </summary>
        /// <param name="activityService">Servicio de administración y gestión de actividades.</param>
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        #endregion

        #region Api's
        /// <summary>
        /// Crea una nueva actividad asociada a un usuario.
        /// </summary>
        /// <param name="activity">Parametros para la creación de una actividad.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ActivityDtoResponse>> Create(ActivityDto activity)
        {
            ActivityDtoResponse response = await _activityService.CreateActivity(activity);
            return response;
        }

        /// <summary>
        /// Crea una cantidad de horas asignadas a una actividad por fecha.
        /// </summary>
        /// <param name="activityHour">Parametros para la generación de fechas y horas por actividad.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ActivityHourDtoResponse>> CreateDateHour(ActivityHourDto activityHour)
        {
            ActivityHourDtoResponse response = await _activityService.CreateActivityHour(activityHour);
            return response;
        }

        /// <summary>
        /// Obtiene todas las actividades asignadas a un usuario.
        /// </summary>
        /// <param name="userId">Identificador unico del usuario.</param>
        /// <returns></returns>
        [HttpGet]
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ActivityDtoResponse>>> GetByUser(string userId)
            => await _activityService.GetActivitiesByUser(userId);
        #endregion
    }
}
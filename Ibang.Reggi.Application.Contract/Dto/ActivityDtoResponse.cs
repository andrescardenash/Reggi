using System;
using System.Collections.Generic;

namespace Ibang.Reggi.Application.Contract.Dto
{
    /// <summary>
    /// Parametros de respuesta sobre las actividaddes de Reggi para un usuario.
    /// </summary>
    public class ActivityDtoResponse
    {
        /// <summary>
        /// Descripción de la actividad.
        /// </summary>
        /// <example>Programar web api IBang</example>
        public string Description { get; set; }

        /// <summary>
        ///  Identificador unico de la actividad.
        /// </summary>
        /// <example>d06b9364-eb22-46fe-c58b-08d86f2885bc</example>
        public Guid IdActivity { get; set; }

        /// <summary>
        /// Lista de fechas con horas aplicadas a una actividad dentro del sistema Reggi.
        /// </summary>
        public List<ActivityHourDtoResponse> ActivityHours { get; set; }
    }
}

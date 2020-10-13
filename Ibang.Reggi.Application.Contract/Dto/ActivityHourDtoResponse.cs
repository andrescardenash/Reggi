using System;

namespace Ibang.Reggi.Application.Contract.Dto
{
    /// <summary>
    /// Parametros de respuesta para las horas relacionadas a una actividad.
    /// </summary>
    public class ActivityHourDtoResponse
    {
        /// <summary>
        /// Fecha en que se ejecuto la actividad
        /// </summary>
        /// <example>2020-10-12T00:00:00</example>
        public DateTime DateHour { get; set; }

        /// <summary>
        /// Horas aplicadas en la fecha en la cual se ejecuto la actividad - unidad de medida horas.
        /// </summary>
        /// <example>2</example>
        public int Hour { get; set; }

        /// <summary>
        /// Identificador unico de la fehca y horas asignadas a una actividad.
        /// </summary>
        /// <example>d06b9364-eb22-46fe-c58b-08d86f2885bc</example>
        public Guid IdActivityHour { get; set; }
    }
}

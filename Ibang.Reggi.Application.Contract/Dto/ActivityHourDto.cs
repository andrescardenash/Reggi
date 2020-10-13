using Ibang.Reggi.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ibang.Reggi.Application.Contract.Dto
{
    /// <summary>
    /// Parametros para la generación de Horas por actividad.
    /// </summary>
    public class ActivityHourDto
    {
        /// <summary>
        /// Fecha en que se ejecuto la actividad
        /// </summary>
        /// <example>2020-10-12T00:00:00</example>
        [Display(ResourceType = typeof(GlobalResource), Name = "DateHour"),
        Required(ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "RequiredField")]
        public DateTime DateHour { get; set; }

        /// <summary>
        /// Horas aplicadas en la fecha en la cual se ejecuto la actividad - unidad de medida horas.
        /// </summary>
        /// <example>2</example>
        [Display(ResourceType = typeof(GlobalResource), Name = "Hour"),
        Required(ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "RequiredField")]
        public int Hour { get; set; }

        /// <summary>
        ///  Identificador unico de la actividad.
        /// </summary>
        /// <example>d06b9364-eb22-46fe-c58b-08d86f2885bc</example>
        [Display(ResourceType = typeof(GlobalResource), Name = "IdActivity"),
        Required(ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "RequiredField")]
        public Guid IdActivity { get; set; }
    }
}

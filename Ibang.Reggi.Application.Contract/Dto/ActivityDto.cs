using Ibang.Reggi.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Ibang.Reggi.Application.Contract.Dto
{
    /// <summary>
    /// Actvidades
    /// </summary>
    public class ActivityDto
    {
        /// <summary>
        /// Descripción de la actividad
        /// </summary>
        /// <example>Programar web api IBang</example>
        [Display(ResourceType = typeof(GlobalResource), Name = "Description"),
        Required(ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "RequiredField"),
        StringLength(50, ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "StringLenghtField"),
        RegularExpression("^[a-zA-Z0-9_ ]*", ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "OnlyNumbersAndLetters")]
        public string Description { get; set; }
        /// <summary>
        /// Identificador unico del usuario.
        /// </summary>
        /// <example>d06b9364-eb22-46fe-c58b-08d86f2885bc</example>
        [Display(ResourceType = typeof(GlobalResource), Name = "IdUser"),
        Required(ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "RequiredField"),
        StringLength(450, ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "StringLenghtField"),
        RegularExpression("^[a-zA-Z0-9_ -]*", ErrorMessageResourceType = typeof(GlobalResource), ErrorMessageResourceName = "OnlyNumbersAndLetters")]
        public string UserId { get; set; }
    }
}

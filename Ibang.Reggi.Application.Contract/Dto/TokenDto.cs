using System;

namespace Ibang.Reggi.Application.Contract.Dto
{
    /// <summary>
    /// Parametros de autorización con Reggi.
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// Token para el consumo de recursos dentro de Reggi.
        /// </summary>
        /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Imthcm</example>
        public string Token { get; set; }

        /// <summary>
        /// Fecha de expiración del token
        /// </summary>
        /// <example>2021-10-13T04:31:37.2733508Z</example>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Identrificador unico del usuario.
        /// </summary>
        /// <example>5aa4cc08-96c6-4ebb-0e10-08d86f3e9b7d</example>
        public string UserId { get; set; }
    }
}

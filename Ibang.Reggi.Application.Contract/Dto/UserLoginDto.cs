namespace Ibang.Reggi.Application.Contract.Dto
{
    /// <summary>
    /// Parametros login usuario.
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        /// <example>mat.car@ib.co</example>
        public string Email { get; set; }
        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        /// <example>SeFeliz</example>
        public string Password { get; set; }
    }
}

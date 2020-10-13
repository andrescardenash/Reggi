using Ibang.Reggi.Application.Contract.Dto;
using System.Threading.Tasks;

namespace Ibang.Reggi.Application.Contract.IService
{
    /// <summary>
    /// Servicio de login con Reggi.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Crea un usuario en el sistema Reggi.
        /// </summary>
        /// <param name="userLogin">parametros para la generación de un nuevo usuario.</param>
        /// <returns></returns>
        Task<bool> CreateUserLogin(UserLoginDto userLogin);

        /// <summary>
        /// Valida e inicia sesión con un usuario en el sistema Reggi.
        /// </summary>
        /// <param name="userLogin">parametros para el inicio de sesión de un usuario.</param>
        /// <returns></returns>
        Task<TokenDto> ValidatePassword(UserLoginDto userLogin);
    }
}

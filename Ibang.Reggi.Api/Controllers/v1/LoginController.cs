using Ibang.Reggi.Application.Contract.Dto;
using Ibang.Reggi.Application.Contract.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ibang.Reggi.Api.Controllers.v1
{
    /// <summary>
    /// Inicia el login para un usuario dentro de Reggi.
    /// </summary>
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Internals
        /// <summary>
        /// Servicio de login para Reggi.
        /// </summary>
        private readonly ILoginService _loginService;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instacia de la clase <see cref="LoginController"/>
        /// </summary>
        /// <param name="loginService">Servicio de login para Reggi.</param>
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        #endregion

        #region Api's
        /// <summary>
        /// Crea un nuevo usuario dentro del sisitema Reggi.
        /// </summary>
        /// <param name="userLogin">parametros para la creación de un usuario.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> CreateUser([FromBody]UserLoginDto userLogin)
        {
            try
            {
                return await _loginService.CreateUserLogin(userLogin);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Inicializa un login con un token de autenticación autorizado para permitir el consumo de recursos en Reggi.
        /// </summary>
        /// <param name="userLogin">Parametros para la verificación del login.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TokenDto>> LoginUser([FromBody] UserLoginDto userLogin)
        {
            try
            {
                TokenDto login = await _loginService.ValidatePassword(userLogin);

                if (login == null || string.IsNullOrEmpty(login.Token))
                {
                    return Unauthorized();
                }

                return login;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        #endregion
    }
}
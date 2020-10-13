using Ibang.Reggi.Application.Contract.Dto;
using Ibang.Reggi.Application.Contract.IService;
using Ibang.Reggi.Domain.IRepositories;
using Ibang.Reggi.Domain.Models;
using System.Threading.Tasks;

namespace Ibang.Reggi.Application.Service
{
    public class LoginService : ILoginService
    {
        #region Internals
        private readonly IUserRepository _userRepository; 
        #endregion

        #region Constructor
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Methods
        public Task<bool> CreateUserLogin(UserLoginDto userLogin) => _userRepository.CreateUser(userLogin.Email, userLogin.Password);
        
        public async Task<TokenDto> ValidatePassword(UserLoginDto userLogin)
        {
            UserToken token = await _userRepository.ValidateUser(userLogin.Email, userLogin.Password);
            return new TokenDto() { Expiration = token.Expiration, Token = token.Token, UserId = token.UserId };
        }
        #endregion
    }
}

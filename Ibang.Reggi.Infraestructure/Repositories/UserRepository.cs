using Ibang.Reggi.Domain.IRepositories;
using Ibang.Reggi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ibang.Reggi.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Internals
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<bool> CreateUser(string email, string password)
        {
            User user = new User() { UserName = email, Email = email };

            IdentityResult identity = await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "guest"));
            await _userManager.AddToRoleAsync(user, "guest");

            return identity.Succeeded;
        }

        public async Task<UserToken> ValidateUser(string email, string password)
        {
            SignInResult signIn = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            UserToken userToken = new UserToken();

            if (signIn.Succeeded)
            {
                User user = await _userManager.FindByEmailAsync(email);
                IList<string> roles = await _userManager.GetRolesAsync(user);
                userToken = BuildToken(email, roles);
                userToken.UserId = user.Id;
            }

            return userToken;
        }
        #endregion

        #region Private Methods
        private UserToken BuildToken(string email, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            DateTime expiration = DateTime.UtcNow.AddHours(1);
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(claims: claims, expires: expiration, signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
        #endregion
    }
}

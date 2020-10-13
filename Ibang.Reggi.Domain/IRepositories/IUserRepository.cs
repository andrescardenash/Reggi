using Ibang.Reggi.Domain.Models;
using System.Threading.Tasks;

namespace Ibang.Reggi.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(string email, string password);
        Task<UserToken> ValidateUser(string email, string password);
    }
}

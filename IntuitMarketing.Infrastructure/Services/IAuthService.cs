using IntuitMarketing.Domain.BusinessModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<UserViewModel> Authenticate(string username, string password);
    }
}
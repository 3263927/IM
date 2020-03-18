using IntuitMarketing.Domain.DataModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface IUserReader
    {
        Task<Users> GetUserByUsername(string username);
    }
}
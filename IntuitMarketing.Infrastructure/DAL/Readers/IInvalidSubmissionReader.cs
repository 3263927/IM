using IntuitMarketing.Domain.DataModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface IInvalidSubmissionReader
    {
        Task<InvalidSubmissions> GetLastSubmissionByIpAsync(string ip);
    }
}

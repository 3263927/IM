using IntuitMarketing.Domain.BusinessModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Writers
{
    public interface IInvalidSubmissionWriter
    {
        Task<bool> SaveInvalidSubmissionAsync(InvalidSubmission invalidSubmission);
    }
}

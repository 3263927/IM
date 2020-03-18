using IntuitMarketing.Domain.BusinessModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Writers
{
    public interface IConvertedLeadWriter
    {
        Task<bool> SaveNewFlag(PostFlagModel model);
    }
}

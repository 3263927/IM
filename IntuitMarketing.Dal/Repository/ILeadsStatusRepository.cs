using IntuitMarketing.Domain.DataModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Repository
{
    public interface ILeadsStatusRepository
    {
        Task<int> AddLeadStatusAsync(LeadStatusHistory leadStatus);
    }
}

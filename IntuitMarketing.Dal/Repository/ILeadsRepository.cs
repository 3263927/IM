using IntuitMarketing.Domain.DataModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Repository
{
    public interface ILeadsRepository
    {
        Task<int> AddLeadAsync(Leads lead);
    }
}

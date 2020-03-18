using IntuitMarketing.Domain.BusinessModels;
using IntuitMarketing.Domain.DataModels;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Writers
{
    public interface ILeadWriter
    {
        Task<bool> SaveNewLeadAsync(NewLead lead);

        Task<bool> ChangePhoneNumberAsync(Guid id, string phone);

        Task<bool> SaveNewLeadAsync(Leads lead);

        Task<int> SetProjectIdAsync(Guid leadId);
    }
}

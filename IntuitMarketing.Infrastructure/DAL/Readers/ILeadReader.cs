using IntuitMarketing.Domain.DataModels;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface ILeadReader
    {
        Task<bool> IsLeadDublicateAsync(Leads lead);

        Task<Leads> GetLeadByIdAsync(Guid id);
    }
}
using IntuitMarketing.Domain.DataModels;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface ICampaignReader
    {
        Task<Campaigns> GetCampaingByPageIdAsync(Guid pageId);
    }
}

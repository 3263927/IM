using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class LeadReader : ILeadReader
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public LeadReader(intuitContext intuitContext)
        {
            _log = LogManager.GetLogger(typeof(LeadReader));
            _intuitContext = intuitContext;
        }

        public async Task<bool> IsLeadDublicateAsync(Leads lead)
        {
            var campaign = await _intuitContext.Campaings.
                Include(x => x.Pages).
                SingleAsync(x => x.Pages.Any(p => p.Id.Equals(lead.PageId)));

            _log.Info($"campaing - {campaign.Title}");

            var result = await _intuitContext.Leads
                .Include(x => x.Page)
                .ThenInclude(x => x.Campaing)
                .CountAsync(x => x.Email.Equals(lead.Email) && x.PhoneNumber.Equals(lead.PhoneNumber) && x.Page.Campaing.ClientType == campaign.ClientType);

            return result > 1;
        }

        public async Task<Leads> GetLeadByIdAsync(Guid id)
        {
            var lead = await _intuitContext.Leads.SingleAsync(x => x.Id.Equals(id));
            _log.Info($"lead - {JsonConvert.SerializeObject(lead)}");

            return lead;
        }
    }
}

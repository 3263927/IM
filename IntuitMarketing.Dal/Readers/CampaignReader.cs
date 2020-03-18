using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class CampaignReader : ICampaignReader
    {
        private readonly ILog _log;
        private readonly intuitContext _context;

        public CampaignReader(intuitContext context)
        {
            _context = context;
            _log = LogManager.GetLogger(typeof(CampaignReader));
        }

        public async Task<Campaigns> GetCampaingByPageIdAsync(Guid pageId)
        {
            var campaing = await _context.Campaings
                .Include(x => x.Pages)
                .SingleOrDefaultAsync(b => b.Pages.Any(p => p.Id.Equals(pageId)));
            _log.Info($"founded campaing - {campaing?.Id}");
            return campaing;
        }
    }
}

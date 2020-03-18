using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class SendingRulesReader : ISendingRulesReader
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public SendingRulesReader(intuitContext intuitContext)
        {
            _log = LogManager.GetLogger(typeof(SqlExecutor));
            _intuitContext = intuitContext;
        }

        public async Task<IEnumerable<SendingRules>> GetSendingRulesForPage(Guid pageId)
        {
            var campaign = await _intuitContext.Campaings.Include(x => x.Pages)
                .SingleAsync(x => x.Pages.Any(p => p.Id.Equals(pageId)));

            _log.Info($"Company was found - {campaign.Title}");

            var result = await _intuitContext.SendingRules.Where(x => x.CampaingId == campaign.Id).ToListAsync();
            _log.Info($"founded {result.Count} sending rules");

            return result;
        }
    }
}

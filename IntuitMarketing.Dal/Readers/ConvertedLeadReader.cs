using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class ConvertedLeadReader : IConvertedLeadReader
    {
        private readonly ILog _log;
        private readonly intuitContext _context;

        public ConvertedLeadReader(intuitContext context)
        {
            _log = LogManager.GetLogger(typeof(ConvertedLeadReader));
            _context = context;
        }

        public async Task<ConvertedLeads> GetConvertedLeadByIdAsync(Guid id)
        {
            var convertedLead = await _context.ConvertedLeads.SingleOrDefaultAsync(x => x.Id.Equals(id));
            _log.Info($"converted lead {JsonConvert.SerializeObject(convertedLead)}");

            return convertedLead;
        }
    }
}

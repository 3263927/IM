using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class LocationReader : ILocationReader
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public LocationReader(intuitContext intuitContext)
        {
            _intuitContext = intuitContext;
            _log = LogManager.GetLogger(typeof(CampaignReader));
        }

        public async Task<Locations> GetLocationByZipAsync(string zip, Guid pageId)
        {
            var location = await _intuitContext.Locations
            .Include(e => e.ZipLocationMapping)
            .ThenInclude(e => e.Zip)
            .Include(e => e.Campaing)
            .ThenInclude(e => e.Pages)
            .SingleOrDefaultAsync(x => x.ZipLocationMapping.Any(z => z.IsActive && z.Zip.Zip.Equals(zip)) && x.Campaing.Pages.Any(p => p.Id.Equals(pageId)));

            _log.Info($"founded location - {location?.Id}");

            return location;
        }
    }
}

using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class ZipCodeReader : IZipCodeReader
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public ZipCodeReader(intuitContext intuitContext)
        {
            _intuitContext = intuitContext;
            _log = LogManager.GetLogger(typeof(ZipCodeReader));
        }

        public async Task<ZipCodes> GetZipCodeByZipAsync(string zip)
        {
            var zipCodes = await _intuitContext.ZipCodes
                .SingleOrDefaultAsync(b => b.Zip.Equals(zip));
            _log.Info($"founded zip codes - {zipCodes?.Id}");

            return zipCodes;
        }

        public async Task<ZipCodes> GetZipCodeCityByZipAsync(string zip)
        {
            var zipCodes = await _intuitContext.ZipCodes
                .Include(x => x.City)
                .SingleOrDefaultAsync(b => b.Zip.Equals(zip));
            _log.Info($"founded zip codes - {zipCodes?.Id}");

            return zipCodes;
        }

        public async Task<ZipCodes> GetFullZipByZipAsync(string zip)
        {
            var result = await _intuitContext.ZipCodes.Include(x => x.City).ThenInclude(x => x.County)
                .ThenInclude(x => x.State).ThenInclude(x => x.Country).SingleOrDefaultAsync(x => x.Zip.Equals(zip));
            _log.Info($"founded zip codes - {result?.Id}");

            return result;
        }
    }
}

using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class InvalidSubmissionReader : IInvalidSubmissionReader
    {
        private readonly ILog _log;
        private readonly intuitContext _context;

        public InvalidSubmissionReader(intuitContext context)
        {
            _context = context;
            _log = LogManager.GetLogger(typeof(InvalidSubmissionReader));
        }

        public async Task<InvalidSubmissions> GetLastSubmissionByIpAsync(string ip)
        {
            var submissions = await _context.InvalidSubmissions.OrderBy(x => x.Date).LastOrDefaultAsync(x => x.Ip.Equals(ip));
            _log.Info($"founded invalid submissions - {submissions?.Id}");
            return submissions;
        }
    }
}

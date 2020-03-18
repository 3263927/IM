using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class ReportReader : IReportReader
    {
        private readonly ILog _log;
        private readonly intuitContext _context;

        public ReportReader(intuitContext context)
        {
            _log = LogManager.GetLogger(typeof(ReportReader));
            _context = context;
        }

        public async Task<IEnumerable<Reports>> GetReportsForUserAsync(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id.Equals(userId));
            _log.Info($"founded user - {user?.Login}");
            if (user == null) return null;

            //var permissions = JsonConvert.DeserializeObject<dynamic>(user.Permisions);
            //_log.Info($"permissions - {user.Permisions}");

            //List<Guid> reportIds = JsonConvert.DeserializeObject<List<Guid>>(permissions.ViewReports.ToString());
            // TODO: Fix this
            var reports = Enumerable.Empty<Reports>(); // _context.Reports.Where(x => reportIds.Contains(x.Id));
            _log.Info($"founded reports - {reports.Select(x => x.Name)}");

            return reports;
        }

        public async Task<Reports> GetReportByIdAsync(Guid id)
        {
            var result = await _context.Reports.Include(x => x.ReportFilters).Include(x => x.ReportColumns)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

            return result;
        }
    }
}

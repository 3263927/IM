using IntuitMarketing.Domain.BusinessModels;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Writers;
using log4net;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Writers
{
    public class InvalidSubmissionWriter : IInvalidSubmissionWriter
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public InvalidSubmissionWriter(intuitContext intuitContext)
        {
            _log = LogManager.GetLogger(typeof(InvalidSubmissionWriter));
            _intuitContext = intuitContext;
        }

        public async Task<bool> SaveInvalidSubmissionAsync(InvalidSubmission invalidSubmission)
        {
            _log.Info($"Save invalid submissins - {JsonConvert.SerializeObject(invalidSubmission)}");
            var invalidSubmissions = new InvalidSubmissions
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Field = invalidSubmission.Field,
                Value = invalidSubmission.Value,
                Ip = invalidSubmission.Ip,
                PageId = Guid.Parse(invalidSubmission.PageId)
            };

            _intuitContext.InvalidSubmissions.Add(invalidSubmissions);
            var result = await _intuitContext.SaveChangesAsync();
            return result > 0;
        }
    }
}

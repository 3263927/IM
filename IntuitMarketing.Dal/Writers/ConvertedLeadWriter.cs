using IntuitMarketing.Domain.BusinessModels;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Writers;
using log4net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Writers
{
    public class ConvertedLeadWriter : IConvertedLeadWriter
    {
        private readonly ILog _log;
        private readonly intuitContext _context;

        public ConvertedLeadWriter(intuitContext context)
        {
            _log = LogManager.GetLogger(typeof(ConvertedLeadWriter));
            _context = context;
        }

        public async Task<bool> SaveNewFlag(PostFlagModel model)
        {
            //var convertedLeads = await _context.ConvertedLeads.SingleAsync(x => x.Id.Equals(model.UserId));
            //_log.Info($"converted lead - {JsonConvert.SerializeObject(convertedLeads)}");

            //var properties = JsonConvert.DeserializeObject<dynamic>(convertedLeads.Properties);
            //properties.Flag = model.Flag;
            //convertedLeads.Properties = JsonConvert.SerializeObject(properties);
            //var result = await _context.SaveChangesAsync();
            //_log.Info($"result - {result}");

            //return result == 1;
            // TODO: fix
            return await Task.FromResult(true);
        }
    }
}

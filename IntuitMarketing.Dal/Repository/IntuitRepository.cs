using IntuitMarketing.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Repository
{
    public class IntuitRepository : ILeadsRepository, ILeadsStatusRepository
    {
        private readonly string _connectionString;

        public IntuitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddLeadAsync(Leads lead)
        {
            using (var intuitContext = GetContext())
            {
                await intuitContext.Leads.AddAsync(lead);
                return await intuitContext.SaveChangesAsync();
            }
        }

        public async Task<int> AddLeadStatusAsync(LeadStatusHistory leadStatus)
        {
            using (var intuitContext = GetContext())
            {
                await intuitContext.LeadStatusHistory.AddAsync(leadStatus);
                return await intuitContext.SaveChangesAsync();
            }
        }

        private intuitContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<intuitContext>();
            optionsBuilder.UseNpgsql(_connectionString);
            var intuitContext = new intuitContext(optionsBuilder.Options);
            return intuitContext;
        }
    }
}

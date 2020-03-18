using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Readers
{
    public class UserReader : IUserReader
    {
        private readonly ILog _log;
        private readonly intuitContext _context;

        public UserReader(intuitContext context)
        {
            _log = LogManager.GetLogger(typeof(UserReader));
            _context = context;
        }

        public async Task<Users> GetUserByUsername(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Login.Equals(username));
            _log.Info($"username - {user?.Login}");

            return user;
        }
    }
}

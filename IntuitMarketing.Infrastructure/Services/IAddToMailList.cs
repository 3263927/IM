using IntuitMarketing.Domain.BusinessModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    public interface IAddToMailList
    {
        Task<bool> AddToMailListAsync(SendBookletModel sendBookletModel);
    }
}

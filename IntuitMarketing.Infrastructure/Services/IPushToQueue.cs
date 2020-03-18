using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    public interface IPushToQueue
    {
        Task<bool> PushNewLeadAsync(object data);
        Task<bool> PushChangePhoneAsync(object data);
        Task<bool> PushSendLeadReportsAsync(object data);
    }
}

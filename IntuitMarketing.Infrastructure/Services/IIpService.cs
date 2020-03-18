using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    public interface IIpService
    {
        Task<string> GetCityByIpAsync(string ip);
    }
}

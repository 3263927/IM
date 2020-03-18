using IntuitMarketing.Domain.HelpModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    public interface ISendEmail
    {
        Task<bool> SendAsync(MailOptions options);
    }
}
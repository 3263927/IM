using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.HelpModels;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.Interfaces
{
    public interface IBusinessValidator
    {
        Task<BusinessValidationResult> ValidateAsync(Leads lead);
    }
}

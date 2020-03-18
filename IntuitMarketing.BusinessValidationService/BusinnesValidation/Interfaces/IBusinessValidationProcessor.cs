using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.HelpModels;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.BusinnesValidation.Interfaces
{
    public interface IBusinessValidationProcessor
    {
        Task<BusinessValidationResult> ProcessBusinessValidation(Leads leadMessage);
    }
}

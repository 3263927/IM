using IntuitMarketing.BusinessValidationService.Interfaces;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.Enums;
using IntuitMarketing.Domain.HelpModels;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.Validators
{
    public class DefaultBusinessValidator : IBusinessValidator
    {
        public virtual Task<BusinessValidationResult> ValidateAsync(Leads lead)
        {
            return Task.FromResult(new BusinessValidationResult { IsSuccess = true });
        }

        protected BusinessValidationResult ReturnValidationResult(LeadStatus status)
        {
            return new BusinessValidationResult { IsSuccess = false, Status = status };
        }
    }
}

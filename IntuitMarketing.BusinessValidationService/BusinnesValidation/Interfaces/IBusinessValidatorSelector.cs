using System;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.Interfaces
{
    public interface IBusinessValidatorSelector
    {
        Task<IBusinessValidator> GetBusinessValidator(Guid pageId);
    }
}

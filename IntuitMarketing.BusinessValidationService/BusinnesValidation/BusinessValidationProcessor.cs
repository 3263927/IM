using IntuitMarketing.BusinessValidationService.BusinnesValidation.Interfaces;
using IntuitMarketing.BusinessValidationService.Interfaces;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.HelpModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.BusinnesValidation
{
    class BusinessValidationProcessor : IBusinessValidationProcessor
    {
        private readonly ILog _logger;
        private readonly IBusinessValidatorSelector _validatorSelector;
        private readonly ICampaignReader _campaignReader;

        public BusinessValidationProcessor(IBusinessValidatorSelector validatorSelector, ICampaignReader campaignReader)
        {
            _logger = LogManager.GetLogger(typeof(BusinessValidationProcessor));
            _validatorSelector = validatorSelector;
            _campaignReader = campaignReader;
        }

        public async Task<BusinessValidationResult> ProcessBusinessValidation(Leads lead)
        {
            var businessValidator = await _validatorSelector.GetBusinessValidator(lead.PageId);
            var businessValidationResult = await businessValidator.ValidateAsync(lead);

            return businessValidationResult;
        }
    }
}

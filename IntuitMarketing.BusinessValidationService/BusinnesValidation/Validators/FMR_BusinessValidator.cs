using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.Enums;
using IntuitMarketing.Domain.HelpModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using IntuitMarketing.Infrastructure.DAL.Writers;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.Validators
{
    public class FMR_BusinessValidator : DefaultBusinessValidator
    {
        private readonly ILocationReader _locationReader;
        private readonly ILeadReader _leadReader;

        public FMR_BusinessValidator(ILocationReader locationReader, ILeadReader leadReader)
        {
            _locationReader = locationReader;
            _leadReader = leadReader;
        }

        public override async Task<BusinessValidationResult> ValidateAsync(Leads lead)
        {
            var isDublicate = await _leadReader.IsLeadDublicateAsync(lead);
            if (isDublicate)
            {
                return ReturnValidationResult(LeadStatus.Dublicate);
            }

            var location = await _locationReader.GetLocationByZipAsync(lead.Zip, lead.PageId);

            if (location == null)
            {
                return ReturnValidationResult(LeadStatus.WrongLocation);
            }

            if (location.Campaing.ClientType != ClientId.FMR)
            {
                return ReturnValidationResult(LeadStatus.WrongLocation);
            }

            return new BusinessValidationResult
            {
                IsSuccess = true
            };
        }
    }
}

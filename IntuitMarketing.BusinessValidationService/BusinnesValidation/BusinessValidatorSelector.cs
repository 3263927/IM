using IntuitMarketing.BusinessValidationService.Interfaces;
using IntuitMarketing.BusinessValidationService.Validators;
using IntuitMarketing.Domain.Enums;
using IntuitMarketing.Infrastructure.DAL.Readers;
using IntuitMarketing.Infrastructure.DAL.Writers;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService.BusinnesValidation
{
    public class BusinessValidatorSelector : IBusinessValidatorSelector
    {
        private readonly ICampaignReader _campaignReader;
        private readonly ILocationReader _locationReader;
        private readonly ILeadReader _leadReader;

        public BusinessValidatorSelector(ICampaignReader campaignReader, ILocationReader locationReader, ILeadReader leadReader)
        {
            _campaignReader = campaignReader;
            _locationReader = locationReader;
            _leadReader = leadReader;
        }

        public async Task<IBusinessValidator> GetBusinessValidator(Guid pageId)
        {
            var campaigns = await _campaignReader.GetCampaingByPageIdAsync(pageId);
            ClientId campaign = (ClientId) campaigns.ClientType;
            switch (campaign)
            {
                case ClientId.CHSP:
                {
                    return new CHSP_BusinessValidator(_locationReader, _leadReader);
                }
                case ClientId.MS:
                {
                    return new MS_BusinessValidator(_locationReader, _leadReader);
                }
                case ClientId.GDL:
                {
                    return new GDL_BusinessValidator(_locationReader, _leadReader);
                }
                case ClientId.FMR:
                {
                    return new FMR_BusinessValidator(_locationReader, _leadReader);
                }
                case ClientId.LF:
                {
                    return new LF_BusinessValidator(_locationReader, _leadReader);
                }
                default:
                {
                    return new DefaultBusinessValidator();
                }
            }
        }
    }
}

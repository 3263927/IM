using IntuitMarketing.Base;
using IntuitMarketing.BusinessValidationService.BusinnesValidation.Interfaces;
using IntuitMarketing.Domain.BusinessModels;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.Enums;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService
{
    public class BusinessValidationWorker : BaseWorker
    {
        private readonly IBusinessValidationProcessor _businessValidationProcessor;
        private readonly ICampaignReader _campaignReader;

        public BusinessValidationWorker(IMessagingService messagingService,
            IBusinessValidationProcessor businessValidationProcessor,
            ICampaignReader campaignReader,
            ILog logger)
            : base(messagingService, logger, new CancellationTokenSource())
        {
            _businessValidationProcessor = businessValidationProcessor;
            _campaignReader = campaignReader;
        }

        public override string TopicName => "business-validated-ms-lead-topic";
        public string TopicNameChsp => "business-validated-chsp-lead-topic";
        public string TopicNameStatusHistory => "status-changed-lead-topic";
        public string TopicNameInvalidLead => "invalid-lead-topic";

        public override string SubscriptionName => "business-validate-dbstored-lead-subscription";

        public string TopicSendEmail => "email-topic";

        public override async Task ProcessAsync(string message)
        {
            var lead = JsonConvert.DeserializeObject<Leads>(message);

            var businessValidationResult = await _businessValidationProcessor.ProcessBusinessValidation(lead);
            if (!businessValidationResult.IsSuccess)
            {
                var newStatusTask = UpdateTaskStatusAsync(lead);
                var sendInvalidLeadTask = SendInvalidLeadAsync(lead);
                var sendEmailTask = _messagingService.PushMessageAsync(TopicSendEmail, new[]
                {
                    new
                    {
                        type = SendingTypes.NewLeadEmail,
                        model = new { lead.PageId, lead.Id }
                    }
                });

                await Task.WhenAll(newStatusTask, sendInvalidLeadTask, sendEmailTask);

                return;
            }

            await SendToClientAsync(lead);
        }

        private Task SendInvalidLeadAsync(Leads lead)
        {
            Task sendInvalidLeadTask;
            var invalidSubmission = new InvalidSubmission();
            invalidSubmission.Field = nameof(lead.Id);
            invalidSubmission.Ip = lead.Ip;
            invalidSubmission.PageId = lead.PageId.ToString();
            invalidSubmission.Value = lead.Id.ToString();
            sendInvalidLeadTask = _messagingService.PushMessageAsync(TopicNameInvalidLead, new[] { invalidSubmission });
            return sendInvalidLeadTask;
        }

        private Task UpdateTaskStatusAsync(Leads lead)
        {
            Task newStatusTask;
            var leadStatusModel = new LeadStatusModel();
            leadStatusModel.LeadId = lead.Id;
            leadStatusModel.Date = DateTime.UtcNow;
            leadStatusModel.Status = LeadStatus.FailedBusinessValidation;
            leadStatusModel.ServiceName = StaticSettings.ServiceName;
            newStatusTask = _messagingService.PushMessageAsync(TopicNameStatusHistory, new[] { leadStatusModel });
            return newStatusTask;
        }

        private async Task SendToClientAsync(Leads lead)
        {
            var campaign = await _campaignReader.GetCampaingByPageIdAsync(lead.PageId);
            switch (campaign.ClientType)
            {
                case ClientId.CHSP:
                    {
                        await _messagingService.PushMessageAsync(TopicNameChsp, new[] { lead });
                        break;
                    }
                case ClientId.MS:
                    {
                        await _messagingService.PushMessageAsync(TopicName, new[] { lead });
                        break;
                    }
                default:
                    _logger.Error($"Unknown client type {campaign.ClientType}");
                    break;
            }
        }
    }
}

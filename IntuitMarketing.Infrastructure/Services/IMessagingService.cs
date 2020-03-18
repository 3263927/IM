using Google.Cloud.PubSub.V1;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    [Obsolete]
    public interface IMessagingService
    {
        Task<bool> PushNewLeadMessageAsync(object data);
        Task<bool> PushLeadValidatedMessageAsync(object data);
        Task<bool> PushLeadToBusinessValidationAsync(object data);
        Task<bool> PushLeadNotValidatedMessageAsync(object data);
        Task<bool> PushToMailAsync(object data);
        Task<bool> PushLeadFormattedMessageAsync(object data);
        Task<bool> PushChangePhoneMessageAsync(object data);
        Task<bool> PushSendLeadReportMessageAsync(object data);
        Task<bool> PushToCHSPLeadAsync(object data);
        Task<bool> PushToMSLeadAsync(object data);
        Task<ReceivedMessage> PullLeadAsync(SubscriberServiceApiClient subcscriber, SubscriptionName subscribtionName);
        Task<ReceivedMessage> PullChangePhoneMessageAsync(SubscriberServiceApiClient subcscriber, SubscriptionName subscribtionName);
        Task<ReceivedMessage> PullLeadReportMessageAsync(SubscriberServiceApiClient subcscriber, SubscriptionName subscribtionName);
        void AckMessage(SubscriberServiceApiClient subcscriber, SubscriptionName subscribtionName, string ackId);
    }
}

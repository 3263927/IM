using Google.Cloud.PubSub.V1;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntuitMarketing.Base
{
    public interface IMessagingService
    {
        Task<IEnumerable<string>> PushMessageAsync(string topicNameId, IEnumerable<object> messages);

        Task<IEnumerable<ReceivedMessage>> PullMessageAsync(string subscriptionId, int count = 1);

        Task AckMessageAsync(string subscriptionId, string ackId);
    }
}
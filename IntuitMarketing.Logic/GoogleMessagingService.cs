using Google.Api.Gax.Grpc;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Base
{
    public class GoogleMessagingService : IMessagingService
    {
        private readonly string _projectId;
        private readonly string _host;
        private readonly int _port;

        public GoogleMessagingService(string projectId, string host, int port)
        {
            _projectId = projectId;
            _host = host;
            _port = port;
        }

        public async Task<IEnumerable<string>> PushMessageAsync(string topicId, IEnumerable<object> messages)
        {
            var publisher = await GetPublisherAsync();
            var topicName = new TopicName(_projectId, topicId);

            var result = await publisher.PublishAsync(topicName, messages.Select(message => GetPubSubMessage(message)));

            return result.MessageIds;
        }

        public async Task<IEnumerable<ReceivedMessage>> PullMessageAsync(string subscriptionId, int count = 1)
        {
            var subscriber = await GetSubscriberAsync();
            var subscriptionNme = new SubscriptionName(_projectId, subscriptionId);

            var response = await subscriber.PullAsync(subscriptionNme, true, count);
            return response.ReceivedMessages;
        }

        public async Task AckMessageAsync(string subscriptionId, string ackId)
        {
            var subscriber = await GetSubscriberAsync();
            var subscriptionName = new SubscriptionName(_projectId, subscriptionId);
            await subscriber.AcknowledgeAsync(subscriptionName, new List<string> { ackId });
        }

        private static PubsubMessage GetPubSubMessage(object message)
        {
            return new PubsubMessage
            {
                Data = ByteString.CopyFromUtf8(JsonConvert.SerializeObject(message))
            };
        }

        private async Task<PublisherServiceApiClient> GetPublisherAsync()
        {
            PublisherServiceApiClient publisher;
            if (!string.IsNullOrEmpty(_host) && _port != 0)
            {
                publisher = await PublisherServiceApiClient.CreateAsync(new ServiceEndpoint(_host, _port));
            }
            else
            {
                publisher = await PublisherServiceApiClient.CreateAsync();
            }

            return publisher;
        }

        private async Task<SubscriberServiceApiClient> GetSubscriberAsync()
        {
            SubscriberServiceApiClient subscriber;
            if (!string.IsNullOrEmpty(_host) && _port != 0)
            {
                subscriber = await SubscriberServiceApiClient.CreateAsync(new ServiceEndpoint(_host, _port));
            }
            else
            {
                subscriber = await SubscriberServiceApiClient.CreateAsync();
            }

            return subscriber;
        }
    }
}

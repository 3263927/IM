using Google.Cloud.PubSub.V1;
using log4net;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntuitMarketing.Base
{
    public abstract class BaseWorker : IWorker
    {
        private readonly CancellationTokenSource _cancellationTokenSource;

        protected readonly IMessagingService _messagingService;
        protected readonly ILog _logger;

        public string ProjectId => "intuit-local-test";

        public abstract string TopicName { get; }

        public abstract string SubscriptionName { get; }

        public BaseWorker(IMessagingService messagingService, ILog logger, CancellationTokenSource cancellationTokenSource = null)
        {
            _messagingService = messagingService;
            _logger = logger;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public async Task StartAsync()
        {
            _logger.Info($"{GetType()} has started processing");
            var cancellationToken = _cancellationTokenSource?.Token;
            await StartProcessingMessagesAsync(cancellationToken);
        }

        public void Stop()
        {
            _logger.Info($"{GetType()} has stopped processing");
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        public abstract Task ProcessAsync(string message);

        private async Task StartProcessingMessagesAsync(CancellationToken? cancellationToken)
        {
            while (cancellationToken == null || !cancellationToken.Value.IsCancellationRequested)
            {
                var count = await ProcessNextMessagesAsync();

                if (count == 0)
                {
                    await Task.Delay(50);
                }
            }
        }

        private async Task<int> ProcessNextMessagesAsync()
        {
            var count = 0;

            try
            {
                var messages = await _messagingService.PullMessageAsync(SubscriptionName, 10);
                await Task.WhenAll(messages.Select(message => ProcessSingleMessageAsync(message)));

                count = messages.Count();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e);
            }

            return count;
        }

        private async Task ProcessSingleMessageAsync(ReceivedMessage message)
        {
            try
            {
                await ProcessAsync(message?.Message?.Data?.ToStringUtf8());
                await _messagingService.AckMessageAsync(SubscriptionName, message.AckId);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e);
            }
        }
    }
}

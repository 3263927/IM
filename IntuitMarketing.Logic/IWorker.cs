using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Base
{
    public interface IWorker
    {
        string ProjectId { get; }

        string TopicName { get; }

        string SubscriptionName { get; }

        Task StartAsync();

        void Stop();

        Task ProcessAsync(string message);
    }
}

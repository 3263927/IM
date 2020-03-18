using Autofac;
using IntuitMarketing.Base;
using IntuitMarketing.BusinessValidationService.BusinnesValidation.Interfaces;
using IntuitMarketing.Infrastructure.DAL.Readers;
using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IntuitMarketing.BusinessValidationService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            XmlConfigurator.Configure(LogManager.GetRepository(typeof(Program).Assembly), new FileInfo("log4net.xml"));
            var logger = LogManager.GetLogger(typeof(BusinessValidationWorker));

            try
            {
                var messagingService = new GoogleMessagingService("intuit-local-test", null, 0);
                var bootstrappable = new BusinessValidationBootstrappable();
                var containerBuilder = bootstrappable.Bootstrap();
                var container = containerBuilder.Build();

                IBusinessValidationProcessor businessValidationProcessor;
                ICampaignReader campaignReader;
                using (var scope = container.BeginLifetimeScope())
                {
                    businessValidationProcessor = scope.Resolve<IBusinessValidationProcessor>();
                    campaignReader = scope.Resolve<ICampaignReader>();
                    var worker = new BusinessValidationWorker(messagingService,
                        businessValidationProcessor,
                        campaignReader,
                        logger);

                    await worker.StartAsync();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
            }
        }
    }
}

using Autofac;
using IntuitMarketing.Base;
using IntuitMarketing.BusinessValidationService.BusinnesValidation;
using IntuitMarketing.BusinessValidationService.BusinnesValidation.Interfaces;
using IntuitMarketing.BusinessValidationService.Interfaces;
using IntuitMarketing.Dal.Readers;
using IntuitMarketing.Dal.Writers;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Infrastructure.DAL.Readers;
using IntuitMarketing.Infrastructure.DAL.Writers;
using Microsoft.EntityFrameworkCore;

namespace IntuitMarketing.BusinessValidationService
{
    internal class BusinessValidationBootstrappable : IBootstrappable
    {
        private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();

        public ContainerBuilder Bootstrap()
        {
            _containerBuilder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<intuitContext>();
                opt.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
                return new intuitContext(opt.Options);
            }).As<intuitContext>();

            _containerBuilder.RegisterType<BusinessValidationProcessor>().As<IBusinessValidationProcessor>();
            _containerBuilder.RegisterType<BusinessValidatorSelector>().As<IBusinessValidatorSelector>();

            _containerBuilder.RegisterType<CampaignReader>().As<ICampaignReader>();
            _containerBuilder.RegisterType<LocationReader>().As<ILocationReader>();
            _containerBuilder.RegisterType<LeadReader>().As<ILeadReader>();
            _containerBuilder.RegisterType<LeadWriter>().As<ILeadWriter>();

            return _containerBuilder;
        }
    }
}

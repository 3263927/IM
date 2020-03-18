using Google.Cloud.Datastore.V1;
using IntuitMarketing.Domain.BusinessModels;
using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.HelpModels;
using IntuitMarketing.Infrastructure.DAL.Writers;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Writers
{
    public class LeadWriter : ILeadWriter
    {
        private readonly ILog _log;
        private readonly intuitContext _intuitContext;

        public LeadWriter(intuitContext intuitContext)
        {
            _log = LogManager.GetLogger(typeof(LeadWriter));
            _intuitContext = intuitContext;
        }

        public async Task<bool> SaveNewLeadAsync(NewLead lead)
        {
            //_log.Info($"Save new lead - {JsonConvert.SerializeObject(lead)}");
            //var datastore = DatastoreDb.Create(StaticServerSettings.GCP.ProjectName, StaticServerSettings.GCP.DataStore.Namespace);

            //var entity = new Entity
            //{
            //    Key = datastore.CreateKeyFactory(StaticServerSettings.GCP.DataStore.NewLeadKindName).CreateKey(lead.Id),
            //    ["Date"] = DateTime.UtcNow,
            //    ["PageId"] = lead.PageId,
            //    ["Zip"] = lead.Zip,
            //    ["Email"] = lead.Email,
            //    ["PhoneNumber"] = lead.PhoneNumber,
            //    ["FullName"] = lead.FullName,
            //    ["Sub1"] = lead.Sub1,
            //    ["Sub2"] = lead.Sub2,
            //    ["Sub3"] = lead.Sub3,
            //    ["SourceId"] = lead.SourceId,
            //    ["TransactionId"] = lead.TransactionId,
            //    ["Ip"] = lead.Ip,
            //    ["Data"] = lead.Data,
            //    ["Macros"] = lead.Macros
            //};

            //using (var transction = datastore.BeginTransaction())
            //{
            //    transction.Insert(entity);
            //    await transction.CommitAsync();
            //}

            //_log.Info("New lead saved successfuly");

            return true;
        }

        public Task<bool> ChangePhoneNumberAsync(Guid id, string phone)
        {
            _log.Info($"Save lead id - {id}, phone - {phone}");
            var datastore = DatastoreDb.Create(StaticServerSettings.GCP.ProjectName, StaticServerSettings.GCP.DataStore.Namespace);

            var entity = new Entity
            {
                Key = datastore.CreateKeyFactory(StaticServerSettings.GCP.DataStore.ChangePhoneKindName).CreateKey(Guid.NewGuid().ToString()),
                ["Date"] = DateTime.UtcNow,
                ["LeadId"] = id.ToString(),
                ["PhoneNumber"] = phone
            };

            using (var transction = datastore.BeginTransaction())
            {
                transction.Insert(entity);
                transction.Commit();
            }
            _log.Info("phone saved successfuly");

            return Task.FromResult(true);
        }

        public async Task<bool> SaveNewLeadAsync(Leads lead)
        {
            await _intuitContext.Leads.AddAsync(lead);
            var result = await _intuitContext.SaveChangesAsync();
            _log.Info($"new lead saved to sql with result {result}");
            return result == 1;
        }

        public async Task<int> SetProjectIdAsync(Guid leadId)
        {
            var lead = await _intuitContext.Leads.SingleAsync(x => x.Id.Equals(leadId));
            _log.Info("lead is founded");
            var campaing = await _intuitContext.Campaings.Include(x => x.Pages)
                .SingleAsync(x => x.Pages.Any(p => p.Id.Equals(lead.PageId)));
            _log.Info($"campaign is founded - {campaing.Title} ({campaing.Id})");
            var currentLeadId = (await _intuitContext.Leads.Include(x => x.Page).ThenInclude(x => x.Campaing)
                .Where(x => x.Page.Campaing.Id.Equals(campaing.Id)).OrderBy(x => x.ProjectLeadId).LastAsync()).ProjectLeadId;
            var nextLeadId = ++currentLeadId;
            _log.Info($"new lead id - {nextLeadId}");
            lead.ProjectLeadId = nextLeadId;
            var result = await _intuitContext.SaveChangesAsync();
            _log.Info($"lead saved with result {result}");

            return result == 1 ? nextLeadId : -1;
        }
    }
}

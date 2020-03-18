using IntuitMarketing.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface ISendingRulesReader
    {
        Task<IEnumerable<SendingRules>> GetSendingRulesForPage(Guid pageId);
    }
}
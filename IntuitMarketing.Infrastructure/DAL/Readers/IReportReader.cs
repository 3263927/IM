using IntuitMarketing.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface IReportReader
    {
        Task<IEnumerable<Reports>> GetReportsForUserAsync(Guid userId);
        Task<Reports> GetReportByIdAsync(Guid id);
    }
}
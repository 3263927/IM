using IntuitMarketing.Domain.DataModels;
using System;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface ILocationReader
    {
        Task<Locations> GetLocationByZipAsync(string zip, Guid pageId);
    }
}

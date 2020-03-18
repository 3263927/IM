using IntuitMarketing.Domain.HelpModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Writers
{
    public interface IZipWriter
    {
        Task<bool> ImportZips(IEnumerable<ZipCodeModel> zips);
    }
}
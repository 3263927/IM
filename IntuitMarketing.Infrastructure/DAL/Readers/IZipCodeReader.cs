using IntuitMarketing.Domain.DataModels;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.DAL.Readers
{
    public interface IZipCodeReader
    {
        Task<ZipCodes> GetZipCodeByZipAsync(string zip);
        Task<ZipCodes> GetZipCodeCityByZipAsync(string zip);
        Task<ZipCodes> GetFullZipByZipAsync(string zip);
    }
}

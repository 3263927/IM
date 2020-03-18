using IntuitMarketing.Domain.DataModels;
using IntuitMarketing.Domain.HelpModels;
using IntuitMarketing.Infrastructure.DAL.Writers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntuitMarketing.Dal.Writers
{
    public class ZipWriter : IZipWriter
    {
        private readonly intuitContext _context;

        public ZipWriter(intuitContext context)
        {
            _context = context;
        }

        public async Task<bool> ImportZips(IEnumerable<ZipCodeModel> zips)
        {
            var zipCodes = await _context.ZipCodes.ToListAsync();
            var countries = await _context.Countries.Include(x => x.States).ThenInclude(x => x.Counties)
                .ThenInclude(x => x.City).ThenInclude(x => x.ZipCodes).ToListAsync();
            var countryId = _context.Countries.Max(x => x.Id);
            var stateId = _context.States.Max(x => x.Id);
            var countyId = _context.Counties.Max(x => x.Id);
            var cityId = _context.City.Max(x => x.Id);
            var zipId = _context.ZipCodes.Max(x => x.Id);

            foreach (var zipCodeModel in zips)
            {
                var country = countries.SingleOrDefault(x => x.Name.Equals(zipCodeModel.Country));
                if (country == null)
                {
                    country = new Countries
                    {
                        Id = ++countryId,
                        Name = zipCodeModel.Country
                    };
                    countries.Add(country);
                    _context.Countries.Add(country);
                }

                var state = country.States.SingleOrDefault(x => x.Name.Equals(zipCodeModel.State));
                if (state == null)
                {
                    state = new States
                    {
                        Id = ++stateId,
                        Name = zipCodeModel.State,
                        CountryId = country.Id
                    };
                    country.States.Add(state);
                    _context.States.Add(state);
                }

                var county = state.Counties.SingleOrDefault(x => x.Name.Equals(zipCodeModel.County));
                if (county == null)
                {
                    county = new Counties()
                    {
                        Id = ++countyId,
                        Name = zipCodeModel.County,
                        StateId = state.Id
                    };
                    state.Counties.Add(county);
                    _context.Counties.Add(county);
                }

                var city = county.City.SingleOrDefault(x => x.Name.Equals(zipCodeModel.City));
                if (city == null)
                {
                    city = new City()
                    {
                        Id = ++cityId,
                        Name = zipCodeModel.City,
                        CountyId = county.Id
                    };
                    county.City.Add(city);
                    _context.City.Add(city);
                }

                var zip = zipCodes.SingleOrDefault(x => x.Zip.Equals(zipCodeModel.Zip));
                if (zip == null)
                {
                    zip = new ZipCodes()
                    {
                        Id = ++zipId,
                        Zip = zipCodeModel.Zip,
                        CityId = city.Id
                    };
                    zipCodes.Add(zip);
                    _context.ZipCodes.Add(zip);
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}

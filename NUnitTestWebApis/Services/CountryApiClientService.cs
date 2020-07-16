using NUnitTestWebApis.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTestWebApis.Services
{
    public class CountryApiClientService : HttpClientService<Country>
    {
        public CountryApiClientService(UrlService urlService) : base(urlService) { }
        public override async Task<IEnumerable<Country>> GetAllAsync(string requestUri)
        {
            IEnumerable<Country> countries = await base.GetAllAsync(requestUri);
            return countries.OrderBy(c => c.Name);
        }
    }

}

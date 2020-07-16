using TestClient.Models;
using TestClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestClient
{
    public class SampleRequestClient
    {
        private readonly UrlService _urlService;
        private readonly CountryApiClientService _client;
        public SampleRequestClient(UrlService urlService, CountryApiClientService client)
        {
            _urlService = urlService;
            _client = client;
        }

        public async Task ReadCountriesAsync()
        {
            Console.WriteLine(nameof(ReadCountryAsync));
            IEnumerable<Country> countries = await _client.GetAllAsync(_urlService.CountriesApi);
            foreach (Country country in countries)
            {
                Console.WriteLine(country.Name);
            }
            Console.WriteLine();
        }

        public async Task ReadCountryAsync()
        {
            Console.WriteLine(nameof(ReadCountryAsync));
            var countries = await _client.GetAllAsync(_urlService.CountriesApi);
            var id = countries.First().Id;
            Country country = await _client.GetAsync(_urlService.CountriesApi + id);
            Console.WriteLine($"{country.Id } {country.Name}");
            Console.WriteLine();
        }

        public async Task ReadNotExistingChapterAsync()
        {
            Console.WriteLine(nameof(ReadNotExistingChapterAsync));
            string requestedIdentifier = Guid.NewGuid().ToString();
            try
            {
                Country country = await _client.GetAsync(
                  _urlService.CountriesApi + requestedIdentifier.ToString());
                Console.WriteLine($"{country.Id} {country.Name}");
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("404"))
            {
                Console.WriteLine($"Country with the identifier " +
                  $"{requestedIdentifier} not found");
            }
            Console.WriteLine();
        }
        public async Task AddCountrAsync()
        {
            Console.WriteLine(nameof(AddCountrAsync));
            Country country = new Country
            {
                Id = 52,
                Name = "Mexico",
            };
            country = await _client.PostAsync(_urlService.CountriesApi, country );
            Console.WriteLine($"added chapter {country.Id} with id {country.Name}");
            Console.WriteLine();
        }

        public async Task UpdateChapterAsync()
        {
            Console.WriteLine(nameof(UpdateChapterAsync));
            var countries = await _client.GetAllAsync(_urlService.CountriesApi);
            var country = countries.SingleOrDefault(c => c.Name == "Krakovia");
            if (country != null)
            {
                country.Name = "Republic of Krakovia";
                await _client.PutAsync(_urlService.CountriesApi + country.Id, country);
                Console.WriteLine($"updated chapter {country.Name}");
            }
            Console.WriteLine();
        }

    }
}

using System;
using TestClient.Models;
using TestClient.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Client app, wait for service");
                Console.ReadLine();
                RegisterServices();
                var test = Container.GetRequiredService<SampleRequestClient>();

                await test.ReadCountriesAsync();
                await test.ReadCountryAsync();
                await test.ReadNotExistingChapterAsync();

                await test.AddCountrAsync();
                await test.UpdateChapterAsync();


                //test.ReadCountriesAsync();
                //test.ReadCountryAsync();
                //test.ReadNotExistingChapterAsync();

                //test.AddCountrAsync();
                //test.UpdateChapterAsync();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static IServiceProvider Container { get; private set; }
        public static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<UrlService>();
            services.AddSingleton<CountryApiClientService>();
            services.AddTransient<SampleRequestClient>();

            Container = services.BuildServiceProvider();
        }


    }
}

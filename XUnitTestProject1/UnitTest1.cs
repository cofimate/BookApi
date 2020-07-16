using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private static readonly HttpClient client = new HttpClient();
        [Fact]
        public async Task Test1Async()
        {
            Assert.True(true);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Local service");

 
            var streamTask = client.GetStreamAsync("http://localhost:60082/api/Countries/1");


            //var countries = new List<Country>();

            //var countries = await JsonSerializer.DeserializeAsync<List<Country>>(await streamTask);

            var singleCountry = await JsonSerializer.DeserializeAsync<Country>(await streamTask);

            // testing the first element id":1,"name":"Canada"

   
            Assert.True(singleCountry.id == 1);
    
            Assert.True(singleCountry.Name == "Canada");

        }
    }
}

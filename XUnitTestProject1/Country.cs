using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XUnitTestProject1
{
    public class Country
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

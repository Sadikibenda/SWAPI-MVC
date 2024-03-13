using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwapiMVC.Models
{
    public class PeopleViewModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("height")]
        public string? Height { get; set; }
        
        [JsonPropertyName("mass")]
        public string? Mass { get; set; }
        
        [JsonPropertyName("birth_year")]
        public string? BirthYear { get; set; }
        
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        public string? Id
        {
            get
            {
                return Url?
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .LastOrDefault();
            }
        }
    }
}
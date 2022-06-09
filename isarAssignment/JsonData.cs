using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace isarAssignment
{
    internal class JsonData
    {
        [JsonProperty(PropertyName = "planets")]
        public List<Planet> Planet { get; set; }

        [JsonProperty(PropertyName = "spacecrafts")]
        public List<Spacecrafts> Spacecrafts { get; set; }
    }
}

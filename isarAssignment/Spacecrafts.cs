using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace isarAssignment
{
    internal class Spacecrafts
    {
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "capacity")]
        public int Capacity { get; set; }

        [JsonProperty(PropertyName = "gravityGenerator")]
        public Boolean GravityGenerator { get; set; }

        [JsonProperty(PropertyName = "maxTravelDistance")]
        public double MaxTravelDistance { get; set; }

        [JsonProperty(PropertyName = "asteroidDeflector")]
        public Boolean AsteroidDeflector { get; set; }

        public Spacecrafts (string name, string type, int capacity, bool gravityGenerator, double maxTravelDistance, bool asteroidDeflector)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            GravityGenerator = gravityGenerator;
            MaxTravelDistance = maxTravelDistance;
            AsteroidDeflector = asteroidDeflector;
        }

        public Spacecrafts() { }
    }
}

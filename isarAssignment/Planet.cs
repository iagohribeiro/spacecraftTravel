using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace isarAssignment
{
    internal class Planet
    {
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "positionIndex")]
        public long positionIndex { get; set; }

        [JsonProperty(PropertyName = "habitable")]
        public Boolean habitable { get; set; }

        [JsonProperty(PropertyName = "diameter")]
        public double diameter { get; set; }

        [JsonProperty(PropertyName = "averageTemperature")]
        public double averageTemperature { get; set; }

        [JsonProperty(PropertyName = "distanceFromEarth")]
        public double distanceFromEarth { get; set; }

        [JsonProperty(PropertyName = "isDwarf")]
        public Boolean isDwarf { get; set; }

        public Planet (string name, long positionIndex, bool habitable, double diameter, double averageTemperature, double distanceFromEarth, bool isDwarf)
        {
            Name = name;
            this.positionIndex = positionIndex;
            this.habitable = habitable;
            this.diameter = diameter;
            this.averageTemperature = averageTemperature;
            this.distanceFromEarth = distanceFromEarth;
            this.isDwarf = isDwarf;
        }

        public Planet() {}
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravity.Json
{
    class CoordinatesJson
    {
       
         [JsonProperty(PropertyName = "xAxis")]
        public double XAxis { get; set; }

         [JsonProperty(PropertyName = "yAxis")]
        public double YAxis { get; set; }

         [JsonProperty(PropertyName = "zAxis")]
        public double ZAxis { get; set; }

     public CoordinatesJson(double x, double y, double z)
      {
        this.XAxis = x;
        this.YAxis = y;
        this.ZAxis = z;
      }

    
    }
}

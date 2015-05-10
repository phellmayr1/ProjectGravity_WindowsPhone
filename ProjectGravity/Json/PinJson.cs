using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravity.Json
{
   
  internal class PinJson
  {
   [JsonProperty(PropertyName = "pin")]
      public string Pin { get; set; }
      
  
  }
}

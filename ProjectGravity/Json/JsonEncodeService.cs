using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravity.Json
{
    class JsonEncodeService
    {
        public static String createPinJsonArray(String pin)
        {
            PinJson pinJson = new PinJson();
            pinJson.Pin = pin;
            return JsonConvert.SerializeObject(pinJson);
        }

      public static String createPositionUpdateJsonArray(double x, double y, double z)
      {
        CoordinatesJson coordinates = new CoordinatesJson(x,y,z);
        return JsonConvert.SerializeObject(coordinates);
                  
      }
    }
}

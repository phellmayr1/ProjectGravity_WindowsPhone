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
            //["checkPin",{"pin":"123"}]

          PinJson pinJson = new PinJson();
          pinJson.Pin = pin;
          return JsonConvert.SerializeObject(pinJson);

          //jsonArray = new JSONArray();
          //jsonArray.put(JsonConstants.CHECK_PIN);
          //jsonArray.put(createJsonObject(JsonConstants.pin, pin));
          //return jsonArray;
        }
    }
}

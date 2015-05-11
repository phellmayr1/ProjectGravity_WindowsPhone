using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravity.Json
{
    class JsonConstants
    {

          /*
   The following strings define the events
    */
    public static readonly String POSITION_UPDATE = "positionUpdate";
    public static readonly String EVENT="event";
 public static readonly String START_GAME = @"[""startGame""]";

    /*
    The following field defines the time, when the json should be send to the server in milliseconds
     */
 public static readonly int SEND_NEW_JSON_TIMER = 2;

    /*
    The following strings define the json fields
     */
    public static readonly String CHECKED_PIN ="checkedPin";
    public static readonly String CHECK_PIN ="checkPin";
    public static readonly String pin="pin";

    public static readonly String X_AXIS = "xAxis";
    public static readonly String Y_AXIS = "yAxis";
    public static readonly String Z_AXIS = "zAxis";
    }
}

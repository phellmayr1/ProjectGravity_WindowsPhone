using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravity
{
    static class SocketIO
    {

      private static Socket socket=null;

      public static Socket getSocket()
      {
        if (socket == null)
        {
          socket = IO.Socket(Constants.SERVER_ADDRESS);
        }
      
          return socket;
        
      }
    }
}

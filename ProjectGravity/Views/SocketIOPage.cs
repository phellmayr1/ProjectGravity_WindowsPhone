using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGravity.Views
{
    class SocketIOPage : Windows.UI.Xaml.Controls.Page
    {
        var socket = IO.Socket(Constants.socket);
    }
}

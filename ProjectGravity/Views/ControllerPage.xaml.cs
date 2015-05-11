using ProjectGravity.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ProjectGravity.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    /// 
    public sealed partial class ControllerPage : Page
    {
        public ControllerPage()
        {
            this.InitializeComponent();
        }

        double x;
        double y;
        double z;

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
         Accelerometer accelerometer = Accelerometer.GetDefault();
            accelerometer.ReadingChanged += accelerometer_ReadingChanged;

        }

        async void accelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
//  "positionUpdate",{"xAxis":"165.94323557797526"},{"yAxis":"-0.4401857706222426"},{"zAxis":"-0.5813971237455975"}]

                tb1.Text = (args.Reading.AccelerationX * 180 / Math.PI).ToString();
                tb2.Text = (args.Reading.AccelerationY * 180 / Math.PI).ToString();
                tb3.Text = (args.Reading.AccelerationZ * 180 / Math.PI).ToString();

                x = (args.Reading.AccelerationX * 180 / Math.PI);
                y =  (args.Reading.AccelerationY * 180 / Math.PI);
                z = (args.Reading.AccelerationZ * 180 / Math.PI);

                Debug.WriteLine(JsonEncodeService.createPositionUpdateJsonArray(x, y, z));

                var socket = SocketIO.getSocket();
                socket.On(Socket.EVENT_CONNECT, () =>
                {
                    socket.Emit(JsonConstants.POSITION_UPDATE, JsonEncodeService.createPositionUpdateJsonArray(x,y,z));

                });
            });
        }
    }
}

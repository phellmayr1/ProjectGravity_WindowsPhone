using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Quobject.SocketIoClientDotNet.Client;
using ProjectGravity.Json;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectGravity.Views;
using Windows.ApplicationModel.Resources.Core;
using Windows.ApplicationModel.Resources;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ProjectGravity
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : SocketIOPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        string json= JsonEncodeService.createPinJsonArray(pinTextBox.Text);

          Debug.WriteLine(json);

          JsonArrayAttribute a = new JsonArrayAttribute("array");
        //  JArray a;

          Constants.SERVER_ADDRESS = ipTextBox.Text;
            var socket = IO.Socket(ipTextBox.Text);
          Constants.socket = socket;
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit("checkPin",json);

            });
            

            socket.On(JsonConstants.CHECKED_PIN, (data) =>
            {

                var x = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(data.ToString());

              foreach (JObject o in x.Children<JObject>())
              {
                  Debug.WriteLine(json);

                  foreach (JProperty p in o.Properties())
                  {
                      string name = p.Name;
                      string value = p.Value.ToString();
                    if (name == "pin")
                    {

                        Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
() =>
{
                      if (value == "true")
                      {
                        Frame.Navigate(typeof(OverviewPage));
                      }
                      else
                      {
                          ResourceLoader resourceLoader = new ResourceLoader();

                          
                          errorTextBlock.Text = resourceLoader.GetString("WrongPin/text"); 

                      }
}
);
                    }
                  }
              }

              //foreach (var i in x)
              //{
                 
                
              //}


              //var x = JsonConvert.DeserializeObject<PinJson>(data.ToString());
              //string t=x.Pin;
              //  Console.WriteLine(data);
              //  socket.Disconnect();
            });
            //  Console.ReadLine();
        }
    }
}

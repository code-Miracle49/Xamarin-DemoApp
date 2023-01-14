using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.LocalNotification;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        bool timervalue;
        void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
            GetData();
            timervalue = true;
            Device.StartTimer(TimeSpan.FromMinutes(5), () =>
                {
                    // called every 5 minutes
                    GetData();
                    SendNotification();
                    return timervalue; // return true of false. true to repeat count, false to stop counting;
                });
        }

        void Button2_Clicked(System.Object sender, System.EventArgs e)
        {
            timervalue = false; //Stop Timer
        }

        void GetData()
        {
            var data = new List<string>();
            API api = new API();
            data = api.demo_api();
            string label = string.Empty;
            string crlf = "\r\n";
            foreach (var item in data)
            {
                label += item + crlf;
            }
            API_Data.Text = label;
        }
        void SendNotification()
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Demo App Data Updated",
                Title = "Notification",
                ReturningData = "DummyData",
                NotificationId = 1234,
            };
            LocalNotificationCenter.Current.Show(notification);
        }
    }
}

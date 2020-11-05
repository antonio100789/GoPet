using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.PET.Database;
using App.PET.Models;
using App.PET.Resources;
using Java.Util;
using Newtonsoft.Json;

namespace App.PET
{
    [Activity(Label = "AppointmentActivity")]
    public class AppointmentActivity : Activity
    {
        private Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Appointment);

            SetUpAppointment();
        }

        private void SetUpAppointment()
        {
            button = FindViewById<Button>(Resource.Id.buttonSchedulleAppointment);
            this.button.Click += (sender, args) =>
            {
                Intent intent = new Intent(this, typeof(InsertAppointmentActivity));
                StartActivity(intent);
            };

            var listData = FindViewById<ListView>(Resource.Id.listViewAppointment);

            List <AppointmentModel> appointments = new GoPetDatabase().GetAppointments().Result;

            var adapter = new AppointmentCustomAdapter(this, appointments);

            listData.Adapter = adapter;


        }
    }
}

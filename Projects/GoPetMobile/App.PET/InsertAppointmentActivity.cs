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
    [Activity(Label = "InsertAppointmentActivity")]
    public class InsertAppointmentActivity : Activity
    {
        private Button button;

        public EditText editTextTitle { get; set; }
        public EditText editTextDate { get; set; }
        public EditText editTextTime { get; set; }
        public EditText editTextDescription { get; set; }
        public EditText editTextPlace { get; set; }
        public EditText editTextAddress { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.InsertAppointment);

            SetUpInsertAppointment();
        }

        private void SetUpInsertAppointment()
        {
            button = FindViewById<Button>(Resource.Id.buttonSaveAppointment);

            editTextTitle = FindViewById<EditText>(Resource.Id.editText1);
            editTextDescription = FindViewById<EditText>(Resource.Id.editTextDesctiprion);
            editTextDate = FindViewById<EditText>(Resource.Id.editTextDate);
            editTextTime = FindViewById<EditText>(Resource.Id.editTextTime);
            editTextPlace = FindViewById<EditText>(Resource.Id.editTextPlace);
            editTextAddress = FindViewById<EditText>(Resource.Id.editTextAddress);

            editTextDate.Text = DateTime.Now.ToShortDateString();
            editTextTime.Text = "00:00";


            this.button.Click += (sender, args) =>
            {

                AppointmentModel model = new AppointmentModel();
                
                model.Title = editTextTitle.Text;
                model.Date = DateTime.Parse(editTextDate.Text);
                model.Time = TimeSpan.Parse(editTextTime.Text);
                model.Description = editTextDescription.Text;
                model.Address = editTextAddress.Text;
                model.Place = editTextPlace.Text;
                

                var id = new GoPetDatabase().SaveAppointment(model).Result;

                this.Finish();
            };
        }

        void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            editTextDate.Text = e.Date.ToLongDateString();
        }
    }
}

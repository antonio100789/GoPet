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
using App.PET.Models;
using Java.Lang;

namespace App.PET.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView textViewTitle { get; set; }
        public TextView textViewDate { get; set; }
        public TextView textViewTime { get; set; }
        public TextView textViewDescription { get; set; }
        public TextView textViewPlace { get; set; }
        public TextView textViewAddress { get; set; }
    }

    public class AppointmentCustomAdapter : BaseAdapter
    {
        private Activity activity;
        private List<AppointmentModel> appointments;

        public AppointmentCustomAdapter(Activity activity, List<AppointmentModel> appointments)
        {
            this.activity = activity;
            this.appointments = appointments;
        }

        public override int Count => appointments.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return appointments[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListViewAppointment, parent, false);

            var textViewTitle = view.FindViewById<TextView>(Resource.Id.textViewTitle);
            var textViewDate = view.FindViewById<TextView>(Resource.Id.textViewDate);
            var textViewTime = view.FindViewById<TextView>(Resource.Id.textViewTime);
            var textViewDescription = view.FindViewById<TextView>(Resource.Id.textViewDescription);
            var textViewPlace = view.FindViewById<TextView>(Resource.Id.textViewPlace);
            var textViewAddress = view.FindViewById<TextView>(Resource.Id.textViewAddress);

            textViewTitle.Text = appointments[position].Title;
            textViewDate.Text = appointments[position].Date.ToShortDateString();
            textViewTime.Text = appointments[position].Time.ToString();
            textViewDescription.Text = appointments[position].Description;
            textViewPlace.Text = appointments[position].Place;
            textViewAddress.Text = appointments[position].Address;

            return view;
        }
    }
}
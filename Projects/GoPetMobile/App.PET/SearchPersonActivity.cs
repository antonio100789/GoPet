using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App.PET
{
    [Activity(Label = "SearchPersonActivity")]
    public class SearchPersonActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SearchPerson);

            SetUpMap();
        }

        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            this.GMap = googleMap;

            this.GMap.UiSettings.ZoomControlsEnabled = true;
            this.GMap.UiSettings.CompassEnabled = true;

            var bmDescriptor = BitmapDescriptorFactory.FromResource(Resource.Drawable.ic_launcher_m);
            var bmDescriptorPet = BitmapDescriptorFactory.FromResource(Resource.Drawable.pet);

            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(new LatLng(25.713178, -100.1638576));
            markerOpt1.SetTitle("Mi ubicación");
            markerOpt1.InvokeIcon(bmDescriptorPet);
            this.GMap.AddMarker(markerOpt1);

            MarkerOptions markerOpt2 = new MarkerOptions();
            markerOpt2.SetPosition(new LatLng(25.7047161, -100.1657792));
            markerOpt2.SetTitle("Juan Alberto Ramirez");
            markerOpt2.InvokeIcon(bmDescriptor);
            this.GMap.AddMarker(markerOpt2);

            MarkerOptions markerOpt3 = new MarkerOptions();
            markerOpt3.SetPosition(new LatLng(25.7117681, -100.1614555));
            markerOpt3.SetTitle("Alejandra Ortiz");
            markerOpt3.InvokeIcon(bmDescriptor);
            this.GMap.AddMarker(markerOpt3);

            MarkerOptions markerOpt4 = new MarkerOptions();
            markerOpt4.SetPosition(new LatLng(25.7158792, -100.1740881));
            markerOpt4.SetTitle("Ximena Rodriguez");
            markerOpt4.InvokeIcon(bmDescriptor);
            this.GMap.AddMarker(markerOpt4);

            MarkerOptions markerOpt5 = new MarkerOptions();
            markerOpt5.SetPosition(new LatLng(25.7180893, -100.1729581));
            markerOpt5.SetTitle("Ileana Garcia");
            markerOpt5.InvokeIcon(bmDescriptor);
            this.GMap.AddMarker(markerOpt5);

            MarkerOptions markerOpt6 = new MarkerOptions();
            markerOpt6.SetPosition(new LatLng(25.7101386, -100.1526981));
            markerOpt6.SetTitle("Ileana Garcia");
            markerOpt6.InvokeIcon(bmDescriptor);
            this.GMap.AddMarker(markerOpt6);

            LatLng location = new LatLng(25.713178, -100.1638576);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(15);
            builder.Bearing(155);
            builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            this.GMap.MoveCamera(cameraUpdate);
        }
    }
}
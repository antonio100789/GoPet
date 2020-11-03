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
    [Activity(Label = "SearchPetActivity")]
    public class SearchPetActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SearchPet);

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

            var bmDescriptor = BitmapDescriptorFactory.FromResource(Resource.Drawable.pet);

            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(new LatLng(25.6699088, -100.3230216));
            markerOpt1.InvokeIcon(bmDescriptor);
            markerOpt1.SetTitle("Mi mascota");

            this.GMap.AddMarker(markerOpt1);

            LatLng location = new LatLng(25.6699088, -100.3230216);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            this.GMap.MoveCamera(cameraUpdate);
        }
    }
}
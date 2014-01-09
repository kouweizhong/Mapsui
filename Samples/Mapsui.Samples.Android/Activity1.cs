﻿using System;
using System.Net;
using Android.App;
using Android.OS;
using BruTile.Tms;
using BruTile.Web;
using Mapsui.Layers;
using Mapsui.UI.Android;

namespace Mapsui.Samples.Android
{
    [Activity(Label = "Mapsui.Samples.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var mapControl = FindViewById<MapControl>(Resource.Id.mapcontrol);
            mapControl.Map.Layers.Add(new TileLayer(new OsmTileSource()));                        
            //mapControl.Map.Layers.Add(LufoTest());
        }

        private TileLayer LufoTest()
        {            
            var client = new WebClient();
            var stream = client.OpenRead(new Uri(@"http://geodata1.nationaalgeoregister.nl/luchtfoto/tms/1.0.0/luchtfoto/EPSG28992"));
            var t = TileMapParser.CreateTileSource(stream);
            return new TileLayer(t);
        }
    }
}


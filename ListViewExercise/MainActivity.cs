using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace ListViewExercise
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            list = FindViewById<ListView>(Resource.Id.listView1);


            List<Facebook> postList = new List<Facebook>() {
                new Facebook(){Name="Bob",PostText="Jim please stop",Date="1. april,12:21",Likes=0},
                new Facebook(){Name="Jim",PostText="| | || |_",Date="1. april,12:00", Likes=0}
            };

            list.Adapter = new CustomAdapter(this, postList);
        }
    }
}
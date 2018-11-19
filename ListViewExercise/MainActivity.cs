using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Content;

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
                new Facebook()
                { PostName="Bob",
                  PostText ="Jim please stop",
                  Date ="1. april,12:21",
                  Likes =21,
                  
                  Comment=new Comment()
                  {
                      Name="Bob",
                      PostText="hit or miss, i guess they never"
                  },
                },
                new Facebook(){PostName="Jim",PostText="| ||\n || |_",Date="1. april,12:00", Likes=1}

            };

            list.Adapter = new PostAdapter(this, postList);
        }
    }
}
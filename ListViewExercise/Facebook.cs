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

namespace ListViewExercise
{
    class Facebook
    {
        public string Name { get; set; }
        public string PostText { get; set; }
        public string Date { get; set; }
        public int Likes { get; set; }
        public ImageView Avatar { get; set; }
        public ImageView Image { get; set; }
    }
}
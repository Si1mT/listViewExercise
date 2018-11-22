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
    public class Facebook
    {
        public string PostName { get; set; }
        public string PostText { get; set; }
        public string Date { get; set; }
        public bool IsLiked { get; set; }
        public int Likes { get; set; }
        public ImageView Avatar { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
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
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : Activity
    {
        ListView listView_comments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.comment_layout);

            listView_comments = FindViewById<ListView>(Resource.Id.listView_Comments);

            List<Comment> commentList = new List<Comment>()
            {
                new Comment()
                {
                }
            };
        }
    }
}
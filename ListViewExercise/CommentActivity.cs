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
        Button button_addComment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.comment_layout);

            listView_comments = FindViewById<ListView>(Resource.Id.listView_Comments);
            button_addComment = FindViewById<Button>(Resource.Id.button_addComment);

            //List<Comment> commentList = new List<Comment>()
            //{
            //    new Comment(){Name="Tom",Text="this is the perfect comment"},
            //    new Comment(){Name="Karr",Text="this is the a comment"},
            //    new Comment(){Name="Plain",Text="this is second comment"}
            //};
            
            listView_comments.Adapter = new CommentAdapter(this, MainActivity.commentsList);

            button_addComment.Click += Button_addComment_Click;
        }

        private void Button_addComment_Click(object sender, EventArgs e)
        {
            EditText AddCommentText = FindViewById<EditText>(Resource.Id.textInputEditText_addComment);

            Comment NewComment = new Comment()
            {
                Name = "User",
                Text = AddCommentText.Text,
            };
            MainActivity.commentsList.Add(NewComment);
        }
    }
}
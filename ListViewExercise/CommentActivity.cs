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
using Newtonsoft.Json;

namespace ListViewExercise
{
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : ListActivity
    {
        Button button_addComment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            List<Comment> listView_Comments = JsonConvert.DeserializeObject<List<Comment>>(Intent.GetStringExtra("Comments"));

            SetContentView(Resource.Layout.comment_layout);

            ListAdapter = new CommentAdapter(this, listView_Comments);

            button_addComment = FindViewById<Button>(Resource.Id.button_addComment);
            button_addComment.Click += Button_addComment_Click;
        }

        private void Button_addComment_Click(object sender, EventArgs e)
        {
            Button commentButton = (Button)sender;
            int position = (int)commentButton.Tag;
            EditText AddCommentText = FindViewById<EditText>(Resource.Id.textInputEditText_addComment);

            MainActivity.postList[position].Comments.Add(new Comment
            {
                Name = "TestUser",
                PostText = AddCommentText.Text,
            });
            AddCommentText.Text = "";
            ListAdapter = new CommentAdapter(this, MainActivity.postList[position].Comments);
        }
    }
}
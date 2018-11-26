using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Content;
using Android.Views.InputMethods;

namespace ListViewExercise
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static List<Facebook> postList;
        public static List<Comment> commentsList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            if (postList == null) TestPosts();

            ListView list = FindViewById<ListView>(Resource.Id.listView1);
            Button ButtonAddPost = FindViewById<Button>(Resource.Id.button_Add_Post);

            ButtonAddPost.Click += AddPost_Button_Click;

            list.Adapter = new PostAdapter(this, postList);
        }

        public void TestPosts()
        {
            postList = new List<Facebook>();
            commentsList = new List<Comment>();

            Comment Comment = new Comment()
            {
                Name = "tom",
                CommentText = "ipsum"
            };
            commentsList.Add(Comment);

            Comment = new Comment()
            {
                Name = "tom",
                CommentText = "comment 1"
            };
            commentsList.Add(Comment);

            Comment = new Comment()
            {
                Name = "tom 2",
                CommentText = "comment 2"
            };
            commentsList.Add(Comment);

            Facebook Post = new Facebook()
            {
                PostName = "Bob",
                PostText = "lorem",
                Date = "1. April,12:21",
                Image = "bike",
                Likes = 21,
                Comments = commentsList
            };
            postList.Add(Post);

            commentsList = new List<Comment>();

            Facebook Post1=new Facebook()
            {
                PostName = "Jim",
                PostText = "| ||" +
                "          || |_",
                Date = "1. April,12:00",
                Image = "tree",
                Likes = 1,
                Comments = commentsList
            };
            postList.Add(Post1);

            commentsList = new List<Comment>();

            Comment = new Comment()
            {
                Name = "bob",
                CommentText = "lorem"
            };
            commentsList.Add(Comment);

            Facebook Post2=new Facebook()
            {
                PostName = "Test",
                PostText = "Van Dyke Brown is a very nice brown, it's almost like a chocolate brown. " +
                          "You can work and carry-on and put lots of little happy things in here. " +
                          "Nothing's gonna make your husband or wife madder than coming home and having a snow-covered dinner.",
                Date = "23. January,23:59",
                Image = null,
                Likes = 1,
                Comments = commentsList
            };
            postList.Add(Post2);
        }

        public void AddPost_Button_Click(object sender, EventArgs e)
        {
            EditText AddPostText = FindViewById<EditText>(Resource.Id.textInputEditText1);

            Facebook NewPost = new Facebook()
            {
                PostName = "User",
                PostText = AddPostText.Text,
                Date = DateTime.Now.ToString(),
                Comments = new List<Comment>(),
                Image = null,
                Likes = 0
            };
            postList.Add(NewPost);
            AddPostText.Text = "";

            //Dismiss Keyboard
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);

            Toast.MakeText(this, "New post added", ToastLength.Short).Show();
        }
    }
}
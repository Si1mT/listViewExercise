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
    class PostAdapter : BaseAdapter<string>
    {
        List<Facebook> posts;
        Activity context;

        public PostAdapter(Activity context, List<Facebook> posts) : base()
        {
            this.posts = posts;
            this.context = context;
        }

        //public override Facebook this[int position]
        //{
        //    get
        //    {
        //        return posts[position];
        //    }
        //}
        public override string this[int position]
        {
            get { return posts[position].PostName.ToString(); }
        }

        public override int Count
        {
            get
            {
                return posts.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);
            
            view.FindViewById<TextView>(Resource.Id.textView_Comments).Text = posts[position].Comments.Count() + " Comments";
            view.FindViewById<TextView>(Resource.Id.textView_name).Text = posts[position].PostName;
            view.FindViewById<TextView>(Resource.Id.textView_date).Text = posts[position].Date;
            view.FindViewById<TextView>(Resource.Id.textView_text).Text = posts[position].PostText;
            view.FindViewById<TextView>(Resource.Id.textView_like).Text = posts[position].Likes + " Likes";

            var postImage=view.FindViewById<ImageView>(Resource.Id.imageView_postImage);
            if (posts[position].Image !=null)
            {
                postImage.SetImageResource(context.Resources.GetIdentifier(posts[position].Image, "drawable", context.PackageName));
                postImage.Visibility = ViewStates.Visible;
            }
            else
            {
                postImage.Visibility = ViewStates.Gone;
            }

            ImageButton imageButton_Like = view.FindViewById<ImageButton>(Resource.Id.imageButton_like);
            view.FindViewById<TextView>(Resource.Id.textView_like).Text = posts[position].Likes + " Likes";
            imageButton_Like.Tag = position;
            imageButton_Like.Click -= LikeButton_Click;
            imageButton_Like.Click += LikeButton_Click;

            TextView textView_Comments = view.FindViewById<TextView>(Resource.Id.textView_Comments);
            textView_Comments.Tag = position;
            textView_Comments.Click -= CommentsClick;
            textView_Comments.Click += CommentsClick;

            return view;
        }

        private void CommentsClick(object sender, EventArgs e)
        {
            TextView clickedCommentsButton = (TextView)sender;
            int position = (int)clickedCommentsButton.Tag;

            Intent commentsActivity = new Intent(context, typeof(CommentActivity));
            commentsActivity.PutExtra("Comments", JsonConvert.SerializeObject(posts[position].Comments));
            commentsActivity.PutExtra("PostPosition", position);
            context.StartActivity(commentsActivity);
        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            var likeBtnClicked = (ImageButton)sender;
            int position = (int)likeBtnClicked.Tag;

            if (!posts[position].IsLiked)
            {
                posts[position].Likes++;
            }
            else
            {
                posts[position].Likes--;
            }

            MainActivity.postList[position].Likes = posts[position].Likes;
            posts[position].IsLiked = !posts[position].IsLiked;

            MainActivity.postList[position].IsLiked = posts[position].IsLiked;
            NotifyDataSetChanged();
        }
    }
}
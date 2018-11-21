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
    class PostAdapter : BaseAdapter<Facebook>
    {
        List<Facebook> posts;
        Activity context;

        public PostAdapter(Activity context, List<Facebook> posts) : base()
        {
            this.posts = posts;
            this.context = context;
        }

        public override Facebook this[int position]
        {
            get
            {
                return posts[position];
            }
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
            bool liked = false;
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);

            ImageButton imageButton_Like = view.FindViewById<ImageButton>(Resource.Id.imageButton_like);
            TextView textView_Comments = view.FindViewById<TextView>(Resource.Id.textView_Comments);

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
            
            textView_Comments.Click += (sender, e) =>
            {
                var commentActivity = new Intent(context, typeof(CommentActivity));
                context.StartActivity(commentActivity);
            };

            imageButton_Like.Click +=(sender, e)=>
            {

                switch (liked)
                {
                    case false:
                        posts[position].Likes++;
                        view.FindViewById<TextView>(Resource.Id.textView_like).Text = posts[position].Likes + " Likes";
                        liked = true;
                        break;
                    case true:
                        posts[position].Likes--;
                        view.FindViewById<TextView>(Resource.Id.textView_like).Text = posts[position].Likes + " Likes";
                        liked = true;
                        break;
                    default:
                        break;
                }
            };

            return view;
            
            //Possible hint on how to fix like button

            //var clicktextview = (TextView)sender;
            //clicktextview.Tag = position;
            
            //position = (int)clicktextview.Tag;
            //clicktextview.FindViewById<TextView>(Resource.Id.imageButton_like);
            //
        }
    }
}
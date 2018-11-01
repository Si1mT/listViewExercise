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
    class CustomAdapter : BaseAdapter<Facebook>
    {
        List<Facebook> posts;
        Activity context;

        public CustomAdapter(Activity context, List<Facebook> posts) : base()
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
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);

            view.FindViewById<TextView>(Resource.Id.textView_name).Text = posts[position].Name;
            view.FindViewById<TextView>(Resource.Id.textView_date).Text = posts[position].Date;
            view.FindViewById<TextView>(Resource.Id.textView_text).Text = posts[position].PostText;

            return view;
        }
    }
}
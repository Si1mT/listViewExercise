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
    class CommentAdapter : BaseAdapter<Comment>
    {
        List<Comment> comments;
        Activity context;

        public CommentAdapter(Activity context,List<Comment> comments) :base()
        {
            this.comments = comments;
            this.context = context;
        }


        public override Comment this[int position]
        {
            get
            {
                return comments[position];
            }
        }

        public override int Count
        {
            get
            {
                return comments.Count;
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
                view = context.LayoutInflater.Inflate(Resource.Layout.comment_row, null);

            view.FindViewById<TextView>(Resource.Id.textView_commentName).Text = comments[position].Name;
            view.FindViewById<TextView>(Resource.Id.textView_post).Text = comments[position].Text;

            return view;
        }
    }
}
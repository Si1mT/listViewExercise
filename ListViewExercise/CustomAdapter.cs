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

        public CustomAdapter(List<Facebook> posts)
        {
            this.posts = posts;
            this.context = context;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override Facebook this[int position]
        {
            get
            {
                return posts[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            //CustomAdapterViewHolder holder = null;

            if (view == null)
            {
                //holder = view.Tag as CustomAdapterViewHolder;
                //view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_row,parent,false);
                view = context.LayoutInflater.Inflate(Resource.Layout.custom_row, null);
               
            }
            var profilePicture=view.FindViewById<ImageView>(Resource.Id.image)

            if (holder == null)
            {
                holder = new CustomAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.custom_row, parent, false);
                //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
                view.Tag = holder;
            }


            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
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
    }

    class CustomAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}
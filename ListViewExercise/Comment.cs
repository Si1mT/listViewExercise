﻿using System;
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
    public class Comment : Facebook
    {
        public string Name { get; set; }
        public string CommentText { get; set; }
    }
}
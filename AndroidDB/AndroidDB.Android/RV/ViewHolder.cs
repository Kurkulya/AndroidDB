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
using Android.Support.V7.Widget;

namespace AndroidDB.Droid.RV
{
    public class PersonViewHolder : RecyclerView.ViewHolder
    {
        public TextView Id { get; private set; }
        public TextView FirstName { get; private set; }
        public TextView LastName { get; private set; }
        public TextView Age { get; private set; }

        public PersonViewHolder(View itemView) : base (itemView)
        {
            Id = itemView.FindViewById<TextView>(Resource.Id.tvId);
            FirstName = itemView.FindViewById<TextView>(Resource.Id.tvFirstName);
            LastName = itemView.FindViewById<TextView>(Resource.Id.tvLastName);
            Age = itemView.FindViewById<TextView>(Resource.Id.tvAge);
        }
    }
}
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
using static Java.Text.Normalizer;

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

            Button del = itemView.FindViewById<Button>(Resource.Id.delBtn);
            Button upd = itemView.FindViewById<Button>(Resource.Id.updBtn);
            del.Click += delegate { DeletePerson(); };
            upd.Click += delegate { UpdatePerson(itemView.Context); };
        }

        private void DeletePerson()
        {
            MainActivity.Database.Delete(new Person(Convert.ToInt32(Id.Text), FirstName.Text, LastName.Text, Convert.ToInt32(Age.Text)));
            MainActivity.ReadDataBase();
        }

        private void UpdatePerson(Context context)
        {
            Intent intent = new Intent(context, typeof(UpdateActivity));
            string[] person = { Id.Text, FirstName.Text, LastName.Text, Age.Text };
            intent.PutExtra("person", person);
            context.StartActivity(intent);
        }


    }
}
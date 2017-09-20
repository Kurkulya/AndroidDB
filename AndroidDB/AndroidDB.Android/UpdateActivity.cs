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
using AndroidDB.Droid;
using AndroidDB;

namespace AndroidDB.Droid
{
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        IPersonDAO _db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Update);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _db = MainActivity.Database;
            string[] person = Intent.GetStringArrayExtra("person");

            if (person != null)
            {
                FindViewById<TextView>(Resource.Id.editId).Text = person[0];
                FindViewById<EditText>(Resource.Id.editFirstName).Text = person[1];
                FindViewById<EditText>(Resource.Id.editLastName).Text = person[2];
                FindViewById<EditText>(Resource.Id.editAge).Text = person[3];
            }

            FindViewById<Button>(Resource.Id.saveBtn).Click += delegate { OnSavePressed(); };
        }

        public void OnSavePressed()
        {
            Person person = new Person()
            {
                Id = int.Parse(FindViewById<TextView>(Resource.Id.editId).Text),
                FirstName = FindViewById<EditText>(Resource.Id.editFirstName).Text,
                LastName = FindViewById<EditText>(Resource.Id.editLastName).Text,
                Age = int.Parse(FindViewById<EditText>(Resource.Id.editAge).Text),
            };
            _db.Update(person);
            base.OnBackPressed();
        }
    }
}
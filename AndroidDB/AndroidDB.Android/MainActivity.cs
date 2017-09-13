
using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using System;
using System.Collections.Generic;

namespace AndroidDB.Droid
{
    [Activity (Label = "AndroidDB", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        string connectionString = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbPeople.db3");

        IPersonDAO database = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            database = DBFactory.GetInstance("SQLite", GetDBPath("Petople.db"));
            // Get our button from the layout resource,
            // and attach an event to it
            Button btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            Button btnRead = FindViewById<Button>(Resource.Id.btnRead);

            btnCreate.Click += delegate
            {
                database.Create(GetPerson());
    
            };

            btnUpdate.Click += delegate
            {
                database.Update(GetPerson());
            };

            btnDelete.Click += delegate
            {
                database.Delete(GetPerson());
            };

            btnRead.Click += delegate
            {
                List<Person> people = database.Read();
                TextView table = FindViewById<TextView>(Resource.Id.Table);
                table.Text = "";
                foreach (Person person in people)
                {
                    table.Text += $"Id: {person.Id}, FirstName: {person.FirstName}, LastName: {person.LastName}, Age: {person.Age}\n";
                }
            };

        }

        private Person GetPerson()
        {
            return new Person(Int32.Parse(FindViewById<EditText>(Resource.Id.ID).Text),
                              FindViewById<EditText>(Resource.Id.FN).Text,
                              FindViewById<EditText>(Resource.Id.LN).Text,
                              Int32.Parse(FindViewById<EditText>(Resource.Id.AGE).Text));
        }

        public string GetDBPath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }

    }
}



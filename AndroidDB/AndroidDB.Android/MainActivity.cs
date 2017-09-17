
using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using AndroidDB.Droid.RV;

namespace AndroidDB.Droid
{
    [Activity (Label = "AndroidDB", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

        RecyclerView _recyclerView;
   
        IPersonDAO _database = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            _database = DBFactory.GetInstance("SQLite", GetDBPath("Petople.db"));

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _recyclerView.HasFixedSize = true;
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            SetButtonListeners();
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
        private void SetButtonListeners()
        {
            Button btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            Button btnRead = FindViewById<Button>(Resource.Id.btnRead);

            btnCreate.Click += delegate
            {
                _database.Create(GetPerson());

            };

            btnUpdate.Click += delegate
            {
                _database.Update(GetPerson());
            };

            btnDelete.Click += delegate
            {
                _database.Delete(GetPerson());
            };

            btnRead.Click += delegate
            {
                List<Person> people = _database.Read();
                _recyclerView.SetAdapter(new PersonDBAdapter(people));
            };
        }
    }
}



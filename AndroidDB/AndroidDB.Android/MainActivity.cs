
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
    [Activity (Label = "DataBase", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

        RecyclerView _recyclerView;
   
        IPersonDAO _database = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            _database = DBFactory.GetInstance("Realm");

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _recyclerView.HasFixedSize = true;
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            SetButtonListeners();
            SetRBListeners();
        }

        private Person GetPerson()
        {
            return new Person(Int32.Parse(FindViewById<EditText>(Resource.Id.ID).Text),
                              FindViewById<EditText>(Resource.Id.FN).Text,
                              FindViewById<EditText>(Resource.Id.LN).Text,
                              Int32.Parse(FindViewById<EditText>(Resource.Id.AGE).Text));
        }
       
        private void SetButtonListeners()
        {
            Button btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            Button btnRead = FindViewById<Button>(Resource.Id.btnRead);

            btnCreate.Click += CRUDClick;
            btnUpdate.Click += CRUDClick;
            btnDelete.Click += CRUDClick;
            btnRead.Click += CRUDClick;
        }
        private void SetRBListeners()
        {
            RadioButton rRealm = FindViewById<RadioButton>(Resource.Id.rRealm);
            RadioButton rSQLite = FindViewById<RadioButton>(Resource.Id.rSQlite);

            rRealm.Click += RadioButtonClick;
            rSQLite.Click += RadioButtonClick;
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            _database = DBFactory.GetInstance(rb.Text);
            ReadDataBase();
        }

        private void ReadDataBase()
        {
            List<Person> people = _database.Read();
            _recyclerView.SetAdapter(new PersonDBAdapter(people));
        }

        private void CRUDClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch(b.Text)
            {
                case "CREATE": _database.Create(GetPerson());break;
                case "UPDATE": _database.Update(GetPerson()); break;
                case "DELETE": _database.Delete(GetPerson()); break;
            }
            ReadDataBase();
        }
    }
}



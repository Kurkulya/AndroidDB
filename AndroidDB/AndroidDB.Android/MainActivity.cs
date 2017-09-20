
using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using AndroidDB.Droid.RV;
using Android.Content;
using Android.Support.V4.Widget;

namespace AndroidDB.Droid
{
    [Activity (Label = "DataBase", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        public static MainActivity Instance { get; set; }
        static RecyclerView _recyclerView;
        List<string> mLeftItems = new List<string>();
        DrawerLayout drawLayout;

        public static IPersonDAO Database { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            Instance = this;
            Database = DBFactory.GetInstance("Realm", GetDBPath());

            mLeftItems.Add("Realm");
            mLeftItems.Add("SQLite");

            drawLayout = FindViewById<DrawerLayout>(Resource.Id.mydrawer);
            ListView mLeftDrawer = FindViewById<ListView>(Resource.Id.leftsideview);
            ArrayAdapter mLeftAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, mLeftItems);
            mLeftDrawer.Adapter = mLeftAdapter;

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _recyclerView.HasFixedSize = true;
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            Button btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            btnCreate.Click += delegate { StartActivity(typeof(CreateActivity)); };

            mLeftDrawer.ItemClick += OnDataBasePick;  
        }

        private void OnDataBasePick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Database = DBFactory.GetInstance(mLeftItems[e.Position], GetDBPath());
            drawLayout.CloseDrawers();
            ReadDataBase();
        }

        protected override void OnResume()
        {
            base.OnResume();
            ReadDataBase();
        }

        public static void ReadDataBase()
        {
            List<Person> people = Database.Read();
            _recyclerView.SetAdapter(new PersonDBAdapter(people));
        }

        public string GetDBPath()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "Petople.db");
            return path;
        }
    }
}



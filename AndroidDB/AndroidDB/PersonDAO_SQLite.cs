﻿

using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidDB
{
    class PersonDAO_SQLite : IPersonDAO
    {
        SQLiteConnection connection = null;
        public PersonDAO_SQLite(string datapath)
        {
            //string documentsPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //var path = Path.Combine(documentsPath, sqliteFilename);
            connection = new SQLiteConnection(datapath);
            connection.CreateTable<Person>();
        }

        public void Create(Person person)
        {
            connection.Insert(person);
        }

        public void Delete(Person person)
        {
            connection.Delete(person);
        }

        public List<Person> Read()
        {
            return connection.Table<Person>().ToList();
        }

        public void Update(Person person)
        {
            connection.Update(person);
        }

    }
}

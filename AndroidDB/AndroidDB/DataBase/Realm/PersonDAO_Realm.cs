﻿
using Realms;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidDB
{
    class PersonDAO_Realm : IPersonDAO
    {
        Realm realm = null;
        public PersonDAO_Realm()
        {
            realm = Realm.GetInstance();
        }

        public void Create(Person person)
        {
            realm.Write(() =>
            {
                realm.Add(new PersonR(person), false);
            });
        }

        public void Delete(Person person)
        {
            var del = realm.All<PersonR>().First(b => b.Id == person.Id);

            using (var trans = realm.BeginWrite())
            {
                realm.Remove(del);
                trans.Commit();
            }
        }

        public List<Person> Read()
        {
            return realm.All<PersonR>().Select(x => x.person).ToList();
        }

        public void Update(Person person)
        {

            realm.Write(() => realm.Add(new PersonR(person), true));
        }


    }
}

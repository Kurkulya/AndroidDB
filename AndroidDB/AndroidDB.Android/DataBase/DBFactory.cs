using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidDB
{
    public class DBFactory
    {
        public static IPersonDAO GetInstance(string type)
        {
            IPersonDAO db = null;
            
            switch (type)
            {
                case "SQLite": db = new PersonDAO_SQLite(); break;
                case "Realm": db = new PersonDAO_Realm(); break;
            }

            return db;
        }
    }
}

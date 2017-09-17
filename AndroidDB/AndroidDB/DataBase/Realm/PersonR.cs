using Realms;


namespace AndroidDB
{
    public class PersonR : RealmObject
    {
        [PrimaryKey]
        public int Id { get { return person.Id; } set { person.Id = value; } }

        public string FirstName { get { return person.FirstName; } set { person.FirstName = value; } }
        public string LastName { get { return person.LastName; } set { person.LastName = value; } }
        public int Age { get { return person.Age; } set { person.Age = value; } }

        public Person person = null;

        public PersonR(int Id, string FirstName, string LastName, int Age)
        {
            person = new Person(Id, FirstName, LastName, Age);
        }

        public PersonR(Person person)
        {
            this.person = person;
        }

        public PersonR()
        {
        }
    }
}
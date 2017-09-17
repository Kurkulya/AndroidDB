using Realms;


namespace AndroidDB
{
    public class PersonR : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

   
        public PersonR(int Id, string FirstName, string LastName, int Age)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }

        public PersonR(Person person)
        {
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.Age = person.Age;
        }

        public Person GetPerson()
        {
            return new Person(Id, FirstName, LastName, Age);
        }
        public PersonR()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidDB
{
    
    public interface IPersonDAO
    {
        List<Person> Read();
        void Update(Person person);
        void Delete(Person person);
        void Create(Person person);
    }
}

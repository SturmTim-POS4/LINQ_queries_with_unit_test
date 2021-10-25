using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDBLing
{
    public class PersonContext
    {
        public List<Person> Persons { get; set; }
        public List<Address> Addresses { get; set; }
        public PersonContext()
        {
            InitializeAddress();
            InitializePersons();
            InitializeKeys();
        }

        private void InitializeKeys()
        {

            var addressMap = Addresses.ToDictionary(x => x.Id, x => x);

            Persons.ForEach(x => x.Address = addressMap[x.AddressId]);

        }

        private void InitializeAddress()
        {
            Addresses = File.ReadAllLines(@"csv\adresses.csv")
                .Skip(1)
                .Select(x => x.Split(","))
                .Select(x => new Address
                {
                    Id = int.Parse(x[0]),
                    Country = x[1],
                    City = x[2],
                    PortalCOde = int.TryParse(x[3],out int val) ?  val : null,
                    StreetName = x[4],
                    StreetNumber = int.Parse(x[5])
                })
                .ToList();
        }

        private void InitializePersons()
        {
             Persons = File.ReadAllLines(@"csv\persons.csv")
                 .Skip(1)
                 .Select(x => x.Split(","))
                 .Select(x => new Person
                 {
                     Id = int.Parse(x[0]),
                     Firstname = x[1],
                     Lastname = x[2],
                     Mail = x[3],
                     Gender = x[4],
                     Birthday = DateTime.ParseExact(x[5], "dd.MM.yyyy", null),
                     AddressId = int.Parse(x[6])
                 })
                 .ToList();
        }
    }
}

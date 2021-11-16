using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDbLibEF
{
    public partial class Adress
    {
        public Adress()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDbLibEF
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int AdressId { get; set; }

        public virtual Adress Adress { get; set; }
    }
}

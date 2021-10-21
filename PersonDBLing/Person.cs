using System;

namespace PersonDBLing
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
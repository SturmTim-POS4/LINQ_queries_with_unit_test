using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDBLing
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? PortalCOde { get; set; }
        public string StreetName { get; set; }

        public int StreetNumber { get; set; }

        public override string ToString()
        {
            return $"{Country}";
        }
    }
}

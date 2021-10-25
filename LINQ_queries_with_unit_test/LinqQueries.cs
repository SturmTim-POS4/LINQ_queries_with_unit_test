using System.Collections.Generic;
using System.Linq;
using PersonDBLing;

namespace LINQ_queries_with_unit_test
{
  public class LinqQueries
  {
    private readonly PersonContext db;

    public LinqQueries(PersonContext db)
    {
      this.db = db;
    }

    public List<string> MalesStreetNrLessThan10()
    {
      return db.Persons.Where(x => x.Address.StreetNumber < 10)
        .Where(x => x.Gender.Equals("Male"))
        .Select(x => $"{x.Lastname} {x.Firstname}")
        .ToList();
    }

    public List<string> FirstnamesInChina()
    {
      return db.Persons.Where(x => x.Address.Country.Equals("China"))
        .Select(x => $"{x.Firstname}")
        .ToList();

    }

    public int MaxStreetNrInCountry(string country)
    {
      return db.Addresses.Where(x => x.Country.Equals(country))
        .Select(x => x.StreetNumber)
        .Max();
    }

    public List<string> CountriesWithEmailEndingWithOrg()
    {
      return db.Persons.Where(x => x.Mail.EndsWith(".org"))
        .Select(x => x.Address.Country)
        .Distinct()
        .ToList();
    }

    public List<Person> PersonsFromIndonesia()
    {
      return db.Persons.Where(x => x.Address.Country.Equals("Indonesia"))
        .OrderBy(x => x.Lastname)
        .Skip(3)
        .Take(4)
        .ToList();
    }
  }
}
